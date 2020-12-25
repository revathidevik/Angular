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
        [Route("GetFolders")]
        public ActionResult GetFolders(string root)
        {
            // string[] subdirectoryEntries = null;
            List<Files> files = new List<Files>();
            try
            {
                string path = configuration.GetValue<string>("Settings:path");
                if (string.IsNullOrEmpty(root))
                {
                    root = path;
                }
               files = GetAllFolders(root);
            }
            catch (Exception ex)
            {
              //  throw ex;
            }
            return Ok(files);
        }

        public List<Files> GetAllFolders(string rootFolder)
        {
            string[] subdirectoryEntries = null;
            List<Files> files = new List<Files>();
            string path = configuration.GetValue<string>("Settings:path");
            if (string.IsNullOrEmpty(rootFolder))
            {
                rootFolder = path;
            }
            // Get all subdirectories
            subdirectoryEntries = Directory.GetDirectories(rootFolder);
            Parallel.ForEach(subdirectoryEntries, i =>
            {
                files.Add(new Files() { Name = i, type = "Folder" });
            });
           
            return files; 
        }

        [HttpGet]
        [Route("GetFolderFiles")]
        public ActionResult GetFolderFiles(string root)
        {
            string[] subdirectoryEntries = null;
            List<Files> files = new List<Files>();
            string path = configuration.GetValue<string>("Settings:path");
            if (string.IsNullOrEmpty(root))
            {
                root = path;
            }
            // Get all subdirectories
            files = GetAllFolders(root);
            // Get all Files
            subdirectoryEntries = Directory.GetFiles(root);
            Parallel.ForEach(subdirectoryEntries, i =>
            {
                files.Add(new Files() { Name = i, type = "Files" });
            });
            
            return Ok(files); 
        }

        public List<Files> GetFolderFilesold(string rootFolder)
        {
            string[] subdirectoryEntries = null;
            List<Files> files = new List<Files>();
            Files _file = null;
            string path = configuration.GetValue<string>("Settings:path");
            if (string.IsNullOrEmpty(rootFolder))
            {
                rootFolder = path;
            }
            // Get all subdirectories
            subdirectoryEntries = Directory.GetDirectories(rootFolder);
            //Parallel.ForEach(subdirectoryEntries, i =>
            //{
               // files.Add(new Files() { Name = i, type = "Folder" });
                var filePaths = Directory.EnumerateFiles(rootFolder,
            "*.*", new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            });
                //string[] directoryfiles = Directory.EnumerateFiles(v);
                //foreach (var dirfiles in filePaths)
                //{
                Parallel.ForEach(filePaths, i =>
                {
                    files.Add(new Files() { Name = i, type = "File" });
                });
               // });
            //  files.Add(_file);
            return files;
        }
        //public List<string> GetFoldersFiles(string rootFolder)
        //{
        //    string[] subdirectoryEntries = null;

        //}

       
    }
}