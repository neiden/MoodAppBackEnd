using DataAccess;
using Services;
using Serilog;



Log.Logger = new LoggerConfiguration().WriteTo.File("../logs.txt").CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepo, DBRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<PlaylistService>();
builder.Services.AddScoped<MoodService>();
builder.Services.AddScoped<FriendService>();

builder.Services.AddControllersWithViews();



var app = builder.Build();

Log.Information("Starting Mood API");

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
