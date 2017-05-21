using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace velibPlanner
{
    [DataContract]
    public class Mock
    {
        [DataMember]
        public int id;

        public Mock()
        {
            this.id = 3;
        }
    }
}
