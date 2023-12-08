using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListTesting.PageObjects
{
    internal class AddContactPage
    {
        IWebDriver? driver;
        public AddContactPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "add-contact")]
        private IWebElement? AddnewContact { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement? FirstNameInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement? LastNameInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='birthdate']")]
        private IWebElement? DateofBirthInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone']")]
        private IWebElement? PhoneInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='street1']")]
        private IWebElement? Address1InputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='street2']")]
        private IWebElement? Address2InputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement? CityInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='stateProvince']")]
        private IWebElement? StateInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='postalCode']")]
        private IWebElement? PostalInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]
        private IWebElement? CountryInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//table[@id='myTable'])/tr/td[2]")]
        private IWebElement? ViewContactDetails { get; set; }

        public void ClickAddnewContact()
        {
            AddnewContact?.Click();
        }

        public AddContactPage SubmitBtnClick(string firstname, string lastname, string email,
            string phone, string address1, string address2,string city, string state, string postal,
            string country)
        {
            FirstNameInputBox?.SendKeys(firstname);
            LastNameInputBox?.SendKeys(lastname);
            EmailInputBox?.SendKeys(email);
            PhoneInputBox?.SendKeys(phone);
            Address1InputBox?.SendKeys(address1);
            Address2InputBox?.SendKeys(address2);
            CityInputBox?.SendKeys(city);
            StateInputBox?.SendKeys(state);
            PostalInputBox?.SendKeys(postal);
            CountryInputBox?.SendKeys(country);

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "element not found";

            wait.Until(d => SubmitBtn?.Displayed);

            SubmitBtn?.SendKeys(Keys.Enter);
            return new AddContactPage(driver);
        }

        public AddContactPage ClickDateofBirth(string dob)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "element not found";

            wait.Until(d => DateofBirthInputBox?.Displayed);
            DateofBirthInputBox?.SendKeys(dob);
            return new AddContactPage(driver);
        }

        public AddContactPage ClickViewDetailsBtn()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "element not found";
            
            wait.Until(d => ViewContactDetails?.Displayed);
            ViewContactDetails?.Click();
            return new AddContactPage(driver); 
        }
    }
}
