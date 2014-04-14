using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessNumberGame
{
    class GuessNumberClass
    {
            public void LetTheGameBegin()
            {
                int usersNumber = 0;
                bool DoesWantToExit = false;
                ConsoleKeyInfo cki;


                Console.Write("Welcome to the Guess Number Game !!!!");
                Console.Write("\nInstructions:\n Computer guess a number between 1 and 100.\n You have to guess what is the number.\n You can submit your guess, when you are prompt.\n If you want to exit type exit.");
                Console.Write("\nGame begins now.\n\n\n");
                Console.Write("\nEnter a number between 1-100: ");



                do
                {

                    if (int.TryParse(Console.ReadLine().ToString(), out usersNumber) == false)
                    {
                        Console.Write("\nInvalid input.");
                        Console.Write("\nDo you want to play again. Press Y/N.");
                        cki = Console.ReadKey();

                        if (cki.Key == ConsoleKey.Y)
                        {
                            Console.Write("\nEnter a number between 1-100: ");
                        }
                        else if (cki.Key == ConsoleKey.N)
                        {
                            DoesWantToExit = true;
                        }
                    }
                    else
                    {
                        if (usersNumber == 42)
                        {
                            Console.Write("\nCorrect !!!.");
                        }
                        else
                        {
                            Console.Write("\nIncorrect.");

                            Console.Write("\nDo you want to play again. Press Y/N.");
                            cki = Console.ReadKey();

                            if (cki.Key == ConsoleKey.Y)
                            {
                                Console.Write("\nEnter a number between 1-100: ");
                            }
                            else if (cki.Key == ConsoleKey.N)
                            {
                                DoesWantToExit = true;
                            }
                        }
                    }

                } while (DoesWantToExit == false);

            }
        
    }
}
