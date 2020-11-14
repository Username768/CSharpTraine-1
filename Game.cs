using System;
using System.Collections.Generic;

class Game
{
		bool isStarted;
		Field field;
    public Game():this(3,3)
    {
    }
		public Game(int rows, int columns){
			if(rows!=columns)
				throw new Exception("Некорректный размер поля");
			this.isStarted=false;
			this.field= new Field(rows,columns);
		}
  
    public bool CheckWin() 
    {
      for (int i=0; i<field.rows; i++)
        for (int j=0; j<field.columns; j++){
					if field.Get(i, j).value
				}
          
    }

    public void Start()
    {
			this.isStarted = true;
			int currentPlayerIndex = 0;
			while(this.isStarted){     
        Console.WriteLine(field);
				try{
          if (currentPlayerIndex == 0) 
            Console.WriteLine("Ходит Х");
            else
            Console.WriteLine("Ходит O");
					int x = Convert.ToInt32(IO.GetLine("Введите строку:"))-1;
					int y = Convert.ToInt32(IO.GetLine("Введите столбец:"))-1;
          if (field.Get(x, y).value==CellType.empty){
						field.Set(x,y,new Cell((CellType)currentPlayerIndex));
						currentPlayerIndex = (currentPlayerIndex+1)%2;
					}
          else{
						Console.WriteLine("Поле занято");
					}
        
				}
				catch(Exception ex){
					Console.WriteLine(ex);
				}				
			}

 				
        
    }
}