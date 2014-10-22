namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary
{
    using OpenQA.Selenium;

    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public class SearchBox
    {
        public static void SearchForItem(string itemToSearch)
        {
            Driver.GoToHomePage();

            var searchBox = Driver.FindElementAndWaitUntilAvailable(By.Id("twotabsearchtextbox"));

            searchBox.SendKeys(itemToSearch);

            searchBox.SendKeys(Keys.Enter);
        }
    }
}