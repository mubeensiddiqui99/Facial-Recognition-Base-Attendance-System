namespace face
{
    partial class Mark_Attendance_Form
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.courseBox = new System.Windows.Forms.ComboBox();
            this.cameraBtn = new System.Windows.Forms.Button();
            this.attendanceBtn = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 309);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // courseBox
            // 
            this.courseBox.FormattingEnabled = true;
            this.courseBox.Location = new System.Drawing.Point(511, 80);
            this.courseBox.Name = "courseBox";
            this.courseBox.Size = new System.Drawing.Size(200, 21);
            this.courseBox.TabIndex = 2;
            // 
            // cameraBtn
            // 
            this.cameraBtn.Location = new System.Drawing.Point(562, 174);
            this.cameraBtn.Name = "cameraBtn";
            this.cameraBtn.Size = new System.Drawing.Size(87, 46);
            this.cameraBtn.TabIndex = 3;
            this.cameraBtn.Text = "Camera: Off";
            this.cameraBtn.UseVisualStyleBackColor = true;
            this.cameraBtn.Click += new System.EventHandler(this.cameraBtn_Click);
            // 
            // attendanceBtn
            // 
            this.attendanceBtn.Location = new System.Drawing.Point(562, 282);
            this.attendanceBtn.Name = "attendanceBtn";
            this.attendanceBtn.Size = new System.Drawing.Size(87, 46);
            this.attendanceBtn.TabIndex = 4;
            this.attendanceBtn.Text = "Mark Attendance";
            this.attendanceBtn.UseVisualStyleBackColor = true;
            this.attendanceBtn.Click += new System.EventHandler(this.attendanceBtn_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.Red;
            this.idLabel.Location = new System.Drawing.Point(22, 373);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(60, 16);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "idLabel";
            // 
            // Mark_Attendance_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.attendanceBtn);
            this.Controls.Add(this.cameraBtn);
            this.Controls.Add(this.courseBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Mark_Attendance_Form";
            this.Text = "Mark_Attendance_Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox courseBox;
        private System.Windows.Forms.Button cameraBtn;
        private System.Windows.Forms.Button attendanceBtn;
        private System.Windows.Forms.Label idLabel;
    }
}