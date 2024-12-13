using Dapper;
using Npgsql;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CarLocationService(DapperConText dapperConText): IAllServices<CarLocation>
{
    public bool Create(CarLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into CarLocations(carid, locationid) values (@CarId, @LocationId);";
        var res = connection.Execute(sql,t);
        return res > 0;
    }

    public List<CarLocation> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from CarLocations;";
        var res = connection.Query<CarLocation>(sql).ToList();
        return res;
    }

    public CarLocation GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from CarLocations where Id=@Id;";
        var res = connection.QuerySingle<CarLocation>(sql,new {Id=id});
        return res;    
    }

    public bool Update(CarLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update CarLocations set CarId=@CarId,LocationId=@LocationId where id=@Id;";
        var res = connection.Execute(sql,t);
        return res > 0;    
    }

    public bool Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from CarLocations where Id=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        return res > 0;
        
    }
}