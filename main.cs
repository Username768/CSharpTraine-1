using System;
using System.Collections.Generic;


class Program
{
    public static void Main(string[] args)
    {
       try{
        int fieldsize = IO.GetInt("Какого размера должно быть поле?");
        int itemsInRow = IO.GetInt("До скольки в ряд играть?");
				Game game = new Game(fieldsize, fieldsize, itemsInRow);
				game.Start();
			 }
			 catch(Exception ex){
				 Console.WriteLine(ex);
			 }

    }
}
