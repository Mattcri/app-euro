using backend_api.Context;
using backend_api.Interfaces;
using backend_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Config CORS
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowSpecificOrigins", 
        builder => builder.WithOrigins("http://127.0.0.1:5173", "http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

// Connection to DB
builder.Services.AddSqlServer<dbEuroContext>(builder.Configuration.GetConnectionString("cnDbEuro"));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register my services
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS politic config
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
