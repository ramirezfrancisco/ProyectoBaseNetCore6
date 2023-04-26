using CoreServicesApp.Services;
using CoreServicesApp.Utils;
using DataAccess.DBContext;
using ExternalServiceApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ChicoteIoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionChicote"));
});


builder.Services.AddScoped<CotizacionServices>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<LogUtils>();
builder.Services.AddHostedService<QueuedHostedService>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
        queueCapacity = 100;
    return new BackgroundTaskQueue(queueCapacity);
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
