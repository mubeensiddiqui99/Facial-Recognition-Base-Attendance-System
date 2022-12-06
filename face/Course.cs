using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace face
{
    [Serializable]
    public class Course
    {
        private string course_name;
        private string course_code;
        private string teacher;
        private string term;

        public Course(string course_name, string course_code, string teacher, string term)
        {
            this.course_name = course_name;
            this.course_code = course_code;
            this.teacher = teacher;
            this.term = term;
        }
        public void set_course_name(string course_name)
        {
            this.course_name = course_name;
        }
        public string get_course_name()
        {
            return course_name;
        }
        public void set_course_code(string course_code)
        {
            this.course_code = course_code;
        }
        public string get_course_code()
        {
            return course_code;
        }
        public void set_term(string term)
        {
            this.term = term;
        }
        public string get_term()
        {
            return term;
        }
        public void set_teacher(string teacher)
        {
            this.teacher = teacher;
        }
        public string get_teacher()
        {
            return teacher;
        }
        public string get_String()
        {
            string value = term + " " + course_code + " " + course_name + " " + teacher;
            return value;
        }
    }
}
