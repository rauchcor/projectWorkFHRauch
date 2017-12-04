using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoSelfHostedWebApi.Controllers.API
{
    [RoutePrefix(AppConfigProvider.ControllersPrefix + "values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(IList<string>))]
        public IHttpActionResult Get()
        {
            return Ok(new List<string>() { "val1", "val2" });
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult Get(int id)
        {
            return Ok("ok");
        }
    }
}
