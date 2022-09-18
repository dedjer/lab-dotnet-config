using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).Build();

// Ask the service provider for the configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();


// Get values from the config given their key and their target type.
// This next 6 lines of code will pull values from appsettings.json
int keyOneValue = config.GetValue<int>("KeyOne");
bool keyTwoValue = config.GetValue<bool>("KeyTwo");
string keyThreeNestedValue = config.GetValue<string>("KeyThree:Message");

// Write the values to the console.
// Console.WriteLine($"KeyOne = {keyOneValue}");
// Console.WriteLine($"KeyTwo = {keyTwoValue}");
// Console.WriteLine($"KeyThree:Message = {keyThreeNestedValue}");

// Since this is a web api project we use System.Diagnostics.Debug.Writeline
// to send data to the "Debug Console" in VSCode    
System.Diagnostics.Debug.WriteLine($"KeyOne = {keyOneValue}");
System.Diagnostics.Debug.WriteLine($"KeyTwo = {keyTwoValue}");
System.Diagnostics.Debug.WriteLine($"KeyThree:Message = {keyThreeNestedValue}");





// Pull from properties.file    


// Below is generated code using "dotnet new webapi" command
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Pull from appsettings.json
    var testValue1 = builder.Configuration.GetValue<string>("KeyOne");
    var testValue2 = builder.Configuration.GetValue<string>("KeyTwo");

    var testValue3Section = builder.Configuration.GetSection("KeyThree");
    var testValue3NestedValue = testValue3Section["Message"];

    System.Diagnostics.Debug.WriteLine($"testValue1 = {testValue1}");
    System.Diagnostics.Debug.WriteLine($"testValue2 = {testValue2}");  
    System.Diagnostics.Debug.WriteLine($"testValue3:Message = {testValue3NestedValue}");

    // Pull from appsettings.development.json
    var testValue4 = builder.Configuration.GetValue<string>("KeyFour");
    var testValue5 = builder.Configuration.GetValue<string>("KeyFive");

    var testValue6Section = builder.Configuration.GetSection("KeySix");
    var testValue6NestedValue = testValue6Section["Message"];

    System.Diagnostics.Debug.WriteLine($"testValue4 = {testValue4}");
    System.Diagnostics.Debug.WriteLine($"testValue5 = {testValue5}");  
    System.Diagnostics.Debug.WriteLine($"testValue6:Message = {testValue6NestedValue}");
    
    // Pull from environment variables
    var envVariable1 = builder.Configuration.GetValue<string>("PATH");
    
    System.Diagnostics.Debug.WriteLine($"envVariable1 = {envVariable1}");

    // Add additional JSON properties file
    builder.Configuration.AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true);

    var postgresSection = builder.Configuration.GetSection("Postgres");
    var dbuser = postgresSection["user"];
    var dbpass = postgresSection["pass"];
    System.Diagnostics.Debug.WriteLine($"postgresSection:user = {dbuser}");
    System.Diagnostics.Debug.WriteLine($"postgresSection:pass = {dbpass}");

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



