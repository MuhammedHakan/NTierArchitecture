namespace NTierArchitecture.Presentation.Forms
{
    partial class Discontinuity_form
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
            lwDiscontinuity = new ListView();
            cID = new ColumnHeader();
            cDiscontinuiyStudent = new ColumnHeader();
            cDiscontinuityDate = new ColumnHeader();
            cDiscontinuityExcuse = new ColumnHeader();
            label1 = new Label();
            cbStudent = new ComboBox();
            label2 = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dtDiscontinuityDate = new DateTimePicker();
            rbExcuse1 = new RadioButton();
            label3 = new Label();
            rbExcuse2 = new RadioButton();
            label4 = new Label();
            tbDiscontinuityDays = new TextBox();
            cDiscontinuityDays = new ColumnHeader();
            SuspendLayout();
            // 
            // lwDiscontinuity
            // 
            lwDiscontinuity.Activation = ItemActivation.OneClick;
            lwDiscontinuity.Columns.AddRange(new ColumnHeader[] { cID, cDiscontinuiyStudent, cDiscontinuityDate, cDiscontinuityExcuse, cDiscontinuityDays });
            lwDiscontinuity.FullRowSelect = true;
            lwDiscontinuity.HotTracking = true;
            lwDiscontinuity.HoverSelection = true;
            lwDiscontinuity.Location = new Point(269, 12);
            lwDiscontinuity.MultiSelect = false;
            lwDiscontinuity.Name = "lwDiscontinuity";
            lwDiscontinuity.Size = new Size(519, 215);
            lwDiscontinuity.TabIndex = 4;
            lwDiscontinuity.UseCompatibleStateImageBehavior = false;
            lwDiscontinuity.View = View.Details;
            lwDiscontinuity.SelectedIndexChanged += lwDiscontinuity_SelectedIndexChanged;
            // 
            // cID
            // 
            cID.Text = "ID";
            // 
            // cDiscontinuiyStudent
            // 
            cDiscontinuiyStudent.Text = "StudentName";
            // 
            // cDiscontinuityDate
            // 
            cDiscontinuityDate.Text = "DiscontinuityDate";
            // 
            // cDiscontinuityExcuse
            // 
            cDiscontinuityExcuse.Text = "Mazeret";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 5;
            label1.Text = "Öğrenci";
            // 
            // cbStudent
            // 
            cbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent.FormattingEnabled = true;
            cbStudent.Location = new Point(12, 52);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(151, 28);
            cbStudent.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 8;
            label2.Text = "Devamsızlık günü";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(493, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 9;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(493, 288);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(493, 335);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dtDiscontinuityDate
            // 
            dtDiscontinuityDate.Location = new Point(12, 121);
            dtDiscontinuityDate.Name = "dtDiscontinuityDate";
            dtDiscontinuityDate.Size = new Size(250, 27);
            dtDiscontinuityDate.TabIndex = 13;
            // 
            // rbExcuse1
            // 
            rbExcuse1.AutoSize = true;
            rbExcuse1.Location = new Point(20, 291);
            rbExcuse1.Name = "rbExcuse1";
            rbExcuse1.Size = new Size(82, 24);
            rbExcuse1.TabIndex = 14;
            rbExcuse1.TabStop = true;
            rbExcuse1.Text = "Özürsüz";
            rbExcuse1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 255);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 15;
            label3.Text = "Mazeret Durumu";
            // 
            // rbExcuse2
            // 
            rbExcuse2.AutoSize = true;
            rbExcuse2.Location = new Point(20, 321);
            rbExcuse2.Name = "rbExcuse2";
            rbExcuse2.Size = new Size(73, 24);
            rbExcuse2.TabIndex = 16;
            rbExcuse2.TabStop = true;
            rbExcuse2.Text = "Özürlü";
            rbExcuse2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(159, 20);
            label4.TabIndex = 17;
            label4.Text = "Devamsızlık Gün Sayısı";
            // 
            // tbDiscontinuityDays
            // 
            tbDiscontinuityDays.Location = new Point(12, 200);
            tbDiscontinuityDays.Name = "tbDiscontinuityDays";
            tbDiscontinuityDays.Size = new Size(125, 27);
            tbDiscontinuityDays.TabIndex = 18;
            // 
            // cDiscontinuityDays
            // 
            cDiscontinuityDays.Text = "Days";
            // 
            // Discontinuity_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbDiscontinuityDays);
            Controls.Add(label4);
            Controls.Add(rbExcuse2);
            Controls.Add(label3);
            Controls.Add(rbExcuse1);
            Controls.Add(dtDiscontinuityDate);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(cbStudent);
            Controls.Add(label1);
            Controls.Add(lwDiscontinuity);
            Name = "Discontinuity_form";
            Text = "Disconyinuity_form";
            Load += Discontinuity_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private ListView lwDiscontinuity;
        private ColumnHeader cID;
        private ColumnHeader cDiscontinuiyStudent;
        private ColumnHeader cDiscontinuityDate;
        private Label label1;
        private ComboBox cbStudent;
        private Label label2;
        private Button btnSave;
        private Button button2;
        private Button btnUpdate;
        private Button btnDelete;
        private DateTimePicker dtDiscontinuityDate;
        private RadioButton rbExcuse1;
        private Label label3;
        private RadioButton rbExcuse2;
        private ColumnHeader cDiscontinuityExcuse;
        private Label label4;
        private TextBox tbDiscontinuityDays;
        private ColumnHeader cDiscontinuityDays;
    }
}