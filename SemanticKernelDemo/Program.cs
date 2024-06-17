var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var builder = Kernel.CreateBuilder();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.ConfigureHttpClientDefaults(_ =>
{
    _.RedactLoggedHeaders(["Authorization"]);
});
builder.Services.AddDbContextFactory<AdventureWorksDbContext>(o =>
{
    o.UseSqlServer(configuration["CHATBOT_CONNECTIONSTRING"]);
});
builder.Services.AddLogging(_ => _.AddConsole().SetMinimumLevel(LogLevel.Trace));
builder.Services.AddScoped<ProductService>();
builder.Services.AddRedaction();

var kernel = builder
    .AddOpenAIChatCompletion("gpt-4o", configuration["OPENAI_API_KEY"]!)
    .Build();
kernel.ImportPluginFromType<Test>();
kernel.ImportPluginFromType<ProductService>();

#pragma warning disable SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
kernel.ImportPluginFromObject(new WebSearchEnginePlugin(new BingConnector(configuration["BING_API_KEY"]!)));
#pragma warning restore SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

var settings = new OpenAIPromptExecutionSettings()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

var chatService = kernel.GetRequiredService<IChatCompletionService>();
var chat = new ChatHistory("You are a friendly AI assistant");
while (true)
{
    Console.Write("You: ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }
    chat.AddUserMessage(input);
    var response = await chatService.GetChatMessageContentAsync(chat, settings, kernel);
    Console.WriteLine($"Bot: {response}");
}

public class Test
{
    [KernelFunction]
    public int GetPersonAge(string blergh) =>
        blergh.ToLower() switch
        {
            "daniel" => 30,
            "maria" => 25,
            _ => 3
        };

    [KernelFunction]
    public int GetDanielAge(string blergh) =>
    blergh.ToLower() switch
    {
        "daniel" => 25,
        "maria" => 25,
        _ => 3
    };

    [KernelFunction]
    public async Task<Movie> GetMovieAsync([FromKernelServices] IHttpClientFactory httpClientFactory,
        [FromKernelServices] IConfiguration configuration, string title, int? year)
    {
        using var client = httpClientFactory.CreateClient();
        var apiKey = configuration["MOVIEDB_API_KEY"];
        var url = $"http://www.omdbapi.com/?apikey={apiKey}&t={title}{(year.HasValue ? $"&y={year}" : "")}";
        var response = await client.GetFromJsonAsync<Movie>(url);
        return response ?? new();

    }
}