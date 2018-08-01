using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebApplication1.Areas.Car.Controllers
{
    public class CarRestController : ApiController
    {
        // GET: api/CarRest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CarRest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CarRest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CarRest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CarRest/5
        public void Delete(int id)
        {
        }
    }
}
