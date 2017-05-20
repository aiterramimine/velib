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

        public Route(double duration)
        {
            this.duration = duration;
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
