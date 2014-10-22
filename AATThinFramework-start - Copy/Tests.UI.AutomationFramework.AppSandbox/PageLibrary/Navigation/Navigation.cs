namespace Tests.UI.AutomationFramework.AppSandbox.PageLibrary.Navigation
{
    public static class TopMenuNavigation
    {
        public static class Cart
        {
            public static void Select()
            {
                NavigationSelector.Select("nav-cart");
            }
        }
    }
}
