using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOGameCore;

namespace XOGameConsole
{
    class Program 
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            int size = ui.GetInt("Введите размер поля");
            int itemsInRow = ui.GetInt("Введите количество фигур в ряд");
            Core gameCore = new Core(ui,size,size, itemsInRow);
            gameCore.Start();
        }
    }
}
