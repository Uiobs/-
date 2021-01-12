using System;
using ContactApp;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        private Contact _contact;
        private static DateTime r = new DateTime(3000, 11, 12);

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        [Test]
        public void Surname_TooLong_ThrowsException()
        {
            //setup
            var TooLongSurname = "ShalamovShalamovShalamovShalamovShalamovShalamovShalamovShalamov";
            var message = "Фамилия длиннее 50 символов";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Surname = TooLongSurname;
                        },
                        message);

        }

        [Test]
        public void Surname_Set_CorrectValue()
        {
            //setup
            var CorrectValue = "Shalamov";
            var message = "Тест пройден";

            //assert
            Assert.DoesNotThrow(
                () =>
                {
                    //act
                    _contact.Surname = CorrectValue;
                },
                message);
        }


        [Test]
        public void Surname_Get_CorrectValue()
        {
            //setup
            var expected = "Shalamov";

            //act
            _contact.Surname = expected;
            var actual = _contact.Surname;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [Test]
        public void Name_TooLong_ThrowsException()
        {
            //setup
            var TooLongName = "AndreyAndreyAndreyAndreyAndreyAndreyAndreyAndreyAndrey";
            var message = "Имя длиннее 50 символов";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Name = TooLongName;
                        },
                        message);
        }
        [Test]
        public void Name_Set_CorrectValue()
        {
            //setup
            var CorrectValue = "Andrey";
            var message = "Тест пройден";

            //assert
            Assert.DoesNotThrow(
                () =>
                {
                    //act
                    _contact.Name = CorrectValue;
                },
                message);
        }


        [Test]
        public void Name_Get_CorrectValue()
        {
            //setup
            var expected = "Andrey";

            //act
            _contact.Name = expected;
            var actual = _contact.Name;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }


        [Test]
        public void Email_TooLong_ThrowsException()
        {
            //setup
            var TooLongEmail = "mail-mail-mail-mail-mail-mail-mail-mail-mail-mail-mail-mail";
            var message = "Должно возникать исключение, если email длиннее 50 символов";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Email = TooLongEmail;
                        },
                        message);
        }
        [Test]
        public void Email_Set_CorrectValue()
        {
            //setup
            var CorrectValue = "Email@mail.com";
            var message = "Тест пройден";

            //assert
            Assert.DoesNotThrow(
                () =>
                {
                    //act
                    _contact.Email = CorrectValue;
                },
                message);
        }


        [Test]
        public void Email_Get_CorrectValue()
        {
            //setup
            var expected = "Email@mail.com";

            //act
            _contact.Email = expected;
            var actual = _contact.Email;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильное имя");
        }







        [Test]
        public void Vkid_TooLong_ThrowsException()
        {
            //setup
            var TooLongVkid = "12345678901234567890";
            var message = "Vkid длиннее 15 символов";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Vkid = TooLongVkid;
                        },
                        message);
        }
        [Test]
        public void Vkid_Set_CorrectValue()
        {
            //setup
            var CorrectValue = "123456";
            var message = "Тест пройден";

            //assert
            Assert.DoesNotThrow(
                () =>
                {
                    //act
                    _contact.Vkid = CorrectValue;
                },
                message);
        }


        [Test]
        public void Vkid_Get_CorrectValue()
        {
            //setup
            var expected = "123456";

            //act
            _contact.Vkid = expected;
            var actual = _contact.Vkid;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Vkid возвращает неправильное имя");
        }


        [Test]
        public void Date_Future_ThrowsException()
        {
            //setup
            var FutureDate = "4123, 11, 12";
            var message = "Дата рождения больше допустимого";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Date = DateTime.Parse(FutureDate);
                        },
                        message);
        }

        [Test]
        public void Date_Past_ThrowsException()
        {
            //setup
            var PastDate = "1790, 01, 01";
            var message = "Дата рождения больше допустимого";

            //assert
            Assert.Throws<ArgumentException>(
                        () =>
                        {
                            //act
                            _contact.Date = DateTime.Parse(PastDate);
                        },
                        message);
        }

        [Test]
        public void Date_Set_CorrectValue()
        {
            //setup
            var CorrectValue = "1998,05,14";
            var message = "Тест пройден";

            //assert
            Assert.DoesNotThrow(
                () =>
                {
                    //act
                    _contact.Date = DateTime.Parse(CorrectValue);
                },
                message);
        }

        [Test]
        public void Date_Get_CorrectValue()
        {
            //setup
            var expected = new DateTime(1991, 12, 31);

            //act
            _contact.Date = expected;
            var actual = _contact.Date;

            //assert
            Assert.AreEqual(expected, actual, "Геттер Date возвращает неправильную дату рождения");
        }


    }
}
