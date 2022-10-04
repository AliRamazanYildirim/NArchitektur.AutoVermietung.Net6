using Anwendung;
using Core.QuerSchnittsBedenken.Ausnahmen;
using Core.Sicherheit;
using Core.Sicherheit.JWT;
using Core.Sicherheit.Verschlüsselung;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistenz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AnwendungsDiensteHinzufügen();

builder.Services.DienstePersistenzHinzufügen(builder.Configuration);

builder.Services.SicherheitsDiensteHinzufügen();

builder.Services.AddHttpContextAccessor();

TokenOptionen? tokenOptionen = builder.Configuration.GetSection("TokenOptionen").Get<TokenOptionen>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptionen.Aussteller,
        ValidAudience = tokenOptionen.Audienz,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SicherheitsSchlüsselHelfer.ErstelleSicherheitsSchlüssel(tokenOptionen.SicherheitsSchlüssel)
    };
});

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
        }
    });
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
if (app.Environment.IsProduction())
    app.BenutzerdefinierteAusnahmeMiddlewareKonfigurieren();
app.UseAuthorization();

app.MapControllers();

app.Run();
