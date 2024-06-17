# Semantid Kernel demo

This is a small demo using [Microsoft Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/?tabs=Csharp) to connect your application to a Large Language Model like [OpenAI](https://platform.openai.com/docs/overview)

To get started you need an API key from OpenAI, you can get one [here](https://platform.openai.com/signup)

If you want to use the Bing api you will need to get an API key from [Azure](https://azure.microsoft.com/en-us/services/cognitive-services/bing-web-search-api/)

For the OMDB api you can get an API key [here](http://www.omdbapi.com/apikey.aspx)

The Adventure works DSL uses a connection string to a SQL Server database, you can download the database [here](https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms)

You will also need to add a usersecrets file like this:
```
{
  "OPENAI_API_KEY": "",
  "MOVIEDB_API_KEY": "",
  "CHATBOT_CONNECTIONSTRING": "",
  "BING_API_KEY": ""
}
```
Then add this key in the SemanticKernelDemo.csproj file
```
<UserSecretsId></UserSecretsId>
```