using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using ContactList_BDD;
using ContactList_BDD.Hooks;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.MarkupUtils;

namespace ContactList_BDD.StepDefinitions
{
    [Binding]
    public class LoginAndAddContactAndViewContactStepDefinitions : Corecodes
    {
        IWebDriver? driver = AllHooks.driver;
        //[Given(@"User is in the Herokuapp Login Page")]
        //public void GivenUserIsInTheHerokuappLoginPage()
        //{
        //    driver.Url = "https://thinking-tester-contact-list.herokuapp.com/";
        //    driver.Manage().Window.Maximize();
        //}
        
        [When(@"User Enter a correct email in the input box '([^']*)'")]
        public void WhenUserEnterACorrectEmailInTheInputBox(string email)
        {
            AllHooks.test = AllHooks.extent.CreateTest("Add To Cart Test");
            IWebElement? emailinput = driver?.FindElement(By.Id("email"));
            Console.WriteLine(email);
            emailinput.SendKeys(email);
            Thread.Sleep(2000);
        }

        [When(@"User Enter a correct password in the input box '([^']*)'")]
        public void WhenUserEnterACorrectPasswordInTheInputBox(string password)
        {
            IWebElement? inputpassword = driver.FindElement(By.Id("password"));
            inputpassword.SendKeys(password);
            Thread.Sleep(3000);
            IWebElement? LoginButtonClick = driver.FindElement(By.XPath("//button[@id='submit']"));
            LoginButtonClick.Click();
            Thread.Sleep(3000);
        }

        [Then(@"User redirect to the My Contacts Page")]
        public void ThenUserRedirectToTheMyContactsPage()
        {
            TakeScreenShot(driver);
            var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;//1
            AllHooks.test.AddScreenCaptureFromBase64String(ss);//
            Assert.That(driver.Url.Contains("contactList"));
        }


        [When(@"User Clicks on the Add a New Contact Button")]
        public void WhenUserClicksOnTheAddANewContactButton()
        {
            IWebElement? addButtonClick = driver.FindElement(By.Id("add-contact"));
            addButtonClick.Click();
            Thread.Sleep(3000);
        }

        [Then(@"User redirect to the Add Contact page")]
        public void ThenUserRedirectToTheAddContactPage()
        {
            Assert.That(driver.Url.Contains("addContact"));
        }
        [When(@"User enter the first name '([^']*)'")]
        public void WhenUserEnterTheFirstName(string first)
        {
            IWebElement firstname = driver.FindElement(By.XPath("//input[@id='firstName']"));
            firstname.SendKeys(first);
        }
        [When(@"User enter the last name '([^']*)'")]
        public void WhenUserEnterTheLastName(string last)
        {
            IWebElement lastname = driver.FindElement(By.XPath("//input[@id='lastName']"));
            lastname.SendKeys(last);
        }


        [When(@"User enter the date of birth '([^']*)'")]
        public void WhenUserEnterTheDateOfBirth(string dob)
        {
            IWebElement dateofB = driver.FindElement(By.XPath("//input[@id='birthdate']"));
            dateofB.SendKeys(dob);
        }
        [When(@"User enter the email '([^']*)'")]
        public void WhenUserEnterTheEmail(string email)
        {
            IWebElement emailinput = driver.FindElement(By.XPath("//input[@id='email']"));
            emailinput.SendKeys(email);
        }
        [When(@"User enter the phone '([^']*)'")]
        public void WhenUserEnterThePhone(string phone)
        {
            IWebElement phoneinput = driver.FindElement(By.XPath("//input[@id='phone']"));
            phoneinput.SendKeys(phone);
        }
        [When(@"User enter the Address1 '([^']*)'")]
        public void WhenUserEnterTheAddress1(string address1)
        {
            IWebElement address1input = driver.FindElement(By.XPath("//input[@id='street1']"));
            address1input.SendKeys(address1);
        }
        [When(@"User enter the Address2 '([^']*)'")]
        public void WhenUserEnterTheAddress2(string address2)
        {
            IWebElement address2input = driver.FindElement(By.XPath("//input[@id='street2']"));
            address2input.SendKeys(address2);
        }
        [When(@"User enter the city '([^']*)'")]
        public void WhenUserEnterTheCity(string city)
        {
            IWebElement cityinput = driver.FindElement(By.XPath("//input[@id='city']"));
            cityinput.SendKeys(city);
        }
        [When(@"User enter the state '([^']*)'")]
        public void WhenUserEnterTheState(string state)
        {
            IWebElement stateinput = driver.FindElement(By.XPath("//input[@id='stateProvince']"));
            stateinput.SendKeys(state);
        }
        [When(@"User enter the postal code '([^']*)'")]
        public void WhenUserEnterThePostalCode(string code)
        {
            IWebElement codeinput = driver.FindElement(By.XPath("//input[@id='postalCode']"));
            codeinput.SendKeys(code);
        }
        [When(@"User enter the country '([^']*)'")]
        public void WhenUserEnterTheCountry(string country)
        {
            IWebElement countryinput = driver.FindElement(By.XPath("//input[@id='country']"));
            countryinput.SendKeys(country);
        }
        [When(@"User click on the submit button")]
        public void WhenUserClickOnTheSubmitButton()
        {
            IWebElement submitinput = driver.FindElement(By.XPath("//button[@id='submit']"));
            submitinput.Click();
            TakeScreenShot(driver);
            Thread.Sleep(3000);
        }

        [When(@"User click on the first contact detail")]
        public void WhenUserClickOnTheFirstContactDetail()
        {
            IWebElement viewinput = driver.FindElement(By.XPath("(//table[@id='myTable'])/tr/td[2]"));
            viewinput.Click();
            TakeScreenShot(driver);
        }

        [Then(@"User will redirect to Contact details page")]
        public void ThenUserWillRedirectToContactDetailsPage()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("contactDetails"));
                TakeScreenShot(driver);
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;//1
                AllHooks.test.AddScreenCaptureFromBase64String(ss);//
                Log.Information("Login And Add Contact Pass");
                AllHooks.test.Pass("pASSED");

            }
            catch (AssertionException ex)
            {
                Log.Error("Login And Add Contact-Fail", ex.Message);
            }
        }


       
            
        
    }
}
