using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace velibPlanner
{
    [DataContract]
    public class Route
    {
        /* The duration of the route. */
        [DataMember]
        private double duration;
        /* Ordered list of all the locations that we should visit in order to arrive to the destination.*/
        [DataMember]
        private List<Location> locations;
        /* Ordered list of durations of the segements of the route. */
        [DataMember]
        private List<int> durations; 

        /**
         * Constructor.
         */
        public Route(double duration, List<Location> locations, List<int> durations)
        {
            this.duration = duration;
            this.locations = locations;
            this.durations = durations;
        }

        /**
         * Returns the duration of the route.
         */
        public double getDuration()
        {
            return duration;
        }
    }
}
