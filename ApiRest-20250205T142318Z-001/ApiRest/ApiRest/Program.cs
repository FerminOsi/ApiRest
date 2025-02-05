var builder = WebApplication.CreateBuilder(args);

// Habilitar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Usar controladores en la API
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
