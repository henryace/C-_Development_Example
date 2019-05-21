using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;

using System.IO.Compression;

using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.Serialization;
using Microsoft.Win32;

namespace GetDiskList
{
    class BaseClass
    {
        public class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
            [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
            public static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);
            [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
            [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
            public static extern int DestroyIcon(IntPtr hIcon);
            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
        }

        #region  資料夾的複製
        /// <summary>
        /// 資料夾的複製
        /// </summary>
        /// <param Ddir="string">要複製的目的路徑</param>
        /// <param Sdir="string">要複製的原路徑</param>
        public void Files_Copy(string Ddir, string Sdir)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            string SbuDir = Ddir;
            try
            {
                if (!dir.Exists)//判斷所指的文件或資料夾是否存在
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//如果給定參數不是資料夾則退出
                string UpDir = UpAndDown_Dir(Ddir);
                if (dirD == null)//判斷資料夾是否為空
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);//如果為空，建立資料夾並退出
                    return;
                }
                else
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);
                }
                SbuDir = UpDir + "\\" + dirD.Name + "\\";
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//取得資料夾中所有文件和資料夾
                //對單個FileSystemInfo進行判斷,如果是資料夾則進行遞迴操作
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;
                    if (file != null)//如果是文件的話，進行文件的複製操作
                    {
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);//取得文件所在的原始路徑
                        SFInfo.CopyTo(SbuDir + "\\" + file.Name, true);//將文件複製到指定的路徑中
                    }
                    else
                    {
                        string pp = FSys.Name;//取得目前搜索到的資料夾名稱
                        Files_Copy(SbuDir + FSys.ToString(), Sdir + "\\" + FSys.ToString());//如果是文件，則進行遞迴呼叫
                    }
                }
            }
            catch
            {
                MessageBox.Show("文件制復失敗。");
                return;
            }
        }
        #endregion

        #region  返回上一級目錄
        /// <summary>
        /// 返回上一級目錄
        /// </summary>
        /// <param dir="string">目錄</param>
        /// <returns>返回String物件</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion

        public void listFolders(ToolStripComboBox tscb)//取得本地磁盤目錄
        {
            string[] logicdrives = System.IO.Directory.GetLogicalDrives();
            for (int i = 0; i < logicdrives.Length; i++)
            {
                tscb.Items.Add(logicdrives[i]);
                tscb.SelectedIndex = 0;
            }
        }
        int k = 0;
        public void GOBack(ListView lv, ImageList il, string path)
        {

            if (AllPath.Length != 3)
            {
                string NewPath = AllPath.Remove(AllPath.LastIndexOf("\\")).Remove(AllPath.Remove(AllPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\";
                lv.Items.Clear();
                GetListViewItem(NewPath, il, lv);
                AllPath = NewPath;
            }
            else
            {
                if (k == 0)
                {
                    lv.Items.Clear();
                    GetListViewItem(path, il, lv);
                    k++;
                }
            }
        }
        public string Mpath()
        {
            string path = AllPath;
            return path;
        }
        public static string AllPath = "";//---------
        public void GetPath(string path, ImageList imglist, ListView lv, int ppath)//-------
        {
            string pp = "";
            string uu = "";
            if (ppath == 0)
            {
                if (AllPath != path)
                {
                    lv.Items.Clear();
                    AllPath = path;
                    GetListViewItem(AllPath, imglist, lv);
                }
            }
            else
            {
                uu = AllPath + path;
                if (Directory.Exists(uu))
                {
                    AllPath = AllPath + path + "\\";
                    pp = AllPath.Substring(0, AllPath.Length - 1);
                    lv.Items.Clear();
                    GetListViewItem(pp, imglist, lv);
                }
                else
                {
                    uu = AllPath + path;
                    System.Diagnostics.Process.Start(uu);
                }
            }
        }
        public void GetListViewItem(string path, ImageList imglist, ListView lv)//取得指定路徑下所有文件及其圖標
        {
            lv.Items.Clear();
            Win32.SHFILEINFO shfi = new Win32.SHFILEINFO();
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string[] info = new string[4];
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if (dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information")
                    { }
                    else
                    {
                        //取得圖標
                        Win32.SHGetFileInfo(dirs[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //取得Icon和TypeName
                        //新增圖標
                        imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = dir.Name;
                        info[1] = "";
                        info[2] = "資料夾";
                        info[3] = dir.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, dir.Name);
                        lv.Items.Add(item);
                        //銷毀圖標
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string[] info = new string[4];
                    FileInfo fi = new FileInfo(files[i]);
                    string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1, fi.Name.Length - fi.Name.LastIndexOf(".") - 1);
                    string newtype = Filetype.ToLower();
                    if (newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db")
                    { }
                    else
                    {


                        //取得圖標
                        Win32.SHGetFileInfo(files[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //取得Icon和TypeName
                        //新增圖標
                        imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = fi.Name;
                        info[1] = fi.Length.ToString();
                        info[2] = fi.Extension.ToString();
                        info[3] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, fi.Name);
                        lv.Items.Add(item);
                        //銷毀圖標
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
