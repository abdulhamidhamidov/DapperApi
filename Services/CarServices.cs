using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CarServices(DapperConText dapperConText):IAllServices<Car>
{
    public Response<bool> Create(Car t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Cars(model, manufacturer, year, priceperDay) values (@Model, @Manufacturer, @Year, @PriceperDay);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully created");
    }

    public Response<List<Car>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars;";
        var res = connection.Query<Car>(sql).ToList();
        return new Response<List<Car>>(res);
    }

    public Response<Car> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars where CarId=@Id;";
        var res = connection.QuerySingle<Car>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Car>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Car>(res);     
    }

    public Response<bool> Update(Car t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Cars set model=@Model, manufacturer=@Manufacturer, year=@Year, priceperDay=@PriceperDay where CarId=@Id;";
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
        var sql = "delete from Cars where CarId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");

        
    }   
}