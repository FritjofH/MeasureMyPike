using System.Collections.Generic;
using System.Web.Http;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Service;

namespace MeasureMyPike.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        //public IEnumerable<Location> Get()
        //{
        //    var cs = new LocationService();

        //    return cs.GetAllLocations();
        //}

        // GET: api/Location/5
        public Location Get(int id)
        {
            return new LocationService().GetLocation(id);            
        }

        // POST: api/Location
        public void Post([FromBody]Location value)
        {
            LocationService cs = new LocationService();
            cs.AddLocation(value);
        }

        // PUT: api/Location/5
        public void Put(int id, String name, String coordinates)
        {
            LocationService cs = new LocationService();
            cs.SetLocation(id, name, coordinates);
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
            LocationService cs = new LocationService();
            cs.DeleteLocation(id);
        }
    }
}
