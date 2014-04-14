using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterTheList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> filteredList=new List<string>();
            List<string> theList = new List<string>();
            
            //Generate the list
            theList.Add("Naleen");
            theList.Add("Nazri");
            theList.Add("Ashen");
            theList.Add("Zero");
            theList.Add("One");
            theList.Add("Pelicon");
            theList.Add("Zebra");
            theList.Add("Android");
            theList.Add("Box");

            myFuntionsClass obj = new myFuntionsClass();
            //Get the filteredlist
            filteredList= obj.filterByChar(theList,'N');


            if (filteredList.Count == 0)
            {
                Console.Write("There are no matching items.");
            }
            else {
                Console.Write("There matching items are...");
                foreach (string str in filteredList) {
                    Console.Write("\n\t\t"+str);
                }
            }

            Console.Write("\n\nPress any key to exit.");
            Console.ReadKey();
        }

    }
}
