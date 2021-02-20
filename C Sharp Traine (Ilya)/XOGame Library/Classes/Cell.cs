using System;
using System.Collections.Generic;
namespace XOGameCore
{
    public enum CellType
    {
        cross,
        zero,
        empty
    }

    public class Cell
    {
        string empty = "_";
        string cross = "X";
        string zero = "0";
        public CellType value;
        public Cell(CellType value)
        {
            this.value = value;
        }
        public Cell() : this(CellType.empty)
        {
        }
        public override string ToString()
        {
            if (this.value == CellType.empty)
                return this.empty;
            if (this.value == CellType.cross)
                return this.cross;
            if (this.value == CellType.zero)
                return this.zero;
            return this.empty;
        }
    }
}