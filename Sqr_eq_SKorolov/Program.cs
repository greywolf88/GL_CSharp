using System;

namespace Sqr_eq_SKorolov
{
    class Program
    {
        static void Clean()
        {
            Console.Clear();
            Console.WriteLine("Square Equation by Sergii Korolov");
        }

        static double GetParameterFromUser(char parameterName)
        {
            double value = 0.0;
            bool parsed = false;
            bool wrongEnter = false;
            string line = "";

            // Transform message in case of parameter 'a', which has special condition
            string message = (parameterName == 'a') ? "Enter 'a'. a should be double and <> 0 \n" : string.Format("Enter '{0}'.\n", parameterName);

            while (!parsed)
            {
                Clean();
                if (wrongEnter) { Console.WriteLine("Wrong enter. Pleas try again."); }
                Console.WriteLine(message);
                line = Console.ReadLine();
                parsed = double.TryParse(line, out value);
                if ((value == 0) & (parameterName == 'a')) { parsed = false; } // Special condition for parameter 'a'
                wrongEnter = !parsed;
            }
            return value;
        }

        static void CalculateAndShowRoots(double a, double b, double c)
        {
            Clean();
            Console.WriteLine("Equation is:\n{0}x\xB2 + ({1})x + ({2}) = 0\n", a, b, c);
            double D = Math.Pow(b, 2) - (4 * a * c);
            switch (Math.Sign(D))
            {
                case 1:
                    Console.WriteLine("Roots are:\n");
                    double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine("x1 = {0} \nx2 = {1}", x1, x2);
                    break;
                case 0:
                    double x = (-b) / (2 * a);
                    Console.WriteLine("D == 0, so x1 = x2 = {0}", x);
                    break;
                case -1:
                    Console.WriteLine("D < 0, so the equation has no root in real numbers \nComplex roots are: \n");
                    double realPart = (-b) / (2 * a);
                    double complexPart = Math.Sqrt(Math.Abs(D)) / (2 * a);
                    Console.WriteLine("x1 = {0} + i*{1}\n", realPart, complexPart);
                    Console.WriteLine("x2 = {0} - i*{1}\n", realPart, complexPart);
                    break;
            }
        }

        static void Main(string[] args)
        {
            bool runAgain = true;
            while (runAgain)
            {
                double aParam = GetParameterFromUser('a');
                double bParam = GetParameterFromUser('b');
                double cParam = GetParameterFromUser('c');

                CalculateAndShowRoots(aParam, bParam, cParam);
                
                Console.WriteLine("\nDo you want to calculate again? If Yes - press 'y'. All other keys - exit.");
                ConsoleKeyInfo cKey = Console.ReadKey();
                if (cKey.Key != ConsoleKey.Y) { runAgain = false; }
            }
        }
    }
}
