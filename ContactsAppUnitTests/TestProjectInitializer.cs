using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp;

namespace ContactsAppUnitTests
{
    /// <summary>
    /// Сервисный класс для создания тестового проекта
    /// </summary>
    static public class TestProjectInitializer
    {
        /// <summary>
        /// Инициализация тестового проекта
        /// </summary>
        /// <returns>Созданный проект для тестов</returns>
        static public Project InitProject()
        {
            var testProject = new Project();

            testProject._contactlist.Add(new Contact(
                surname:"3TestSurname",
                name:"TestName",
                new PhoneNumber(digits:79998877666),
                new DateTime(2000, 1, 1),
                mail:"TestEmail",
                vk:"TestVK"));

            testProject._contactlist.Add(item:new Contact(
                surname:"1TestSurname",
                name:"TestName",
                new PhoneNumber(79998877667),
                new DateTime(2000, 2, 1),
                mail:"TestEmail",
                vk:"TestVK"));

            testProject._contactlist.Add(item:new Contact(
                surname:"2TestSurname",
                name:"TestName",
                new PhoneNumber(79998877668),
                new DateTime(2000, 3, 1),
                mail:"TestEmail",
                vk:"TestVK"));

            return testProject;
        }
    }
}
