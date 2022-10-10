using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Test.Db;
using Test.Models;
using Test.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PartDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Qventus API",
        Description = "Part",
        Version = "v1"
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Qventus API V1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/parts", async (PartDb db) => await db.Parts.ToListAsync());

app.MapPost("/part", async (PartDb db, Part part) =>
{
    var wordService = new WordService(db);
    await db.Parts.AddAsync(part);
    await db.SaveChangesAsync();

    wordService.LogNewWords(part.Description);
    return Results.Created($"/part/{part.Id}", part);
});

app.MapPut("/part/{id}", async (PartDb db, Part updatedPart, int id) =>
{
    var wordService = new WordService(db);
    var part = await db.Parts.FindAsync(id);

    if (part is null) return Results.NotFound();
    wordService.UpdateWords(part.Description, updatedPart.Description);

    part.Update(updatedPart.Name, updatedPart.Sku, updatedPart.Description, updatedPart.Weight_Ounces, updatedPart.Is_Active);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/part/{id}", async (PartDb db, int id) =>
{
    var wordService = new WordService(db);
    var part = await db.Parts.FindAsync(id);
    if (part is null)
    {
        return Results.NotFound();
    }
    
    db.Parts.Remove(part);
    wordService.RemoveWords(part.Description);

    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/part/mostcommon", async (PartDb db) =>
{
    var words = await db.Words.ToListAsync();

    return words.OrderByDescending(w => w.Occurence).Take(5);
});

app.Run();
public partial class Program { }
