namespace testServer.Services.interfaces;
using testServer.Models.Entities;


public interface IUser  
{
    Users? GetUserByID(int Id);

    List<Users> GetUsers();

    void DeleteUser(int id);

    Users AddUser(Users user);

}