namespace face
{
    partial class student_form
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.rollnoBox = new System.Windows.Forms.TextBox();
            this.captureBtn = new System.Windows.Forms.Button();
            this.trainBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.faceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.courseListBox = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nameBox
            // 
            this.nameBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.nameBox.Location = new System.Drawing.Point(397, 30);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(127, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.Text = "Enter Name";
            this.nameBox.Click += new System.EventHandler(this.nameBox_Click);
            // 
            // rollnoBox
            // 
            this.rollnoBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rollnoBox.Location = new System.Drawing.Point(397, 72);
            this.rollnoBox.Name = "rollnoBox";
            this.rollnoBox.Size = new System.Drawing.Size(127, 20);
            this.rollnoBox.TabIndex = 2;
            this.rollnoBox.Text = "Enter Roll Number";
            this.rollnoBox.Click += new System.EventHandler(this.rollnoBox_Click);
            // 
            // captureBtn
            // 
            this.captureBtn.Location = new System.Drawing.Point(397, 229);
            this.captureBtn.Name = "captureBtn";
            this.captureBtn.Size = new System.Drawing.Size(127, 36);
            this.captureBtn.TabIndex = 4;
            this.captureBtn.Text = "Capture";
            this.captureBtn.UseVisualStyleBackColor = true;
            this.captureBtn.Click += new System.EventHandler(this.captureBtn_Click);
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(397, 294);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(127, 36);
            this.trainBtn.TabIndex = 5;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(598, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(162, 168);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Faces Detected:";
            // 
            // faceLabel
            // 
            this.faceLabel.AutoSize = true;
            this.faceLabel.Location = new System.Drawing.Point(135, 287);
            this.faceLabel.Name = "faceLabel";
            this.faceLabel.Size = new System.Drawing.Size(39, 13);
            this.faceLabel.TabIndex = 8;
            this.faceLabel.Text = "Label2";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.Red;
            this.nameLabel.Location = new System.Drawing.Point(31, 317);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "label2";
            this.nameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // courseListBox
            // 
            this.courseListBox.FormattingEnabled = true;
            this.courseListBox.HorizontalScrollbar = true;
            this.courseListBox.Location = new System.Drawing.Point(397, 104);
            this.courseListBox.Name = "courseListBox";
            this.courseListBox.Size = new System.Drawing.Size(127, 109);
            this.courseListBox.TabIndex = 10;
            // 
            // student_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.courseListBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.faceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.captureBtn);
            this.Controls.Add(this.rollnoBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "student_form";
            this.Text = "student_form";
            this.Load += new System.EventHandler(this.student_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox rollnoBox;
        private System.Windows.Forms.Button captureBtn;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label faceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckedListBox courseListBox;
    }
}