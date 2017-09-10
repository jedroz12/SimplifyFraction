using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyFraction
{
    class Program
    {
        public static int numerator;
        public static int denominator;
        public static int mixed;

        static void Main(string[] args)
        {
            //run input function
            GetInput();
        }

        static void GetInput()
        {
            //get numbers
            try
            {
                Console.WriteLine("Enter Numerator: ");
                numerator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Denominator: ");
                denominator = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Check Inputs.");
                GetInput();
            }

            //set greatestCommonFactor
            int greatestCommonFactor = 0;
            GreatestCommonD(ref numerator, ref denominator, ref greatestCommonFactor, ref mixed);
            //output answer
            if (numerator == 0)
            {
                //if the anser is a whole number, simply output mixed
                Console.WriteLine("Answer: {0}", mixed);
            }
            else
            {
                //otherwise, output mixed fraction
                Console.WriteLine("Answer: {0} {1}/{2} with a GCD of {3}", mixed, numerator, denominator, greatestCommonFactor);
            }
            //when finished, restart
            GetInput();
        }

        static void GreatestCommonD(ref int numerator, ref int denominator, ref int greatestCommonFactor, ref int mixed)
        {
            //loop through denominator
            for (int x = 1; x <= denominator; x++)
            {
                //if both divide by x = 0
                if ((numerator % x == 0) && (denominator % x == 0))
                {
                    //set gcf to x
                    greatestCommonFactor = x;
                }
            }
            if (greatestCommonFactor == 0)
            {
                return;
            }
            else
            {
                //divide numerator and denominator by gcf
                numerator = numerator / greatestCommonFactor;
                denominator = denominator / greatestCommonFactor;
                //set mixed to numerator divided by denominator
                mixed = numerator / denominator;
                //set numerator to numerator minus denominator times mixed
                numerator = numerator - denominator * mixed;
            }
        }
    }
}
