using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XsaFsStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var storage = new Storage();
            return storage.GetContent();
        }

        [HttpGet("write/{text}")]
        public string Write(string text)
        {
            var storage = new Storage();
            storage.AddText(text);
            return storage.GetContent();
        }
    }
}