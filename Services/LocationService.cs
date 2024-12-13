using Dapper;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class LocationService(DapperConText dapperConText): IAllServices<Location>
{
    public bool Create(Location t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Locations(city, address) values (@City, @Address);";
        var res = connection.Execute(sql,t);
        return res > 0;
    }

    public List<Location> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from  Locations;";
        var res = connection.Query<Location>(sql).ToList();
        return res;
    }

    public Location GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from  Locations where LocationId=@Id;";
        var res = connection.QuerySingle<Location>(sql,new {Id=id});
        return res;    
    }
    public bool Update(Location t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Locations set city=@City, address=@Address where LocationId=@Id;\n";
        var res = connection.Execute(sql,t);
        return res > 0;    
    }

    public bool Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Locations where LocationId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        return res > 0;
        
    }      
}