using System.Net;
using estudoRepository.Context;
using estudoRepository.Interfaces;
using estudoRepository.Repositories;
using estudoRepository.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Moq;
using Moq.Protected;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var handleMock = new Mock<HttpMessageHandler>();
handleMock
  .Protected()
  .Setup<Task<HttpResponseMessage>>(
    "SendAsync",
    ItExpr.IsAny<HttpRequestMessage>(),
    ItExpr.IsAny<CancellationToken>()
  )
  .ReturnsAsync(new HttpResponseMessage
  {
      StatusCode = HttpStatusCode.OK,
      Content = new StringContent("{\"authorized\": true}")
  });

if (builder.Configuration.GetValue<bool>("UseMock"))
{
    builder.Services.AddHttpClient<IAuthorizeService, AuthorizeService>()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("http://mocked-url.com");
        })
        .ConfigurePrimaryHttpMessageHandler(() => handleMock.Object);

    builder.Services.AddHttpClient<INotifyService, NotifyService>()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("http://mocked-url.com");
        })
        .ConfigurePrimaryHttpMessageHandler(() => handleMock.Object);
}
else
{
    builder.Services.AddHttpClient<IAuthorizeService, AuthorizeService>()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("https://util.devi.tools");
        });
}

//Repositoies
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();
//Services
builder.Services.AddScoped<ITransferServices, TransferServices>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
// builder.Services.AddScoped<IAuthorizeService, AuthorizeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
