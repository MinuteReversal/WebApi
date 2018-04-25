using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/DateTimeAndJSDate")]
    public class DateTimeAndJSDateController : ApiController
    {
        [Route("ISO")]
        [HttpGet]
        public DateTime Get()
        {
            return DateTime.Now;
        }

        [HttpPost]
        public DateTime Post([FromBody]DateTime d)
        {
            return d;
        }
    }
}