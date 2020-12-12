using System;
using System.Collections.Generic;

class Game
{
    int itemsInRow;
    bool isStarted;
    Field field;
    public Game() : this(3, 3, 3)
    {
    }
    public Game(int rows, int columns, int itemsInRow)
    {
        if (rows != columns)
            throw new Exception("Некорректный размер поля");
        if (itemsInRow < 2)
            throw new Exception("Некорректное число элементов в ряд");
        this.itemsInRow = itemsInRow;
        this.isStarted = false;
        this.field = new Field(rows, columns);
    }
    public bool CheckWin()
    {
        // for (int i = 0; i < field.Rows; i++){
        // 	int counter=0;

        // 	for (int j = 0; j < field.Columns; j++)

        // }


        int WinCounter = 0;
        CellType Flag = CellType.cross;
        for (int i = 0; i < field.Rows; i++)
        {
            WinCounter = 0;
            for (int j = 0; j < field.Columns; j++)
            {
                if (Flag == field[i, j].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[i, j].value;
                    WinCounter = 1;
                }
            }
        }

        for (int i = 0; i < field.Rows; i++)
        {
            WinCounter = 0;
            for (int j = 0; j < field.Columns; j++)
            {
                if (Flag == field[j, i].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[j, i].value;
                    WinCounter = 1;
                }
            }
        }
        for (int k = 0; k < field.Columns; k++)
        {
            int i = 0;
            WinCounter = 0;
            for (int j = k; j < field.Columns; j++)
            {
                if (Flag == field[i, j].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[i, j].value;
                    WinCounter = 1;
                }
                i++;
            }


        }
        for (int k = 0; k < field.Columns; k++)
        {
            int i = 0;
            WinCounter = 0;
            for (int j = k; j < field.Columns; j++)
            {
                if (Flag == field[j, i].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[j, i].value;
                    WinCounter = 1;
                }
                i++;
            }


        }
        for (int k = field.Columns - 1; k >= 0; k--)
        {
            int i = 0;
            WinCounter = 0;
            for (int j = k; j >= 0; j--)
            {
                if (Flag == field[i, j].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[i, j].value;
                    WinCounter = 1;
                }
                i++;
            }


        }

        for (int k = field.Columns - 1; k >= 0; k--)
        {
            int i = 0;
            WinCounter = 0;
            for (int j = k; j >= 0; j--)
            {
                if (Flag == field[j, i].value && Flag != CellType.empty)
                {
                    WinCounter++;
                    if (WinCounter == this.itemsInRow)
                        return true;

                }
                else
                {
                    Flag = field[j, i].value;
                    WinCounter = 1;
                }
                i++;
            }


        }

        return false;
    }
    public void Start()
    {
        this.isStarted = true;
        int currentPlayerIndex = 0;
        while (this.isStarted)
        {
            Console.WriteLine(field);
            try
            {
                if (currentPlayerIndex == 0)
                    Console.WriteLine("Ходит Х");
                else
                    Console.WriteLine("Ходит O");
                int x = Convert.ToInt32(IO.GetLine("Введите строку:")) - 1;
                int y = Convert.ToInt32(IO.GetLine("Введите столбец:")) - 1;
                if (field[x, y].value == CellType.empty)
                {
                    field.Set(x, y, new Cell((CellType)currentPlayerIndex));
                    if (CheckWin())
                    {
                        Console.WriteLine("Game over");
                        this.isStarted = false;
                    }

                    currentPlayerIndex = (currentPlayerIndex + 1) % 2;
                }
                else
                {
                    Console.WriteLine("Поле занято");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        Console.WriteLine(field);



    }
}