namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary
{
    using OpenQA.Selenium;

    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public class SearchResults
    {
        public static bool ResultOnPage(string itemToSearch)
        {
            return Driver.FindElementAndWaitUntilAvailable(By.PartialLinkText(itemToSearch)).Displayed;
        }

        public static void ClickResult(string itemToSearch)
        {
            Driver.FindElementAndWaitUntilAvailable(By.PartialLinkText(itemToSearch)).Click();
        }
    }
}
