using UserManagementAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 1. Error-handling middleware first
app.UseMiddleware<ErrorHandlerMiddleware>();

// 2. Authentication middleware next
app.UseMiddleware<AuthenticationMiddleware>();

// 3. Logging middleware last
app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();