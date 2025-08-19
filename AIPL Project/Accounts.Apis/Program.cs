using AccountApi.Application.Interfaces;
using AccountApi.Infrastructure.Repository;
using AccountApi.Logging;
using Accounts.Apis;
using Accounts.Models.UIModels;
using AutoMapper;
using log4net;
using log4net.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Configure log4net
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new MappingProfile());
});

var mapper = mapperConfiguration.CreateMapper();

//services.AddSingleton(mapper);
builder.Services.AddSingleton(mapper);
// Add the IUnitOfWork as a scoped service
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); // Replace YourUnitOfWorkImplementation with the actual implementation class

builder.Services.AddScoped<IRopeConstantsRepository, RopeConstantsRepository>();
builder.Services.AddScoped<IChainConstantsRepository, ChainConstantsRepository>();
builder.Services.AddScoped<IFloatCategoryRepository, FloatCategoryRepository>();
builder.Services.AddScoped<IFloatSelectionRepository, FloatSelectionRepository>();
builder.Services.AddScoped<ILoadDatasRepository, LoadDatasRepository>();
builder.Services.AddScoped<IOutputDetailsRepository, OutputDetailsRepository>();
builder.Services.AddScoped<IInputsandLayoutRepository, InputsandLayoutRepository>();
builder.Services.AddScoped<IProjectDetailsRepository, ProjectDetailsRepository>();
builder.Services.AddScoped<IParametersRepository, ParametersRepository>();
//services.AddScoped<ICommissionAgentPercentageRepository, CommissionAgentPercentageRepository>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    Logger.Instance.Error($"Request: {context.Request.Path}");
    await next.Invoke();
});


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//public class Startup
//{
//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public IConfiguration Configuration { get; }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        var mapperConfiguration = new MapperConfiguration(configuration =>
//        {
//            configuration.AddProfile(new MappingProfile());
//        });

//        var mapper = mapperConfiguration.CreateMapper();

//        services.AddSingleton(mapper);
//    }
//}