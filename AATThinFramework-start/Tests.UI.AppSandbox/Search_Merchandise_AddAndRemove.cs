namespace Tests.UI.AppSandbox
{
    using NUnit.Framework;

    using Tests.UI.AutomationFramework.AppSandbox.PageLibrary;
    using Tests.UI.AutomationFramework.AppSandbox.Workflows;

    public class Search_Merchandise_AddAndRemove : AutomatedAcceptanceTest 
    {
        private const string ItemToSearch = "SwissGear SA1923";

        [Test]
        public void WhenSearchingForItem_CanSeeDesiredResult()
        {
            SearchBox.SearchForItem(ItemToSearch);

            Assert.That(SearchResults.ResultOnPage(ItemToSearch));
        }

        [Test]
        public void WhenAddingToCart_AddsSuccessfully()
        {
            ProductWorkflows.AddItemToCart(ItemToSearch);

            Cart.Go();

            Assert.That(Cart.HasItem(ItemToSearch));
        }

        [Test]
        public void WhenRemovingItemFromCart_RemovesSuccessfully()
        {
            ProductWorkflows.AddItemToCart(ItemToSearch);
            
            Cart.Go();

            Cart.RemoveItem(ItemToSearch);

            Assert.That(Cart.Empty);
        }
    }
}
