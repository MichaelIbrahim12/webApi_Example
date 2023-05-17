using Lab2BL.Manger.Department;
using Lab2BL.Manger.Ticket;
using Lab2DAL.Data.Context;
using Lab2DAL.Data.Models;
using Lab2DAL.Repo.Departments;
using Lab2DAL.Repo.Tickets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITicketRepo,TicketRepo>();
builder.Services.AddScoped<ITicketManger,TicketManger>();

builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
builder.Services.AddScoped<IDepartmentManger,DepartmentManger>();


# region context

var connectionString = builder.Configuration.GetConnectionString("Lab2_ConString");

builder.Services.AddDbContext<Lab2Context>(options =>
{
    options.UseSqlServer(connectionString);
});

# endregion

# region userManger

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<Lab2Context>();


# endregion

#region authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Cool";
    options.DefaultChallengeScheme = "Cool";
})
.AddJwtBearer("Cool", options =>
{
    string keyString = builder.Configuration.GetValue<string>("secretKey") ?? string.Empty;
    var keyInBytes = Encoding.ASCII.GetBytes(keyString);
    var key = new SymmetricSecurityKey(keyInBytes);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

#endregion

#region authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", policy => policy
        .RequireClaim(ClaimTypes.Role, "user"));
        

    options.AddPolicy("admin", policy => policy
        .RequireClaim(ClaimTypes.Role, "admin"));
});


#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
