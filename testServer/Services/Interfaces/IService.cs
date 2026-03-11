namespace testServer.Services.interfaces; 

public interface IService<T>
{
    T? GetByID(int Id);
    List<T> GetAll();

    void DeleteByID(int Id);

    T AddItem(T val);
}