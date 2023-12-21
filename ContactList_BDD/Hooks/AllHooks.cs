using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace ContactList_BDD.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        public static IWebDriver? driver;
        public static ExtentReports extent;
        static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;


        [BeforeFeature]
        public static void InitializeBrowser()
        {
           // ReadConfigFile.ReadConfigProperty();
           Corecodes.ReadConfigSettings();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report"+ DateTime.Now.ToString("yyyy_MM_ddHH-mms-s") + ".html");
            extent.AttachReporter(sparkReporter);


            if (Corecodes.Properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (Corecodes.Properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url =Corecodes.Properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario]
        public static void CreateLogFile()
        {
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/logs/log_" +
                DateTime.Now.ToString("dd/ddMMyyyy-hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }



        [BeforeScenario]
        public static void RefreshPage()
        {
            driver?.Navigate().Refresh();
        }
        [AfterScenario]
        public static void NavigateBack()
        {
            driver.Navigate().GoToUrl(Corecodes.Properties["baseUrl"]);
            Log.CloseAndFlush();
        }
        [AfterFeature]
        public static void CloseBrowser()
        {
            driver?.Close();
            extent.Flush();
        }

    }
}