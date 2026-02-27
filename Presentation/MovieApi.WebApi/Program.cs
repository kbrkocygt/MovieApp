
using System.Reflection;
using Microsoft.OpenApi;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>();
// Add services to the container.
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();




builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();


//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
});
// builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
    });

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


