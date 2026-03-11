using testServer.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
//here is where you configure the api, add services, etc.
var app = builder.Build();
List<Users> users = new List<Users>();

app.MapGet("/", () => "Hello World!");

//User Requests
app.MapGet("/users/{id}", (int id) =>
{
   Users targetUser =  users.SingleOrDefault( u => u.Id == id);
   return targetUser is null ? Results.NotFound() : Results.Ok(targetUser);
});

app.MapGet("/users", () => Results.Ok(users));

app.MapPost("/users", (Users user) =>
{
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.MapDelete("/users/{id}", (int id) =>
{
    users.RemoveAll( u => id == u.Id);
    return Results.NoContent();
});


//Car Requests


//Car Image Requests

app.Run();
