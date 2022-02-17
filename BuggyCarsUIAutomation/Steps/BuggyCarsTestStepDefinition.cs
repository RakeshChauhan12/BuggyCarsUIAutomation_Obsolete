using BuggyCarsUIAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BuggyCarsUIAutomation.Steps
{
    [Binding]
    public sealed class BuggyCarsTestStepDefinition
    {

        private readonly ScenarioContext _scenarioContext;

        public BuggyCarsTestStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Browser.scenarioContext = _scenarioContext;
        }

        [Given(@"I login as existing user in buggy cars rating")]
        public void GivenILoginAsExistingUserInBuggyCarsRating()
        {
            BuggyCars.BuggyCarsLoginPage.EnterUserName(BuggyCars.BuggyCarsData.userDetail.Username);
            BuggyCars.BuggyCarsLoginPage.EnterPassword(BuggyCars.BuggyCarsData.userDetail.Password);
        }

        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            BuggyCars.BuggyCarsLoginPage.ClickOnLoginButton();
        }

        [Then(@"I will see login page")]
        public void ThenIWillSeeLoginPage()
        {
            string welcomeMessage = "Hi, " + BuggyCars.BuggyCarsData.userDetail.FirstName;
            BuggyCars.BuggyCarsLoginPage.VerifySuccesfulLoginMessageDisplayed(welcomeMessage);
        }

        [Given(@"I click on register button on login page")]
        public void GivenIClickOnRegisterButtonOnLoginPage()
        {
            BuggyCars.BuggyCarsLoginPage.ClickOnRegisterButton();
        }

        [Given(@"I fill details on registration page")]
        public void GivenIFillDetailsOnRegistrationPage()
        {
            string username = StringHelper.GenerateRandomString(6);
            string password = "Tester1!";
            BuggyCars.BuggyCarsRegistrationPage.EnterUserName(username);
            BuggyCars.BuggyCarsRegistrationPage.EnterFirstName(username);
            BuggyCars.BuggyCarsRegistrationPage.EnterLastName(username);
            BuggyCars.BuggyCarsRegistrationPage.EnterPassword(password);
            BuggyCars.BuggyCarsRegistrationPage.EnterConfirmPassword(password);
            BuggyCars.BuggyCarsRegistrationPage.ClickOnRegisterButton();
        }

        [When(@"I click on register link")]
        public void WhenIClickOnRegisterLink()
        {
            BuggyCars.BuggyCarsRegistrationPage.ClickOnRegisterButton();
        }

        [Then(@"I get a success message ""(.*)""")]
        public void ThenIGetASuccessMessage(string successMessage)
        {
            BuggyCars.BuggyCarsRegistrationPage.VerifySuccessMessageDisplayed(successMessage);
        }

        [Given(@"I login as invalid user in buggy cars rating")]
        public void GivenILoginAsInvalidUserInBuggyCarsRating()
        {
            BuggyCars.BuggyCarsLoginPage.EnterUserName("fake");
            BuggyCars.BuggyCarsLoginPage.EnterPassword("fake");
        }

        [Then(@"I will see login failed message ""(.*)""")]
        public void ThenIWillSeeLoginFailedMessage(string failMessage)
        {
            BuggyCars.BuggyCarsLoginPage.VerifyInvalidLoginMessageDisplayed(failMessage);
        }

        [Given(@"I click on popular make image on home page")]
        public void GivenIClickOnPopularMakeImageOnHomePage()
        {
            BuggyCars.BuggyCarsHomePage.ClickOnPopularMakeImage();
        }

        [When(@"I navigate back to home page")]
        public void WhenINavigateBackToHomePage()
        {
            _scenarioContext.Add("MostPopularCar", BuggyCars.BuggyCarsPopularMakeListPage.GetTopModelFromTable());
            Browser.Back();
        }

        [Then(@"I will see popular model displayed correctly")]
        public void ThenIWillSeePopularModelDisplayedCorrectly()
        {
            string topCar;
            _scenarioContext.TryGetValue("MostPopularCar", out topCar);
            BuggyCars.BuggyCarsHomePage.VerifyPopularModelDisplayedAsExpected(topCar);
        }

        [Given(@"I fill details on registration page for password ""(.*)""")]
        public void GivenIFillDetailsOnRegistrationPageForPassword(string ErrorType)
        {
            string username = StringHelper.GenerateRandomString(6);
            BuggyCars.BuggyCarsRegistrationPage.EnterUserName(username);
            BuggyCars.BuggyCarsRegistrationPage.EnterFirstName(username);
            BuggyCars.BuggyCarsRegistrationPage.EnterLastName(username);
            switch (ErrorType)
            {
                case "PasswordLength":
                    BuggyCars.BuggyCarsRegistrationPage.EnterPassword("qwertyu");
                    BuggyCars.BuggyCarsRegistrationPage.EnterConfirmPassword("qwertyu");
                    break;
                case "UpperCaseLetter":
                    BuggyCars.BuggyCarsRegistrationPage.EnterPassword("qwertyui");
                    BuggyCars.BuggyCarsRegistrationPage.EnterConfirmPassword("qwertyui");
                    break;
            }
        }

        [Then(@"I get a password error message ""(.*)""")]
        public void ThenIGetAPasswordErrorMessage(string errorMessage)
        {
            BuggyCars.BuggyCarsRegistrationPage.VerifyCorrectInvalidPasswordExceptionDisplayed(errorMessage);
        }
    }
}
