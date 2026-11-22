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
        //Question: the assignment asks a weak password (score below 3) to return 400. Where should the strength check go, and how does this controller get the password service?
        public ActionResult<User> Post([FromBody] User user)
        {
           user= classService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] UserLogin loginUser)
        {
            //The assignment asks a wrong password to return 204 NoContent: what should be returned instead of NotFound when the login fails?
            var user =classService.login(loginUser);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        //Question: the assignment asks a weak password (score below 3) to return 400. Where is the strength check done before the user is updated?
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
