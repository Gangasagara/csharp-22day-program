using CareBridge.EFCoredemo.Models.Generated;

using Microsoft.EntityFrameworkCore;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext.
// ASP.NET Core will automatically create and inject it when needed.
builder.Services.AddDbContext<CareBridgeScaffoldContext>();

// Add Swagger support.
// Swagger gives us a testing screen for APIs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow Vue.js running on another port
// to call this API from the browser.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable Swagger.
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS.
app.UseCors();

// Simple health-check endpoint.
app.MapGet("/", () =>
{
    return "CareBridge API is running";
});

// Return first 20 patients.
// EF Core converts this LINQ query into SQL.
//app.MapGet("/api/patients",
//    (CareBridgeScaffoldContext db) =>
//    {
//        return db.Patients

//                 // Select only columns we need.
//                 .Select(p => new
//                 {
//                     p.PatientId,
//                     p.FullName,
//                     p.City
//                 })

//                 // Return only first 20 rows.
//                 .Take(20)

//                 // Execute query.
//                 .ToList();
//    });
app.MapGet("/api/patients/city",
    (CareBridgeScaffoldContext db) =>
    {
        var data = db.Patients

                 // Select only columns we need.
                 //.Select(p => new
                 //{
                 //    p.PatientId,
                 //    p.FullName,
                 //    p.City
                 //})
                 .Where(p => p.City == "Pune");
        return data.Select(p => new
        {
            p.PatientId,
            p.FullName,
            p.City,
            p.IsActive
            
        }).Where(p => p.IsActive).ToList();
                 // Return only first 20 rows.
                 
        
    });
app.MapGet("/api/patients/city/count",
    (CareBridgeScaffoldContext db) =>
    {
        var data = db.Patients

                 // Select only columns we need.
                 //.Select(p => new
                 //{
                 //    p.PatientId,
                 //    p.FullName,
                 //    p.City
                 //})
                 .Where(p => p.City == "Pune");
        return data.Where(p => p.IsActive).Count();
        // Return only first 20 rows.


    });

app.MapGet("/api/departments/encountertype",
    (CareBridgeScaffoldContext db) =>
    {


        var result = from e in db.Encounters join dept in db.Departments
                     on e.DepartmentId equals dept.DepartmentId


                     group e by dept.Name into depotGroup
                     select new
                     {
                         Department = depotGroup.Key,
                         outpatient = depotGroup.Count(x => x.EncounterType == "outpatient"),
                         inpatient= depotGroup.Count(x => x.EncounterType == "Inpatient"),
                         ED= depotGroup.Count(x => x.EncounterType == "Ed"),

                         Total = depotGroup.Count()
                     };


        return result.OrderByDescending(r=>r.Total);


        //return data.Select(p => new
        //{
        //    p.PatientId,
        //    p.FullName,
        //    p.City,
        //    p.IsActive

        //}).Where(p => p.IsActive).ToList();
        //// Return only first 20 rows.


    });



app.Run();

