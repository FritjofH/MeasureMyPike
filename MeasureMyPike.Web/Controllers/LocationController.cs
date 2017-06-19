﻿using System.Web.Http;
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
        public void Post([FromBody]string lake, string coordinates)
        {
            LocationService cs = new LocationService();
            cs.AddLocation(lake, coordinates);
        }

        // PUT: api/Location/5
        public void Put(int id, string name, string coordinates)
        {
            LocationService cs = new LocationService();
            cs.UpdateLocation(id, name, coordinates);
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
            LocationService cs = new LocationService();
            cs.DeleteLocation(id);
        }
    }
}