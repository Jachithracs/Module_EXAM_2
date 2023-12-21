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
    internal class RemoveContactPage
    {
        IWebDriver? driver;
        public RemoveContactPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "(//table[@id='myTable'])/tr/td[2]")]
        private IWebElement? ViewContactDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='delete']")]
        private IWebElement? DeleteContactBtn { get; set; }

        public AddContactPage ClickViewDetailsBtn()
        {
            //DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            //wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //wait.Timeout = TimeSpan.FromSeconds(10);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.Message = "element not found";

            //wait.Until(d => ViewContactDetails?.Displayed);
            ViewContactDetails?.Click();
            return new AddContactPage(driver);
        }
       
        public void ClickDeleteContactBtn()
        {
            //DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            //wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //wait.Timeout = TimeSpan.FromSeconds(10);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.Message = "element not found";

            //wait.Until(d => DeleteContactBtn?.Displayed);
            DeleteContactBtn?.Click();
        }


    }
}
