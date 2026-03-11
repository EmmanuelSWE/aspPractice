namespace testServer.Services.interfaces;
using testServer.Models.Entities;


public interface ICarImage  
{
    CarImages? GetUserByID(int Id);

    List<CarImages> GetCarImages();

    void DeleteUser(int id);

    CarImages AddUser(CarImages user);

}