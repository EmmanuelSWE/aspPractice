namespace testServer.Services.interfaces;
using testServer.Models.Entities;


public interface ICar  
{
    Cars? GetUserByID(int Id);

    List<Cars> GetCars();

    void DeleteUser(int id);

    Cars AddUser(Cars user);

}