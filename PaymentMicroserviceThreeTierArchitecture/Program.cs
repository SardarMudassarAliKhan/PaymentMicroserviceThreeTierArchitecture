using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentMicroserviceThreeTierArchitecture_BAL.IPaymentService;
using PaymentMicroserviceThreeTierArchitecture_BAL.PaymentService;
using PaymentMicroserviceThreeTierArchitecture_DAL.ApplicationContext;
using PaymentMicroserviceThreeTierArchitecture_DAL.Entities;
using PaymentMicroserviceThreeTierArchitecture_DAL.IPaymentService;
using PaymentMicroserviceThreeTierArchitecture_DAL.PaymentRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Payment>, PaymentService>();
#endregion
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESports Shop Payment Microservice: 3-Tier Architecture", Version = "v2" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
