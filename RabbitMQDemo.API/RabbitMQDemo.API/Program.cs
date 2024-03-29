using RabbitMQDemo.API.Helpers.MongoDB;
using RabbitMQDemo.API.Producer;
using RabbitMQDemo.API.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMongoDBHelper, MongoDBHelper>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
