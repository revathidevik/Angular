using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MyAngularAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IConfiguration configuration;
        public FileController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        [Route("GetFiles")]
        public ActionResult GetFile(string root)
        {
            string[] subdirectoryEntries = null;
            try
            {
                string path = configuration.GetValue<string>("Settings:path");
                if (string.IsNullOrEmpty(root))
                {
                    root = path;
                }
                // Get all subdirectories
                subdirectoryEntries = Directory.GetDirectories(root);
                //GetSubDirectories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(subdirectoryEntries);
        }
        public void GetSubDirectories()

        {

            string root = @"D:\\PrimePay\";

            // Get all subdirectories

            string[] subdirectoryEntries = Directory.GetDirectories(root);

            // Loop through them to see if they have any other subdirectories

            foreach (string subdirectory in subdirectoryEntries)

                LoadSubDirs(subdirectory);

        }

        private void LoadSubDirs(string dir)

        {

            Console.WriteLine(dir);

            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)

            {

                LoadSubDirs(subdirectory);

            }

        }
    }
}