using WatiN.Core;

namespace MyProject.Specs.Helpers
{
    internal class BrowserHelper
    {
        private IE _browser;

        public void OpenBrowser(string url)
        {
            _browser = new IE(url);
        }

        public void CloseBrowser()
        {
            _browser.Close();
        }

        public void SetSearchCriteria(string searchCriteria)
        {
            _browser.TextField(Find.ByName("q")).TypeText(searchCriteria);
        }

        public void ClickSearchButton()
        {
            _browser.Button(Find.ByName("btnK")).Click();
        }

        public bool HasText(string text)
        {
            return _browser.ContainsText(text);
        }

        public void SearchFor(string product)
        {
            _browser.TextField(Find.ById("twotabsearchtextbox")).TypeText(product);
//            _browser.WaitForComplete(3);
        }

        public void Go()
        {
            _browser.Button(Find.ByClass("nav-submit-input")).Click();
        }

        public void GoToProductPage()
        {
            _browser.Link(Find.ByText("Microsoft Xbox One Console (Xbox One)")).Click();
        }

        public void AddProductToBasket()
        {
//            _browser.Button(Find.ById("bb_atc_button")).Click();
            _browser.Image(Find.ById("bb_atc_button")).FireEvent("onclick");
        }

        public string AddedToBasketMessage()
        {
            return _browser.Element(Find.ById("confirm-text")).ToString();
        }
    }
}