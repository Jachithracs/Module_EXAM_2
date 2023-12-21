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
    internal class ContactListHomePage
    {
        IWebDriver? driver;
        public ContactListHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "signup")]
        private IWebElement? CreateSignupBtn { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? EmailInputBox { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? SubmitBtn { get; set; }


        public SignUpPage ClickSignUpBtn()
        {
            
            CreateSignupBtn?.Click();
            return new SignUpPage(driver);
        }
        public AddContactPage ClickSubmit(string email,string password)
        {
            EmailInputBox?.SendKeys(email);
            PasswordInputBox?.SendKeys(password);

            //DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            //wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //wait.Timeout = TimeSpan.FromSeconds(10);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.Message = "element not found";

            //wait.Until(d => SubmitBtn?.Displayed);
            SubmitBtn?.SendKeys(Keys.Enter);
            return new AddContactPage(driver);
        }


    }
}
