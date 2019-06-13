using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            //test harness
            //           Gengine.GVector myVector = new Gengine.GVector(10, 10);

            //Gengine.Out.Print(myVector);
            // Gengine.Out.Print(myVector.Add(2, 0));

            int temp = 2;
            Console.WriteLine(Gengine.Math.Pow(temp, 2));
            Console.WriteLine(temp);

            Console.WriteLine(Gengine.Math.Round(3.6));
            Console.WriteLine(Gengine.Math.Floor(3.6));


            Console.WriteLine(Gengine.Math.Cos(60));
            Console.WriteLine(Gengine.Math.Sin(15));
            Console.WriteLine(Gengine.Math.Round(2.1455, 3));
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }
    }
}
