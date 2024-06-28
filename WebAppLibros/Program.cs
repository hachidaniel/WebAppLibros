using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebAppLibros.Core.Interfaces;
using WebAppLibros.Core.Interfaces.Repositories;
using WebAppLibros.Core.Interfaces.Services;
using WebAppLibros.Infrastructure.Data;
using WebAppLibros.Infrastructure.Repositories;
using WebAppLibros.Services;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(ILibrosRepository), typeof(LibrosRepository));

builder.Services.AddScoped(typeof(ILibrosService), typeof(LibrosService));

//Crear la variable para conexion a la base de datos 
//var connectionString = builder.Configuration.GetConnectionString("Connection");
var connectionString = "Data Source=:memory:";

var keepAliveConnection = new SqliteConnection(connectionString);
SQLitePCL.raw.SetProvider(new SQLite3Provider_e_sqlite3());
keepAliveConnection.Open();

//Registar servicios par la conexion
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(keepAliveConnection)
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://example.com",
                          //                    "http://www.contoso.com",
                          //                    "http://localhost:3000/")
                          // .AllowAnyHeader()
                          // .AllowAnyMethod();
                          policy.SetIsOriginAllowed(origen => new Uri(origen).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                      });
});
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
