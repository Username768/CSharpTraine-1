using System;
using System.Collections.Generic;


class Program
{
    public static void Main(string[] args)
    {
       try{
         int fieldsize;
         fieldsize = IO.GetInt("Какого размера должно быть поле?");
         int winsCount;
         winsCount = IO.GetInt("До скольки в ряд играть?");
				Game game = new Game(fieldsize, fieldsize);
				game.Start();
			 }
			 catch(Exception ex){
				 Console.WriteLine(ex);
			 }

    }
}
