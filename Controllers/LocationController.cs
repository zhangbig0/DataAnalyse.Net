using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using DataAnalyze.Entity;
using DataAnalyze.Infrastructure;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAnalyze.Net.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly TelecomContext _telecomContext;

        public LocationController(TelecomContext telecomContext)
        {
            _telecomContext = telecomContext;
        }


        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _telecomContext.Locations.Take(2000).AsEnumerable();
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetProvinceLocations([FromQuery] int num)
        {
            // return await _telecomContext.Locations.Take(num).GroupBy(x => x.Province, (s, l) =>
            //     new
            //     {
            //         Province = s,
            //         Count = l.Sum(y => 1)
            //     }).ToListAsync();

            return await _telecomContext.Locations.Take(num).GroupBy(x => x.Province, (s, l) => new
                {
                    name = s,
                    value = l.Count()
                })
                .ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<float?[]>> GetLocationsByCity(string city)
        {
            var location =
                (await _telecomContext.Locations.SingleAsync(location => location.City.ToLower() == city.ToLower()));
            return new[]
            {
                location.Latitude,
                location.Longitude
            };
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetTeleRecordByCity([FromQuery] string cityName)
        {
            var location = await _telecomContext.Locations.SingleAsync(x =>
                string.Equals(x.City, cityName, StringComparison.CurrentCultureIgnoreCase));
            return new
            {
                city = location.City,
                position = new[]
                {
                    location.Latitude,
                    location.Longitude
                },
                teleport = new List<object>()
                {
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                    _telecomContext.Locations.ToList()[new Random().Next(0, _telecomContext.Locations.Count())],
                }
            };
        }
    }
}