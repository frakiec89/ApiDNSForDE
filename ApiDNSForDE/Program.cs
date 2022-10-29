var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.UseUrls(new string[] { "http://192.168.10.160:81" });
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
