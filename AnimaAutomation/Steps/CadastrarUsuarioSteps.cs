using AnimaAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AnimaAutomation.Features.CriarUsuario
{
    [Binding, Scope(Tag = "@CadastrarUsuario")]
    public class CadastrarUsuarioSteps
    {
        readonly Browser _browser = new Browser();
        IWebDriver browser = null;
        CadastrarUsuario cadastro = new CadastrarUsuario();

        [BeforeScenario]
        public void IniciarNavegador()
        {
            browser = _browser.CreateDriver();
            cadastro.SetDriver(browser);
        }

        [AfterScenario]
        public void EncerrarNavegador()
        {
            this.browser.Close();
            this.browser.Dispose();
        }

        [Given(@"que eu acesse a página de treinamentos")]
        public void DadoQueEuAcesseAPaginaDeTreinamentos()
        {
            cadastro.acessaPaginaTreinamento();
        }
        
        [Given(@"que eu clique no botão Funcionalidade")]
        public void DadoQueEuCliqueNoBotaoFuncionalidade()
        {
            cadastro.clicarFuncionalidade();
        }

        [Given(@"no botão Criar Usuários")]
        public void DadoNoBotaoCriarUsuarios()
        {
            cadastro.clicarCriarUsuario();
        }

        [When(@"eu preencher os campos (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void QuandoEuPreencherOsCampospreenchendoCampos(string nome, string ultimo, string email, string endereco,
                                        string universidade, string profissao, string genero, short idade)
        {
            cadastro.preenchendoCampos(nome, ultimo, email, endereco, universidade, profissao, genero, idade);
        }


        [When(@"clique no botão enviar")]
        public void QuandoCliqueNoBotaoEnviar()
        {
            cadastro.enviarDados();
        }
        
        [Then(@"deverá ser apresentada tela para preenchimento de dados")]
        public void EntaoDeveraSerApresentadaTelaParaPreenchimentoDeDados()
        {
           cadastro.validaPaginaNovoUsuario();
        }
        
        [Then(@"usuário deverá ser criado com sucesso")]
        public void EntaoUsuarioDeveraSerCriadoComSucesso()
        {
            cadastro.validaMsgSucesso();
        }

        [When(@"o usuario não preencher um campo obrigatorio (.*), (.*), (.*)")]
        public void QuandoOUsuarioNaoPreencherUmCampoObrigatorio(string nome, string ultimo, string email)
        {
            cadastro.validarCampoObrigatorio(nome, ultimo, email);
        }

        [Then(@"deverá ser apresentada uma mensagem de erro")]
        public void EntaoDeveraSerApresentadaUmaMensagemDeErro()
        {
            cadastro.mensagemObrigatoriedade();
        }

        [When(@"o usuario clicar no botão voltar")]
        public void QuandoOUsuarioClicarNoBotaoVoltar()
        {
            cadastro.clicarVoltar();
        }

        [Then(@"ele deverá ser redirecionado para a página anterior")]
        public void EntaoEleDeveraSerRedirecionadoParaAPaginaAnterior()
        {
           cadastro.paginaAnterior();
        }

    }
}
