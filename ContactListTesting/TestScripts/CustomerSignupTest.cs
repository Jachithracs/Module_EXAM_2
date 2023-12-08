using CasekaroModel.Utilities;
using ContactListTesting.PageObjects;
using ContactListTesting.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListTesting.TestScripts
{
    [TestFixture,Order(1)]
    internal class CustomerSignupTest : CoreCode
    {
        [Test]
        public void CustomerLoginTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
             .CreateLogger();

            ContactListHomePage contactList = new ContactListHomePage(driver);
            Thread.Sleep(3000);
            Log.Information("Creating new customer Account Started");
            var customerlogin = contactList.ClickSignUpBtn();
            Log.Information("Creating Customer Account Link Clicked");
            Thread.Sleep(3000);

            Log.Information("Creating new customer Account Clicked");
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


                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName},Email: {email}, Password: {password}");
                Log.Information("The details for creating account details selected");
                Thread.Sleep(3000);
                customerlogin.ClickSubmitBtn(firstName, lastName, email, password);
                Log.Information("Creating Customer Account Completed");
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


                Log.CloseAndFlush();
               
            }
        }
    }
}
