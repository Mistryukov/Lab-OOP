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
            //TODO: different languages
            string ruPattern = @"^[А-Яа-яЁё]+(?:[ -][А-Яа-яЁё]+)*$";
            string engPattern = @"^[A-Za-z]+(?:[ -][A-Za-z]+)*$";

            if (!Regex.IsMatch(value, ruPattern)
                && !Regex.IsMatch(value, engPattern))
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
    }
}
