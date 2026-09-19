var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    if (path == "/" && context.Request.Query.Count > 0)

    {
        try
        {
            int firstNumber;
            int secondNumber;
            Int32.TryParse(context.Request.Query["firstNumber"],out firstNumber);
            Int32.TryParse(context.Request.Query["secondNumber"],out secondNumber);
            string? operation = context.Request.Query["operation"];
            string result;
            switch (operation)
            {
                case "add":
                    result = $"{firstNumber + secondNumber}";
                    break;
                case "subtract":
                    result = $"{firstNumber - secondNumber}";
                    break;
                case "multiply":
                    result = $"{firstNumber * secondNumber}";
                    break;
                case "divide":
                    result = $"{((decimal)firstNumber / secondNumber)}";
                    break;
                default:
                    context.Response.StatusCode = 400;
                    result = "Invalid input for 'operation";
                    break;
            }
            await context.Response.WriteAsync($"<p>{result}<p>");
        }
        catch
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("<h1>Error</h1>");
        }
        ;

    }
    else if (path == "/")
    {
        await context.Response.WriteAsync("<h1>Welcome to calculator app</h1>");
    }
});
app.Run();