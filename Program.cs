using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie.Name = "EducationConnectLoginCookie";
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.HttpOnly = true;
    options.Cookie.MaxAge = new TimeSpan(7, 0, 0, 0);
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = new TimeSpan(24, 0, 0);
    options.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;

        return Task.CompletedTask;
    };
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityCore<IdentityUser>(config =>
{
    config.Password.RequireDigit = true;
    config.Password.RequireLowercase = true;
    config.Password.RequireNonAlphanumeric = true;
    config.Password.RequireUppercase = true;
    config.Password.RequiredLength = 12;
    config.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>();
// .AddEntityFrameworkStores<EducationConnectDbContext>();
// builder.Services.AddNpgsql<EducationConnectDbContext>(builder.Configuration["EducationConnectDbConnectionString"]);
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimespanBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.Run();