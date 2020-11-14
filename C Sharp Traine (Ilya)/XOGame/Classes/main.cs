using System;
using System.Collections.Generic;


class Program
{
    public static void Main(string[] args)
    {
       try{
				Game game = new Game();
				game.Start();
			 }
			 catch(Exception ex){
				 Console.WriteLine(ex);
			 }

    }
}
