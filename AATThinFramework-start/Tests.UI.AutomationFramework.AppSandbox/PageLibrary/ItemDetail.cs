namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary
{
    using OpenQA.Selenium;

    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public class ItemDetail
    {
        public static void AddItemToCart()
        {
            Driver.FindElementAndWaitUntilAvailable(By.Id("add-to-cart-button")).Click();
        }
    }
}
