# broker

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

<p align="center">Projeto para monitoramento de preço de ações do Ibovespa, permitindo configurar alertas de preço para receber por email.</p>

### Features

- [X] Envio de email
- [X] Cadastro de alertas
- [X] Comunicação com Yahoo Finance
- [X] Job para envio de alertas
- [ ] Job para sincronização de ações listadas na bolsa
- [ ] Gráfico para monitoramento de cotações
- [ ] Exibir ordens nos gráficos

### Como executar
1. Adicione nas váriaves de ambiente ou no appsettings.json as seguintes variáveis:
	- ConnectionStrings:DefaultConnection | String de conexão com a database
	- SmtpSettings:login | Login do Usuário SMTP(também será o sender do email)
	- SmtpSettings:password | Senha do Usuário SMTP
	- YahooFinanceSettings:X-RapidAPI-Key | Chave o RapidAPI para comunicação com a API do yahoofinance
2. Rode pelo package manager console os comandos
	- enable-migrations
	- update-database
3. Inicie a aplicação com
	- dotnet restore
	- dotnet run
