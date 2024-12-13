using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(CustomerService customerService) : ControllerBase
{
    [HttpPost]
    public bool Create(Customer customer) => customerService.Create(customer);
    [HttpGet]
    public List<Customer> GetAll() => customerService.GetAll();
    [HttpGet("/get-By-Id-customer")]
    public Customer GetById(int id) =>customerService.GetById(id);
    [HttpPut]
    public bool Update(Customer customer) => customerService.Update(customer);
    [HttpDelete]
    public bool Delete(int id) => customerService.Delete(id);
}