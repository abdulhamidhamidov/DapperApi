using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CarLocationController(IAllServices<CarLocation> carLocationService) : ControllerBase
{
    [HttpPost]
    public bool Create(CarLocation carLocation) => carLocationService.Create(carLocation);
    [HttpGet]
    public List<CarLocation> GetAll() => carLocationService.GetAll();
    [HttpGet("/get-By-Id-CarLocation")]
    public CarLocation GetById(int id) =>carLocationService.GetById(id);
    [HttpPut]
    public bool Update(CarLocation carLocation) => carLocationService.Update(carLocation);
    [HttpDelete]
    public bool Delete(int id) => carLocationService.Delete(id);
}

