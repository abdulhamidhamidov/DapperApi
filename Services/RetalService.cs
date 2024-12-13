using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class RetalService(DapperConText dapperConText): IAllServices<Rental>
{
    public Response<bool> Create(Rental t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Rentals(CarId, CustomerId, StartDate, EndDate, TotalCost) values (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost);\n";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully created");

    }

    public Response<List<Rental>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Rentals;";
        var res = connection.Query<Rental>(sql).ToList();
        return new Response<List<Rental>>(res);
    }

    public Response<Rental> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Rentals where RentalId=@Id;";
        var res = connection.QuerySingle<Rental>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Rental>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Rental>(res);    
    }
    public Response<bool> Update(Rental t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Rentals set @CarId, @CustomerId, @StartDate, @EndDate, @TotalCost where RentalId=@Id;";
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
        var sql = "delete from Rentals where RentalId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");

        
    }  
}

