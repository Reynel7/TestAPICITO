Feature: Get posts

A short summary of the feature

@positive @smoke @regression @integration @JIRA-7777 
Scenario: Get by id 
	Given I have an id with value 17
	When I send a get request
	Then I expected a valid code response



