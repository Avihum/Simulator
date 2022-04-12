using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

class HttpContract 
{
    public int id = 10;
    public int value = 20;
    public bool status = true;
    public string name = "Success";
}

namespace SimulatorNamespace.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private ICampRepository _repo;
        private HttpContract myIcd;
        public SimulatorController(ICampRepository campRepository)
        {
            if(campRepository is not null)
            {
                _repo = campRepository;
            }
            // test 03
            this.myIcd = new HttpContract();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            var res = await _repo.GetAllCampsAsync();
            return Ok(res);
        } 

        // GET api/<ValuesController>/5
        [HttpGet("{icdMember}")]
        public IActionResult GetInt(int icdMember)
        {
            switch (icdMember)
            {
                case 1:
                    return Ok(myIcd.id);
                case 2:
                    return Ok(myIcd.name);
                case 3:
                    return Ok(myIcd.status);
                case 4:
                    return Ok(myIcd.value);

                default:
                    break;
            }
            return Ok(myIcd);
        }

        // POST api/<ValuesController>
        [HttpPost("{value}")]
        public void Post([FromBody] string value)
        {
            myIcd.name = value;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }
            return Ok(myIcd.name = value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
