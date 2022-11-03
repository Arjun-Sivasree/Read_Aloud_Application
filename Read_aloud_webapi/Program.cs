using Read_aloud_webapi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .WithHeaders("content-type")
                                .WithMethods("GET", "POST", "DELETE", "OPTIONS");
                      });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding Azure AD support
builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

//adding dependency injection
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//automapper service
builder.Services.AddAutoMapper(typeof(Program));

//dbcontext
builder.Services.AddDbContext<ReadAloudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("read_aloud_connectionString")));

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
