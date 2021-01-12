using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactApp
{
    public class ProjectManager
    {

        /// <summary>
        /// Имя файла для сериализации/десериализации данных проекта.
        /// Путь для сериализации/десериализации данных проекта.
        /// </summary>

        public static string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
            + "\\ContactApp";

        public static string DefaultfilePath = DefaultPath + "\\ContactApp.note";
        /// <summary>
        /// Метод сериализации данных проекта.
        /// </summary>
        public static void SaveToFile(Project project, string filepath)
        {
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных проекта.
        /// </summary>
        public static Project LoadFromFile(string filePath)
        {

            Project project = new Project();
            JsonSerializer serializer = new JsonSerializer();
            
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }

            if (System.IO.File.Exists(DefaultfilePath) == false)
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
            }
            catch
            {
                project = new Project();
            }
            return project;
        }
    }
}