Feature: ChatBot Feature

//Feature file allows me to write tests , reusing existing code. Helps stakeholders understand the tests better. 
//each step is an instruction that simulates user experience
//then is always an assertion
@mytag
Scenario: I can progress through each page.
	Given I enter 'Europe' in the select continent page
	When I click submit
	And I enter 'active' in the select catergory page
	When I click submit
	And I enter 'sea' in the select location page
	When I click submit
	And I enter 'mild' in the select Temperature Rating page
	When I click submit
	Then I should be taken to the 'Filtered Results' page

Scenario: When I input an invalid continent I am brought to an Invalid option page 
	Given I enter 'PlanetVenus' in the select continent page
	When I click submit
	Then I should be taken to the 'Invalid Continent' page

	Scenario: When I input an invalid category I am brought to an Invalid page 
	Given I enter 'Europe' in the select continent page
	When I click submit
	And I enter 'dangerous' in the select catergory page
	When I click submit
	Then I should be taken to the 'Invalid Category' page

	Scenario: When I input an invalid location I am brought to an Invalid page 
	Given I enter 'Europe' in the select continent page
	When I click submit
	And I enter 'active' in the select catergory page
	When I click submit
	And I enter 'snow' in the select location page
	Then I should be taken to the 'Invalid Location' page

	Scenario: When I input an invalid temperature rating i am brought to an invalid page
	Given I enter 'Europe' in the select continent page
	When I click submit
	And I enter 'active' in the select catergory page
	When I click submit
	And I enter 'sea' in the select location page
	When I click submit
	And I enter 'sasahajs' in the select Temperature Rating page
	When I click submit
	Then I should be taken to the 'Invalid Temperature Rating' page