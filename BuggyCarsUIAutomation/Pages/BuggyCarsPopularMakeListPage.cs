using BuggyCarsUIAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Pages
{
    public class BuggyCarsPopularMakeListPage : BasePage
    {
        public BuggyCarsPopularMakeListPage() : base()
        {
            string title = "Buggy Cars Rating";
            Browser.WaitForTitle(title);
        }

        #region Locators
        private IWebElement PopularMakeTable
        {
            get
            {
                return Browser.Driver.FindElement(By.XPath("//tbody"));
            }
        }
        #endregion

        #region Accessers
        public string GetTopModelFromTable()
        {
            string topModel;
            IWebElement firstCar = PopularMakeTable.FindElement(By.XPath("//tbody/tr/td[text()='1']/preceding-sibling::td/a/img"));
            topModel = firstCar.GetAttribute("title"); 
            return topModel;
        }

        #endregion
    }
}
