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
        public async Task<ActionResult<object>> Post(IFormFile file)
        {
            try
            {
                string fName = file.FileName;
                string path = Path.Combine(_environment.ContentRootPath, "Images/" + file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return new { image = file.FileName };
            } 
            catch(Exception ex)
            {
                return  BadRequest(new { mensaje = ex });
            }

        }
    }
}
