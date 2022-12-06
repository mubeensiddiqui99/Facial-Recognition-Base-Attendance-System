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
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;

namespace face
{
    public partial class Mark_Attendance_Form : Form
    {
        Student std;
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

        private void cameraBtn_Click(object sender, EventArgs e)
        {
            cameraBtn.Text = "Camera: On";
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            cameraBtn.Enabled = false;
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            if(courseBox.Text=="Subject")
            {
                MessageBox.Show("All entries must be filled");
            }
            else if(cameraBtn.Text=="Camera: Off")
            {
                MessageBox.Show("Can not mark attendance. Please open camera");
            }
            else if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Can not mark attendance. Person not recognized");
            }
            else
            {
                BinarySearchTree bst = new BinarySearchTree();
                for (ListNode<Student> temp = student_list.getHead(); temp != null; temp = temp.next)
                {
                    bst.Insert(temp.val);
                }
                BinNode bstnode = bst.FindByValue(name);
                std = bstnode.data;

                string attendance_file = courseBox.Text + " " + DateTime.Now.ToString("d-M-yyyy") + ".xls";
                if (File.Exists(attendance_file))
                {
                    // open xls file
                    Workbook book = Workbook.Load(attendance_file);
                    Worksheet sheet = book.Worksheets[0];

                    // traverse rows by Index 
                    for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);
                        if(row.GetCell(0).ToString().Equals(name))
                        {
                            row.SetCell(2, new Cell("Present"));
                        }
                        for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                        {
                            Cell cell = row.GetCell(colIndex);
                        }
                    }

                    book.Save(attendance_file);
                }
                else
                {
                    //create new xls file
                    Workbook workbook = new Workbook();
                    Worksheet worksheet = new Worksheet("First Sheet");
                    worksheet.Cells.ColumnWidth[0, 0] = 6000;
                    worksheet.Cells.ColumnWidth[0, 1] = 6000;
                    worksheet.Cells.ColumnWidth[0, 2] = 6000;
                    worksheet.Cells[0, 0] = new Cell("Roll Number");
                    worksheet.Cells[0, 1] = new Cell("Name");
                    worksheet.Cells[0, 2] = new Cell("Attendance");
                    for (ListNode<Student> temp = student_list.getHead(); temp != null; temp = temp.next)
                    {
                        if (name.Equals(temp.val.get_rollno()))
                        {
                            int r = worksheet.Cells.LastRowIndex;
                            worksheet.Cells[r + 1, 0] = new Cell(temp.val.get_rollno());
                            worksheet.Cells[r + 1, 1] = new Cell(temp.val.get_name());
                            worksheet.Cells[r + 1, 2] = new Cell("Present");
                        }
                        else
                        {
                            int r = worksheet.Cells.LastRowIndex;
                            worksheet.Cells[r + 1, 0] = new Cell(temp.val.get_rollno());
                            worksheet.Cells[r + 1, 1] = new Cell(temp.val.get_name());
                            worksheet.Cells[r + 1, 2] = new Cell("Absent");
                        }
                    }
                    workbook.Worksheets.Add(worksheet);
                    workbook.Save(attendance_file);
                }
                MessageBox.Show("Attendance Marked Successfully");
                this.Hide();
                this.Close();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                // traverse cells 
                //foreach (Pair, Cell > cell in sheet.Cells) 
                //{ 
                //    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
                //}
            }
        }

        string name, names = null;

        public Mark_Attendance_Form()
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
            for(ListNode<Course> temp=loadcourses.getHead();temp!=null;temp=temp.next)
            {
                courseBox.Items.Add(temp.val.get_String());
            }
            
            courseBox.Text = "Subject";
            idLabel.Text = "";


            string studentfile = "student_file.bin";
            using (Stream stream = File.Open(studentfile, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();

                student_list = (Linked_List<Student>)bformatter.Deserialize(stream);

            }

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
            idLabel.Text = name;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }
    }
}
