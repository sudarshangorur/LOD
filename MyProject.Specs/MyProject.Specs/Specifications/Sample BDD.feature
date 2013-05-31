Feature: SpecFlow patterns and anti-patterns
	As a QA
	I want to understand good practices using BDD tools
	So that I use the tools as intended

Scenario: Add two numbers
	Given I have entered 40 as the first number into the calculator
	And I have entered 70 as the second number into the calculator
	When I press add
	Then the result should be 110 on the screen
	And the result should be greater than 50 and 70

Scenario: Test that a given array is sorted in descending order
	Given I have an array with values "8,876,90,5,-3"
	When I sort the array in descending order
	Then the array returned is "876,90,8,5,-3"

Scenario: Test that a given array is sorted in ascending order
	Given I have an array with values "7,89,32,-67"
	When I sort the array in ascending order
	Then the array returned is "-67,7,32,89"

Scenario: Test if rolling in the deep is in the list of top rated videos
	Given I have a list of top rated videos from YouTube
	Then "Adele - Rolling In The Deep" is in the list

Scenario: Search for WatiN on google
	Given I am on google search page
	When I enter "WatiN" in Search box
	And when I search
	Then the browser should contain text "WatiN"

Scenario: Add xbox-one to basket for later purchase
	Given I have searched for "xbox one" on amazon
	When I add the console to my shopping basket
	Then the console is added to the basket





