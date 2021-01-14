﻿using System;
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
            var testProject = TestProjectInitializer.InitProject();

            var expectedList = testProject._contactlist;

            Assert.AreEqual(expectedList, testProject._contactlist, 
                "Был передан неправильный список");
        }

        [TestCase("1testsurnam111", Description = "Тест сортировки с подстрокой больше фамилии")]
        [TestCase("Аааа", Description = "Тест сортировки с подстрокой отличающейся от фамилии")]
        [Test(Description = "Негативный тест сортировки")]
        public void TestSortBySurname_WrongSubstring(string wrongSubstring)
        {
            var testProject = TestProjectInitializer.InitProject();

            List<Contact> sortedContacts = testProject.SortList(wrongSubstring);

            Assert.IsEmpty(sortedContacts, "Список осторирован по строке неверно");
        }
    }
