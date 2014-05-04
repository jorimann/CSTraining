using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using System.Diagnostics;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;

namespace WhiteTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ProcessInfo = new ProcessStartInfo(@"D:\Repos\Visual Studio\git_repo\App_Debug\WpfTodo.exe");
            var app = Application.AttachOrLaunch(ProcessInfo);
            var window = app.GetWindow("Wpf Todo");
            //var btn = window.Get<Button>(SearchCriteria.ByText("New Task"));
            var btn = window.Get<Button>(SearchCriteria.ByAutomationId("AddTaskButton"));
            Assert.AreEqual("New Task", btn.Text);
            //btn.Click();
            //app.Close();
            Retry.For<Button>( () =>
                window.Get<Button>(SearchCriteria.ByAutomationId("AddTaskButton")),
                TimeSpan.FromSeconds(15));
            
        }
    }
}
