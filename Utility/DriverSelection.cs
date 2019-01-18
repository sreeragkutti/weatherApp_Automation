using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppAutomation.Utility
{
    public class DriverSelection
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    BrowserTypes _browserTypes;
                    Enum.TryParse(ConfigurationManager.AppSettings[AutomationConstatants.Browser], out _browserTypes);

                    switch (_browserTypes)
                    {
                        case BrowserTypes.Chrome:
                            _driver = new ChromeDriver();
                            break;
                        case BrowserTypes.Firfox:
                            _driver = new FirefoxDriver();
                            break;
                        default:
                            _driver = new ChromeDriver();
                            break;
                    }
                }

                return _driver;
            }
        }

    }
    enum BrowserTypes
    {
        Chrome,
        Firfox
    }
}
