namespace NTierArchitecture.Presentation.Forms
{
    partial class Lesson_form
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
            lwLesson = new ListView();
            cID = new ColumnHeader();
            cLessonName = new ColumnHeader();
            cLessonWeeklyHour = new ColumnHeader();
            tbLessonName = new TextBox();
            tbWeeklyHour = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lwLesson
            // 
            lwLesson.Activation = ItemActivation.OneClick;
            lwLesson.Columns.AddRange(new ColumnHeader[] { cID, cLessonName, cLessonWeeklyHour });
            lwLesson.FullRowSelect = true;
            lwLesson.HotTracking = true;
            lwLesson.HoverSelection = true;
            lwLesson.Location = new Point(269, 12);
            lwLesson.MultiSelect = false;
            lwLesson.Name = "lwLesson";
            lwLesson.Size = new Size(519, 215);
            lwLesson.TabIndex = 3;
            lwLesson.UseCompatibleStateImageBehavior = false;
            lwLesson.View = View.Details;
            lwLesson.SelectedIndexChanged += lwLesson_SelectedIndexChanged;
            // 
            // cID
            // 
            cID.Text = "ID";
            // 
            // cLessonName
            // 
            cLessonName.Text = "Lesson";
            // 
            // cLessonWeeklyHour
            // 
            cLessonWeeklyHour.Text = "WeeklyHour";
            // 
            // tbLessonName
            // 
            tbLessonName.Location = new Point(41, 44);
            tbLessonName.Name = "tbLessonName";
            tbLessonName.Size = new Size(125, 27);
            tbLessonName.TabIndex = 4;
            // 
            // tbWeeklyHour
            // 
            tbWeeklyHour.Location = new Point(41, 152);
            tbWeeklyHour.Name = "tbWeeklyHour";
            tbWeeklyHour.Size = new Size(125, 27);
            tbWeeklyHour.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 129);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 6;
            label1.Text = "HaftalıkSaat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 21);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 7;
            label2.Text = "Ders Adı";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(562, 331);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(562, 389);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(562, 279);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Lesson_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbWeeklyHour);
            Controls.Add(tbLessonName);
            Controls.Add(lwLesson);
            Name = "Lesson_form";
            Text = "Lesson_form";
            Load += Lesson_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lwLesson;
        private ColumnHeader cID;
        private ColumnHeader cLessonName;
        private ColumnHeader cLessonWeeklyHour;
        private TextBox tbLessonName;
        private TextBox tbWeeklyHour;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button btnDelete;
        private Button btnSave;
        private Button btnUpdate;
    }
}