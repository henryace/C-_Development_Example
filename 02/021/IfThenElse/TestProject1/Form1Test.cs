using IfThenElse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///這是 Form1Test 的測試類，旨在
    ///包含所有 Form1Test 單元測試
    ///</summary>
    [TestClass()]
    public class Form1Test
    {
        

private TestContext testContextInstance;

/// <summary>
///獲取或設定測試上下文，上下文提供
///有關當前測試執行及其功能的訊息。
///</summary>
public TestContext TestContext
{
    get
    {
        return testContextInstance;
    }
    set
    {
        testContextInstance = value;
    }
}

#region 附加測試屬性
// 
//編寫測試時，還可使用以下屬性:
//
//使用 ClassInitialize 在執行類中的第一個測試前先執行程式碼
//[ClassInitialize()]
//public static void MyClassInitialize(TestContext testContext)
//{
//}
//
//使用 ClassCleanup 在執行完類中的所有測試後再執行程式碼
//[ClassCleanup()]
//public static void MyClassCleanup()
//{
//}
//
//使用 TestInitialize 在執行每個測試前先執行程式碼
//[TestInitialize()]
//public void MyTestInitialize()
//{
//}
//
//使用 TestCleanup 在執行完每個測試後執行程式碼
//[TestCleanup()]
//public void MyTestCleanup()
//{
//}
//
#endregion

    }
}
