Feature: Varzesh3

A short summary of the feature

@tag1
Scenario: Search for "تیم ملی ایران"
	Given the API endpoint is "https://www.varzesh3.com/search"
	When I search for "تیم ملی ایران"
    Then the response should contain "تیم ملی ایران"
    And the status code should be 200
