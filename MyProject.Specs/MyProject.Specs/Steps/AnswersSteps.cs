using System.Collections.Generic;
using Application;
using FluentAssertions;
using MyProject.Specs.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyProject.Specs.Steps
{
    [Binding]
    [RequiresSTA]
    public class AnswersSteps
    {
        private IEnumerable<int> _array;
        private int _firstNumber;
        private float _resultNumber;
        private int _secondNumber;
        private List<string> _topRatedVideosList;
        private BrowserHelper _browser;

        [Given(@"I have entered (.*) as the first number into the calculator")]
        public void GivenIHaveEnteredAsTheFirstNumberIntoTheCalculator(int firstNumber)
        {
            _firstNumber = firstNumber;
        }

        [Given(@"I have entered (.*) as the second number into the calculator")]
        public void GivenIHaveEnteredAsTheSecondNumberIntoTheCalculator(int secondNumber)
        {
            _secondNumber = secondNumber;
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _resultNumber = Calculator.AddTwoNumbers(_firstNumber, _secondNumber);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(float resultNumber)
        {
            resultNumber.Should().Be(_resultNumber);
        }

        [Then(@"the result should be greater than (.*) and (.*)")]
        public void ThenTheResultShouldBeGreaterThanAnd(int firstNumber, int secondNumber)
        {
            _resultNumber.Should().BeGreaterThan(firstNumber);
            _resultNumber.Should().BeGreaterThan(secondNumber);
        }

        [Given(@"I am on google search page")]
        public void GivenIHaveOpenedIE()
        {
            _browser = new BrowserHelper();
            _browser.OpenBrowser("http://www.google.co.uk/");
        }

        [When(@"I enter ""(.*)"" in Search box")]
        public void WhenIEnterInSearchBox(string p0)
        {
            _browser.SetSearchCriteria(p0);
        }

        [When(@"when I search")]
        public void WhenIClick()
        {
            _browser.ClickSearchButton();
        }

        [Then(@"the browser should contain text ""(.*)""")]
        public void ThenTheBrowserShouldContainText(string resultText)
        {
            _browser.HasText(resultText).Should().BeTrue();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            if (_browser != null)
                _browser.CloseBrowser();
        }

        [Given(@"I have an array with values ""(.*)""")]
        public void GivenIHaveAnArrayWithValues(string numberString)
        {
            _array = ArrayConverter.StringToIntList(numberString);
        }

        [When(@"I sort the array in descending order")]
        public void WhenIWantToSortThemInDescendingOrder()
        {
            _array = SortData.SortArrayDescending(_array);
        }

        [When(@"I sort the array in ascending order")]
        public void WhenIWantToSortThemInAscendingOrder()
        {
            _array = SortData.SortArrayAscending(_array);
        }


        [Then(@"the array returned is ""(.*)""")]
        public void ThenTheArrayReturnedShouldBe(string numberString)
        {
            _array.ShouldBeEquivalentTo(ArrayConverter.StringToIntList(numberString));
        }

        [Given(@"I have a list of top rated videos from YouTube")]
        public void GivenIHaveAListOfTopRatedVideosFromYouTube()
        {
            _topRatedVideosList = YouTubeWebService.YouTubeTopRatedVideosList();
        }

        [Then(@"""(.*)"" is in the list")]
        public void ThenIsInTheList(string video)
        {
            _topRatedVideosList.Contains(video).Should().BeTrue();
        }

        [Given(@"I have searched for ""(.*)"" on amazon")]
        public void GivenIHaveSearchedForOnAmazon(string product)
        {
            _browser =  new BrowserHelper();
            _browser.OpenBrowser("http://www.amazon.co.uk/");
            _browser.SearchFor(product);
            _browser.Go();
        }

        [When(@"I add the console to my shopping basket")]
        public void WhenIAddTheConsoleToMyShoppingBasket()
        {
            _browser.GoToProductPage();
            _browser.AddProductToBasket();
        }

        [Then(@"the console is added to the basket")]
        public void ThenTheConsoleIsAddedToTheBasket()
        {
            _browser.AddedToBasketMessage().Should().Be("1 item was added to your basket");
        }

    }
}