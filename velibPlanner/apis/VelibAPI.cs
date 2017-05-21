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
    public class VelibAPI
    {
        /* The last requested velib chart. */
        private XmlDocument lastRequestedVelibChart;

        /* The last requested velib stations. */
        private List<VelibStation> lastRequestedVelibStations;

        /**
         * Constructor.
         */
        public VelibAPI()
        { }

        public List<VelibStation> requestVelibStations()
        {
            requestVelibChart();

            List<VelibStation> ret = new List<VelibStation>();
            XmlNodeList markers = lastRequestedVelibChart.GetElementsByTagName("marker");
            for (int i = 0; i < markers.Count; i++)
            {
                String name = markers[i].Attributes["name"].Value;
                double latitude = Convert.ToDouble(markers[i].Attributes["lat"].Value);
                double longitude = Convert.ToDouble(markers[i].Attributes["lng"].Value);
                int stationNb = int.Parse(markers[i].Attributes["number"].Value);

                Location location = new Location(latitude, longitude);


               // XmlDocument stationChart = requestStationChart(stationNb);
                /*int availableVehicles = getAvailableVehicles(stationChart);
                int freeSpots = getFreeSpots(stationChart);*/

               VelibStation station = new VelibStation(name, location, 0, 0);

               ret.Add(station);
            }

            //ret.Add(new VelibStation("some", new Location(0, 0), 0, 0));
            //lastRequestedVelibStations = ret;

            return ret;
        }

        /**
         * Returns the velib chart in form of an XML document requested from the velib web service.
         */
        private XmlDocument requestVelibChart()
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument ret = new XmlDocument();
            ret.LoadXml(responseFromServer);

            lastRequestedVelibChart = ret;

            reader.Close();
            response.Close();

            return ret;
        }

        /**
         * Gets the number of available vehicles from the xml chart of the station.
         */
        private int getAvailableVehicles(XmlDocument stationChart)
        {
            stationChart.GetElementsByTagName("availbale");

            return int.Parse(stationChart.GetElementsByTagName("availbale")[0].InnerText);
        }

        /**
         * Gets the number of free spots on the station from the chart of the xml station.
         */
        private int getFreeSpots(XmlDocument stationChart)
        {
            return int.Parse(stationChart.GetElementsByTagName("free")[0].InnerText);
        }

        /**
         * Requests the chart of the station from its number.
         */
        private XmlDocument requestStationChart(int stationNumber)
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + 906);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseBody = reader.ReadToEnd();
            /*
            XmlDocument ret = new XmlDocument();
            ret.LoadXml(responseBody);*/

            return null;
        }
    }
}
