using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
            
using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        return Ok(user);
                }
            }
            return NotFound();    
        }
        //fix: The path never changes, so it can be readonly
        readonly string filePath = "file.txt";
        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.id },
            user);
        }

        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] UserLogin loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return Ok(user);
                }
            }
            return NotFound();

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User updateUser)
        {
        
            string textToReplace = string.Empty;
            using (StreamReader reader =System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if(textToReplace != string.Empty)
{
                //fix: Keep the id, otherwise the updated user is saved without it
                updateUser.id = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
