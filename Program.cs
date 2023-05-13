using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо список пар
            List<Lesson> lessons = new List<Lesson>();
            lessons.Add(new Lesson("Math", "Ivanov", "Am-1"));
            lessons.Add(new Lesson("Physics", "Petro", "KNS-22"));
            lessons.Add(new Lesson("OOP", "Volynets", "KNS"));

            // Сортуємо список
            lessons.Sort();

            // Виводимо список
            Console.WriteLine("List:");
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine("{0}, {1}, {2}", lesson.Subject, lesson.Teacher, lesson.Group);
            }
            // Серіалізуємо список
            string serialized = Lesson.Serialize(lessons);

            Console.WriteLine("\nSerealized:\n" + serialized);

            // Десеріалізуємо список
            List<Lesson> deserialized = Lesson.Deserialize(serialized);

            Console.WriteLine("\nDeserialized List:");
            foreach (Lesson lesson in deserialized)
            {
                Console.WriteLine("{0}, {1}, {2}", lesson.Subject, lesson.Teacher, lesson.Group);
            }
        }
    }
}