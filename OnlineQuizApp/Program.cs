using MongoDB.Driver;
using OnlineQuizApp.DBContext;
using OnlineQuizApp.Helper.Custom_Mapper;
using OnlineQuizApp.Repository.Implementation;
using OnlineQuizApp.Repository.Interfaces;
using OnlineQuizApp.Services.Implementation;
using OnlineQuizApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json")
    .Build();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQuizService,QuizService>();
builder.Services.AddScoped<IQuizRepository,QuizRepository>();
builder.Services.AddSingleton<QuestionMapper>();

// ✅ Register MongoClient first
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = configuration.GetValue<string>("MongoDBSettings:ConnectionString");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<QuizDBContext>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var databaseName = configuration.GetValue<string>("MongoDBSettings:DatabaseName");
    return new QuizDBContext(client, databaseName!);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
