namespace Tests.UI.AppSandbox
{
    using NUnit.Framework;

    using Tests.UI.AutomationFramework.AppSandbox.PageLibrary;

    public class Search_Merchandise_AddAndRemove : AutomatedAcceptanceTest 
    {
        private const string ItemToSearch = "SwissGear SA1923";

        [Test]
        public void GivenAnyUser_WhenSearchingForItem_CanSeeDesiredResult()
        {
            SearchBox.SearchForItem(ItemToSearch);

            Assert.That(SearchResults.ResultOnPage(ItemToSearch));
        }

        [Test]
        public void GivenAnyUser_WhenAddingToCart_AddsSuccessfully()
        {
            SearchBox.SearchForItem(ItemToSearch);

            SearchResults.ClickResult(ItemToSearch);

            ItemDetail.AddItemToCart();

            Cart.Go();

            Assert.That(Cart.HasItem(ItemToSearch));
        }

        [Test]
        public void GivenAnyUser_WhenRemovingItemFromCart_RemovesSuccessfully()
        {
            SearchBox.SearchForItem(ItemToSearch);

            SearchResults.ClickResult(ItemToSearch);

            ItemDetail.AddItemToCart();

            Cart.Go();

            Cart.RemoveItem(ItemToSearch);

            Assert.That(Cart.Empty);
        }

        // Refactored to use a workflow class 

    }
}
