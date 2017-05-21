using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using velibPlanner.entities;

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
        private List<Segment> segments;
        /* Ordered list of durations of the segements of the route. */
        [DataMember]
        private List<int> durations; 

        /**
         * Constructor.
         */
        public Route(List<Segment> segments)
        {
            this.segments = segments;
            calculateDuration();
        }

        /**
         * Returns the duration of the route.
         */
        public double getDuration()
        {
            return duration;
        }

        private void calculateDuration()
        {
            double duration = 0;
            for(int i = 0; i < segments.Count; i++)
            {
                duration += segments[i].duration;
            }

            this.duration = duration;
        }
    }
}
