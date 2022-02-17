using BuggyCarsUIAutomation.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BuggyCarsUIAutomation.Utilities
{
    [Binding]
    public static class Browser
    {
        private static IWebDriver webDriver;
        private static int waitTimeInSeconds = 30;
        public static ScenarioContext scenarioContext;

        /// <summary>
        /// Reference to webdriver.
        /// </summary>
        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        /// <summary>
        /// Write methods that will be run before every test scripts
        /// Use this section to do all necessary setup before run e.g start browser and launch URL
        /// </summary>
        #region Pre Run Methods
        [BeforeScenario(Order = 1)]
        private static void ScenarioSetUp()
        {
            PopulateBuggyCarsData();
            StartBrowser(ConfigurationManager.AppSettings["TestEnvironment"], ConfigurationManager.AppSettings["Browser"]);
        }

        private static void StartBrowser(string environment, string browser)
        {
            string URL = ResolveEnvironementURL(environment);

            switch (browser.ToUpper())
            {
                case "CHROME":
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTimeInSeconds);
                    break;
                case "FIREFOX":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTimeInSeconds);
                    break;
                case "IE":
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.RequireWindowFocus = true;
                    webDriver = new InternetExplorerDriver(options);
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTimeInSeconds);
                    break;
                default:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTimeInSeconds);
                    break;
            }

            webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(waitTimeInSeconds);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(waitTimeInSeconds);
        }

        private static string ResolveEnvironementURL(string environment)
        {
            string url;

            switch (environment?.ToUpper())
            {
                case "Stage1": url = ConfigurationManager.AppSettings["StagingEnv1URL"]; break;
                case "Stage2": url = ConfigurationManager.AppSettings["StagingEnv2URL"]; break;
                case "Stage3": url = ConfigurationManager.AppSettings["StagingEnv3URL"]; break;
                default: url = ConfigurationManager.AppSettings["StagingEnv1URL"]; break;
            }
            return url;
        }
        #endregion

        #region Post Run Methods
        [AfterScenario]
        private static void CleanUp()
        {

            try
            {
                if (scenarioContext.TestError != null)
                {
                    string ResultfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["TestResultPath"]);
                    Directory.CreateDirectory(ResultfilePath);
                        Screenshot screenShot = ((ITakesScreenshot)webDriver).GetScreenshot();
                        string fileName = ResultfilePath + "\\Screenshot_" +
                                          String.Format(@"{0}.png",
                                              scenarioContext.ScenarioInfo.Title);
                        screenShot.SaveAsFile((fileName), ScreenshotImageFormat.Png);
                        Console.WriteLine("Screenshot: {0}", new Uri(fileName));

                }
                if (webDriver != null)
                {
                    webDriver.Close();
                    webDriver.Quit();
                }
            }
            catch
            {
                if (ConfigurationManager.AppSettings["Browser"].ToUpper() == "CHROME")
                {
                    KillProcess("chromedriver");
                    KillProcess("chrome");
                }
                else if (ConfigurationManager.AppSettings["Browser"].ToUpper() == "IE")
                {
                    KillProcess("IEDriverServer");
                    KillProcess("iexplore");
                }

            }
            finally
            {

            }
        }

        private static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
        #endregion

        public static void Back()
        {
            webDriver.Navigate().Back();
        }

        public static void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

        public static void WaitForTitle(string title)
        {
            Retry(() =>
            {
                return webDriver.Title.Contains(title);
            }, exceptionMessage: "Page title " + title + " Couldn't be found. Please verify if page is loaded correctly");
        }

        public static void WaitForElement(IWebElement element)
        {
            Retry(() =>
            {
                return element.Displayed && element.Enabled;
            });
        }

        public static void PopulateBuggyCarsData()
        {
            string DatafilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["DataPath"]);
            var testUser = JsonHandler.DeserializeJsonArrayFromFile<Users>(DatafilePath);
            foreach(var user in testUser)
            {
                BuggyCars.BuggyCarsData.userDetail.Username = user.Username;
                BuggyCars.BuggyCarsData.userDetail.Password = user.Password;
                BuggyCars.BuggyCarsData.userDetail.FirstName = user.FirstName;
            }
        }

        private static void Retry(Func<bool> function, int retryInterval = 500, int retryCount = 20, string exceptionMessage = null)
        {
            int count = 0;
            Exception exception = null;
            do
            {
                try
                {
                    if (function())
                    {
                        return;
                    }
                    else
                    {
                        Thread.Sleep(retryInterval);
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                    Thread.Sleep(retryInterval);
                    count++;
                }
            } while (count != retryCount);

            if (exception != null)
            {
                exceptionMessage = exception.Message;
            }

            exceptionMessage = exceptionMessage ?? "Retry Timed Out while trying to execute - " + function.Method.Name.ToString();

            throw new Exception(exceptionMessage, exception);
        }
    }
}
