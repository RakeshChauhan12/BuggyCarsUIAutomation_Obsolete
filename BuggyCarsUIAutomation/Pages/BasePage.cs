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
    /// Base page can be used as home for widely used methods.
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// Enters text in edit box.
        /// </summary>
        /// <param name="element">Editbox element</param>
        /// <param name="text">text to enter</param>
        protected void EnterTextInInputBox(IWebElement element, string text)
        {
            Browser.WaitForElement(element);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Click on element
        /// </summary>
        /// <param name="element">Button to click on</param>
        protected void ClickOnButton(IWebElement element)
        {
            Browser.WaitForElement(element);
            element.Click();
        }

        /// <summary>
        /// Compare expected string with text on webelement
        /// </summary>
        /// <param name="element">Element to get text from</param>
        /// <param name="ExpectedMessage">Expected string to compare</param>
        protected void VerifyTextMessageDisplayedAsExpected(IWebElement element, string ExpectedMessage)
        {
            string text = GetText(element).Trim();
            Assert.That(text == ExpectedMessage, "Expected text did not display on screen. Actual text displayed: " + text + " while expected was: " + ExpectedMessage);
        }

        /// <summary>
        /// Get text from element
        /// </summary>
        /// <param name="element">Element to get text from</param>
        /// <returns></returns>
        protected string GetText(IWebElement element)
        {
            Browser.WaitForElement(element);
            return element.Text;
        }
    }
}
