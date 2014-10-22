namespace Tests.UI.AutomationFramework.AppSandbox.Workflows
{
    using Tests.UI.AutomationFramework.AppSandbox.PageLibrary;

    public class ProductWorkflows
    {
        public static void AddItemToCart(string itemToAdd)
        {
            SearchBox.SearchForItem(itemToAdd);

            SearchResults.ClickResult(itemToAdd);

            ItemDetail.AddItemToCart();
        }         
    }
}