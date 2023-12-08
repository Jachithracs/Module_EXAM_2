using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListTesting.PageObjects
{
    
    internal class SignUpPage
    {
        IWebDriver? driver;
        public SignUpPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement? FirstNameInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement? LastNameInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? SubmitBtn { get; set; }

        
        public AddContactPage ClickSubmitBtn(string firstname, string lastname,string email,
            string password)
        {
            FirstNameInputBox?.SendKeys(firstname);
            LastNameInputBox?.SendKeys(lastname);
            EmailInputBox?.SendKeys(email);
            PasswordInputBox?.SendKeys(password);

            SubmitBtn?.SendKeys(Keys.Enter);
            return new AddContactPage(driver);
        }

    }
}
