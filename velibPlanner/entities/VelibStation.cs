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
        public String name;
        /* The location of the station. */
        [DataMember]
        public Location location;
        [DataMember]
        public int number;
        /* Number of available vehicles in the station. */
        [DataMember]
        public int availableVehicles;
        /* Free sports where to put a vheicle. */
        [DataMember]
        public int free;

        public VelibStation(String name, Location location, int number, int availableVehicles, int free)
        {
            this.name = name;
            this.location = location;
            this.availableVehicles = availableVehicles;
            this.number = number;
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

        /**
         * Returns true if there is a free spot where to connect a vehicle.
         */
        public bool isFreeAvailable()
        {
            return free > 0;
        }
    }
}
