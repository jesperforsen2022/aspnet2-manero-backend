using Backend.Contexts;
using Backend.Repositories;
using Backend.Repositories.Users;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Contexts
builder.Services.AddDbContext<NoSqlContext>(x => x.UseCosmos(builder.Configuration.GetConnectionString("NoSql")!, builder.Configuration.GetSection("NoSqlDatabaseName").Value!));
builder.Services.AddDbContext<SqlContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

//Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<CreditCardService>();
builder.Services.AddScoped<PromoCodeService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();

//Repositories
builder.Services.AddScoped<ProductRepositoy>();
builder.Services.AddScoped<AddressRepositoy>();
builder.Services.AddScoped<CreditCardRepository>();
builder.Services.AddScoped<RoleRepositoty>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<ProductRepository>();

//Authentications
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddCookie()
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["TokenGenerator:Issuer"]!,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["TokenGenerator:Audience"]!,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenGenerator:Secret"]!))

    };
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            if (string.IsNullOrEmpty(context.Principal?.Identity?.Name))
            {
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    };
});



var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
