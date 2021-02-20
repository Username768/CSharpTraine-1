using System;

namespace XOGameCore
{
    public enum GameState
    {
        /// <summary>
        /// Выиграл Х
        /// </summary>
        winX,
        /// <summary>
        /// Выиграл О
        /// </summary>
        winO,
        /// <summary>
        /// Ничья - закончились клетки поля
        /// </summary>
        draw,
        /// <summary>
        /// Игра продолжается
        /// </summary>
        run,
        /// <summary>
        /// Игра остановлена
        /// </summary>
        stopped
    }
    public class Core
    {
        int itemsInRow;
        int currentPlayerIndex;
        GameState currentGameState;
        Field field;
        XOGameIO io;
        public Field Field
        {
            get
            {
                return field;
            }
        }
        public Core(XOGameIO io) : this(io, 3, 3, 3)
        {

        }
        public Core(XOGameIO io, int rows, int columns, int itemsInRow)
        {
            this.io = io;
            if (rows != columns)
                throw new Exception("Некорректный размер поля");
            if (itemsInRow < 2)
                throw new Exception("Некорректное число элементов в ряд");
            this.itemsInRow = itemsInRow;
            this.currentGameState = GameState.stopped;
            this.field = new Field(rows, columns);
        }
        public GameState CheckState()
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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }
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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }

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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }

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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }

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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }

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
                        {
                            if (currentPlayerIndex == 0)
                                return GameState.winX;
                            else
                                return GameState.winO;
                        }

                    }
                    else
                    {
                        Flag = field[i, j].value;
                        WinCounter = 1;
                    }
                    j--;
                }


            }

            while (true)
            {
                int emptyCount = 0;
                for (int i = 0; i < field.Rows; i++)
                {


                    for (int j = 0; j < field.Columns; j++)
                    {

                        if (field[i, j].value == CellType.empty)
                        {
                            emptyCount++;
                        }


                    }

                }
                if (emptyCount == 0)
                    return GameState.draw;
                else
                    return GameState.run;
            }
            

        }
            public void MakeStep(int x, int y)
            {
                if (field[x, y].value == CellType.empty)
                {
                    field.Set(x, y, new Cell((CellType)this.currentPlayerIndex));
                    this.currentGameState = CheckState();
                    this.currentPlayerIndex = (this.currentPlayerIndex + 1) % 2;
                }
                else
                    throw new Exception("Поле занято");
            }
            public void Start()
            {
                this.currentGameState = GameState.run;
                this.currentPlayerIndex = 0;
                while (this.currentGameState == GameState.run)
                {
                    this.io.ClearUI();
                    this.io.PrintField(field);
                    try
                    {
                        if (this.currentPlayerIndex == 0)
                            this.io.PrintMessage("Ходит Х");
                        else
                            this.io.PrintMessage("Ходит O");
                        this.io.PrintMessage("Введите координаты клетки");
                        int[] coords = this.io.GetCoords();
                        this.MakeStep(coords[0] - 1, coords[1] - 1);

                    }
                    catch (Exception ex)
                    {
                        this.io.PrintError(ex);
                        this.io.GetLine("Для продолжения нажмите enter");
                    }
                }

                this.io.ClearUI();
                this.io.PrintField(field);
                if (this.currentGameState == GameState.draw)
                    this.io.PrintMessage("Игра закончилась ничьей");
                if (this.currentGameState == GameState.winX)
                    this.io.PrintMessage("Победили крестики");
                if (this.currentGameState == GameState.winO)
                    this.io.PrintMessage("Победили нолики");
                this.io.GetLine("Для продолжения нажмите enter");
            }
        }
    }

