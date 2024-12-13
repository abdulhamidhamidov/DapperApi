using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CarController(IAllServices<Car> carServices) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Car car) => carServices.Create(car);
    [HttpGet]
    public Response<List<Car>> GetAll() => carServices.GetAll();
    [HttpGet("/get-By-Id-Car")]
    public Response<Car> GetById(int id) => carServices.GetById(id);
    [HttpPut]
    public  Response<bool>  Update(Car car) => carServices.Update(car);
    [HttpDelete]
    public  Response<bool>  Delete(int id) => carServices.Delete(id);
}

