using System;
using ContactApp;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTests
    {
        private PhoneNumber _number;
        [SetUp]
        public void InitNumber()
        {
            _number = new PhoneNumber();
        }

        [Test]
        public void Number_Set_LongNumber()
        {
            var wrongNumber = 7777777777777;
            var message = "Номер длинее 11";
            Assert.Throws<ArgumentException>(
            () => { _number.Number = wrongNumber; },
            message);
        }

        [Test]
        public void Name_Get_CorrectValue()
        {
            //setup
            var expected = 79999999999;

            //act
            _number.Number = expected;
            var actual = _number.Number;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильное имя");
        }
    }
}
