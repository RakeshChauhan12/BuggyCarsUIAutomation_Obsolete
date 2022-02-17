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
    /// <summary>
    /// Landing page of buggy cars excluding top login header
    /// </summary>
    public class BuggyCarsHomePage : BasePage
    {
        public BuggyCarsHomePage() : base()
        {
            string title = "Buggy Cars Rating";
            Browser.WaitForTitle(title);
        }

        #region Locators
        private IWebElement PopularMake
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//div/h2[text()='Popular Make']/following-sibling::a"));
            }
        }
        private IWebElement PopularModelText
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//div/h2[text()='Popular Model']/following-sibling::div/h3"));
            }

        }
        #endregion

        #region Accessers
        /// <summary>
        /// Click on popular make image on home page.
        /// </summary>
        /// <returns></returns>
        public BuggyCarsHomePage ClickOnPopularMakeImage()
        {
            ClickOnButton(PopularMake);
            return this;
        }

        /// <summary>
        /// Verify popular model displayed on home page matches expected model name
        /// </summary>
        /// <param name="modelName">Expected model name</param>
        /// <returns></returns>
        public BuggyCarsHomePage VerifyPopularModelDisplayedAsExpected(string modelName)
        {
            string CarModelName = GetText(PopularModelText).Split('(')[0].Trim();
            Assert.That(modelName == CarModelName, "Expected car model name did not display on screen. Actual text displayed: " + CarModelName + " while expected was: " + modelName);
            return this;
        }

        #endregion
    }
}
