using Microsoft.EntityFrameworkCore;
using emergen_see_backend.Data;
using emergen_see_backend.Services;
using AutoMapper;
using System.Reflection; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper manually
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Register your services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IQueueService, QueueService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<ITriageFormService, TriageFormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();