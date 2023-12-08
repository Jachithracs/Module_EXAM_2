using TechTalk.SpecFlow;

namespace ContactList_BDD.Hooks
{
    [Binding]
    public sealed class AfterHook
    {
        [AfterFeature]
        public static void CleanUp()
        {
            BeforeHook.driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            BeforeHook.driver?.Navigate().GoToUrl("https://thinking-tester-contact-list.herokuapp.com/");
        }
    }
}