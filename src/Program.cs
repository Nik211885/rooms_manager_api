using Microsoft.EntityFrameworkCore;
using src.Data;
using src.SeederData;
using src.Services.Admin.Manager;
using src.Services.Auth;
using src.Services.ServicesShared.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
SwaggerAuthorization.AddSwaggerAuthorization(builder);
builder.Services.AddTransient<ILogin, LoginServices>();

var regristServices = new RegristServices(builder);
regristServices.AddAllServices();

builder.Services.AddDbContext<RoomsManagerDbConText>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));
RegristAuthentication.AddAuthenticationJwtBearer(builder);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await SeederData.SeederDataAsync(app);

app.Run();
