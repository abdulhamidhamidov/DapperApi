using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CarLocationController(IAllServices<CarLocation> carLocationService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(CarLocation carLocation) => carLocationService.Create(carLocation);
    [HttpGet]
    public Response<List<CarLocation>> GetAll() => carLocationService.GetAll();
    [HttpGet("/get-By-Id-CarLocation")]
    public Response<CarLocation> GetById(int id) =>carLocationService.GetById(id);
    [HttpPut]
    public Response<bool> Update(CarLocation carLocation) => carLocationService.Update(carLocation);
    [HttpDelete]
    public Response<bool> Delete(int id) => carLocationService.Delete(id);
}

