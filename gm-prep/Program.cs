using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookDbContext>(options =>
{
    var conString = Env.GetString("ConnectionString");
    var dbName = Env.GetString("Database_name");

    Console.WriteLine($"Connection string is: {conString}");
    Console.WriteLine($"Database name is: {dbName}");

    options.UseMongoDB("mongodb://localhost:27017/", "sample_books");
});

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
