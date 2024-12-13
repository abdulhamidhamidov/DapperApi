﻿using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class LocationController(LocationService locationService) : ControllerBase
{
    [HttpPost]
    public bool Create(Location location) => locationService.Create(location);
    [HttpGet]
    public List<Location> GetAll() => locationService.GetAll();
    [HttpGet("/get-By-Id-location")]
    public Location GetById(int id) =>locationService.GetById(id);
    [HttpPut]
    public bool Update(Location location) => locationService.Update(location);
    [HttpDelete]
    public bool Delete(int id) => locationService.Delete(id);
}