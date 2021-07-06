# DPCTeste
Projeto de teste para Seleção DPC

Desenvolva o projeto abaixo, escolhendo um dos desafios, de acordo com seu nível de
conhecimento. Observe que o avanço de nível sempre inclui o requisito do nível anterior.

Após finalizar o desafio, enviaminhar via e-mail o endereço da solução em algum repositório
GIT.

Iniciante: Criar um CRUD de clientes com nome, endereço, telefone, data de nascimento e
status de ativo, utilizando um banco de dados relacional + deve ser possível inativar e ativar
um cliente;

Intermediário: Requisitos fase iniciante + adicionar ao CRUD uma lista de contatos por
cliente com Tipo (Celular, Trabalho, E-mail, etc...) e Descrição. Os clientes deverão ter ao
menos dois contatos de tipos diferentes para serem cadastrados. + Incluir testes unitários;

Avançado: Requisitos fase intermediário + CRUD de usuários com login, email e senha; +
login com mecanismo de autorização usando JWT e RBAC;

Expert: Requisitos fase avançado + pesquisa de clientes por nome e endereço somente
disponível para usuários com a role “ADMIN”.

*O projeto foi desenvolvido em .net core 3.5
*Usei SQLite como base de dados e EFCore com Migration
*FrontEnd utilizado o swagger
