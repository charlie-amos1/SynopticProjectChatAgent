Feature: ChatBot Feature


@mytag
Scenario: Enter continent and progress through the next page
	Given I enter 'Europe' in the select continent page
	When I click submit
	And I enter 'active' in the select catergory page
	When I click submit
	And I enter 'sea' in the select location page
	When I click submit
	And I enter 'mild' in the select Temperature Rating page
	When I click submit
	Then I should be taken to the 'Filtered Results' page