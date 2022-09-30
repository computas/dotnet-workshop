using BuberBreakfast.Models;
using BuberBreakfast.Repositories;
using BuberBreakfast.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Dependency injection
    builder.Services.AddTransient<IBreakfastService, BreakfastService>(); // Hva skjer hvis denne er transient?
    builder.Services.AddSingleton<IBreakfastRepository>(_ =>
        new BreakfastRepository(new Dictionary<Guid, Breakfast>())
    );
    // TODO Legg til BreakfastRepository. Hvilke scope kan man bruke?
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}