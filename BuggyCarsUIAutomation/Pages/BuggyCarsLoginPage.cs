using BuggyCarsUIAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Pages
{
    public class BuggyCarsLoginPage : BasePage
    {
        public BuggyCarsLoginPage() : base()
        {
            string title = "Buggy Cars Rating";
            Browser.WaitForTitle(title);
        }

        #region Locators
        private IWebElement UserName
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//input[@name='login']"));
            }
        }
        private IWebElement Password
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//input[@name='password']"));
            }

        }
        private IWebElement LoginButton
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//button[text()='Login']"));
            }
        }
        private IWebElement RegisterButton
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//a[text()='Register']"));
            }
        }
        private IWebElement WelcomeMessage
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//span[@class='nav-link disabled']"));
            }
        }

        private IWebElement InvalidUserMessage
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//span[contains(text(),'Invalid')]"));
            }
        }
        #endregion

        #region Accessers
        public BuggyCarsLoginPage EnterUserName(string userID)
        {
            EnterTextInInputBox(UserName, userID);
            return this;
        }

        public BuggyCarsLoginPage EnterPassword(string userPwd)
        {
            EnterTextInInputBox(Password, userPwd);
            return this;
        }

        public BuggyCarsLoginPage ClickOnLoginButton()
        {
            ClickOnButton(LoginButton);
            return this;
        }

        public BuggyCarsLoginPage ClickOnRegisterButton()
        {
            ClickOnButton(RegisterButton);
            return this;
        }

        public BuggyCarsLoginPage VerifySuccesfulLoginMessageDisplayed(string expectedMessage)
        {
            VerifyTextMessageDisplayedAsExpected(WelcomeMessage, expectedMessage);
            return this;
        }

        public BuggyCarsLoginPage VerifyInvalidLoginMessageDisplayed(string expectedMessage)
        {
            VerifyTextMessageDisplayedAsExpected(InvalidUserMessage, expectedMessage);
            return this;
        }
        #endregion
    }
}
