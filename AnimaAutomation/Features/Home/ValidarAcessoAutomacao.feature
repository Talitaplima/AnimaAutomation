#language: pt-BR

Funcionalidade: ValidarAcessoAutomacao
	Eu como aluno de Automação
	Gostaria de acessar o site Automação Com Batista
	Para colocar meus conhecimentos em prática

@AcessoAoSite
Cenario: Realizar acesso ao site
	Dado que eu acesse o link do site "Automação com Batista"
	Quando eu clicar no botão "Começar Automação Web"
	Então deverá ser apresentada a página de treinamentos