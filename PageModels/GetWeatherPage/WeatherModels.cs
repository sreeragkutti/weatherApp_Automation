using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherAppAutomation.Utility;

namespace WeatherAppAutomation.PageModels.GetWeatherPage
{
    public class WeatherModels
    {
        private static IWebDriver _driver;

        [FindsBy(How= How.Id, Using= "countryName")]
        private readonly IWebElement _country;

        [FindsBy(How=How.Id, Using ="cityName")]
        private readonly IWebElement _city;

        [FindsBy(How = How.Id, Using = "btnGetWeather")]
        private readonly IWebElement _getWeather;

        [FindsBy(How= How.Id, Using = "spWeatherDetails")]
        private readonly IWebElement _message;

        public WeatherModels(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        public static WeatherModels NavigateToWeatherPage()
        {
            _driver = DriverSelection.Driver;
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings[AutomationConstatants.WeatherAppUrl]);
            return new WeatherModels(_driver);

        }

        public void TypeCountryName (string country)
        {
            _country.SendKeys(country);
        }

        public void TypeCityName(string city)
        {
            _city.SendKeys(city);
        }

        public void ClickGetWeather()
        {
            _getWeather.Click();
        }

        public string GetWeatherMsg()
        {
            Thread.Sleep(5000);
            return _message.Text;
        }
    }
}
