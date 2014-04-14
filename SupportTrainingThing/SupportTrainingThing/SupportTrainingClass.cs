using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportTrainingThing
{
    class SupportTrainingClass
    {
        public void printNumbers()
        {

            Console.Write("Support Training Program.");
            Console.WriteLine();
            Console.Write("*************************");
            Console.WriteLine("\n\n");


            for (int cnt = 1; cnt <= 100; cnt++)
            {

                //If number is divisibal by only 3
                if (cnt % 5 != 0 && cnt % 3 == 0)
                {
                    Console.Write("Support");
                    Console.WriteLine();
                }
                //If number is divisibal by only 5
                else if (cnt % 5 == 0 && cnt % 3 != 0)
                {
                    Console.Write("Training");
                    Console.WriteLine();
                }
                //If number is divisibal by both 3 and 5
                else if (cnt % 5 == 0 && cnt % 3 == 0)
                {

                    Console.Write("SupportTraining");
                    Console.WriteLine();
                }
                //If number is not divisibal by both 3 and 5
                else
                {
                    Console.Write(cnt);
                    Console.WriteLine();
                }

            }

            Console.WriteLine("\n\n\n");
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
