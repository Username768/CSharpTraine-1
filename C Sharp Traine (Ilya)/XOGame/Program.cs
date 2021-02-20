using System;

namespace XOGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int fieldsize = ConsoleUI.GetInt("Какого размера должно быть поле?");
                int itemsInRow = ConsoleUI.GetInt("До скольки в ряд играть?");
                Game game = new Game(fieldsize, fieldsize, itemsInRow);
                game.Start();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}





