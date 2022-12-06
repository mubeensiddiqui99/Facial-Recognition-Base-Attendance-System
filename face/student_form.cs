using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using Emgu.CV.Util;
using System.Runtime.Serialization.Formatters.Binary;

namespace face
{
    public partial class student_form : Form
    {
        Linked_List<Course> loadcourses;
        Linked_List<Student> student_list;
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        string finalname;
        //HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        private void captureBtn_Click(object sender, EventArgs e)
        {
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            captureBtn.Enabled = false;
        }

        private void nameBox_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "Enter Name")
            {
                nameBox.Text = "";
                nameBox.ForeColor = Color.Black;
            }
            if (rollnoBox.Text == "")
            {
                rollnoBox.ForeColor = Color.Gray;
                rollnoBox.Text = "Enter Roll Number";
            }

        }

        private void rollnoBox_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.ForeColor = Color.Gray;
                nameBox.Text = "Enter Name";
            }
            if (rollnoBox.Text == "Enter Roll Number")
            {
                rollnoBox.ForeColor = Color.Black;
                rollnoBox.Text = "";
            }
        }

        private void student_form_Load(object sender, EventArgs e)
        {

        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(rollnoBox.Text);

                //Show face added in gray scale
                pictureBox2.Image = TrainedFace.ToBitmap();

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                Student student = new Student(nameBox.Text, rollnoBox.Text);
                
                foreach (var index in courseListBox.CheckedIndices)
                {
                    ListNode<Course> temp = loadcourses.getHead();
                    for (int i = 0; temp != null;i++,temp = temp.next )
                        {
                            if(i==(int)index)
                            {
                                break;
                            }
                        }
                    student.studentcourses.Add(temp.val);
                }
                student_list.Add(student);
                string studentfile = "student_file.bin";

                //serialize
                using (Stream stream = File.Open(studentfile, FileMode.Create))
                {
                    var bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, student_list);
                }


                MessageBox.Show(nameBox.ToString() + "Student registered", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Failed To Register "+ exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public student_form()
        {
            InitializeComponent();
            loadcourses = new Linked_List<Course>();
            student_list = new Linked_List<Student>();

            string serializationFile = "course_file.bin";
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                loadcourses = (Linked_List<Course>)bformatter.Deserialize(stream);

            }
            for (ListNode<Course> item_c = loadcourses.getHead(); item_c != null; item_c = item_c.next)
            {
                courseListBox.Items.Add(item_c.val.get_String());
            }

            string studentfile = "student_file.bin";
            using (Stream stream = File.Open(studentfile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                student_list = (Linked_List<Student>)bformatter.Deserialize(stream);

            }
            //foreach(var item in student_list)
            //{
            //    for(int j=0;j<courseListBox.Items.Count;j++)
            //    {
            //        courseListBox.SetItemChecked(j, false);
            //    }
            //    nameBox.Text = item.get_name();
            //    rollnoBox.Text = item.get_rollno();
            //    foreach(var i in item.studentcourses)
            //    {
            //        for(int ind=0;ind<courseListBox.Items.Count;ind++)
            //        {
            //            if(courseListBox.Items[ind].ToString().Equals(i.get_String()))
            //            {
            //                courseListBox.SetItemChecked(ind, true);
            //            }
            //        }
            //    }
            //    MessageBox.Show("done");
            //}


            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch
            {
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            name = "";
            faceLabel.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {

                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);
                    // MessageBox.Show("" + name);
                    // textBox2.Text = name;
                    finalname = name;
                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                faceLabel.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 */

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            pictureBox1.Image = currentFrame.ToBitmap();
            nameLabel.Text = name;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }
    }
}


















