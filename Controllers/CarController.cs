using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CarController(IAllServices<Car> carServices) : ControllerBase
{
    [HttpPost]
    public bool Create(Car car) => carServices.Create(car);
    [HttpGet]
    public List<Car> GetAll() => carServices.GetAll();
    [HttpGet("/get-By-Id-Car")]
    public Car GetById(int id) => carServices.GetById(id);
    [HttpPut]
    public bool Update(Car car) => carServices.Update(car);
    [HttpDelete]
    public bool Delete(int id) => carServices.Delete(id);
}

