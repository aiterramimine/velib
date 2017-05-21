using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using velibPlanner;
using velibPlanner.entities;

namespace velibPlanner.core
{
    public class RouteComputer
    {
        /* The google directions API.*/
        public GoogleDirectionsAPI googleDirectionsAPI;
        /* The velib API. */
        public VelibAPI velibAPI;

        /**
         * Constructor.
         */
        public RouteComputer(GoogleDirectionsAPI googleDirectionsAPI, VelibAPI velibAPI)
        {
            this.googleDirectionsAPI = googleDirectionsAPI;
            this.velibAPI = velibAPI;
        }

        /**
         * Gets the nearest velib station with an available vehicle.
         */
        private VelibStation getNearestVelibStationWithAvailableVehicle()
        {
            return null;
        }

        /**
        * Gets the nearest velib stations to the parameter location.
        */
        private VelibStation getNearestVeilbStationStation(Location l)
        {
            List<VelibStation> stations = velibAPI.requestVelibStations();

            VelibStation nearestStation = null;
            double min = -1;

            for(int i = 0; i < stations.Count; i++)
            {
                VelibStation s = stations[i];
                double distance = computeDistance(l, s.getLocation());

                if(min == -1)
                {
                    nearestStation = s;
                    min = distance;
                }
                else if (distance < min)
                {
                    nearestStation = s;
                    min = distance;
                }
            }

            return nearestStation;
        }

        /**
         * Computes the distance between two locations.
         */
        private double computeDistance(Location l1, Location l2)
        {
            return Math.Sqrt(Math.Pow(l1.getLatitude() - l2.getLatitude(), 2) + Math.Pow(l1.getLongitude() - l2.getLongitude(), 2));
        }

        public Route computeRoute(Location current, Location destination)
        {
            return googleDirectionsAPI.computeRoute(current, destination, "walking");
            /*List<Segment> segs = new List<Segment>();
            Location source = new Location(1, 2);
            Location d = new Location(4, 5);

            Segment s = new Segment(source, d, 1.22, 5, "walking", "instructs");
            segs.Add(s);

            return new Route(1, segs);*/
        }

        /**
         * Computes and returns the route from the source to the destination by walking and cycling.
         */
        public Route computeRouteWalkingAndBicycle(Location current, Location destination)
        {
            return null;
        }

        /**
         * Computes and returns the route from the source to the destination by walking only.
         */
        public Route computeRouteWalkingOnly(Location current, Location destination)
        {
            return googleDirectionsAPI.computeRoute(current, destination, "walking");
        }
    }
}