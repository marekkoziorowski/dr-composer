using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace DrComposer.Api.Controllers
{
    [Route("api/[controller]")]
    public class ComposeController: Controller
    {
        public IConfigurationRoot Configuration { get; }

        public ComposeController(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            string files = Configuration["Files"];
            string f = System.IO.File.ReadAllText(files);

            return new string[] { "value1", "value2", f };
        }
    }
}
