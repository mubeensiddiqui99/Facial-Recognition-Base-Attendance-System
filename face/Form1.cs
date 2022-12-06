using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace face
{
    public partial class Form1 : Form
    {
        Linked_List<Student> student_list;
        Linked_List<Course> courses;
        ListNode<Student> std;
        ListNode<Course> crs;
        public Form1()
        {
            InitializeComponent();
            delCourseBox.Hide();
            button1.Hide();
            button2.Hide();
            delStudentBox.Hide();
            string studentfile = "student_file.bin";
            using (Stream stream = File.Open(studentfile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();

                student_list = (Linked_List<Student>)bformatter.Deserialize(stream);

            }
            string serializationFile = "course_file.bin";
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                courses = (Linked_List<Course>)bformatter.Deserialize(stream);

            }
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            student_form sform = new student_form();
            sform.ShowDialog();
        }

        private void courseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course_form cform = new Course_form();
            cform.ShowDialog();
        }

        private void markBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mark_Attendance_Form mark_Attendance_Form = new Mark_Attendance_Form();
            mark_Attendance_Form.ShowDialog();
        }

        private void delStudentBtn_Click(object sender, EventArgs e)
        {
            delStudentBox.Show();
            button1.Show();
            delCourseBox.Hide();
            button2.Hide();
        }

        private void delCourseBtn_Click(object sender, EventArgs e)
        {
            delCourseBox.Show();
            button2.Show();
            button1.Hide();
            delStudentBox.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (ListNode<Student> temp = student_list.getHead(); temp != null; temp = temp.next)
            {
                if (temp.val.get_rollno() == delStudentBox.Text)
                    std = temp;
            }
            student_list.delete(std);
            string studentfile = "student_file.bin";
            using (Stream stream = File.Open(studentfile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, student_list);
            }
            button1.Hide();
            delStudentBox.Hide();
            MessageBox.Show("Deleted Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (ListNode<Course> temp = courses.getHead(); temp != null; temp = temp.next)
            {
                if (temp.val.get_course_code() == delCourseBox.Text)
                {
                    crs = temp;
                }
            }
            MessageBox.Show(crs.val.get_course_code());
            courses.delete(crs);
            string serializationFile = "course_file.bin";
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, courses);
            }
            button2.Hide();
            delCourseBox.Hide();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
