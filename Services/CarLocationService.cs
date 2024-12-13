using System.Net;
using Dapper;
using Npgsql;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CarLocationService(DapperConText dapperConText): IAllServices<CarLocation>
{
    public Response<bool> Create(CarLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into CarLocations(carid, locationid) values (@CarId, @LocationId);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully created");
    }

    public Response<List<CarLocation>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from CarLocations;";
        var res = connection.Query<CarLocation>(sql).ToList();
        return new Response<List<CarLocation>>(res);
    }

    public Response<CarLocation> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from CarLocations where Id=@Id;";
        var res = connection.QuerySingle<CarLocation>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<CarLocation>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<CarLocation>(res);    
    }

    public Response<bool> Update(CarLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update CarLocations set CarId=@CarId,LocationId=@LocationId where id=@Id;";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully update");   
    }

    public Response<bool> Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from CarLocations where Id=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");
        
    }
}