using System;
using System.Collections.Generic;

namespace bingoCardGenerator
{
    public class Card
    {
        public List<int> ValueList;

        public Card()
        {
            this.ValueList = new List<int>();
        }

        public void CreateNewCard(double cardSize)
        {
            int newCard = Convert.ToInt32(Math.Pow(cardSize, 2));

            this.ValueList.Clear();

            List<int> duplicates = new List<int>();
            Random randomValue = new Random();

            for (int i = 0; i < newCard; i++)
            {
                int newValue = randomValue.Next(1, 90);

                if (this.ValueList.Contains(newValue))
                {
                    duplicates.Add(newValue);
                    i--;
                }
                else
                {
                    this.ValueList.Add(newValue);
                }

            }
        }


        public void MarkNumber(int removeNumber)
        {
            int numberIndex = 0;

            numberIndex = this.ValueList.IndexOf(removeNumber);

            this.ValueList.Remove(removeNumber);
            this.ValueList.Insert(index: numberIndex, item: 0);
        }
    }
}