using ConsoleApp1.VelibPlannerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Google maps direction API key:  AIzaSyBmXF6HgaLoSivK5fHS_p0dS-emZQ5t0HA 
namespace ConsoleApp1
{
    class Program
    {
        public static double GALERIE_LAFAYETTE_LATITUDE = 43.698874;
        public static double GALERIE_LAFAYETTE_LONGITUDE = 7.269778;
        public static double EGLISE_STNICOLAS_LATITUDE = 43.699496;
        public static double EGLISE_STNICOLAS_LONGITUDE = 7.267542;

        static void Main(string[] args)
        {
            Mock mock = new Mock();
            Location source = new Location();
            Location destination = new Location();
            VelibPlannerServiceClient client = new VelibPlannerServiceClient();
            Console.WriteLine(client.ComputeRoute(null, null).duration);
        }
    }
}
