﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace velibPlanner
{
    public class GoogleDirectionsAPI
    {
        /* Latitude and longitude values of two locations only for testing purposes. */
        public static double GALERIE_LAFAYETTE_LATITUDE = 43.698874;
        public static double GALERIE_LAFAYETTE_LONGITUDE = 7.269778;
        public static double EGLISE_STNICOLAS_LATITUDE = 43.699496;
        public static double EGLISE_STNICOLAS_LONGITUDE = 7.267542;

        public static String exempleRequest = "https://maps.googleapis.com/maps/api/directions/xml?origin=43.698874,7.269778&destination=43.699496,7.267542&key=AIzaSyBmXF6HgaLoSivK5fHS_p0dS - emZQ5t0HA";

        /* The key of the google maps API. */
        private static String GOOGLE_MAPS_API_KEY = "AIzaSyBmXF6HgaLoSivK5fHS_p0dS - emZQ5t0HA";
        /* Google maps request URL parameter for "bicycling" mode. */
        private static String CYCLING_MODE = "bicycling";
        /* Google maps request URL parameter for "walking" mode. */
        private static String WALKING_MODE = "walking";
        /* The last requested route from the service. */
        private XmlDocument lastRequestedRoute;

        /**
         * Constructor.
         */
        public GoogleDirectionsAPI()
        { }

        /**
         * Returns a list of all the locations of the requested route.
         */
        public List<Location> getLocations(XmlDocument requestedRoute)
        {
            List<Location> ret = new List<Location>();
            return ret;
        }

        /**
         * Returns a list of durations of the segments of the requested route.
         */
        public List<int> getDurations(XmlDocument requestedRoute)
        {
            List<int> ret = new List<int>();
            return ret;
        }

        /**
         * Returns a list of all the locations of the last requested route.
         */
        public List<Location> getLocations()
        {
            return getLocations(lastRequestedRoute);
        }

        /**
         * Returns a list of all the locations of the last requested route.
         */
        public List<int> getDurations()
        {
            return getDurations(lastRequestedRoute);
        }

        /**
         * Returns a new route and updates the last requested route by sending request to the Google maps direction API with the current and destination 
         * location and transport mode as parameters.
         */
        public XmlDocument requestRoute(Location current, Location destination, String transportMode)
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/xml" +
                "?origin=" + current.getLatitude() + "," + current.getLongitude() +
                "&destination=" + destination.getLatitude() + "," + destination.getLongitude() +
                "&key=" + GOOGLE_MAPS_API_KEY
                );
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseBody = reader.ReadToEnd();

            XmlDocument route = new XmlDocument();
            route.LoadXml(responseBody);

            lastRequestedRoute = route;

            reader.Close();
            response.Close();

            return route;
        }

    }
}
