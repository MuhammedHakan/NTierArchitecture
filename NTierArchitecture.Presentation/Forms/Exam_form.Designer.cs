namespace NTierArchitecture.Presentation.Forms
{
    partial class Exam_form
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
            lwExam = new ListView();
            cID = new ColumnHeader();
            cExamLesson = new ColumnHeader();
            cExamDuration = new ColumnHeader();
            cExamStudent = new ColumnHeader();
            cExamNote = new ColumnHeader();
            cExamDate = new ColumnHeader();
            cSecondaryExam = new ColumnHeader();
            label1 = new Label();
            cbLesson = new ComboBox();
            tbDurarion = new TextBox();
            btnUpdate = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbStudent = new ComboBox();
            dtExamDate = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            cbSecondExam = new CheckBox();
            btnDelete = new Button();
            btnSave = new Button();
            tbNote = new TextBox();
            SuspendLayout();
            // 
            // lwExam
            // 
            lwExam.Activation = ItemActivation.OneClick;
            lwExam.Columns.AddRange(new ColumnHeader[] { cID, cExamLesson, cExamDuration, cExamStudent, cExamNote, cExamDate, cSecondaryExam });
            lwExam.FullRowSelect = true;
            lwExam.HotTracking = true;
            lwExam.HoverSelection = true;
            lwExam.Location = new Point(269, 12);
            lwExam.MultiSelect = false;
            lwExam.Name = "lwExam";
            lwExam.Size = new Size(519, 215);
            lwExam.TabIndex = 3;
            lwExam.UseCompatibleStateImageBehavior = false;
            lwExam.View = View.Details;
            lwExam.SelectedIndexChanged += lwExam_SelectedIndexChanged;
            // 
            // cID
            // 
            cID.Text = "ID";
            // 
            // cExamLesson
            // 
            cExamLesson.Text = "Name";
            // 
            // cExamDuration
            // 
            cExamDuration.Text = "Duration";
            // 
            // cExamStudent
            // 
            cExamStudent.Text = "Student";
            // 
            // cExamNote
            // 
            cExamNote.Text = "Note";
            // 
            // cExamDate
            // 
            cExamDate.Text = "Date";
            // 
            // cSecondaryExam
            // 
            cSecondaryExam.Text = "first or secondary";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 4;
            label1.Text = "Lesson";
            // 
            // cbLesson
            // 
            cbLesson.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLesson.FormattingEnabled = true;
            cbLesson.Location = new Point(12, 35);
            cbLesson.Name = "cbLesson";
            cbLesson.Size = new Size(151, 28);
            cbLesson.TabIndex = 15;
            // 
            // tbDurarion
            // 
            tbDurarion.Location = new Point(12, 89);
            tbDurarion.Name = "tbDurarion";
            tbDurarion.Size = new Size(125, 27);
            tbDurarion.TabIndex = 16;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(503, 294);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 173);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 19;
            label2.Text = "Öğrencinin Puan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 20;
            label3.Text = "Öğrenci";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 66);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 21;
            label4.Text = "Süre";
            // 
            // cbStudent
            // 
            cbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent.FormattingEnabled = true;
            cbStudent.Location = new Point(12, 142);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(151, 28);
            cbStudent.TabIndex = 22;
            // 
            // dtExamDate
            // 
            dtExamDate.Location = new Point(12, 249);
            dtExamDate.Name = "dtExamDate";
            dtExamDate.Size = new Size(250, 27);
            dtExamDate.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 226);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 25;
            label5.Text = "Tarih";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 303);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 26;
            // 
            // cbSecondExam
            // 
            cbSecondExam.AutoSize = true;
            cbSecondExam.Location = new Point(12, 294);
            cbSecondExam.Name = "cbSecondExam";
            cbSecondExam.Size = new Size(105, 24);
            cbSecondExam.TabIndex = 27;
            cbSecondExam.Text = "2.Sınav mı?";
            cbSecondExam.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(503, 329);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 28;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(503, 364);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 29;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbNote
            // 
            tbNote.Location = new Point(12, 196);
            tbNote.Name = "tbNote";
            tbNote.Size = new Size(125, 27);
            tbNote.TabIndex = 30;
            // 
            // Exam_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbNote);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(cbSecondExam);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtExamDate);
            Controls.Add(cbStudent);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnUpdate);
            Controls.Add(tbDurarion);
            Controls.Add(cbLesson);
            Controls.Add(label1);
            Controls.Add(lwExam);
            Name = "Exam_form";
            Text = "Exam_form";
            Load += Exam_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lwExam;
        private ColumnHeader cID;
        private ColumnHeader cExamStudent;
        private ColumnHeader cExamNote;
        private ColumnHeader cExamDate;
        private ColumnHeader cSecondaryExam;
        private ColumnHeader cExamLesson;
        private ColumnHeader cExamDuration;
        private Label label1;
        private ComboBox cbLesson;
        private TextBox tbDurarion;
        private Button btnUpdate;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbStudent;
        private TextBox textBox2;
        private DateTimePicker dtExamDate;
        private Label label5;
        private Label label6;
        private CheckBox cbSecondExam;
        private Button btnDelete;
        private Button btnSave;
        private TextBox tbNote;
    }
}