using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace velibPlanner
{
    public class VelibPlannerService : IVelibPlannerService
    {
        private XmlDocument velibChart;
        private List<VelibStation> velibStations; 

        public Route ComputeRoute(Location current, Location destination)
        {
            refreshVelibStations();
            return new Route(velibStations.Count);
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

        private void refreshVelibStations()
        {
            refreshVelibChart();

            List<VelibStation> ret = new List<VelibStation>();
            XmlNodeList markers = velibChart.GetElementsByTagName("marker");
            for(int i = 0; i < markers.Count; i++)
            {
                String name = markers[i].Attributes["name"].Value;

                // Debug
                Console.WriteLine(name);

                double latitude = Convert.ToDouble(markers[i].Attributes["lat"].Value);
                double longitude = Convert.ToDouble(markers[i].Attributes["lng"].Value);
                Location location = new Location(latitude, longitude);

                // TODO: number of available vehicles mock.
                VelibStation station = new VelibStation(name, location, 1);

                ret.Add(station);


            }
            velibStations = ret;
        }

        private VelibStation getNearestVelibStationWithAvailableVehicle()
        {
            return null;
        }

        private VelibStation getNearestVelibStation()
        {
            return null;
        }

        /**
         * Returns the velib chart in form of an XML document requested from the velib web service.
         */
        private void refreshVelibChart()
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument velibChart = new XmlDocument();
            velibChart.LoadXml(responseFromServer);

            this.velibChart = velibChart;
        }
    }
}
