using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace face
{
    [Serializable]
     class Student
    {
        private string name;
        private string rollno;
        public Linked_List<Course> studentcourses;

        public Student(string name,string rollno)
        {
            this.name = name;
            this.rollno = rollno;
            studentcourses = new Linked_List<Course>();
        }
        public void set_name(string name)
        {
            this.name = name;
        }
        public string get_name()
        {
            return name;
        }
        public void set_rollno(string rollno)
        {
            this.rollno = rollno;
        }
        public string get_rollno()
        {
            return rollno;
        }
        public static bool operator >(Student c1, Student c2)
        {
            if (Int16.Parse(c1.get_rollno()) > Int16.Parse(c2.get_rollno()))
                return true;
            return false;
        }
        public static bool operator <(Student c1, Student c2)
        {
            if (Int16.Parse(c1.get_rollno()) < Int16.Parse(c2.get_rollno()))
                return true;
            return false;
        }
    }
}
