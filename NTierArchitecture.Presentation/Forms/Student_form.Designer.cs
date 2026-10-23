namespace NTierArchitecture.Presentation.Forms
{
    partial class Student_form
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
            btnSave = new Button();
            btnDelete = new Button();
            tbStudent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnUpdate = new Button();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            tbStudentName = new TextBox();
            label5 = new Label();
            cbStudentClass = new ComboBox();
            cID = new ColumnHeader();
            cStudentName = new ColumnHeader();
            cStudentPhone = new ColumnHeader();
            cStudentClass = new ColumnHeader();
            cStudentDateOfBirth = new ColumnHeader();
            cStudentGender = new ColumnHeader();
            lwLesson = new ListView();
            cStudentDiscontinuity = new ColumnHeader();
            rbStudentFemale = new RadioButton();
            label4 = new Label();
            rbStudentMale = new RadioButton();
            tbError = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(616, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(616, 340);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbStudent
            // 
            tbStudent.Location = new Point(21, 97);
            tbStudent.Name = "tbStudent";
            tbStudent.PlaceholderText = "(XXX) XXX XXXX";
            tbStudent.Size = new Size(125, 27);
            tbStudent.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 12);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 5;
            label1.Text = "Ad Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 65);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 6;
            label2.Text = "Telefon Numarası";
            label2.Click += label2_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(616, 286);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(20, 204);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 181);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 9;
            label3.Text = "Doğum Tarihi";
            // 
            // tbStudentName
            // 
            tbStudentName.Location = new Point(20, 35);
            tbStudentName.Name = "tbStudentName";
            tbStudentName.Size = new Size(125, 27);
            tbStudentName.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 127);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 13;
            label5.Text = "Sınıf";
            // 
            // cbStudentClass
            // 
            cbStudentClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudentClass.FormattingEnabled = true;
            cbStudentClass.Location = new Point(19, 150);
            cbStudentClass.Name = "cbStudentClass";
            cbStudentClass.Size = new Size(151, 28);
            cbStudentClass.TabIndex = 14;
            // 
            // cID
            // 
            cID.Text = "ID";
            // 
            // cStudentName
            // 
            cStudentName.Text = "Name";
            // 
            // cStudentPhone
            // 
            cStudentPhone.Text = "Phone";
            // 
            // cStudentClass
            // 
            cStudentClass.Text = "Class";
            // 
            // cStudentDateOfBirth
            // 
            cStudentDateOfBirth.Text = "Date";
            // 
            // cStudentGender
            // 
            cStudentGender.Text = "Gender";
            // 
            // lwLesson
            // 
            lwLesson.Activation = ItemActivation.OneClick;
            lwLesson.Columns.AddRange(new ColumnHeader[] { cID, cStudentName, cStudentPhone, cStudentClass, cStudentDateOfBirth, cStudentGender, cStudentDiscontinuity });
            lwLesson.FullRowSelect = true;
            lwLesson.HotTracking = true;
            lwLesson.HoverSelection = true;
            lwLesson.Location = new Point(269, 12);
            lwLesson.MultiSelect = false;
            lwLesson.Name = "lwLesson";
            lwLesson.Size = new Size(519, 215);
            lwLesson.TabIndex = 2;
            lwLesson.UseCompatibleStateImageBehavior = false;
            lwLesson.View = View.Details;
            lwLesson.SelectedIndexChanged += lwStudent_SelectedIndexChanged;
            // 
            // cStudentDiscontinuity
            // 
            cStudentDiscontinuity.Text = "Discontinuity";
            // 
            // rbStudentFemale
            // 
            rbStudentFemale.AutoSize = true;
            rbStudentFemale.Location = new Point(21, 288);
            rbStudentFemale.Name = "rbStudentFemale";
            rbStudentFemale.Size = new Size(50, 24);
            rbStudentFemale.TabIndex = 16;
            rbStudentFemale.TabStop = true;
            rbStudentFemale.Text = "Kız";
            rbStudentFemale.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 234);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 11;
            label4.Text = "Cinsiyet";
            // 
            // rbStudentMale
            // 
            rbStudentMale.AutoSize = true;
            rbStudentMale.Location = new Point(21, 258);
            rbStudentMale.Name = "rbStudentMale";
            rbStudentMale.Size = new Size(65, 24);
            rbStudentMale.TabIndex = 17;
            rbStudentMale.TabStop = true;
            rbStudentMale.Text = "Erkek";
            rbStudentMale.UseVisualStyleBackColor = true;
            // 
            // tbError
            // 
            tbError.Location = new Point(243, 284);
            tbError.Multiline = true;
            tbError.Name = "tbError";
            tbError.Size = new Size(212, 85);
            tbError.TabIndex = 18;
            // 
            // Student_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbError);
            Controls.Add(rbStudentMale);
            Controls.Add(rbStudentFemale);
            Controls.Add(cbStudentClass);
            Controls.Add(label5);
            Controls.Add(tbStudentName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnUpdate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbStudent);
            Controls.Add(lwLesson);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Name = "Student_form";
            Text = "Student_form";
            Load += Student_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnDelete;
        private TextBox textBox1;
        private TextBox tbStudent;
        private Label label1;
        private Label label2;
        private Button btnUpdate;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox tbStudentName;
        private Label label5;
        private ComboBox cbStudentClass;
        private ColumnHeader cID;
        private ColumnHeader cStudentName;
        private ColumnHeader cStudentPhone;
        private ColumnHeader cStudentClass;
        private ColumnHeader cStudentDateOfBirth;
        private ColumnHeader cStudentGender;
        private ListView lwLesson;
        private ColumnHeader cStudentDiscontinuity;
        private RadioButton radioButton1;
        private RadioButton rbStudentFemale;
        private Label label4;
        private RadioButton rbStudentMale;
        private TextBox tbError;
    }
}