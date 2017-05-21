using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace velibPlanner
{
    [DataContract]
    public class Location
    {
        /* Value of the latitude. */
        [DataMember]
        public double latitude;
        /* Value of the longitude. */
        [DataMember]
        public double longitude;

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
