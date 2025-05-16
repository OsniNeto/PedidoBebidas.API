using Microsoft.EntityFrameworkCore;
using PedidoBebidas.Aplicacao.Mappings;
using PedidoBebidas.Infraestrutura.Persistencia;
using PedidoBebidasAPI;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Database/banco.db"));

ServicesInject.Execute(builder.Services);
SwaggerConfig.Execute(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins([
            "https://127.0.0.1:3000",
            "http://127.0.0.1:3000",
            "http://localhost:3000",
            "https://localhost:3000"])
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Aplicação de migration automático apenas para facilitar a execução do projeto
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigins");
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-1);
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs para camada de negócio");
    c.DocExpansion(DocExpansion.None);
});

app.MapControllers();

app.Run();