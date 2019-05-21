using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace SingleFormatTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Computer MyComputer = new Computer();
            txtResult.Text = MyComputer.FileSystem.ReadAllText("test.txt");
        }

        private void btnParseTextFiles_Click(object sender, EventArgs e)
        {
            using (TextFieldParser myReader = new TextFieldParser("test.txt"))
            {
                // 表示檔案內容是字符分隔。
                myReader.TextFieldType = FieldType.Delimited;
                // 定義文字檔案的字符分隔符。
                myReader.Delimiters = new String[] { "," };
                this.DataGridView1.Rows.Clear();
                DataGridView1.ColumnHeadersVisible = true;
                // 設定欄標題樣式。
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
                DataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                string[] currentRow;
                int myRowCount = 1;
                int myColCount = 0;
                // 循環處理文字檔案中所有資料列的所有欄位。
                while (!myReader.EndOfData)
                {
                    try
                    {
                        currentRow = myReader.ReadFields();
                        if (myRowCount == 1)
                        {
                            foreach (string currentField in currentRow)
                            {
                                // 動態設定 DataGridView 控制元件的欄位數目。
                                DataGridView1.ColumnCount = myColCount + 1;
                                // 設定 DataGridView 控制元件各欄的標題名稱。
                                DataGridView1.Columns[myColCount].Name = currentField;
                                myColCount += 1;
                            }
                        }
                        else
                        {
                            this.DataGridView1.Rows.Add(currentRow);
                        }
                    }
                    catch (MalformedLineException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    myRowCount += 1;
                }
            }
        }
    }
}
