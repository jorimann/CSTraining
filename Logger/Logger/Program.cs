using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Logger4net
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Util.LogLog.InternalDebugging = true;
            LoggerCom logger = new LoggerCom();
            //logger.SetTestCaseName("Test Case 1");
            ////logger.SetEnv("UAT2");
            logger.RecordTestRun("ddf");
            logger.StartTestCase("Test Case 1");
            //logger.SetStepName("Book trade");
            logger.Info("Start batch execution");
            logger.StepInfo("Step1", "Some Info");
            logger.Error("Error");
            logger.Pass("pass");
            logger.SetLogName("XMLAppender", @"D:\Logger\xml.txt");           

            ////logger.info("batch returned 100");
            ////logger.AssertEqual("101", "100");
            ////logger.AssertEqual("90", "90");
            ////logger.pass("passed!");
            ////logger.ExitTest();
            //logger.LoadConfig("D:\\Repos\\Visual Studio\\git_repo\\Logger\\Logger4net\\log.config");
            //logger.LoadDefaultConfig();
            //logger.SetLogFileName("D:\\logger4net.txt");
            //logger.InitTestCase("UAT2", "KIE");    
            //logger.StartTestCase("Check Excel Import to EE");
            //logger.Pass("Open EE tool", "Express Entry opened succesfully");
            //logger.Pass("Import Excel", "Excel was imported succesfully");
            //logger.Error("Check all trades yellow", "Not all trades are yellow after import");
            //logger.ExitTest();
            //logger.StartTestCase("Check STE Trade");
            //logger.StartStep("Open STE");
            //logger.Info("Click menu button");
            //logger.Pass("STE opened");
            //logger.Pass("Open STE 1", "Opened");
            //logger.ExitTest();
            //logger.StartTestCase("Calculate Trades");
            //logger.Error("Calculate Trade", "Error");
            //logger.AssertEqual("Check Face", "100", "101");
            //logger.ExitTest();   
            //Console.ReadLine();
        }
    }
}
