namespace Tests.UI.AutomationFramework.AppSandbox.Selenium
{
    using System;
    using System.Configuration;
    using System.Drawing;
    using System.Threading;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;

    public class Driver
    {
        private const string CurrentServer = "www.amazon.com";

        public static IWebDriver Instance { get; set; }

        public static string BaseUrl
        {
            get { return string.Format("http://{0}", CurrentServer); }
        }

        public static void Initialize()
        {
            InitializeFirefoxDriver();
        }

        private static void InitializeFirefoxDriver()
        {
            var profile = new FirefoxProfile();
            Instance = new FirefoxDriver(profile);
			Instance.Manage().Window.Size = new Size(1100, 800); 
        }

        public static void Close()
        {
            if (Instance != null)
            {
                Instance.Close();
            }
        }

        public static void GoToHomePage()
        {
            if (Instance == null)
                throw new NullReferenceException("You likely didn't inherit your test class from the Test parent class.  Driver.Intialize() was likley not called, as its Instance is null.");

            Instance.Navigate().GoToUrl(BaseUrl);
        }

        public static void GoTo(string url)
        {
            Instance.Navigate().GoToUrl(BaseUrl + url);
        }

        public static IWebElement FindElementAndWaitUntilAvailable(By by)
        {
            return WaitExplicitlyUntil_FindElement_IsAvailable(by, 30);
        }

        public static IWebElement WaitExplicitlyUntil_FindElement_IsAvailable(By by, int timeoutInSeconds)
        {
            IWebElement webElement = null;

            try
            {
                var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(30));

                webElement = wait.Until(
                        d =>
                        {
                            var elements = Instance.FindElements(by);
                            if (elements.Count > 0 && elements[0].Displayed)
                            {
                                return elements[0];
                            }
                            return null;
                        });
            }
            catch (Exception ex)
            {
                //webElement = WaitWithBruteForce(by);

                if (webElement == null)
                {
                    throw new TimeoutException("Selenium timed out after trying to find this element: " + by, ex);
                }
            }

            return webElement;
        }

        private static IWebElement WaitWithBruteForce(By by, int seconds)
        {
            IWebElement e = null;
            long elapsedTime = 0;
            while (elapsedTime < seconds)
            {
                try
                {
                    elapsedTime++;
                    Thread.Sleep(1000);
                    e = Instance.FindElement(by);
                    break;
                }
                catch (NoSuchElementException nse)
                {
                    // Record error
                }
            }

            return e;
        }
    }
}
