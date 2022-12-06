namespace face
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentBtn = new System.Windows.Forms.Button();
            this.courseBtn = new System.Windows.Forms.Button();
            this.markBtn = new System.Windows.Forms.Button();
            this.delStudentBtn = new System.Windows.Forms.Button();
            this.delCourseBtn = new System.Windows.Forms.Button();
            this.delCourseBox = new System.Windows.Forms.TextBox();
            this.delStudentBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentBtn
            // 
            this.studentBtn.Location = new System.Drawing.Point(301, 94);
            this.studentBtn.Name = "studentBtn";
            this.studentBtn.Size = new System.Drawing.Size(161, 30);
            this.studentBtn.TabIndex = 0;
            this.studentBtn.Text = "Add Student";
            this.studentBtn.UseVisualStyleBackColor = true;
            this.studentBtn.Click += new System.EventHandler(this.studentBtn_Click);
            // 
            // courseBtn
            // 
            this.courseBtn.Location = new System.Drawing.Point(301, 213);
            this.courseBtn.Name = "courseBtn";
            this.courseBtn.Size = new System.Drawing.Size(161, 28);
            this.courseBtn.TabIndex = 1;
            this.courseBtn.Text = "Add Course";
            this.courseBtn.UseVisualStyleBackColor = true;
            this.courseBtn.Click += new System.EventHandler(this.courseBtn_Click);
            // 
            // markBtn
            // 
            this.markBtn.Location = new System.Drawing.Point(301, 322);
            this.markBtn.Name = "markBtn";
            this.markBtn.Size = new System.Drawing.Size(161, 27);
            this.markBtn.TabIndex = 2;
            this.markBtn.Text = "Mark Attendance";
            this.markBtn.UseVisualStyleBackColor = true;
            this.markBtn.Click += new System.EventHandler(this.markBtn_Click);
            // 
            // delStudentBtn
            // 
            this.delStudentBtn.Location = new System.Drawing.Point(301, 159);
            this.delStudentBtn.Name = "delStudentBtn";
            this.delStudentBtn.Size = new System.Drawing.Size(161, 29);
            this.delStudentBtn.TabIndex = 3;
            this.delStudentBtn.Text = "Delete Student";
            this.delStudentBtn.UseVisualStyleBackColor = true;
            this.delStudentBtn.Click += new System.EventHandler(this.delStudentBtn_Click);
            // 
            // delCourseBtn
            // 
            this.delCourseBtn.Location = new System.Drawing.Point(301, 266);
            this.delCourseBtn.Name = "delCourseBtn";
            this.delCourseBtn.Size = new System.Drawing.Size(161, 29);
            this.delCourseBtn.TabIndex = 4;
            this.delCourseBtn.Text = "Delete Course";
            this.delCourseBtn.UseVisualStyleBackColor = true;
            this.delCourseBtn.Click += new System.EventHandler(this.delCourseBtn_Click);
            // 
            // delCourseBox
            // 
            this.delCourseBox.Location = new System.Drawing.Point(514, 266);
            this.delCourseBox.Multiline = true;
            this.delCourseBox.Name = "delCourseBox";
            this.delCourseBox.Size = new System.Drawing.Size(118, 29);
            this.delCourseBox.TabIndex = 5;
            // 
            // delStudentBox
            // 
            this.delStudentBox.Location = new System.Drawing.Point(514, 159);
            this.delStudentBox.Multiline = true;
            this.delStudentBox.Name = "delStudentBox";
            this.delStudentBox.Size = new System.Drawing.Size(118, 29);
            this.delStudentBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.delStudentBox);
            this.Controls.Add(this.delCourseBox);
            this.Controls.Add(this.delCourseBtn);
            this.Controls.Add(this.delStudentBtn);
            this.Controls.Add(this.markBtn);
            this.Controls.Add(this.courseBtn);
            this.Controls.Add(this.studentBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button studentBtn;
        private System.Windows.Forms.Button courseBtn;
        private System.Windows.Forms.Button markBtn;
        private System.Windows.Forms.Button delStudentBtn;
        private System.Windows.Forms.Button delCourseBtn;
        private System.Windows.Forms.TextBox delCourseBox;
        private System.Windows.Forms.TextBox delStudentBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

