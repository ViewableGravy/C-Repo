using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEngine
{
    public static class Gengine
    {

        public class GVector
        {
            public int x;
            public int y;

            public GVector(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public GVector Add( int x, int y)
            {
                return new GVector(this.x + x, this.y + y);
            }
            public GVector Add(GVector aOther)
            {
                return new GVector(x + aOther.x, y + aOther.y);
            }
            public GVector Sub(int x, int y)
            {
                return new GVector(this.x - x, this.y - y);
            }
            public GVector Sub ( GVector aOther)
            {
                return new GVector(x - aOther.x, y - aOther.y);
            }
            public GVector Mult ( int x, int y)
            {
                return new GVector(this.x * x, this.y * y);
            }
            public GVector Mult ( GVector aOther )
            {
                return new GVector(x * aOther.x, y * aOther.y);
            }
            public GVector Div (int x, int y)
            {
                return new GVector(this.x / x, this.y / y);
            }
            public GVector Div ( GVector aOther )
            {
                return new GVector(x / aOther.x, y / aOther.y);
            }
            public GVector Copy ()
            {
                return new GVector(x, y);
            }

            /// <summary>
            /// casts this vector onto aOther.
            /// can be used to find the angle between two vectors
            /// </summary>
            1public float Dot( GVector aOther)
            {
                return x * aOther.x + y * aOther.y;
            }
    
        }
        public static class Out
        {
            public static void Print(GVector vector)
            {
                Console.WriteLine("[ " + vector.x + ", " + vector.y + " ]");
            }
        }
        /// <summary>
        /// A custom Math library that covers several useful functions that can be used in games. This is likely not
        /// more efficient than the standard math libary but I am sure it will come in useful
        /// </summary>
        public static class Math
        {
            public const double PI = 3.142;

            /// <summary>
            /// An appropriate approximation of cos(x) where x is a decimal value. accurate to 3 decimal places
            /// </summary>
            public static double Cos(double x)
            {
                x = x * (PI / 180.0);

                double res = 1;
                double sign = 1, fact = 1,
                                 pow = 1;
                for (int i = 1; i < 5; i++)
                {
                    sign = sign * -1;
                    fact = fact * (2 * i - 1) *
                                       (2 * i);
                    pow = pow * x * x;
                    res = res + sign * pow / fact;
                }

                return Round(res, 3);
            }

            /// <summary>
            /// defined in terms of cos(x) where x is an angle in degrees, hence it is as accurate as the cos function;
            /// </summary>
            public static double Sin(double x)
            {
                return Cos(90 - x);
            }

            /// <summary>
            /// defined in terms of cos(x) and sin(x) where x is an angle in degrees, hence it is as accurate as the cos function
            /// </summary>
            public static double Tan(double x)
            {
                return Sin(x) / Cos(x);
            }

            /// <summary>
            /// rounds a double number to an integer
            /// </summary>
            public static int Round(double x)
            {
                return x < 0 ? (int)(x + 0.5) : (int)(x + 0.5);
            }

            /// <summary>
            /// Takes a Double (x) and rounds to an amount (n) of decimal places. Also removes excess 0's after the last number > 0;
            /// </summary>
            public static double Round(double x, int n)
            {
                x *= Pow(10,n);
                double value =x >= 0 ? (int)(x + .5) : (int)(x - 0.5);
                return value /= Pow(10,n);
            }

            /// <summary>
            /// Takes a double (x) and rounds down.
            /// </summary>
            public static int Floor(double x)
            {
                return (int)x;
            }
            
            /// <summary>
            /// takes a double (x) and rounds up.
            /// </summary>
            public static int Ceil(double x)
            {
                return (int)(x + 1);
            }

            /// <summary>
            /// takes a double (baseNum) and raises it to a power (exponent), returns the result
            /// </summary>
            public static double Pow(double baseNum, int Exponent)
            {
                double temp = baseNum;
                for (int i = 0; i < Exponent - 1; i++)
                {
                    temp *= baseNum;
                }
                return temp;
            }
            
            /// <summary>
            /// currently returns System.Math.Sqrt as other methods have too much performance decrease (often 10-100x)
            /// </summary>
            public static double Sqrt(double x)
            {
                return System.Math.Sqrt(x);
            }

            public static double Abs(double val)
            {
                return val < 0 ? val * -1 : val;
            }

            /*
            public static double ACos(double val)
            {
                //-1 <= val <= 1
                // calculates the angle based on the value
            }
            */
        }

    }
}
