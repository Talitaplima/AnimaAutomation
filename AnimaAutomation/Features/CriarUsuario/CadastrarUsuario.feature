#language: pt-BR

@CadastrarUsuario
Funcionalidade: CadastrarUsuario
	Eu como estudante de Automação
	Gostaria de acessar o site Automação com Bastita
	Para realizar um cadastro de usuário automatizado

Contexto:
	Dado que eu acesse a página de treinamentos
	E que eu clique no botão Funcionalidade
	E no botão Criar Usuários
	Então deverá ser apresentada tela para preenchimento de dados

Esquema do Cenário: Criar usuário com sucesso
	Quando eu preencher os campos <Nome> , <ultimo>, <Email>, <Endereço>, <Universidade>, <Profissão>, <Gênero>, <Idade>
	E clique no botão enviar
	Então usuário deverá ser criado com sucesso

	Exemplos: 
	| Nome   | ultimo | Email                  | Endereço        | Universidade | Profissão   | Gênero | Idade |
	| Talita | Lima   | talitaplsp99@gmail.com | Rua Lorem Ipsum | USP          | Analista QA | Fem    | 22    |
	
Esquema do Cenario: Validar obrigatoriedade de campo
	Quando o usuario não preencher um campo obrigatorio <Nome> , <ultimo>, <Email>
	Entao deverá ser apresentada uma mensagem de erro

	Exemplos: 
	| Nome | ultimo | email |
	|      |        |       |

Cenario: Validar voltar página anterior
	Quando o usuario clicar no botão voltar
	Então ele deverá ser redirecionado para a página anterior