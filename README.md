# FileDownloadBot

Um robô em C# com Selenium que automatiza o download de arquivos de teste da internet. Ele acessa o Google, entra no site Test Files (https://fsn1-speed.hetzner.com), baixa arquivos via clique e requisição HTTP, e organiza tudo direitinho em pastas no seu computador. O projeto também inclui testes automatizados.

## O que ele faz

1. Acessa o site https://fsn1-speed.hetzner.com  
2. Baixa os arquivos:  
   - 100MB.bin  
   - 1GB.bin  
   - 10GB.bin  
3. Faz download via clique (Selenium)  
4. Inclui testes unitários com xUnit  

## Tecnologias

- .NET 8  
- Selenium WebDriver  
- xUnit  
- C# (POO)  
- ChromeDriver  

## Como usar

1. Clone o repositório:  
```
git clone https://github.com/seu-usuario/FileDownloadBot.git
```

2. Restaure as dependências e compile o projeto:  
```
dotnet restore
dotnet build
```

3. Rode o projeto:  
```
dotnet run --project FileDownloadBot
```

4. Para executar os testes:  
```
dotnet test
```

## Testes

O projeto conta com testes para validar:  
- Criação de pastas  
- Sucesso no download via requisição HTTP  
- Presença dos arquivos baixados  
- Organização correta dos arquivos no disco  

## Melhorias futuras

- Adicionar logs com ILogger  
- Painel de status dos downloads  

---

## Sobre mim

Luana Moreira  
Estudante de Desenvolvimento de Software e estagiária em .NET
