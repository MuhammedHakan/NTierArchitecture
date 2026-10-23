namespace NTierArchitecture.Presentation
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClassManegmentForm = new Button();
            btnStudent = new Button();
            btnLesson = new Button();
            btnTeacher = new Button();
            btnDiscontinuity = new Button();
            btnExam = new Button();
            SuspendLayout();
            // 
            // btnClassManegmentForm
            // 
            btnClassManegmentForm.Location = new Point(650, 47);
            btnClassManegmentForm.Name = "btnClassManegmentForm";
            btnClassManegmentForm.Size = new Size(94, 29);
            btnClassManegmentForm.TabIndex = 0;
            btnClassManegmentForm.Text = "Sınıf GİRİŞ";
            btnClassManegmentForm.UseVisualStyleBackColor = true;
            btnClassManegmentForm.Click += btnClassManegmentForm_Click;
            // 
            // btnStudent
            // 
            btnStudent.Location = new Point(633, 101);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(111, 29);
            btnStudent.TabIndex = 1;
            btnStudent.Text = "Öğrenci GİRİŞ";
            btnStudent.UseVisualStyleBackColor = true;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnLesson
            // 
            btnLesson.Location = new Point(650, 158);
            btnLesson.Name = "btnLesson";
            btnLesson.Size = new Size(94, 29);
            btnLesson.TabIndex = 2;
            btnLesson.Text = "Ders GİRİŞ";
            btnLesson.UseVisualStyleBackColor = true;
            btnLesson.Click += btnLesson_Click;
            // 
            // btnTeacher
            // 
            btnTeacher.Location = new Point(620, 212);
            btnTeacher.Name = "btnTeacher";
            btnTeacher.Size = new Size(124, 29);
            btnTeacher.TabIndex = 3;
            btnTeacher.Text = "Öğretmen GİRİŞ";
            btnTeacher.UseVisualStyleBackColor = true;
            btnTeacher.Click += btnTeacher_Click;
            // 
            // btnDiscontinuity
            // 
            btnDiscontinuity.Location = new Point(606, 263);
            btnDiscontinuity.Name = "btnDiscontinuity";
            btnDiscontinuity.Size = new Size(138, 29);
            btnDiscontinuity.TabIndex = 4;
            btnDiscontinuity.Text = "Devamsızlık GİRİŞ";
            btnDiscontinuity.UseVisualStyleBackColor = true;
            btnDiscontinuity.Click += btnDiscontinuity_Click;
            // 
            // btnExam
            // 
            btnExam.Location = new Point(650, 309);
            btnExam.Name = "btnExam";
            btnExam.Size = new Size(94, 29);
            btnExam.TabIndex = 5;
            btnExam.Text = "Sınav GİRİŞ";
            btnExam.UseVisualStyleBackColor = true;
            btnExam.Click += btnExam_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExam);
            Controls.Add(btnDiscontinuity);
            Controls.Add(btnTeacher);
            Controls.Add(btnLesson);
            Controls.Add(btnStudent);
            Controls.Add(btnClassManegmentForm);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClassManegmentForm;
        private Button btnStudent;
        private Button btnLesson;
        private Button btnTeacher;
        private Button btnDiscontinuity;
        private Button btnExam;
    }
}
