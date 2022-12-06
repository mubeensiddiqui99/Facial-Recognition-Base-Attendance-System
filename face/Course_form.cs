using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace face
{
    public partial class Course_form : Form
    {
        Linked_List<Course> courses;
        Linked_List<Course> loadcourses;
        public Course_form()
        {
            InitializeComponent();
            courses = new Linked_List<Course>();
            loadcourses = new Linked_List<Course>();

            string serializationFile = "course_file.bin";
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                courses = (Linked_List<Course>)bformatter.Deserialize(stream);

            }
            //deserialize
            //string serializationFile = "course_file.bin";
            //using (Stream stream = File.Open(serializationFile, FileMode.Open))
            //{
            //    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            //    loadcourses = (List<Course>)bformatter.Deserialize(stream);
            //}

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Course Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Taught By:";
            }
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Course Code";
            }

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Course Name";
            }
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Taught By:";
            }
            if (textBox3.Text == "Course Code")
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Course Name";
            }
            if (textBox2.Text == "Taught By:")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
            }
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Course Code";
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if((fallRadioBtn.Checked==false && springRadioBtn.Checked==false) || (textBox1.Text=="") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                Course course = new Course(textBox1.Text, textBox3.Text, textBox2.Text, (fallRadioBtn.Checked == true) ? fallRadioBtn.Text : springRadioBtn.Text);
                courses.Add(course);
                string message = "Course Added Successfully. Do you want to add more?";
                string title = "Registered!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Black;
                    textBox1.Text = "Course Name";
                    textBox2.ForeColor = Color.Black;
                    textBox2.Text = "Taught By:";
                    textBox3.ForeColor = Color.Black;
                    textBox3.Text = "Course Code";
                }
                else
                {
                    string serializationFile = "course_file.bin";

                    //serialize
                    using (Stream stream = File.Open(serializationFile, FileMode.Create))
                    {
                        var bformatter = new BinaryFormatter();

                        bformatter.Serialize(stream, courses);
                    }
                    this.Hide();
                    this.Close();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();

                }
                //try
                //{
                //    MemoryStream memoryStream = new MemoryStream();
                //    // create new BinaryFormatter
                //    BinaryFormatter binaryFormatter = new BinaryFormatter();
                //    // Serializes an object, or graph of connected objects, to the given stream.
                //    binaryFormatter.Serialize(memoryStream, course);
                //    byte[] byteArray = memoryStream.ToArray();
                //    // Open file for writing
                //    string filename = "course_file";
                //    FileStream fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                //    // Writes a block of bytes to this stream using data from a byte array.
                //    fileStream.Write(byteArray.ToArray(), 0, byteArray.Length);
                //    // close file stream
                //    fileStream.Close();
                //    // cleanup
                //    memoryStream.Close();
                //    memoryStream.Dispose();
                //    memoryStream = null;
                //    byteArray = null;
                //}
                //catch (Exception _Exception)
                //{
                //    // Error
                //    Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                //}
            }
        }

        private void Course_form_Load(object sender, EventArgs e)
        {

        }
    }
}
