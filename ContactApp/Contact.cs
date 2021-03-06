﻿using System;

namespace ContactApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта.
        /// </summary>
        public string _surname;

        /// <summary>
        /// Имя контакта.
        /// </summary>
        private string _name;

        /// <summary>
        /// Дата рождения контакта.
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// Адрес электронной почты контакта.
        /// </summary>
        private string _email;

        /// <summary>
        /// Идентификатор Вконтакте контакта.
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Свойство фамилии контакта.
        /// Устанавливает значение фамилии с заглавной буквы, если фамилия не длиннее 50 символов.
        /// </summary>
        public string Surname
        {
            get => _surname;

            set
            {
                if (value.ToString().Length > 50)
                {
                    throw new ArgumentException("Длина фамилии не может быть больше 50 символов" 
                        + value + " - некорректная длина фамилии");
                }
                else
                {
                    _surname = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        /// <summary>
        /// Свойство имени контакта.
        /// Устанавливает значение имени с заглавной буквы, если имя не длиннее 50 символов.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                if (value.ToString().Length > 50)
                {
                    throw new ArgumentException("Длина фамилии не может быть больше 50 символов. "
                        + value + " некорректная длина имени");
                }
                else
                {
                    _name = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        /// <summary>
        /// Свойство даты
        /// Устанавливает значение, если дата не новее нынешней и не позднее 1900 года.
        /// </summary>
        public DateTime Date
        {
            get => _birthDate;

            set
            {
                if (value.Year > 1900 && value < DateTime.Now)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new ArgumentException("Дата не рождение не может быть больше текущей даты " +
                        "или раньше 1900 года" + value + " - некорректная дата");
                }
            }
        }

        /// <summary>
        /// Свойство электронной почты контакта.
        /// Устанавливает значение электронной почты, если почта не длиннее 50 символов.
        /// </summary>
        public string Email
        {
            get => _email;

            set
            {
                if (value.ToString().Length > 50)
                {
                    throw new ArgumentException("Длина email не может быть больше 50 символов" + value + " -  некорректная длина email");
                }
                else
                {
                    _email = value;
                }
            }
        }

        /// <summary>
        /// Свойство идентификатора
        /// Устанавливает значение номера в случае, если он не длиннее 15 символов.
        /// </summary>
        public string Vkid
        {
            get => _vkId;
            set
            {
                if (value.ToString().Length > 15)
                {
                    throw new ArgumentException("Длина Id не может быть больше 15" + value + " - некорректная длина vk id");
                }
                else
                {
                    _vkId = value;
                }
            }
        }

        /// <summary>
        /// Номер телефона персоны.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();
        public Contact() {}
        public Contact(string surname, string name, PhoneNumber phoneNumber, DateTime dateTime, string mail, string vk)
        {
            this.Surname = surname;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Date = dateTime;
            this.Email = mail;
            this.Vkid = vk;
        }

        // <summary>
        /// Метод клонирования объекта данного класса.
        /// </summary>
        /// <returns>
        /// Возвращает копию объекта данного класса.
        /// </returns>
        public object Clone()
        {
            PhoneNumber phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };

            return new Contact
            {
                Surname = this.Surname,
                Name = this.Name,
                Date = this.Date,
                PhoneNumber = phoneNumber,
                Email = this.Email,
                Vkid = this.Vkid
            };
        }
    }
}
