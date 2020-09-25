using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AnimaAutomation
{
    class Browser
    {
        public IWebDriver CreateDriver()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            var driver = new ChromeDriver(driverService, options, new TimeSpan(0, 0, 240));
            return driver;
        }
    }
}
