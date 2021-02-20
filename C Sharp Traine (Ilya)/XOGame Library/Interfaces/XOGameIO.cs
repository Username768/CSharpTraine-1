using System;

namespace XOGameCore
{
    /// <summary>
    /// Интерфейс ввода/вывода
    /// </summary>
    public interface XOGameIO
    {
        /// <summary>
        /// Получает строковое значение от пользователя
        /// </summary>
        /// <param name="message">инструкция по вводу данных</param>
        /// <returns></returns>
        string GetLine(string message="");
        /// <summary>
        /// Получает целое число от пользователя
        /// </summary>
        /// <param name="message">инструкция по вводу данных</param>
        /// <returns></returns>
        int GetInt(string message = "");
        /// <summary>
        ///  Получает координаты клетки
        /// </summary>
        /// <param name="message">инструкция по вводу данных</param>
        /// <returns>возвращает массив из двух элементов: координаты X,Y</returns>
        int[] GetCoords(string message = "");
        /// <summary>
        /// Выводит поле на экран
        /// </summary>
        /// <param name="field">поле</param>
        void PrintField(Field field);
        /// <summary>
        /// Выводит сообщение на экран
        /// </summary>
        /// <param name="message">сообщение</param>
        void PrintMessage(string message);
        /// <summary>
        /// Вывод сообщения об ошибке на экран
        /// </summary>
        /// <param name="message">сообщение об ошибке</param>
        void PrintError(string message);
        /// <summary>
        /// Вывод сообщения об ошибке на экран
        /// </summary>
        /// <param name="message">сообщение об ошибке</param>
        void PrintError(Exception ex);
        /// <summary>
        /// Очистка интерфейса
        /// </summary>
        void ClearUI();

    }
}
