namespace face
{
    partial class Course_form
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.fallRadioBtn = new System.Windows.Forms.RadioButton();
            this.springRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(314, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Course Name";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(314, 244);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Taught By:";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox3.Location = new System.Drawing.Point(314, 190);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Course Code";
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // fallRadioBtn
            // 
            this.fallRadioBtn.AutoSize = true;
            this.fallRadioBtn.Location = new System.Drawing.Point(6, 18);
            this.fallRadioBtn.Name = "fallRadioBtn";
            this.fallRadioBtn.Size = new System.Drawing.Size(41, 17);
            this.fallRadioBtn.TabIndex = 3;
            this.fallRadioBtn.TabStop = true;
            this.fallRadioBtn.Text = "Fall";
            this.fallRadioBtn.UseVisualStyleBackColor = true;
            // 
            // springRadioBtn
            // 
            this.springRadioBtn.AutoSize = true;
            this.springRadioBtn.Location = new System.Drawing.Point(109, 18);
            this.springRadioBtn.Name = "springRadioBtn";
            this.springRadioBtn.Size = new System.Drawing.Size(55, 17);
            this.springRadioBtn.TabIndex = 4;
            this.springRadioBtn.TabStop = true;
            this.springRadioBtn.Text = "Spring";
            this.springRadioBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fallRadioBtn);
            this.groupBox1.Controls.Add(this.springRadioBtn);
            this.groupBox1.Location = new System.Drawing.Point(293, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 41);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Term";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(339, 299);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(88, 37);
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // Course_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Course_form";
            this.Text = "Course_form";
            this.Load += new System.EventHandler(this.Course_form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton fallRadioBtn;
        private System.Windows.Forms.RadioButton springRadioBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button registerBtn;
    }
}