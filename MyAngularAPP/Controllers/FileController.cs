using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAngularAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        [Route("GetFile")]
        public ActionResult GetFile()
        {
           // FileNames fns = new FileNames();
            List<string> fn = new List<string>();
            fn.Add("MyComputer");
            fn.Add("Videos");
            fn.Add("Personal");
            fn.Add("Code");

            return Ok(fn);
        }
    }
}