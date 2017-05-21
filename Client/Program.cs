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
            
            //48.8764198136411,2.3586300645446                                      Gare de l'est
            //48.875867,2.359228                                                    East side cofee
            //48.857091635218225,2.341747995157864                                  ile cité
            //48.855377, 2.345016                                                   Sainte chapelle

            Console.WriteLine("--- Première démonstration qui consistes à se déplacer de East Side Coffee à Sainte Chapelle. ---");
            Console.WriteLine("");
            Location eastSideCoffee = new Location();
            eastSideCoffee.latitude = 48.875867;
            eastSideCoffee.longitude = 2.359228;

            Location gareDeLEst = new Location();
            gareDeLEst.latitude = 48.855377;
            gareDeLEst.longitude = 2.345016;
            
            Route r = client.ComputeRoute(eastSideCoffee, gareDeLEst);
            printRoute(r);

            Console.WriteLine("--- Deuxième démonstration qui consistes à se déplacer de Food hall à fnacParisGareEst. ---");
            Console.WriteLine("");

            // Food hall                    48.876614, 2.359375
            // starbucks     48.877453, 2.358539
            Location foodHall = new Location();
            eastSideCoffee.latitude = 48.876614;
            eastSideCoffee.longitude = 2.359375;

            Location fnacParisGareEst = new Location();
            fnacParisGareEst.latitude = 48.877453;
            fnacParisGareEst.longitude = 2.358539;

            Route r2 = client.ComputeRoute(foodHall, fnacParisGareEst);
            printRoute(r2);


        }

        public static void printRoute(Route r)
        {
            Console.WriteLine("ROUTE - Total duration : " + r.duration + " sec");
            for (int i = 0; i < r.segments.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Step--- ");
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

        public static void printVelibStations(VelibStation[] stations)
        {
            Console.WriteLine("ALL VELIB STATIONS: ");
            for (int i = 0; i < stations.Length; i++)
            {
                VelibStation currentStation = stations[i];

                Console.WriteLine("");
                Console.WriteLine("station--- " + currentStation.name);
                Console.WriteLine("Availbale vehicles: " + currentStation.availableVehicles);
                Console.WriteLine("Free spots: " + currentStation.free);
            }
        }
    }
}
