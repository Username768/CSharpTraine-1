using System;

namespace XOGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int fieldsize = ConsoleUI.GetInt("������ ������� ������ ���� ����?");
                int itemsInRow = ConsoleUI.GetInt("�� ������� � ��� ������?");
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





