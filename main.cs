using System;

  class Game{
    public Game(){

    }
    public void Start(){
      Console.Clear();
      Random random = new Random(); 
      int value = random.Next(1,100);
      bool isFinished = false;  
      for(int i=0;!isFinished;i++){
         int guess=Convert.ToInt32(Console.ReadLine());
        if(value>guess) 
          Console.WriteLine("Ваше число меньше");
        if(value<guess)
        Console.WriteLine("Ваше число больше");
        if(value==guess){
          Console.WriteLine("Вы угадали!");
          Console.WriteLine(i);
          isFinished=true;          
          Console.ReadKey();
        }
      }
    }
  }

  class Program {
    public static void Main (string[] args) {
     Game game = new Game();
     game.Start();
    }
  }
