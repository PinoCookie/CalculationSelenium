using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace CalculatorSelenium.Specs.Drivers
{
    public class BrowserDriver: IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
            var firefoxOptions = new FirefoxOptions();
            var firefoxDriver = new FirefoxDriver(firefoxDriverService, firefoxOptions){Url = "http://localhost:58909"};

            return firefoxDriver;
        }
        
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;

        }
    }
}