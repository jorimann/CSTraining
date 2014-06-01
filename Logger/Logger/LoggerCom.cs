using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using log4net;
using log4net.Appender;
namespace Logger4net
{
    [Guid("5F8EB648-80E7-4DC3-A401-5CE6DEE569F3")]
    public interface LoggerCom_Interface
    {
        [DispId(1)]
        void LoadConfig(String path);
        //[DispId(2)]
        //void LoadDefaultConfig();
        //[DispId(3)]
        //void SetLogFileName(String path);
        [DispId(4)]
        void InitEnv(String env, String siteCode);
        [DispId(5)]
        void StartTestCase(String TestCaseName);
        [DispId(6)]
        void StartStep(String stepName);
        [DispId(7)]
        void ExitTest();
        [DispId(8)]
        void FinishStep();
        [DispId(9)]
        void Pass(String message);
        [DispId(10)]
        void Error(String message);
        [DispId(11)]
        void Fatal(String message);
        [DispId(12)]
        void Info(String message);
        [DispId(13)]
        void StepPass(String Step, String message);
        [DispId(14)]
        void StepError(String Step, String message);
        [DispId(15)]
        void StepFatal(String Step, String message);//, Exception ex);
        [DispId(16)]
        void StepInfo(String Step, String message);
        [DispId(17)]
        Boolean AssertEqual(String description, String exp, String act);
        [DispId(18)]
        Boolean AssertContains(String text, String substr);
        //[DispId(19)]
        //void SetLogLevel(String LogLevel);
    }

    [Guid("431E6906-7019-4357-9765-9FC112DC9B26"),
    ClassInterface(ClassInterfaceType.None)]
    public class LoggerCom : LoggerCom_Interface, IDisposable
    {
        private String TestCaseName = "";
        private String Env = "";
        private String StepName = "";
        private String SiteCode = "";

        private int StepNumber = 0;
        private int errCount = 0;
        private int passCount = 0;
        private int fatalCount = 0;
        private int TestCaseNameLength = 30;
        private int StepNameLength = 40;

        //add PASSED log level
        log4net.Core.Level passLevel = new log4net.Core.Level(50000, "PASSED");

        // create instance of logger
        //public log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly ILog Log = LogManager.GetLogger(typeof(LoggerCom).Name);

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        //default Constructor
        public LoggerCom()
        {
            //add PASSED level
            log4net.LogManager.GetRepository().LevelMap.Add(passLevel);

            //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Info("Info");
            //put default values to logger properties
            log4net.GlobalContext.Properties["StepName"] = StepName;
            log4net.GlobalContext.Properties["TestCaseName"] = TestCaseName;
            log4net.GlobalContext.Properties["SiteCode"] = SiteCode;
            log4net.GlobalContext.Properties["myEnv"] = Env;
            log4net.GlobalContext.Properties["StepNumber"] = StepNumber;
            log4net.ThreadContext.Properties["AdoLevel"] = "OFF";
            //initialize configuration
            //log4net.Config.XmlConfigurator.Configure();

            log4net.Config.XmlConfigurator.Configure(new FileInfo(@"D:\Logger\log.config"));
        }
        public void LoadConfig(String path)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }

        //public void LoadDefaultConfig()
        //{
        //    log4net.Config.XmlConfigurator.Configure();
        //}

        //appropriate only for deafult app.config. After change path you need invoke LoadDefaultConfig. It's better to not use it
        public void SetLogFileName(String path)
        {
            log4net.ThreadContext.Properties["FileAppenderLogName"] = path;
        }

        public void RecordTestRun(String TestCase)
        {
            //Log.Debug(TestCase);
            var h = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a.Name == "AdoNetAppender_AccessTestCase")
                {
                    var logdata = new log4net.Core.LoggingEventData();
                    logdata.Level = log4net.Core.Level.Debug;
                    logdata.LoggerName = typeof(LoggerCom).Name;
                    logdata.Message = TestCase;
                    logdata.TimeStamp = DateTime.Now;
                    var logevent = new log4net.Core.LoggingEvent(logdata);
                    a.DoAppend(logevent);
                }
            }
        }

        //any additional initializing can require there
        public void InitEnv(String env, String siteCode)
        {
            Env = env;
            SiteCode = siteCode;
            log4net.ThreadContext.Properties["myEnv"] = Env;
            log4net.ThreadContext.Properties["SiteCode"] = SiteCode;
        }

        //Set internal values
        private void SetEnv(String env)
        {
            Env = env;
            log4net.ThreadContext.Properties["myEnv"] = Env;
        }
        private void SetSiteCode(string code)
        {
            SiteCode = code;
            log4net.ThreadContext.Properties["SiteCode"] = code;
        }
        private void SetTestCaseName(String name)
        {
            TestCaseName = name;
            if (name.Length > TestCaseNameLength)
            {
                name = name.Substring(0, TestCaseNameLength);
            }
            log4net.ThreadContext.Properties["TestCaseName"] = name;
        }
        private void SetStepName(String step)
        {
            StepName = step;
            if (step.Length > StepNameLength)
            {
                step = step.Substring(0, StepNameLength);
            }

            log4net.ThreadContext.Properties["StepName"] = step;
        }
        public void IncrementStepNumber()
        {
            StepNumber++;
            log4net.ThreadContext.Properties["StepNumber"] = StepNumber + ". ";
        }
        public void FlushStepNumber()
        {
            StepNumber = 0;
            log4net.ThreadContext.Properties["StepNumber"] = "";
        }

        //Start-Finish Tests and Steps
        public void StartTestCase(String TestCaseName)
        {
            passCount = 0;
            errCount = 0;
            fatalCount = 0;

            log4net.ThreadContext.Properties["StepNumber"] = "***";
            SetTestCaseName(TestCaseName);
            SetStepName("TEST STARTED" + "****************************");

            Log.Info("HAS BEEN STARTED!");
            SetStepName("");
            FlushStepNumber();
        }
        public void StartStep(String stepName)
        {
            SetStepName(stepName);
            IncrementStepNumber();
        }

        public Boolean SetLogName(String AppenderName, String FileName)
        {
            var h = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a.Name == AppenderName)
                {
                    FileAppender fa = (FileAppender)a;
                    //var logFileLocation = string.Format(".\\Logs\\Device_{0}.log", device);
                    
                    fa.File = FileName;
                    fa.ActivateOptions();
                    a.Close();
                    return true;                    
                }
            }
            return false;
        }

        public void ExitTest()
        {
            log4net.ThreadContext.Properties["StepNumber"] = "###";
            SetStepName("TEST FINISHED" + "###########################");
            if ((errCount + fatalCount) > 0)
            {
                Error("PASSED: " + passCount + ", ERROR: " + errCount + ", FATAL: " + fatalCount);
            }
            else
            {
                Pass("PASSED: " + passCount + ", ERROR: " + errCount + ", FATAL: " + fatalCount);
            }
            FlushStepNumber();
            SetStepName("");
            SetTestCaseName("");
        }
        public void FinishStep()
        {
            //Log.Info("STEP '" + StepName + "' has been finished");
            SetTestCaseName("");
        }

        ////logging of pass-errors
        public void Pass(String message)
        {
            Log.Logger.Log(typeof(LoggerCom), passLevel, message, null);
            passCount++;
        }
        public void Error(String message)
        {
            Log.Error(message);
            errCount++;
        }
        public void Fatal(String message)
        {
            var ex = new FileNotFoundException();
            Log.Fatal(message, ex);
            fatalCount++;
        }

        public void Info(String message)
        {
            //MDC.Set("TestCaseName", "MyTestCa);
            Log.Info(message);
        }

        public void StepPass(String Step, String message)
        {
            if (!StepName.Equals(Step))
            {
                IncrementStepNumber();
            }
            SetStepName(Step);
            Log.Logger.Log(typeof(LoggerCom), passLevel, message, null);
            passCount++;
        }
        public void StepError(String Step, String message)
        {
            if (!StepName.Equals(Step))
            {
                IncrementStepNumber();
            }

            SetStepName(Step);
            Log.Error(message);
            errCount++;
        }
        public void StepFatal(String Step, String message)
        {
            if (!StepName.Equals(Step))
            {
                IncrementStepNumber();
            }

            SetStepName(Step);
            Log.Fatal(message);
            fatalCount++;
        }
        public void StepInfo(String Step, String message)
        {

            if (!StepName.Equals(Step))
            {
                IncrementStepNumber();
            }

            SetStepName(Step);
            Log.Info(message);
        }


        ////Section with Asserts
        public Boolean AssertEqual(String description, String exp, String act)
        {
            if (exp == act)
            {
                Pass(description + ": " + "EQUAL. Compared: '" + exp + "', '" + act + "'");
                return true;
            }
            else
            {
                Error(description + ": " + "NOT EQUAL. Compared: '" + exp + "', '" + act + "'");
                return false;
            }
        }
        public Boolean AssertContains(String text, String substr)
        {
            if (text.Contains(substr))
            {
                Pass("CONTAINS. String contains substring");
                return true;
            }
            else
            {
                Error("NOT CONTAINS. String does not contain substring");
                return false;
            }
        }

        ////system functions
        //public void SetLogLevel(String LogLevel)
        //{

        //}
    }
}


