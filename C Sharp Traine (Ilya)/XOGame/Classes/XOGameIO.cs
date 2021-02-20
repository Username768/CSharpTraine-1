namespace XOGame.Classes
{
    interface XOGameIO
    {
        /// <summary>
        ///  Получает координаты клетки
        /// </summary>
        /// <returns>возвращает массив из двух элементов: координаты X,Y</returns>
        int[] GetCoords();
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
    }
}
