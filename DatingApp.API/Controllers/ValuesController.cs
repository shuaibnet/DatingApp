
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _conext;
        public ValuesController(DataContext conext)
        {
            _conext = conext;

        }

        [HttpGet] 
        public async Task<IActionResult>GetValues()
        {
            var values = await _conext.Values.ToListAsync();
            return Ok(values);
        }
       [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult>GetValue(int id)  
        {
          var value = await _conext.Values.FirstOrDefaultAsync(x => x.Id == id);
          return Ok(value);

        }
    }
}