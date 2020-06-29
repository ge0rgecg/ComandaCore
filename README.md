# ComandaCore


Projeto que realiza algumas das operação de uma comanda

Com esse projeto é possivel fazer lançamentos de produtos em uma comanda,
e fechamento da comanda, onde é calculado o valor a pagar, com os descontos realizados.

Para rodar o projeto, criar um banco com sql server e rodar o script que esta no caminho SQL/ScriptInicial.sql.
Alterar a conexão do banco no caminho API/appsettings.json/ na tag ConnectionStrings/DefaultConnection


O projeto foi separado em 3 camadas, API, Servicos e Repositorios.

A Camada de API é a que fica exposta, por onde serão iniciadas as requisições.

A Camada de serviços, é onde se encontram as logicas e regras de negócios

A Camada de Repositorio é a parte que faz a conexão com os bancos, com um repositorioBase, que ao ser herdado, já faz a comunicação CRUD nas tabelas, 
apenas sendo necessário implementar consultas diferentes do já herdado.

Os testes unitarios foram feitos para as camadas de servicos e api, para garantir que as regras funcionam como deveriam.

A pagina web foi feita de forma simples com Razor e MVC, fazendo as comunicações necessarios na API.


Pontos a melhorar -

Criar autenticação para permitir apenas requisições válidas.
