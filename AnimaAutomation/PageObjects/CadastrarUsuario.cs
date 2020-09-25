using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using OpenQA.Selenium.Interactions;

namespace AnimaAutomation.PageObjects
{
    class CadastrarUsuario
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

        public void acessaPaginaTreinamento()
        {
            AcessoHome();
            clicarComecarAutomacao();
        }

        public void clicarFuncionalidade()
        {
            var btnFuncionalidade = driver.FindElement(By.LinkText("Formulário"));
            btnFuncionalidade.Click();
        }
        public void clicarCriarUsuario()
        {
            var btnCriarUsuario = driver.FindElement(By.LinkText("Criar Usuários"));
            btnCriarUsuario.Click();
        }

        public void validaPaginaNovoUsuario()
        {
            var url = driver.Url;
            Assert.AreEqual(url, "https://automacaocombatista.herokuapp.com/users/new");
        }

        public void preenchendoCampos(string nome, string ultimo, string email, string endereco,
                                        string universidade, string profissao, string genero, short idade)
        {
            //nome
            var campoNome = driver.FindElement(By.Id("user_name"));
            campoNome.SendKeys(nome);

            //ultimo
            var campoUltimo = driver.FindElement(By.Id("user_lastname"));
            campoUltimo.SendKeys(ultimo);

            //email
            var campoEmail = driver.FindElement(By.Id("user_email"));
            campoEmail.SendKeys(email);

            //endereco
            var campoEndereco = driver.FindElement(By.Id("user_address"));
            campoEndereco.SendKeys(endereco);

            //universidade
            var campoUniversidade = driver.FindElement(By.Id("user_university"));
            campoUniversidade.SendKeys(universidade);

            //profissao
            var campoProfissao = driver.FindElement(By.Id("user_profile"));
            campoProfissao.SendKeys(profissao);

            //genero
            var campoGenero = driver.FindElement(By.Id("user_gender"));
            campoGenero.SendKeys(genero);

            //idade
            var campoIdade = driver.FindElement(By.Id("user_age"));
            campoIdade.SendKeys(idade.ToString());
        }

        public void enviarDados()
        {
            var btnCriar = driver.FindElement(By.Name("commit"));
            btnCriar.Click();
        }

        public void validaMsgSucesso()
        {
            var id = "notice";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public void validarCampoObrigatorio(string nome, string ultimo, string email)
        {   //nome
            var campoNome = driver.FindElement(By.Id("user_name"));
            campoNome.SendKeys(nome);

            //ultimo
            var campoUltimo = driver.FindElement(By.Id("user_lastname"));
            campoUltimo.SendKeys(ultimo);

            //email
            var campoEmail = driver.FindElement(By.Id("user_email"));
            campoEmail.SendKeys(email);

            enviarDados();

        }

        public void mensagemObrigatoriedade()
        {
            //nome
            if (driver.FindElement(By.Id("user_name")) == null)
            {
                var msgErro = driver.FindElement(By.Id("error_explanation")).Text;
                Assert.AreEqual(msgErro, "error proibiu que este usuário fosse salvo:");
            }
        }

        public void clicarVoltar()
        {
            var xpath = "/html/body/div[2]/div[2]/div[3]/div[2]/form/div[5]/div/a";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(xpath))).Click().Perform();
            //btnVoltar.Click();
        }

        public void paginaAnterior()
        {
            var url = driver.Url;
            Assert.AreEqual(url, "https://automacaocombatista.herokuapp.com/treinamento/home");
        }
    }
}
