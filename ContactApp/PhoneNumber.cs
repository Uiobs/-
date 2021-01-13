using System;

namespace ContactApp
{
    /// <summary>
    /// Класс номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;

        /// <summary>
        /// Свойство номера
        /// Устанавливает значение номера в случае, если его длина равна 11 и начинается с 7.
        /// </summary>
        public long Number
        {
            get { return _number; }

            set
            {
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Некорректно введен номер телефона " + value + ". Введите номер начинающийся с 7 и длинной равной 11.");
                }
            }
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="digits">Цифры номера телефона</param>
        public PhoneNumber(long digits) { this.Number = digits; }
        public PhoneNumber() { }
    }
}