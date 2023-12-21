using CasekaroModel.Utilities;
using ContactListTesting.PageObjects;
using ContactListTesting.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListTesting.TestScripts
{
    [TestFixture,Order(2)]
    internal class AddContactTest : CoreCode
    {
        [Test]
        [Category("End-to-End Test")]
        [TestCase("1998-10-03")]
        public void AddContact(string dob)
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
                    IWebElement ContactHeader = driver.FindElement(By.XPath("(//div[@class='main-content'])/header/h1"));
                    Assert.That(ContactHeader.Text.Contains("Contact"));
                    //Assert.IsTrue(driver?.Url.Contains("contactList"));
                    
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

            AddContactPage addContact = new AddContactPage(driver);
            addContact.ClickAddnewContact();
            string? sheetName1 = "AddContact";

            List<ExcelDataAddContact> excelList = ExcelUtils.ReadExcelDataAddContact(excelFilePath, sheetName1);

            foreach (var excelData in excelList)
            {
                string? firstname = excelData?.FirstName;
                string? lastname = excelData?.LastName;
                string? email = excelData?.Email;
                string? phone = excelData?.Phone;
                string? address1 = excelData?.Address1;
                string? address2 = excelData?.Address2;
                string? city = excelData?.City;
                string? state = excelData?.State;
                string? postalcode = excelData?.PostalCode;
                string? country = excelData?.Country;


                Console.WriteLine($"First Name: {firstname},Last Name: {lastname},Email: {email}, Phone: {phone}," +
                    $"Address1 : {address1},Address2: {address2},City: {city},State: {state}," +
                    $"Postal Code: {postalcode},Country: {country},");
                Log.Information("The details for adding contact details selected");
                addContact.ClickDateofBirth(dob);
                Thread.Sleep(3000);
                addContact.SubmitBtnClick(firstname,lastname,email, phone,address1,
                    address2,city,state,postalcode,country);
                Log.Information("Adding new Contact Completed");
                Thread.Sleep(3000);

                try
                {
                    Assert.IsTrue(driver?.Title.Contains("My Contacts"));

                    TakeScreenShot();
                    Log.Information("Test passed for Creating Add Contact Account");
                    test = extent.CreateTest("Creating Add Contact Account Link Test");
                    test.Pass("Creating Add Contact Link success");

                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for Creating Add Contact. \n Exception: {ex.Message}");

                    TakeScreenShot();
                    test = extent.CreateTest("Creating Add Contact Link Test");
                    test.Fail("Creating Add Contact Link failed");
                }
            }
           
            addContact.ClickViewDetailsBtn();
            
            TakeScreenShot();
            try
            {
                Assert.IsTrue(driver?.Url.Contains("contactDetails"));

                Log.Information("Test passed for Viewing Added Contact Account");
                test = extent.CreateTest("Viewing Added Contact Account Link Test");
                test.Pass("Viewing Added Contact Link success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Viewing Added Contact. \n Exception: {ex.Message}");

                test = extent.CreateTest("Viewing Added Contact Link Test");
                test.Fail("Viewing Added Contact Link failed");
            }

            Log.CloseAndFlush();
        }

    }
}
