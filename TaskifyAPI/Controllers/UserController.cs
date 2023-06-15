using Microsoft.AspNetCore.Mvc;
using TaskifyAPI.Models;


namespace TaskifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAll()
        {

            return Ok();
        }
    }
}
