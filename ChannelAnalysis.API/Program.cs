using ChannelAnalysis.API.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChannelAnalysisDbContext>(
    options => options.UseNpgsql(builder.Configuration["ConnectionStrings:ChannelAnalysisConnection"]));
builder.Services.AddMvc().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((origin) => true).AllowCredentials());

app.UseAuthorization();

app.MapControllers();

var context = app.Services.CreateScope().ServiceProvider
	.GetRequiredService<ChannelAnalysisDbContext>();

if (context.Database.GetPendingMigrations().Any())
{
	context.Database.Migrate();
}
			
app.Run();
