using Dapper;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CustomerService(DapperConText dapperConText): IAllServices<Customer>
{
    public bool Create(Customer t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Customers(fullname, phone, email) values (@FullName, @Phone, @Email);";
        var res = connection.Execute(sql,t);
        return res > 0;
    }

    public List<Customer> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Customers;";
        var res = connection.Query<Customer>(sql).ToList();
        return res;
    }

    public Customer GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars where CarId=@Id;";
        var res = connection.QuerySingle<Customer>(sql,new {Id=id});
        return res;    
    }
    public bool Update(Customer t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Customers set fullname=@FullName, phone=@Phone, email=@Email where CustomerId=@Id;";
        var res = connection.Execute(sql,t);
        return res > 0;    
    }

    public bool Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Customers where CustomerId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        return res > 0;
        
    }      
}