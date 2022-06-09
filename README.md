# broker

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

<p align="center">Projeto para monitoramento de pre�o de a��es do Ibovespa, permitindo configurar alertas de pre�o para receber por email.</p>

### Features

- [X] Envio de email
- [X] Cadastro de alertas
- [X] Comunica��o com Yahoo Finance
- [X] Job para envio de alertas
- [ ] Job para sincroniza��o de a��es listadas na bolsa
- [ ] Gr�fico para monitoramento de cota��es
- [ ] Exibir ordens nos gr�ficos

### Como executar
1. Adicione nas v�riaves de ambiente ou no appsettings.json as seguintes vari�veis:
	- ConnectionStrings:DefaultConnection | String de conex�o com a database
	- SmtpSettings:login | Login do Usu�rio SMTP(tamb�m ser� o sender do email)
	- SmtpSettings:password | Senha do Usu�rio SMTP
	- YahooFinanceSettings:X-RapidAPI-Key | Chave o RapidAPI para comunica��o com a API do yahoofinance
2. Rode pelo package manager console os comandos
	- enable-migrations
	- update-database
3. Inicie a aplica��o com
	- dotnet restore
	- dotnet run
