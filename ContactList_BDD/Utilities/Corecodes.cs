using OpenQA.Selenium;
using Serilog;

namespace ContactList_BDD
{
    public class Corecodes
    {
       public static Dictionary<string, string> Properties;

        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/ScreenShots/scs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot1.SaveAsFile(filepath);

        }

        protected void LogTestResult(string testName, string result, string erroMessage)
        {
            Log.Information(result);
            if (erroMessage == null)
            {
                Log.Information(testName + "Passed");
            }
            else
            {
                Log.Error($"Test Failed for {testName}." + $"\n Exception: \n {erroMessage}");
            }

        }
        public static void ReadConfigSettings()
        {
            
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            Properties = new Dictionary<string, string>();
            string fileName = currentDirectory + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }



    }
}
