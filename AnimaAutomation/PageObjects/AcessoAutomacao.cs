using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechTalk.SpecFlow.Configuration.JsonConfig;

namespace AnimaAutomation.PageObjects
{
    class AcessoAutomacao
    {
        private IWebDriver driver;
        public string url = "https://automacaocombatista.herokuapp.com/home/index";


        public void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver GetDriver()
        {
            return this.driver;
        }

        public void AcessoHome()
        {
            try
            {
                IWebDriver driver = GetDriver();
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
            }

            catch (ArgumentNullException)
            {
                AcessoHome();
            }

        }

        public void clicarComecarAutomacao()
        {
            var btnComecarAutomacao = driver.FindElement(By.CssSelector("#index-banner .btn"));
            btnComecarAutomacao.Click();
        }

        public void validaPaginaTreinamentos()
        {
            var url = driver.Url;
            Assert.AreEqual(url, "https://automacaocombatista.herokuapp.com/treinamento/home");
        }
    }
}
