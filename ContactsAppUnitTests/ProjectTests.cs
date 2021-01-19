using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp;
using ContactsAppUnitTests;
using NUnit.Framework;

    [TestFixture]
    public class ProjectTests
    {
        [Test(Description ="Позитивный тест по передачи правильного списка")]
        public void TestProject_CorrectValue()
        {
            //setup
            var testProject = TestProjectInitializer.InitProject();

            //act
            var expectedList = testProject._contactlist;

            //assert
            Assert.AreEqual(expectedList, testProject._contactlist, 
                "Был передан неправильный список");
        }

        [Test(Description = "Позитивный тест сортировки")]
        public void TestSortBySurname()
        {

        //setup
        var testProject = TestProjectInitializer.InitProject();

        //act
        IEnumerable<string> expected = new[]
        {
                "Aloha",
                "Cerega",
                "Grey",
        };

        List<Contact> sortedContacts = testProject.SortList();

        //assert
        Assert.IsTrue(sortedContacts.Select(n => n.Surname).SequenceEqual(expected),
            "Список отсортирован неверно");
        }

        [TestCase("1testsurnam111", Description = "Тест сортировки с подстрокой больше фамилии")]
        [TestCase("Аааа", Description = "Тест сортировки с подстрокой отличающейся от фамилии")]
        [Test(Description = "Негативный тест сортировки")]
        public void TestSortBySurname_WrongSubstring(string wrongSubstring)
        {

            //setup
            var testProject = TestProjectInitializer.InitProject();

            //act
            List<Contact> sortedContacts = testProject.SortList(wrongSubstring);

            //assert
            Assert.IsEmpty(sortedContacts, "Список осторирован по строке неверно");
        }
    }
