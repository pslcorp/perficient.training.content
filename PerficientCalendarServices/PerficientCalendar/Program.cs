using Microsoft.EntityFrameworkCore;
using PerficientCalendar.Business;
using PerficientCalendar.Business.Services;
using PerficientCalendar.Data.Contexts;
using PerficientCalendar.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var a = builder.Configuration["ConnectionStrings:PerficientCalendarConnection"];
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AplicationDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:PerficientCalendarConnection"]));
builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<ITypeEventRepository, TypeEventRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IOperationsOffice, OperationsOffice>();
builder.Services.AddScoped<IOperationsTypeEvent, OperationsTypeEvent>();
builder.Services.AddScoped<IOperationRoom, OperationRoom>();
builder.Services.AddScoped<IOperationMeeting, OperationMeeting>();
builder.Services.AddScoped<IOperationDeveloper, OperationDeveloper>();
builder.Services.AddScoped<IWeatherStackService, WeatherStackService>();
builder.Services.AddScoped<IOperationInvitation, OperationInvitation>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddApplicationInsightsTelemetry();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
    options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Perficient Calendar Services V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();