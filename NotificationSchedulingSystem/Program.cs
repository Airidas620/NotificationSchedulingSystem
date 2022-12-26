using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.DBAccess;
using System.Configuration;
using NotificationSchedulingSystem.RESTRequsetClasses;

var builder = WebApplication.CreateBuilder(args);
var dataManagerREST = new DataManagerREST();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serverless SQLite was used for database
builder.Services.AddDbContext<CompanyContext>(options =>
    {
        options.UseSqlite($"Data Source=.\\CompanyDB.db");
    }
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/CompanyNotificationsSchedule/{id}", (string id, CompanyContext companyContext) =>
{
    if (companyContext.DoesCompanyScheduleIdExist(id))
    {
        return Results.Ok(new CompanyScheduleGET(companyContext.GetNotificationSchedule(id)));
    }
    return Results.NotFound();
})
.WithName("CompanyNotificationsSchedule")
.WithOpenApi();


app.MapPost("/CompanyInformation", async (CompanyInformationPOST companyPOST, CompanyContext companyContext) =>
{

    dataManagerREST.cmpInfPOST = companyPOST;

    if (!dataManagerREST.IsDataValid())
        return Results.StatusCode(500);

    if (companyContext.DoesCompanyIdExist(companyPOST.CompanyID))
        return Results.StatusCode(500);

    companyContext.AddCompany(dataManagerREST.CreateCompanyDetails());

    if (dataManagerREST.HasASchedule())
        companyContext.AddCompanychedule(dataManagerREST.CreateCompanyNotificationSchedule());

    return Results.Ok();
})
.WithName("CompanyInformation")
.WithOpenApi();


app.Run();
