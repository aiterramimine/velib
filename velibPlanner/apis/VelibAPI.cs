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

        private List<VelibStation> refreshAndGetVelibStations()
        {
            requestVelibChart();

            List<VelibStation> ret = new List<VelibStation>();
            XmlNodeList markers = lastRequestedVelibChart.GetElementsByTagName("marker");
            for (int i = 0; i < markers.Count; i++)
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

            lastRequestedVelibStations = ret;

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
    }
}
