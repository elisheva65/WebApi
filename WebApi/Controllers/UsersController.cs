using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IClassService classService;
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = classService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        string filePath = "file.txt";

        public UsersController(IClassService _classService)
        {
            classService = _classService;
        }

        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
           user= classService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] UserLogin loginUser)
        {
            var user =classService.login(loginUser);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updateUser)
        {
            classService.UpdateUser(id, updateUser);
            return Ok();

        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
