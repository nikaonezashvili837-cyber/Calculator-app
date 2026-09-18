var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run(async (HttpContext context) =>
{
    
    string? firstNumber = context.Request.Query["firstNumber"];
    string? secondNumber = context.Request.Query["secondNumber"];
    string? operation = context.Request.Query["operation"];
    switch
    await context.Response.WriteAsync($"<p></p>");
});
app.Run();