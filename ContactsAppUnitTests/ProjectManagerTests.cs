using ContactApp;
using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;
using ContactsAppUnitTests;

[TestFixture]
    public class ProjectManagerTests
    {
        private readonly string _testFilePath = 
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + @"\TestData\TestData.notes";

        private readonly string _corruptedFilePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + @"\TestData\CorruptedTestData.notes";


        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_FromNonExistentDirectory()
        {
            Project project = ProjectManager.LoadFromFile("");
            Assert.IsEmpty(project._contactlist, "В проект загруженны неизвестные данные");
        }

        [Test(Description = "Позитивный тест на сохранение файла")]
        public void TestSave_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            string location =
             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
             + @"\TestData\TestSavedData.notes";

            if (File.Exists(location))
            {
                File.Delete(location);
            }
            ProjectManager.SaveToFile(testProject, location);
            Assert.IsTrue(File.Exists(location), "Файл не был создан при сохранении");
            Assert.AreEqual(File.ReadAllText(location), File.ReadAllText(_testFilePath),
                "Содержание файлов отличается");
        }

        [Test(Description = "Позитивный тест на загрузку файла")]
        public void TestLoad_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            ProjectManager.SaveToFile(testProject, _testFilePath);
            var expectedProject = ProjectManager.LoadFromFile(_testFilePath);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedProject._contactlist.Count, testProject._contactlist.Count,
                    "Загруженные проекты отличаются количеством контактов");
                for (int i = 0; i < expectedProject._contactlist.Count; i++)
                {
                    Assert.IsTrue(expectedProject._contactlist[i].Equals(testProject._contactlist[i]),
                        "Контакт из файла был загружен неправильно");
                }
            });
        }

        [Test(Description = "Негативный тест на загрузку поврежденного файл")]
        public void TestLoad_CorruptedFile()
        {
            var testProject = ProjectManager.LoadFromFile(_corruptedFilePath);

            Assert.IsEmpty(testProject._contactlist, "Загружены неизвестные данные");
        }
    }
