namespace Tests.UI.AppSandbox
{
    using NUnit.Framework;

    using Tests.UI.AutomationFramework.AppSandbox.Selenium;

    public class AutomatedAcceptanceTest
    {
        [TestFixtureSetUp]
        public virtual void TestsSetup()
        {
            Driver.Close();

            Driver.Initialize();
        }

        [TestFixtureTearDown]
        public virtual void TestsCleanUp()
        {
            Driver.Close();
        }
    }
}
