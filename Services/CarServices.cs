using Dapper;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CarServices(DapperConText dapperConText):IAllServices<Car>
{
    public bool Create(Car t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Cars(model, manufacturer, year, priceperDay) values (@Model, @Manufacturer, @Year, @PriceperDay);";
        var res = connection.Execute(sql,t);
        return res > 0;
    }

    public List<Car> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars;";
        var res = connection.Query<Car>(sql).ToList();
        return res;
    }

    public Car GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars where CarId=@Id;";
        var res = connection.QuerySingle<Car>(sql,new {Id=id});
        return res;    
    }

    public bool Update(Car t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Cars set model=@Model, manufacturer=@Manufacturer, year=@Year, priceperDay=@PriceperDay where CarId=@Id;";
        var res = connection.Execute(sql,t);
        return res > 0;    
    }

    public bool Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Cars where CarId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        return res > 0;
        
    }   
}