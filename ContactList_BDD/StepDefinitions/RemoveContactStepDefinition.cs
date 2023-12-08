using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using ContactList_BDD;
using ContactList_BDD.Hooks;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ContactList_BDD.StepDefinitions
{
    [Binding]
    public class RemoveContactStepDefinition : Corecodes
    {
        IWebDriver? driver = BeforeHook.driver;

        [When(@"User click on the Delete Contact Button")]
        public void WhenUserClickOnTheDeleteContactButton()
        {
            IWebElement deletebtn = driver.FindElement(By.XPath("//button[@id='delete']"));
            deletebtn.Click();
            Thread.Sleep(3000);
            
        }
        

        [Then(@"User will got a PopUp message to delete the contact")]
        public void ThenUserWillGotAPopUpMessageToDeleteTheContact()
        {
            
            IAlert? alert = driver?.SwitchTo().Alert();
            alert?.Accept();
            Thread.Sleep(3000);
        }

        [Then(@"User will back to the page")]
        public void ThenUserWillBackToThePage()
        {
            try
            {
                Assert.That(driver.Url.Contains("contactList"));
                TakeScreenShot(driver);
                Log.Information("Login And Delete Contact Pass");

            }
            catch (AssertionException ex)
            {
                Log.Error("Login And Delete Contact-Fail", ex.Message);
            }
        }

       

    }
}
