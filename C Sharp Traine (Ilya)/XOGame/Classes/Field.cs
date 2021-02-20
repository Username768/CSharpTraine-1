using System;
using System.Collections.Generic;
namespace XOGame
{
    public class Field
    {
        List<List<Cell>> cells;
        int rows;
        int columns;
        public int Rows
        {
            set
            {
                this.rows = value;
                if (cells == null || this.cells.Count != 0)
                    this.cells = new List<List<Cell>>();
                for (int i = 0; i < rows; i++)
                    this.cells.Add(new List<Cell>());
            }
            get
            {
                return this.cells.Count;
            }
        }
        public int Columns
        {
            set
            {
                if (cells != null)
                {
                    columns = value;
                    for (int i = 0; i < this.rows; i++)
                        for (int j = 0; j < columns; j++)
                            this.cells[i].Add(new Cell());
                }
            }
            get
            {
                if (this.cells.Count > 0)
                    return this.cells[0].Count;
                else
                    return 0;
            }
        }
        public Field() : this(3, 3)
        {
        }
        public Field(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }
        public Cell this[int row, int column]
        {
            get
            {
                if
                            (
                            row >= 0 && row < this.Rows &&
                            column >= 0 && column < this.Columns
                            )
                    return this.cells[row][column];
                throw new Exception("Некорректные значения строки/столбца!");
            }
            set
            {
                // this[row,column];
                this.cells[row][column] = value;
            }
        }
        public Cell Get(int row, int column)
        {
            if (row >= 0 && row < this.cells.Count && column >= 0 && this.cells[0].Count > 0 && column < this.cells[0].Count)
                return this.cells[row][column];
            throw new Exception("Некорректные значения строки/столбца!");
        }
        public void Set(int row, int column, Cell cell)
        {
            this.Get(row, column);
            this.cells[row][column] = cell;
        }
        public override string ToString()
        {
            string result = "";
            if (this.cells != null)
                for (int i = 0; i < this.cells.Count; i++)
                {
                    for (int j = 0; j < this.cells[i].Count; j++)
                    {
                        result += this.cells[i][j];
                        if (j < this.cells[i].Count - 1)
                            result += " ";
                    }
                    if (i < this.cells.Count - 1)
                        result += '\n';
                }
            return result;
        }
    }
}