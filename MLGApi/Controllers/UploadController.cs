using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase { 
        public static IHostingEnvironment _environment;
        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
    
        [HttpPost]
        public async Task<ActionResult<string>> Post(IFormFile file)
        {
            try
            {
                string fName = file.FileName;
                string path = Path.Combine(_environment.WebRootPath, "Images", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(file.FileName);
            } 
            catch(Exception ex)
            {
                return  BadRequest(new { mensaje = ex });
            }

        }
    }
}
