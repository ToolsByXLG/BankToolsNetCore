using Dal;
using Microsoft.AspNetCore.Mvc;
using Model.Cmb;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace ToolApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ToolDbContext _db;
        //通过.NET Core框架自动为我们做构造函数依赖注入IOC。
        public ValuesController(ToolDbContext db)
        {
            _db = db;
        }
 
        // GET api/values
        [HttpGet]
        public OkObjectResult Get()
        {
            var list = _db.tuser.Take(10).ToList();


            var user = list.FirstOrDefault(x => x.id == 1);


            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
