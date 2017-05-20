using ConsoleApp1.VelibPlannerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibPlannerServiceClient client = new VelibPlannerServiceClient();
            Console.WriteLine(client.ComputeRoute(null, null).duration);
        }
    }
}
