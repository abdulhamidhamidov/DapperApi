using Dapper;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class RetalService(DapperConText dapperConText): IAllServices<Rental>
{
    public bool Create(Rental t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Rentals(CarId, CustomerId, StartDate, EndDate, TotalCost) values (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost);\n";
        var res = connection.Execute(sql,t);
        return res > 0;
    }

    public List<Rental> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Rentals;";
        var res = connection.Query<Rental>(sql).ToList();
        return res;
    }

    public Rental GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Rentals where RentalId=@Id;";
        var res = connection.QuerySingle<Rental>(sql,new {Id=id});
        return res;    
    }
    public bool Update(Rental t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Rentals set @CarId, @CustomerId, @StartDate, @EndDate, @TotalCost where RentalId=@Id;";
        var res = connection.Execute(sql,t);
        return res > 0;    
    }

    public bool Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Rentals where RentalId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        return res > 0;
        
    }  
}

