using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class RentalController(IAllServices<Rental> retalService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Rental rental) => retalService.Create(rental);
    [HttpGet("/get-All")]
    public Response<List<Rental>> GetAll() => retalService.GetAll();
    [HttpGet("/get-By-Id")]
    public Response<Rental> GetById(int id) =>retalService.GetById(id);
    [HttpPut]
    public Response<bool> Update(Rental rental) => retalService.Update(rental);
    [HttpDelete]
    public Response<bool> Delete(int id) => retalService.Delete(id);
}