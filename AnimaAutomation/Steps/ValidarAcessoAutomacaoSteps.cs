using AnimaAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AnimaAutomation.Features.Home
{
    [Binding, Scope(Tag ="@AcessoAoSite")]
    public class ValidarAcessoAutomacaoSteps
    {
        readonly Browser _browser = new Browser();
        IWebDriver browser = null;
        AcessoAutomacao acesso = new AcessoAutomacao();

        [BeforeScenario]
        public void IniciarNavegador()
        {
            browser = _browser.CreateDriver();
            acesso.SetDriver(browser);
        }

        [AfterScenario]
        public void EncerrarNavegador()
        {
            this.browser.Close();
            this.browser.Dispose();
        }

        [Given(@"que eu acesse o link do site ""(.*)""")]
        public void DadoQueEuAcesseOLinkDoSite(string p0)
        {
            acesso.AcessoHome();
        }
        
        [When(@"eu clicar no botão ""(.*)""")]
        public void QuandoEuClicarNoBotao(string p0)
        {
            acesso.clicarComecarAutomacao();
        }
        
        [Then(@"deverá ser apresentada a página de treinamentos")]
        public void EntaoDeveraSerApresentadaAPaginaDeTreinamentos()
        {
            acesso.validaPaginaTreinamentos();
        }


    }
}
