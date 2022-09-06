using Anwendung;
using Core.QuerSchnittsBedenken.Ausnahmen;
using Persistenz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AnwendungsDiensteHinzufügen();

builder.Services.DienstePersistenzHinzufügen(builder.Configuration);


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
if (app.Environment.IsProduction())
    app.BenutzerdefinierteAusnahmeMiddlewareKonfigurieren();
app.UseAuthorization();

app.MapControllers();

app.Run();
