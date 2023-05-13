using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    [Serializable]
    public class Lesson : IComparable<Lesson>
    {
        public string Subject { get; set; }

        public string Teacher { get; set; }

        public string Group { get; set; }

        public Lesson(string subject, string teacher, string group)
        {
            Subject = subject;
            Teacher = teacher;
            Group = group;
        }

        public int CompareTo(Lesson other)
        {
            if (Subject != other.Subject)
            {
                return Subject.CompareTo(other.Subject);
            }
            else if (Teacher != other.Teacher)
            {
                return Teacher.CompareTo(other.Teacher);
            }
            else
            {
                return Group.CompareTo(other.Group);
            }
        }

        public static string Serialize(List<Lesson> lessons)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, lessons);
            return Convert.ToBase64String(stream.ToArray());
        }

        public static List<Lesson> Deserialize(string data)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(data));
            IFormatter formatter = new BinaryFormatter();
            return (List<Lesson>)formatter.Deserialize(stream);
        }
    }
}
