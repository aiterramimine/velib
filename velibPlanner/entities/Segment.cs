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
        private Location source;
        [DataMember]
        private Location destination;
        [DataMember]
        private double duration;
        [DataMember]
        private double distance;
        [DataMember]
        private String transportMode;
        [DataMember]
        private String instructions;

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
