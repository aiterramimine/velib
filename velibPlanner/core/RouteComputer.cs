using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace velibPlanner.core
{
    public class RouteComputer
    {
        public GoogleDirectionsAPI googleDirectionsAPI;
        public VelibAPI velibAPI;

        public RouteComputer(GoogleDirectionsAPI googleDirectionsAPI, VelibAPI velibAPI)
        {
            this.googleDirectionsAPI = googleDirectionsAPI;
            this.velibAPI = velibAPI;
        }
    }
}
