using BuggyCarsUIAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Pages
{
    public class BuggyCarsRegistrationPage : BasePage
    {
        public BuggyCarsRegistrationPage() : base()
        {
            string title = "Buggy Cars Rating";
            Browser.WaitForTitle(title);
        }

        #region Locators
        private IWebElement UserName
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("username"));
            }
        }
        private IWebElement FirstName
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("firstName"));
            }

        }
        private IWebElement LastName
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("lastName"));
            }

        }

        private IWebElement Password
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("password"));
            }

        }

        private IWebElement ConfirmPassword
        {
            get
            {
                return Browser.Driver.FindElement(By.Id("confirmPassword"));
            }

        }

        private IWebElement RegisterButton
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//button[text()='Register']"));
            }
        }

        private IWebElement SuccessMessage
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//div[contains(text(),'Registration is successful')]"));
            }
        }

        private IWebElement InvalidPasswordException
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException')]"));
            }
        }
        #endregion

        #region Accessers
        public BuggyCarsRegistrationPage EnterUserName(string userName)
        {
            EnterTextInInputBox(UserName, userName);
            return this;
        }

        public BuggyCarsRegistrationPage EnterFirstName(string userName)
        {
            EnterTextInInputBox(FirstName, userName);
            return this;
        }

        public BuggyCarsRegistrationPage EnterLastName(string userName)
        {
            EnterTextInInputBox(LastName, userName);
            return this;
        }

        public BuggyCarsRegistrationPage EnterPassword(string userPwd)
        {
            EnterTextInInputBox(Password, userPwd);
            return this;
        }

        public BuggyCarsRegistrationPage EnterConfirmPassword(string userPwd)
        {
            EnterTextInInputBox(ConfirmPassword, userPwd);
            return this;
        }

        public BuggyCarsRegistrationPage ClickOnRegisterButton()
        {
            ClickOnButton(RegisterButton);
            return this;
        }

        public BuggyCarsRegistrationPage VerifySuccessMessageDisplayed(string successMessage)
        {
            VerifyTextMessageDisplayedAsExpected(SuccessMessage, successMessage);
            return this;
        }

        public BuggyCarsRegistrationPage VerifyCorrectInvalidPasswordExceptionDisplayed(string errorMessage)
        {
            string actualError = GetText(InvalidPasswordException).Trim();
            Assert.That(actualError == errorMessage, "Expected password error does not display on registration form error. Actual Error: " + actualError + " While expected was: " + errorMessage);
            return this;
        }

        #endregion
    }
}
