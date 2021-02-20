using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOGameCore;

namespace XOGameConsole
{
    class UI : XOGameIO
    {
        public void ClearUI()
        {
            Console.Clear();
        }

        public int[] GetCoords(string message = "")
        {
            if (message != null && message != String.Empty)
                Console.WriteLine(message);
            int[] coords = new int[2];
            coords[0] = this.GetInt("Введите X:");
            coords[1] = this.GetInt("Введите Y:");
            return coords;

        }

        public int GetInt(string message = "")
        {
            try
            {
                return Convert.ToInt32(GetLine(message));
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Введено некорректное значение! Повторите попытку!");
                this.PrintError(ex);
                return GetInt(message);
            }
        }

        public string GetLine(string message = "")
        {
            if (message != null && message != String.Empty)
                Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void PrintError(string message)
        {
            this.PrintMessage("Произошла ошибка!");
            this.PrintMessage(message);
        }

        public void PrintError(Exception ex)
        {
            this.PrintError(ex.Message);
            this.PrintMessage("Стек вызовов");
            this.PrintMessage(ex.StackTrace);
        }

        public void PrintField(Field field)
        {
            Console.WriteLine(field.ToString());
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
