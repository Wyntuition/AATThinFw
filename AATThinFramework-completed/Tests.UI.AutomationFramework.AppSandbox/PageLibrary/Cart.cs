namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary
{
    using System.Threading;

    using OpenQA.Selenium;

    using Tests.UI.AutomationFramework.AppSandbox.Data;
    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public class Cart
    {
        public static void Go()
        {
            Driver.GoToHomePage();

            Navigation.TopMenuNavigation.Cart.Select();
        }

        public static bool HasItem(string itemToSearch)
        {
            return Driver.FindElementAndWaitUntilAvailable(By.PartialLinkText(AmazonConstants.Backpack_Name)).Displayed;
        }

        public static void RemoveItem(string itemToSearch)
        {
            Driver.FindElementAndWaitUntilAvailable(
                By.XPath("//div[@class='a-fixed-left-grid-inner']/div[2]/div/span[1]/span/input")).Click();
        }

        public static bool Empty
        {
            get
            {
                Thread.Sleep(((int)(2 * 1000)));
                return Driver.FindElementAndWaitUntilAvailable(By.TagName("html")).Text.Contains("$0.00");
            }
        }
    }
}