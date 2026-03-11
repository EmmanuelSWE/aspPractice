using testServer.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;
using testServer.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
//here is where you configure the api, add services, etc.

var app = builder.Build();

List<Cars> cars = new List<Cars>();
List <CarImages> images = new List<CarImages>();


//middlewares 
app.Use(async (context, next) =>
{
   Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}] Started."); 
   await next(context);
     Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}] Finished.");   
});
app.MapGet("/", () => "Hello World!");

//instantiating my services
UserService userService = new UserService();
//User Requests
app.MapGet("/login/{Id}", (int Id) =>
{
   Users targetUser =  userService.GetUserByID(Id);
   return targetUser is null ? Results.NotFound() : Results.Ok(targetUser);
});

app.MapGet("/users", () => Results.Ok(userService.GetUsers()));

app.MapPost("/signin", (Users user) =>
{
    userService.AddUser(user);
    return Results.Created($"/users/{user.Id}", user);
});


app.MapDelete("/users/{id}", (int id) =>
{
    userService.DeleteUser(id);
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
    cars.Add(car);
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
   CarImages targetImage =  images.SingleOrDefault( u => u.Id == id);
   return targetImage is null ? Results.NotFound() : Results.Ok(targetImage);
});

app.MapGet("/images", () => Results.Ok(images));

app.MapPost("/images", (CarImages image) =>
{
    images.Add(image);
    return Results.Created($"/images/{image.Id}", image);
});

app.MapDelete("/images/{id}", (int id) =>
{
    images.RemoveAll( u => id == u.Id);
    return Results.NoContent();
});




app.Run();
