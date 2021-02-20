using System;
using System.Collections.Generic;

namespace XOGame
{
    public class Game
    {
        int itemsInRow;
        int currentPlayerIndex;
        bool isStarted;
        Field field;
        public Field Field
        {
            get
            {
                return field;
            }
        }
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

            for (int k = 0; k < field.Rows; k++)
            {
                int j = field.Columns - 1;
                WinCounter = 0;
                for (int i = k; i < field.Rows; i++)
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
                    j--;
                }


            }

            return false;
        }
        public void MakeStep(int x, int y)
        {
            if (field[x, y].value == CellType.empty)
            {
                field.Set(x, y, new Cell((CellType)this.currentPlayerIndex));
                if (CheckWin())
                {
                    Console.WriteLine("Game over");
                    this.isStarted = false;
                }

                this.currentPlayerIndex = (this.currentPlayerIndex + 1) % 2;
            }
            else
            {
                Console.WriteLine("Поле занято");
            }
        }
        public void Start()
        {
            this.isStarted = true;
            this.currentPlayerIndex = 0;
            while (this.isStarted)
            {
                Console.WriteLine(field);
                try
                {
                    if (this.currentPlayerIndex == 0)
                        Console.WriteLine("Ходит Х");
                    else
                        Console.WriteLine("Ходит O");
                    int x = Convert.ToInt32(ConsoleUI.GetLine("Введите строку:")) - 1;
                    int y = Convert.ToInt32(ConsoleUI.GetLine("Введите столбец:")) - 1;
                    this.MakeStep(x, y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            Console.WriteLine(field);



        }
    }
}