using api.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddQueryType<Query>().AddMutationType<Mutation>();

builder.Services.AddDbContext<BookDbContext>(options =>
{
    options.UseMongoDB("mongodb://localhost:27017/", "sample_books");
});

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapGraphQL();

app.Run();
