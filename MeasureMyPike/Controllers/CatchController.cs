using MeasureMyPike.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeasureMyPike.Controllers
{
    public class CatchController : ApiController
    {
        // GET: api/Catch
        public IEnumerable<Catch> Get()
        {
            CatchService cs = new CatchService();
            
            return cs.getAllCatch();
        }

        // GET: api/Catch/5
        public Catch Get(int id)
        {
            return new CatchService().getCatch(id);
        }

        // POST: api/Catch
        public void Post([FromBody]string value)
        {
            // TODO
        }

        // PUT: api/Catch/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
        }

        // DELETE: api/Catch/5
        public void Delete(int id)
        {
            new CatchService().deleteCatch(id);
        }
    }
}
