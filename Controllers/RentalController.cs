using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class RentalController(IAllServices<Rental> retalService) : ControllerBase
{
    [HttpPost]
    public bool Create(Rental rental) => retalService.Create(rental);
    [HttpGet("/get-All")]
    public List<Rental> GetAll() => retalService.GetAll();
    [HttpGet("/get-By-Id")]
    public Rental GetById(int id) =>retalService.GetById(id);
    [HttpPut]
    public bool Update(Rental rental) => retalService.Update(rental);
    [HttpDelete]
    public bool Delete(int id) => retalService.Delete(id);
}