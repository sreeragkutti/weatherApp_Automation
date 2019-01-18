Feature: GetWeatherPage
	Check the Get Weather functionality in WeatherApp

@mytag
Scenario: Get weather with valid inputs
	Given I have launched the WeatherApp
	And I have entered the country "UK"
	And I have entered the city "London"
	When I press getWeather
	Then It must show the message "Weather Details"
