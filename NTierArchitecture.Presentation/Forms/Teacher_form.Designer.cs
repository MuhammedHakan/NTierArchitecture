namespace NTierArchitecture.Presentation.Forms
{
    partial class Teacher_form
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
            label1 = new Label();
            btnUpdate = new Button();
            tbName = new TextBox();
            btnDelete = new Button();
            btnSave = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lwTeacher = new ListView();
            cID = new ColumnHeader();
            cTeacherName = new ColumnHeader();
            cTeacherPhone = new ColumnHeader();
            cTeacherLesson = new ColumnHeader();
            cTeacherBranch = new ColumnHeader();
            rbBranch1 = new RadioButton();
            rbBranch2 = new RadioButton();
            tbPhone = new TextBox();
            cbLesson = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 36);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad-Soyad";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(539, 257);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // tbName
            // 
            tbName.Location = new Point(60, 59);
            tbName.Name = "tbName";
            tbName.Size = new Size(125, 27);
            tbName.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(539, 312);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(539, 365);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 97);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 6;
            label2.Text = "Telefon";
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 12;
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 159);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 14;
            label5.Text = "Ders";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 220);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 15;
            label6.Text = "Branş";
            // 
            // lwTeacher
            // 
            lwTeacher.Activation = ItemActivation.OneClick;
            lwTeacher.Columns.AddRange(new ColumnHeader[] { cID, cTeacherName, cTeacherPhone, cTeacherLesson, cTeacherBranch });
            lwTeacher.FullRowSelect = true;
            lwTeacher.HotTracking = true;
            lwTeacher.HoverSelection = true;
            lwTeacher.Location = new Point(269, 12);
            lwTeacher.MultiSelect = false;
            lwTeacher.Name = "lwTeacher";
            lwTeacher.Size = new Size(519, 215);
            lwTeacher.TabIndex = 16;
            lwTeacher.UseCompatibleStateImageBehavior = false;
            lwTeacher.View = View.Details;
            lwTeacher.SelectedIndexChanged += lwTeacher_SelectedIndexChanged;
            // 
            // cID
            // 
            cID.Text = "ID";
            // 
            // cTeacherName
            // 
            cTeacherName.Text = "Name";
            // 
            // cTeacherPhone
            // 
            cTeacherPhone.Text = "Phone";
            // 
            // cTeacherLesson
            // 
            cTeacherLesson.Text = "Class";
            // 
            // cTeacherBranch
            // 
            cTeacherBranch.Text = "Branch";
            // 
            // rbBranch1
            // 
            rbBranch1.AutoSize = true;
            rbBranch1.Location = new Point(62, 246);
            rbBranch1.Name = "rbBranch1";
            rbBranch1.Size = new Size(75, 24);
            rbBranch1.TabIndex = 17;
            rbBranch1.TabStop = true;
            rbBranch1.Text = "Sayısal";
            rbBranch1.UseVisualStyleBackColor = true;
            // 
            // rbBranch2
            // 
            rbBranch2.AutoSize = true;
            rbBranch2.Location = new Point(60, 276);
            rbBranch2.Name = "rbBranch2";
            rbBranch2.Size = new Size(66, 24);
            rbBranch2.TabIndex = 18;
            rbBranch2.TabStop = true;
            rbBranch2.Text = "Sözel";
            rbBranch2.UseVisualStyleBackColor = true;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(60, 120);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(125, 27);
            tbPhone.TabIndex = 19;
            // 
            // cbLesson
            // 
            cbLesson.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLesson.FormattingEnabled = true;
            cbLesson.Location = new Point(60, 182);
            cbLesson.Name = "cbLesson";
            cbLesson.Size = new Size(151, 28);
            cbLesson.TabIndex = 20;
            // 
            // Teacher_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbLesson);
            Controls.Add(tbPhone);
            Controls.Add(rbBranch2);
            Controls.Add(rbBranch1);
            Controls.Add(lwTeacher);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(tbName);
            Controls.Add(btnUpdate);
            Controls.Add(label1);
            Name = "Teacher_form";
            Text = "Teacher_form";
            Load += Teacher_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnUpdate;
        private TextBox tbName;
        private Button btnDelete;
        private Button btnSave;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListView lwTeacher;
        private ColumnHeader cID;
        private ColumnHeader cTeacherName;
        private ColumnHeader cTeacherPhone;
        private ColumnHeader cTeacherLesson;
        private ColumnHeader cTeacherBranch;
        private RadioButton rbBranch1;
        private RadioButton rbBranch2;
        private ColumnHeader c;
        private ColumnHeader cStudentDiscontinuity;
        private TextBox tbPhone;
        private ComboBox cbLesson;
    }
}