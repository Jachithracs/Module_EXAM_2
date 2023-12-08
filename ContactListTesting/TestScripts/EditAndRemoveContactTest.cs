using CasekaroModel.Utilities;
using ContactListTesting.PageObjects;
using ContactListTesting.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListTesting.TestScripts
{
    [TestFixture,Order(3)]
    internal class EditAndRemoveContactTest : CoreCode
    {
        [Test]
        [Category("End-to-End Test")]
        public void ClickEditAndDeleteContact()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
             .CreateLogger();

            ContactListHomePage contactList = new ContactListHomePage(driver);

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelDataCreateAccount(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? password = excelData?.Password;


                Console.WriteLine($"Email: {email}, Password: {password}");
                Log.Information("The details for creating account details selected");
                contactList.ClickSubmit(email, password);
                Log.Information("Login to the Customer Account Completed");
                Thread.Sleep(3000);

                TakeScreenShot();
                try
                {
                    Assert.IsTrue(driver?.Url.Contains("contactList"));

                    Log.Information("Test passed for Create Account");
                    test = extent.CreateTest("Create Account Link Test");
                    test.Pass("Create Account Link success");

                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");

                    test = extent.CreateTest("Create Account Link Test");
                    test.Fail("Create Account Link failed");
                }
            }
            AddContactPage removeContact = new AddContactPage(driver);
            removeContact.ClickViewDetailsBtn();
            Thread.Sleep(3000);
            RemoveContactPage remove = new RemoveContactPage(driver);
            
            remove.ClickDeleteContactBtn();
            

            IAlert? alert = driver?.SwitchTo().Alert();     
            alert?.Accept();
            Log.Information("Delete Contact Details Completed");

            TakeScreenShot();
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                wait.Timeout = TimeSpan.FromSeconds(10);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Message = "element not found";

                wait.Until(d => d.Url.Contains("contactList"));

                Assert.IsTrue(driver?.Url.Contains("contactList"));

                Log.Information("Test passed for Delete Contact Details");
                test = extent.CreateTest("Delete Contact Details Test");
                test.Pass("Delete Contact Details success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Delete Contact Details. \n Exception: {ex.Message}");

                test = extent.CreateTest("Delete Contact Details Test");
                test.Fail("Delete Contact Details failed");
            }
            Log.CloseAndFlush();
        }
    }
}
