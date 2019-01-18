using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WeatherAppAutomation.PageModels.GetWeatherPage;
using WeatherAppAutomation.Utility;

namespace WeatherAppAutomation.Features.GetWeatherPage
{
    [Binding]
    public sealed class GetWeatherSteps
    {
        private WeatherModels _weatherPageModel;
        [Given(@"I have launched the WeatherApp")]
        public void GivenIHaveLaunchedTheWeatherApp()
        {
            _weatherPageModel = WeatherModels.NavigateToWeatherPage();
        }

        [Given(@"I have entered the country ""(.*)""")]
        public void GivenIHaveEnteredTheCountry(string country)
        {
            _weatherPageModel.TypeCountryName(country);
        }

        [Given(@"I have entered the city ""(.*)""")]
        public void GivenIHaveEnteredTheCity(string city)
        {
            _weatherPageModel.TypeCityName(city);
        }

        [When(@"I press getWeather")]
        public void WhenIPressGetWeather()
        {
            _weatherPageModel.ClickGetWeather();
        }

        [Then(@"It must show the message ""(.*)""")]
        public void ThenItMustShowTheMessage(string weatherMsg)
        {
          var actualMsg = _weatherPageModel.GetWeatherMsg();
            var expectedMsg = ConfigurationManager.AppSettings[AutomationConstatants.FinalMessage];
            Assert.AreEqual(actualMsg, expectedMsg);
            
        }

    }
}
