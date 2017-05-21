using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using velibPlanner.core;

namespace velibPlanner
{
    public class VelibPlannerService : IVelibPlannerService
    {

        private XmlDocument velibChart;
        private List<VelibStation> velibStations;
        /* Initialize the route computer. */
        private RouteComputer routeComputer = new RouteComputer(new GoogleDirectionsAPI(), new VelibAPI());

        public Route ComputeRoute(Location current, Location destination)
        {
            return routeComputer.computeRoute(current, destination);
        }

        public Route anotherRoute()
        {
            return null;
        }

        public List<VelibStation> getVelibStations()
        {
            List<VelibStation> stations = routeComputer.getVelibStations();
            List<VelibStation> ret = new List<VelibStation>();

            for(int i = 0; i < stations.Count && i < 10; i++)
            {
                ret.Add(stations[i]);
            }
            return ret;
        }

    }
}
