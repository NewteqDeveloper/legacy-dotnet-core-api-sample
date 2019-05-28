using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace StandardSampleWithSsl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly string complex1;
        private readonly string complex2;
        private readonly string simple;

        public ValuesController(IConfiguration configuration)
        {
            this.simple = configuration.GetSection("SingleValue").Get<string>();
            this.complex1 = configuration.GetSection("Complex").GetValue<string>("Value1");
            this.complex2 = configuration.GetSection("Complex").GetValue<string>("Value2");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", simple, complex1, complex2 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
