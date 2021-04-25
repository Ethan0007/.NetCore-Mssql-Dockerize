using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApis.Data.Entities;
using SampleApis.Data.Models;
using SampleApis.Repository;
using SampleApis.Utils;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemsController : ControllerBase
    {
        private readonly IRepository<SystemsModel> _repository;

        private readonly SystemsDbContext _context;

        public SystemsController(IRepository<SystemsModel> repository, SystemsDbContext context)
        {
            _repository = repository;

            _context = context;
        }


        [HttpGet, Route("Check")]
        public IActionResult HealthCheck()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            return Ok(version);
        }

        [HttpPost, Route("Save/{key}/{version}")]
        public async Task<IActionResult> SaveKey([FromRoute] string key, [FromRoute] string version)
        {
            var result = await _context.SystemsModel.AddAsync(new SystemsModel()
            {
                Id = Guid.NewGuid().ToTinyUuid(),
                Key = key,
                Expiration = DateTime.Now.AddHours(1).ToString("yyyy-mm-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Version = version
            });

            await _context.SaveChangesAsync();

            if (result is null) return BadRequest("Unable to save key!");

            return Ok(result.Entity.Id);
        }

        [HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound("Id is required!");

            return Ok(await _repository.Find(c =>c.Id == id).SingleOrDefaultAsync());
        }

        [HttpGet, Route("GetByKey")]
        public async Task<IActionResult> GetByKey(string key)
        {
            if (string.IsNullOrEmpty(key)) return NotFound("Key is required!");

            return Ok(await _repository.Find(c => c.Key == key).ToListAsync());
        }
    }
}
