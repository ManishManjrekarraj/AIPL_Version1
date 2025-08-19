using AccountApi.Application.Interfaces;
using AccountApi.Infrastructure.Repository;
//using Accounts.Apis;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Radzen;
using System.Globalization;

namespace AccountsUIBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services needed for your application
            services.AddServerSideBlazor().AddCircuitOptions(e => {
                e.DetailedErrors = true;
            });

            // Add the IUnitOfWork as a scoped service
            services.AddTransient<IUnitOfWork, UnitOfWork>(); // Replace YourUnitOfWorkImplementation with the actual implementation class
            
            services.AddScoped<IRopeConstantsRepository, RopeConstantsRepository>();
            services.AddScoped<IChainConstantsRepository, ChainConstantsRepository>();
            services.AddScoped<IFloatCategoryRepository, FloatCategoryRepository>();
            services.AddScoped<IFloatSelectionRepository, FloatSelectionRepository>();
            services.AddScoped<IOutputDetailsRepository, OutputDetailsRepository>();
            services.AddScoped<ILoadDatasRepository, LoadDatasRepository>();
            services.AddScoped<IInputsandLayoutRepository, InputsandLayoutRepository>();
            services.AddScoped<IProjectDetailsRepository, ProjectDetailsRepository>();
           
            services.AddScoped<IParametersRepository, ParametersRepository>();
            //services.AddScoped<ICommissionAgentPercentageRepository, CommissionAgentPercentageRepository>();

           
            services.AddScoped<DialogService>();
            // Add other services as needed
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IProductRepository, ProductRepository>();

            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSwagger",
                    builder => builder.WithOrigins("http://localhost:7207") // Update with your Blazor app URL
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());

                //options.AddPolicy("AllowSwagger",
                //   builder => builder.WithOrigins("http://192.168.1.192") // Update with your Blazor app URL
                //                     .AllowAnyHeader()
                //                     .AllowAnyMethod());


            });

            //var mapperConfiguration = new MapperConfiguration(configuration =>
            //{
            //    configuration.AddProfile(new MappingProfile());
            //});

            //var mapper = mapperConfiguration.CreateMapper();

            //services.AddSingleton(mapper);


            // Add MVC or API controllers
            services.AddControllers();
            //services.AddHttpClient();
            services.AddScoped(sp =>
            {
                var client = new HttpClient();               
                client.BaseAddress = new Uri(Configuration["Services:AccountApi"]);
                return client;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1"));
            }
            else
            {
                // Add production-specific configuration
                // For example, app.UseExceptionHandler("/Home/Error");
                // app.UseHsts();
            }

            // Configure other middleware as needed
            app.UseCors("AllowSwagger");
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Add endpoint mapping for controllers
            });
        }
    }
}
