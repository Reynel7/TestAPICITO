Feature: Get All Products

A short summary of the feature

@positive @smoke @regression @integration
Scenario: Get by all products
	Given I send a get request for all products
	Then I expected a valid code response is correct



