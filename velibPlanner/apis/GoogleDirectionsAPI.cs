﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using velibPlanner.entities;

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
        /* The last requested chart from the service. This chart represents the route from the current location to the destination. */
        private XmlDocument lastRequestedChart;

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
            return getLocations(lastRequestedChart);
        }

        /**
         * Returns a list of all the locations of the last requested route.
         */
        public List<int> getDurations()
        {
            return getDurations(lastRequestedChart);
        }

        /**
         * Returns a new route and updates the last requested route by sending request to the Google maps direction API with the current and destination 
         * location and transport mode as parameters.
         */
        private XmlDocument requestChart(Location current, Location destination, String transportMode)
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/xml" +
                "?origin=" + current.getLatitude() + "," + current.getLongitude() +
                "&destination=" + destination.getLatitude() + "," + destination.getLongitude() +
                "&mode=" + transportMode +
                "&key=" + GOOGLE_MAPS_API_KEY
                );
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseBody = reader.ReadToEnd();

            XmlDocument chart = new XmlDocument();
            chart.LoadXml(responseBody);

            lastRequestedChart = chart;

            reader.Close();
            response.Close();

            return chart;
        }

        public Route computeRoute(Location current, Location destination, String transportMode)
        {
            Route ret;
            XmlDocument rawRoute = requestChart(current, destination, transportMode);

            ret = new Route(generateSegments(rawRoute));

            return ret;
        
        }

        private List<Segment> generateSegments(XmlDocument rawRoute)
        {
            List<Segment> ret = new List<Segment>();
            XmlNodeList steps = rawRoute.GetElementsByTagName("step");

            for(int i = 0; i < steps.Count; i++)
            {
                XmlNode step = steps[i];

                String startLocationLat = step.SelectNodes("descendant::start_location/lat")[0].InnerText;
                String startLocationLng = step.SelectNodes("descendant::start_location/lng")[0].InnerText;
                String destinationLocationLat = step.SelectNodes("descendant::end_location/lat")[0].InnerText;
                String destinationLocationLng = step.SelectNodes("descendant::end_location/lng")[0].InnerText;
                String duration = step.SelectNodes("descendant::duration/value")[0].InnerText;
                String distance = step.SelectNodes("descendant::distance/value")[0].InnerText;
                String transportMode = step.SelectNodes("descendant::travel_mode")[0].InnerText;
                String instructions = step.SelectNodes("descendant::html_instructions")[0].InnerText;

                Location source = new Location(Double.Parse(startLocationLat), Double.Parse(destinationLocationLat));
                Location destination = new Location(Double.Parse(destinationLocationLat), Double.Parse(destinationLocationLng));
                double durationDbl = Double.Parse(duration);
                double distanceDbl = Double.Parse(distance);

                Segment s = new Segment(source, destination, durationDbl, distanceDbl, transportMode, instructions);
                ret.Add(s);
            }

            return ret;
        }

        public List<Segment> generateSegments(Location current, Location destination, String transportMode)
        {
            List<Segment> ret = new List<Segment>();
            XmlDocument rawRoute = requestChart(current, destination, transportMode);
            return generateSegments(rawRoute);
        }

    }
}
