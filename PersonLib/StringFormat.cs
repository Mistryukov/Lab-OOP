using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonLib
{
    /// <summary>
    /// Предоставляет набор методов взаимодействия со строками и приведением их к определенному формату
    /// </summary>
    public static class StringFormat
    {
        /// <summary>
        /// Обрабатывает входную строку, приводя ее к заданному формату (формат фиксирован)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Строка, приведенная под формат</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string NameFormat(string value)
        {
            value = Regex.Replace(value.Trim(), @"\s+", " ");
            //TODO: different languages +
            string russianPattern = @"^[А-Яа-яЁё]+(?:[ -][А-Яа-яЁё]+)*$";
            string englishPattern = @"^[A-Za-z]+(?:[ -][A-Za-z]+)*$";

            if (!Regex.IsMatch(value, russianPattern)
                && !Regex.IsMatch(value, englishPattern))
            {
                throw new ArgumentException(
                    "Введенные данные не соответствуют формату"
                    );
            }
            string[] words = value.ToLower().Split(' ', '-');

            for (int i = 0; (i < words.Length); i++)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = Char.ToUpper(letters[0]);
                words[i] = string.Join("", letters);
            }
            return string.Join("-", words);
        }

        /// <summary>
        /// Приводит слова на русском в необходимый формат
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Строка, приведенная под русский формат</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string RussianFormat(string value)
        {
            value = Regex.Replace(value.Trim(), @"\s+", " ");
            string russianPattern = @"^[А-Яа-яЁё]+(?:[ -][А-Яа-яЁё]+)*$";

            if (!Regex.IsMatch(value, russianPattern))
            {
                throw new ArgumentException(
                    "Фамилия  тоже должна быть на русском языке"
                    );
            }
            string[] words = value.ToLower().Split(' ', '-');

            for (int i = 0; (i < words.Length); i++)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = Char.ToUpper(letters[0]);
                words[i] = string.Join("", letters);
            }
            return string.Join("-", words);
        }

        /// <summary>
        /// Приводит слова на английском в необходимый формат
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Строка, приведенная под английский формат</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string EnglishFormat(string value)
        {
            value = Regex.Replace(value.Trim(), @"\s+", " ");
            string englishPattern = @"^[A-Za-z]+(?:[ -][A-Za-z]+)*$";

            if (!Regex.IsMatch(value, englishPattern))
            {
                throw new ArgumentException(
                    "Surname must be also in english "
                    );
            }
            string[] words = value.ToLower().Split(' ', '-');

            for (int i = 0; (i < words.Length); i++)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = Char.ToUpper(letters[0]);
                words[i] = string.Join("", letters);
            }
            return string.Join("-", words);
        }
    }
}
