class program
{
    static void Main()
    {
        System.Console.Title = "迴圈向控制台中輸入內容";//定義控制台標題
        System.Console.WindowWidth = 30;//設定控制台視窗寬度
        System.Console.WindowHeight = 2;//設定控制台視窗高度
        for (; ; )//開始無限迴圈
        {
            System.Console.WriteLine("目前系統時間是：{0}",//輸出系統目前時間
                System.DateTime.Now.ToString("dd日 hh:mm:sss"));
            System.Threading.Thread.Sleep(1000);//執行緒掛起1秒鐘
            System.Console.Clear();//清空控制台訊息
        }
    }
}