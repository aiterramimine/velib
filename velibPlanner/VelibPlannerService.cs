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

        public Route ComputeRoute(Location current, Location destination)
        {
            return null;
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

        private List<VelibStation> getVelibStations()
        {
            refreshVelibChart();

            List<VelibStation> ret = new List<VelibStation>();

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
