namespace WebApiDapper.Services;

public interface IAllServices<T>
{
    bool Create(T t);
    List<T> GetAll();
    T GetById(int id);
    bool Update(T t);
    bool Delete(int id);
}