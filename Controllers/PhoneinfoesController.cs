using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAnalyze;
using DataAnalyze.Infrastructure;
using DataAnalyze.Net.Services;

namespace DataAnalyze.Net.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhoneinfoesController : ControllerBase
    {
        private readonly TelecomContext _context;
        private readonly IProvinceConversionService _provinceConversionService;

        public PhoneinfoesController(TelecomContext context, IProvinceConversionService provinceConversionService)
        {
            _context = context;
            this._provinceConversionService = provinceConversionService;
        }

        // GET: api/Phoneinfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phoneinfo>>> GetPhoneinfos()
        {
            return await _context.Phoneinfos.Take(10000).ToListAsync();
        }

        // GET: api/Phoneinfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phoneinfo>> GetPhoneinfo([FromRoute] string id)
        {
            var phoneinfo = await _context.Phoneinfos.FindAsync(id);

            if (phoneinfo == null)
            {
                return NotFound();
            }

            return phoneinfo;
        }

        // PUT: api/Phoneinfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneinfo(string id, Phoneinfo phoneinfo)
        {
            if (id != phoneinfo.Phone)
            {
                return BadRequest();
            }

            _context.Entry(phoneinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneinfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Phoneinfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phoneinfo>> PostPhoneinfo([FromBody] Phoneinfo phoneinfo)
        {
            _context.Phoneinfos.Add(phoneinfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhoneinfoExists(phoneinfo.Phone))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhoneinfo", new {id = phoneinfo.Phone}, phoneinfo);
        }

        // DELETE: api/Phoneinfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneinfo([FromRoute] string id)
        {
            var phoneinfo = await _context.Phoneinfos.FindAsync(id);
            if (phoneinfo == null)
            {
                return NotFound();
            }

            _context.Phoneinfos.Remove(phoneinfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneinfoExists([FromRoute] string id)
        {
            return _context.Phoneinfos.Any(e => e.Phone == id);
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetProvinceLocations()
        {
            var list = await _context.Phoneinfos.GroupBy(x => x.Province, (p, pho) =>
                new
                {
                    name = _provinceConversionService.GetProvinceByProvincePrefix()[p],
                    value = pho.Count()
                }).ToListAsync();
            return new
            {
                max = list.Max(x => x.value),
                min = list.Min(x => x.value),
                data = list,
            };
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCityPhoneCount()
        {
            var list = await _context.Phoneinfos.GroupBy(x => x.City, (s, p) => new
            {
                city = s,
                value = p.Count()
            }).Select(arg => new
            {
                name = arg.city,
                value =
                    new[]
                    {
                        _context.Locations.Single(x =>
                                x.City.Contains(arg.city))
                            .Latitude,
                        _context.Locations.Single(x =>
                                x.City.Contains(arg.city))
                            .Longitude,
                    }.Append(arg.value)
            }).ToListAsync();
            return new
            {
                max = list.Max(y => y.value.Last().GetValueOrDefault(0)),
                min = list.Min(z => z.value.Last().GetValueOrDefault(float.MaxValue)),
                data = list
            };
        }
    }
}