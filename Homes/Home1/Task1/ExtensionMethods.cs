namespace Task1
{
    public static class ExtensionMethods
    {
        /// <summary>
        ///     Метод для центрирования строк, дополняет строку до нужной длинны пробелами
        /// </summary>
        /// <param name="str">Строка для центрирования</param>
        /// <param name="totalWidth">Общая ширина новой строки</param>
        /// <returns>Строку центрированную строку шириной totalWidth</returns>
        public static string Center(this string str, int totalWidth)
        {
            return str.PadLeft((totalWidth - str.Length)/2 + str.Length).PadRight(totalWidth);
        }
    }
}