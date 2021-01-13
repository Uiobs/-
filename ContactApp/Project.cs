using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp
{
    /// <summary>
    /// Класс логики проекта.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список из объектов класса Contact
        /// </summary>
        public List<Contact> _contactlist { get; set; } = new List<Contact>();

        /// <summary>
        /// Поиск контактов содержащих в своем имени или фамилии конкретной строчки
        /// </summary>
        public List<Contact> SortList()
        {
            var sortedList = _contactlist.OrderBy(contact => contact.Surname).ToList();
            return sortedList;
        }
        /// <summary>
        /// Поиск контактов по фамилии
        /// </summary>
        public List<Contact> SortList(string substring)
        {
            var findSortedList = from contact in _contactlist
                                 where contact.Surname.StartsWith(substring,
                                     StringComparison.OrdinalIgnoreCase)
                                 orderby contact.Surname
                                 select contact;

            return findSortedList.ToList();
        }
        /// <summary>
        /// Поиск именинников из текущего списка контактов и создание списка из таких контактов
        /// </summary>
        public List<Contact> BirthdayData(DateTime date)
        {
            var birthdatedataList = new List<Contact>();
            var Contactlist = new List<Contact>();
            Contactlist = _contactlist;
            foreach (Contact contact in Contactlist)
            {
                if (contact.Date.Month == date.Month && contact.Date.Day == date.Day)
                {
                    birthdatedataList.Add((contact));
                }
            }
            return birthdatedataList;
        }
    }
}
