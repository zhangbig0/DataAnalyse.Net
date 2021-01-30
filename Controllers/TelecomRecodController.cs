using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAnalyze.Infrastructure;
using DataAnalyze.Net.Entity;
using DataAnalyze.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAnalyze.Net.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelecomRecodController : ControllerBase
    {
        private readonly ITelecomRepository _telecomRepository;
        private readonly TelecomContext _context;

        public TelecomRecodController(ITelecomRepository telecomRepository, TelecomContext context)
        {
            _telecomRepository = telecomRepository;
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<TelecomRecord>> Index()
        {
            return await _telecomRepository.GetAll();
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetTeleportInCity(string cityName)
        {
            var location = await _context.Locations.SingleAsync(x =>
                string.Equals(x.City, cityName, StringComparison.CurrentCultureIgnoreCase));
            var f = new[] {location.Latitude, location.Longitude};

            // ReSharper disable once ComplexConditionExpression
            var teleportInCity = (await _telecomRepository.GetByCity(cityName)).Select(x =>
                new
                {
                    city1 = x.CallerSite1 == cityName ? x.CallerSite1 : x.CallerSite2,
                    city2 = x.CallerSite2 == cityName ? x.CallerSite1 : x.CallerSite2,
                }).GroupBy(x => x.city2, (endCity, telecom) =>
            {
                var endLocation = _context.Locations.Single(location1 => location1.City == endCity);
                return
                    new
                    {
                        fromName = cityName,
                        toName = endCity,
                        coords = new[]
                        {
                            f,
                            new[]
                            {
                                endLocation.Latitude,
                                endLocation.Longitude
                            }
                        },
                        count = telecom.Count(),
                    };
                // ReSharper disable once TooManyChainedReferences
            }).ToList();
            return new
            {
                point = teleportInCity.Select(x =>
                    new
                    {
                        name = x.toName,
                        value = x.coords[1].Append(x.count),
                    }),
                line = teleportInCity.Select(y =>
                    new
                    {
                        fromName = y.fromName,
                        toName = y.toName,
                        coords = y.coords
                    })
            };
        }

        [HttpGet]
        public async Task<ActionResult<long>> GetCount()
        {
            return await _telecomRepository.GetCount();
        }
    }
}