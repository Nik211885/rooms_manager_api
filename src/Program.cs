using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using src.Data;
using src.Services.Admin.ManageCustomer;
using src.Services.Admin.ManageUser;
using src.Services.ServicesShared.Login;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddTransient<ILogin, LoginServices>();
builder.Services.AddTransient<ICreateCustomer, CreateCustomer>();
builder.Services.AddTransient<IDeleteCustomer, DeleteCustomer>();
builder.Services.AddDbContext<RoomsManagerDbConText>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtBearer =>
    {
        jwtBearer.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            ValidIssuer = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("K@lnt211885"));

app.UseHttpsRedirection();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
