using ConsoleApp1.VelibPlannerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*class Program
    {
        static void Main(string[] args)
        {
            VelibPlannerServiceClient client = new VelibPlannerServiceClient();
            Console.WriteLine(client.ComputeRoute(null, null).duration);
        }
    } */

    public class MainApp
    {
        public static void Main()
        {
            Director d = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            d.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            d.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.ReadKey();

        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartX");
        }

        public override void BuildPartB()
        {
            product.Add("PartY");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    class Product
    {
        private List<String> parts = new List<String>();

        public void Add(String part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct parts ------ ");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }
}
