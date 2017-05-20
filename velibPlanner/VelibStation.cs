using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace velibPlanner
{
    [DataContract]
    public class VelibStation
    {
        /* The name of the station. */
        [DataMember]
        private String name;
        /* The location of the station. */
        [DataMember]
        private Location location;
        /* Number of available vehicles in the station. */
        [DataMember]
        private int availableVehicles;

        public VelibStation(String name, Location location, int availableVehicles)
        {
            this.name = name;
            this.location = location;
            this.availableVehicles = availableVehicles;
        }

        /**
         * Gets the location of the station.
         */
        public Location getLocation()
        {
            return location;
        }

        /**
         * Gets the number of available vehicles in the station
         */
        public int getAvailableVehicle()
        {
            return availableVehicles;
        }

        /**
         * True if there is at least on available vehicle in the station.
         */
        public bool isVehicleAvailable()
        {
            return availableVehicles > 0;
        }
    }
}
