using testServer.Services.interfaces;
using testServer.Models.Entities;

namespace testServer.Services.Implementations;

public class UserService : IUser
{   
    List<Users> users = [];
   public static Users? GetUserByID(int Id)
    {
         Users targetUser =  users.SingleOrDefault( u => u.Id == Id);
   return targetUser is null ? Results.NotFound() : Results.Ok(targetUser);
    }

     public List<Users> GetUsers()
    {
        return users;
    }

    public static void DeleteUser(int id)
    {
        users.RemoveAll( u => id == u.Id);
    }

      public static Users AddUser(Users user)
    {
        users.Add(user);
        return user;   
    }
}
