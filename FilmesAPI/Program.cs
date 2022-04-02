using FilmesAPI;
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string FilmeConnection = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContextPool<FilmeContext>(options =>
                options.UseMySql(FilmeConnection,
                      ServerVersion.AutoDetect(FilmeConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 

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

app.UseAuthorization();

app.MapControllers();

app.Run();
