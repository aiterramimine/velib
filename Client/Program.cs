using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

// Google maps direction API key:  AIzaSyBmXF6HgaLoSivK5fHS_p0dS-emZQ5t0HA 
namespace Client
{
    class Program
    {
        public static double GALERIE_LAFAYETTE_LATITUDE = 43.698874;
        public static double GALERIE_LAFAYETTE_LONGITUDE = 7.269778;
        public static double EGLISE_STNICOLAS_LATITUDE = 43.699496;
        public static double EGLISE_STNICOLAS_LONGITUDE = 7.267542;
        private static String GOOGLE_MAPS_API_KEY = "AIzaSyBmXF6HgaLoSivK5fHS_p0dS - emZQ5t0HA";

        static void Main(string[] args)
        {
            Location source = new Location();
            source.latitude = GALERIE_LAFAYETTE_LATITUDE;
            source.longitude = GALERIE_LAFAYETTE_LONGITUDE;

            Location destination = new Location();
            destination.latitude = EGLISE_STNICOLAS_LATITUDE;
            destination.longitude = EGLISE_STNICOLAS_LONGITUDE;

            VelibPlannerServiceClient client = new VelibPlannerServiceClient();
            Route r = client.ComputeRoute(source, destination);
            printRoute(r);
            //Console.WriteLine(r.segments[0].instructions);

            /* XmlDocument doc = requestRoute(source, destination, "walking");
            List<Segment> segs = generateSegments(doc);
            Console.WriteLine(segs.Count);
            Console.WriteLine(segs[0].instructions);*/

        }

        public static List<Segment> generateSegments(XmlDocument rawRoute)
        {
            List<Segment> ret = new List<Segment>();
            XmlNodeList steps = rawRoute.GetElementsByTagName("step");

            for (int i = 0; i < steps.Count; i++)
            {
                XmlNode step = steps[i];

                String startLocationLat = step.SelectNodes("descendant::start_location/lng")[0].InnerText;
                String startLocationLng = step.SelectNodes("descendant::start_location/lng")[0].InnerText;
                String destinationLocationLat = step.SelectNodes("descendant::end_location/lat")[0].InnerText;
                String destinationLocationLng = step.SelectNodes("descendant::end_location/lng")[0].InnerText;
                String duration = step.SelectNodes("descendant::duration/value")[0].InnerText;
                String distance = step.SelectNodes("descendant::distance/value")[0].InnerText;
                String transportMode = step.SelectNodes("descendant::travel_mode")[0].InnerText;
                String instructions = step.SelectNodes("descendant::html_instructions")[0].InnerText;

                Location source = new Location();
                source.latitude = Double.Parse(startLocationLat);
                source.longitude = Double.Parse(destinationLocationLat);

                Location destination = new Location();
                destination.latitude = Double.Parse(destinationLocationLat);
                destination.longitude = Double.Parse(destinationLocationLng);

                double durationDbl = Double.Parse(duration);
                double distanceDbl = Double.Parse(distance);

                Segment s = new Segment();
                s.source = source;
                s.destination = destination;
                s.duration = durationDbl;
                s.distance = distanceDbl;
                s.transportMode = transportMode;
                s.instructions = instructions;

                ret.Add(s);
            }

            return ret;
        }

        public static XmlDocument requestRoute(Location current, Location destination, String transportMode)
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/directions/xml" +
                "?origin=" + current.latitude + "," + current.longitude +
                "&destination=" + destination.latitude + "," + destination.longitude +
                "&mode=" + transportMode +
                "&key=" + GOOGLE_MAPS_API_KEY
                );
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseBody = reader.ReadToEnd();

            XmlDocument route = new XmlDocument();
            route.LoadXml(responseBody);

            reader.Close();
            response.Close();

            return route;
        }

        public static void printRoute(Route r)
        {
            Console.WriteLine("ROUTE - Total duration : " + r.duration + " sec");
            for (int i = 0; i <r.segments.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Step---- ");
                printSegment(r.segments[i]);
            }

        }

        public static void printSegment(Segment s)
        {
            // We will convert the HTML to plain text.
            String segmentInstructions = s.instructions;

            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            segmentInstructions = reg.Replace(segmentInstructions, "");
            
            /* Console.WriteLine("* Source: " + s.source.latitude + "," + s.source.longitude);
            Console.WriteLine("* Destination: " + s.destination.latitude + "," + s.destination.longitude);*/
            Console.WriteLine("* Mode: " + s.transportMode);
            Console.WriteLine("* Instrucitons: " + segmentInstructions);
            Console.WriteLine("* Duration: " + s.duration + " sec");
            Console.WriteLine("* Distance: " + s.distance + " m");

        }
    }
}
