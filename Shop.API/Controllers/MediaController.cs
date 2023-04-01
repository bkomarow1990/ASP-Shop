using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MediaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get(string filename)
        {
            string root = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey) + @"\Images\";

            return PhysicalFile(root + @"\" + filename + ".jpeg", "image/jpeg");
        }
    }
}
