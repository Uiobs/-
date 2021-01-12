using ContactApp;
using NUnit.Framework;
using System;

namespace ContactsApp.UnitTests
{

    [TestFixture]
    class ProjectManagerTests
    {
        private Contact _contact;
        private Project _project;
        [SetUp]
        public void InitProject()
        {
            _contact = new Contact();
            _contact.Surname = "Shalamov";
            _contact.Name = "Andrey";
            _contact.PhoneNumber.Number = 79999999999;
            _contact.Date = new DateTime(2000, 01, 01);
            _contact.Email = "example@mail.ru";
            _contact.Vkid = "123456";

            _project = new Project();
        }

        [Test]
        public void Test_Save_To_File_Correct_Value()
        {
            _project._contactlist.Add(_contact);
            //act
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath
                + "//ContactsAppTest1.notes");
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath
                + "//ContactsAppTest.notes");

            string reference = System.IO.File.ReadAllText(ProjectManager.DefaultPath
                + "//ContactsAppTest.notes");
            string actual = System.IO.File.ReadAllText(ProjectManager.DefaultPath
                + "//ContactsAppTest1.notes");
            //assert
            Assert.AreEqual(reference, actual, "Тест пройден, если исключений не возникло");
        }
    }
}

