using System;
using System.Collections.Generic;

namespace bingoCardGenerator
{
    public class Menu
    {
        Card newCard;

        public Menu()
        {
            this.newCard = new Card();
        }
        public void Start()
        {
            Console.WriteLine("Bingo Card Generator\n");

            Console.WriteLine("1. Create new card");
            Console.WriteLine("2. View card");
            Console.WriteLine("3. Mark off number");
            int userSelection = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (userSelection)
            {
                case 1:
                    CreateNewCard();
                    break;
                case 2:
                    ViewCard();
                    break;
                case 3:
                    MarkNumber();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
        }

        public void CreateNewCard()
        {
            Console.WriteLine("Create new card");

            Console.Write("How many rows would you like the card? (2-5): ");
            double userSelection = double.Parse(Console.ReadLine());

            if (userSelection > 5 || userSelection < 2)
            {
                Console.WriteLine("Please choose a valid size (2-5)");
                Console.WriteLine();

                CreateNewCard();
            }
            else
            {
                newCard.CreateNewCard(userSelection);

                Console.WriteLine();
                ViewCard();
            }
        }

        public void ViewCard()
        {
            // finds length of list and where breaks should be
            double listLength = newCard.ValueList.Count;
            int rowLength = Convert.ToInt32(Math.Sqrt(listLength));

            int reset = Convert.ToInt32(listLength) - (rowLength + 1);
            int breakLine = 0;

            // sorts list numerically
            newCard.ValueList.Sort();

            for (int i = 0; i < listLength; i++)
            {

                while (breakLine <= i)
                {
                    //inserts break
                    if (breakLine == rowLength)
                    {
                        breakLine -= reset;
                        Console.WriteLine();

                        // evens markers for single digit numbers
                        if (newCard.ValueList[breakLine] < 10)
                        {
                            Console.Write(newCard.ValueList[breakLine] + "    | ");
                            breakLine += rowLength;
                        }
                        else
                        {
                            Console.Write(newCard.ValueList[breakLine] + "   | ");
                            breakLine += rowLength;
                        }

                    }
                    else
                    {
                        // evens markers for single digit numbers
                        if (newCard.ValueList[breakLine] < 10)
                        {
                            Console.Write(newCard.ValueList[breakLine] + "    | ");
                            breakLine += rowLength;
                        }
                        else
                        {
                            Console.Write(newCard.ValueList[breakLine] + "   | ");
                            breakLine += rowLength;
                        }
                    }
                }
            }

            Console.WriteLine();

            Start();
        }


        public void MarkNumber()
        {
            Console.WriteLine("Mark off number");

            Console.Write("Enter the number: ");
            int userSelection = int.Parse(Console.ReadLine());

            if (newCard.ValueList.Contains(userSelection))
            {
                newCard.MarkNumber(userSelection);
                Console.WriteLine("Number removed");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This number does not exist on the card");
            }

            Start();
        }
    }
}
