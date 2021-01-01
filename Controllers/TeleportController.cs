using System;
using System.Linq;
using System.Threading.Tasks;
using DataAnalyse.Infrastructure;
using DataAnalyse.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAnalyse.Net.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeleportController : ControllerBase
    {
        private readonly TelecomContext _context;
        private readonly IProvinceConversionService _provinceConversion;

        public TeleportController(TelecomContext context, IProvinceConversionService provinceConversion)
        {
            _context = context;
            _provinceConversion = provinceConversion;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetTeleportInCity()
        {
            return await _context.Locations.Take(200).Select(x => new
            {
                city = x.City,
                position = new[] {x.Latitude, x.Longitude},
                data = new[] {new Random().Next(1, 300), new Random().Next(1, 300)}
            }).ToListAsync();
        }
    }
}