namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary.Navigation
{
    using OpenQA.Selenium;

    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public static class NavigationSelector
    {
        public static void Select(string id)
        {
            Driver.Instance.FindElement(By.Id(id)).Click();
        }
    }
}
