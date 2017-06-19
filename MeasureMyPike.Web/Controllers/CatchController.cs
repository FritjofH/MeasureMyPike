using MeasureMyPike.Models.Application;
using System.Collections.Generic;
using System.Web.Http;

namespace MeasureMyPike.Controllers
{
    public class CatchController : ApiController
    {
        // GET: api/Catch
        public List<Catch> Get()
        {
            var cs = new CatchService();
            var catchList = cs.GetAllCatches();

            return catchList;
        }

        // GET: api/Catch/5
        public Catch Get(int id)
        {
            var cs = new CatchService();
            var selectedCatch = cs.GetCatch(id);

            return selectedCatch;
        }

        // POST: api/Catch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Catch/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
        }

        // DELETE: api/Catch/5
        public bool Delete(int id)
        {
            var cs = new CatchService();
            var deleted = cs.DeleteCatch(id);

            return deleted;
        }
    }
}
