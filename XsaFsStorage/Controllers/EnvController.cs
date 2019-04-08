using System;
using Microsoft.AspNetCore.Mvc;

namespace XsaFsStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetStoragePath()
        {
            return Environment.GetEnvironmentVariable("VCAP_SERVICES") ?? "VCAP_SERVICES don't set";
        }
    }
}