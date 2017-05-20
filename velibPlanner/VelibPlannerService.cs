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
            //refreshVelibStations();
            return new Route(velibStations.Count, null, null);
        }


        /**
         * Gets the nearest location of the parameter location.
         */
        private Location getNearestStation(Location l)
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            XmlNodeList elemList = doc.GetElementsByTagName("marker");

            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].Attributes["fullAddress"].Value.Contains("75001"))
                {
                    String name = elemList[i].Attributes["name"].Value;
                    Console.WriteLine(i + " : " + name);

                }
            }
            Console.ReadLine();
            reader.Close();
            response.Close();
            return null;
        }


        private VelibStation getNearestVelibStationWithAvailableVehicle()
        {
            return null;
        }

        private VelibStation getNearestVelibStation()
        {
            return null;
        }
    }
}
