using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace velibPlanner
{
    public class Location
    {
        /* Value of the latitude. */
        private double latitude;
        /* Value of the longitude. */
        private double longitude;

        /**
         * Create a location from latitude and longitude.
         */
        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /**
         * Gets the latitude
         */
        public double getLatitude()
        {
            return latitude;
        }

        /**
         * Gets the longitude
         */
        public double getLongitude()
        {
            return longitude;
        }
    }
}
