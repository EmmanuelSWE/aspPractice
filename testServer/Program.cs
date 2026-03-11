using testServer.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
//here is where you configure the api, add services, etc.
var app = builder.Build();
List<Users> users = new List<Users>();
List<Cars> cars = new List<Cars>();
List <CarImages> images = new List<CarImages>();

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
app.MapGet("/cars/{id}", (int id) =>
{
   Cars targetCar =  cars.SingleOrDefault( u => u.Id == id);
   return targetCar is null ? Results.NotFound() : Results.Ok(targetCar);
});

app.MapGet("/cars", () => Results.Ok(cars));

app.MapPost("/cars", (Cars car) =>
{
    cars.Add(cars);
    return Results.Created($"/cars/{car.Id}", car);
});

app.MapDelete("/cars/{id}", (int id) =>
{
    cars.RemoveAll( u => id == u.Id);
    return Results.NoContent();
});

//Car Image Requests
app.MapGet("/images/{id}", (int id) =>
{
   Users targetImage =  images.SingleOrDefault( u => u.Id == id);
   return targetImage is null ? Results.NotFound() : Results.Ok(targetImage);
});

app.MapGet("/images", () => Results.Ok(images));

app.MapPost("/images", (CarImages image) =>
{
    images.Add(user);
    return Results.Created($"/images/{user.Id}", image);
});

app.MapDelete("/images/{id}", (int id) =>
{
    images.RemoveAll( u => id == u.Id);
    return Results.NoContent();
});

app.Run();
