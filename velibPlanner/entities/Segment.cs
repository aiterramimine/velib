using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace velibPlanner.entities
{
    [DataContract]
    public class Segment
    {
        public static String WALKING_MODE = "walking";
        public static String CYCLING_MODE = "bicycling";

        [DataMember]
        public Location source;
        [DataMember]
        public Location destination;
        [DataMember]
        public double duration;
        [DataMember]
        public double distance;
        [DataMember]
        public String transportMode;
        [DataMember]
        public String instructions;

        public Segment(Location source, Location destination, double duration, double distance, String transportMode, String instructions)
        {
            this.source = source;
            this.destination = destination;
            this.duration = duration;
            this.distance = distance;
            this.transportMode = transportMode;
            this.instructions = instructions;
        }

        public Location getSource()
        {
            return source;
        }

        public Location getDesination()
        {
            return destination;
        }

        public double getDuration()
        {
            return duration;
        }

        public double getDistance()
        {
            return distance;
        }

        public String getTransportMode()
        {
            return transportMode;
        }

        public String getInstructions()
        {
            return instructions;
        }
    }
}
