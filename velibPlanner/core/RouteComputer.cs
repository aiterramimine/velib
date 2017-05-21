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
        public VelibStation getNearestVeilbStationStation(Location l, List<VelibStation> stations)
        {
            VelibStation nearestStation = stations[0];
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

            if (hasAvailableVehicle(nearestStation))
            return nearestStation;
            else {
                stations.Remove(nearestStation);
                return getNearestVeilbStationStation(l, stations);
            }
        }

        public VelibStation getNearestVeilbStationStation(Location l)
        {
            return getNearestVeilbStationStation(l, velibAPI.requestVelibStations());

        }


        private bool hasAvailableVehicle(VelibStation station) 
        {
            return velibAPI.getAvailableVehicles(station.number) > 0;
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
            
            /* Move by foot to the nearest station. */
            List<Segment> toNearestStation = googleDirectionsAPI.generateSegments(current, getNearestVeilbStationStation(current).location, "walking");
            /* Move by bicycle from the source station to the destination station. */
            List<Segment> stationToStation = googleDirectionsAPI.generateSegments(getNearestVeilbStationStation(current).location, getNearestVeilbStationStation(destination).location, "bicycling");
            /* Move by foot from the destination station to the destination.*/
            List<Segment> toDestinationStation = googleDirectionsAPI.generateSegments(getNearestVeilbStationStation(destination).location, destination, "walking");

            /* Concatenate all the computed segments */
            List<Segment> trajectTotal = new List<Segment>();
            trajectTotal = trajectTotal.Concat(toNearestStation).ToList();
            trajectTotal = trajectTotal.Concat(stationToStation).ToList();
            trajectTotal = trajectTotal.Concat(toDestinationStation).ToList();

            /* Create the walking and cycling route from the concatenated segments. */
            Route walkingAndCycling = new Route(trajectTotal);
            /* Ask the google API for a route in which walking is the only transport mechanic from the source to the destination. */
            Route walkingOnly = googleDirectionsAPI.computeRoute(current, destination, "walking");

            /* Returns the route with the shortest duration. */
            return walkingOnly.getDuration() >= walkingAndCycling.getDuration() ? walkingAndCycling : walkingOnly;
            
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

        public List<VelibStation> getVelibStations()
        {
            List<VelibStation> stations = new List<VelibStation>();
            //stations.Add(new VelibStation("name", new Location(0, 0), 0, 0));
            //return velibAPI.requestVelibStations();
            //return stations;
            return null;

        }
    }
}