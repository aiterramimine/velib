using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace velibPlanner
{
    public class VelibStation
    {
        /* The location of the station. */
        private Location location;
        /* Number of available vehicles in the station. */
        private int availableVehicles;

        public VelibStation(Location location, int availableVehicles)
        {
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
