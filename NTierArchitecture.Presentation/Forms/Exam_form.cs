using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Presentation.Forms
{
    public partial class Exam_form : Form
    {
        private readonly ExamServices _examServices;
        private readonly StudentServices _studentServices;
        private readonly LessonServices _lessonServices;
        public Exam_form(ExamServices examServices, StudentServices studentServices, LessonServices lessonServices)
        {
            InitializeComponent();
            _examServices = examServices;
            _studentServices = studentServices;
            _lessonServices = lessonServices;
        }

        public Exam_form()
        {
        }

        private void GetAllExams()
        {
            lwExam.Items.Clear();
            var exams = _examServices.GetAll();
            foreach (var exam in exams)
            {
                ListViewItem item = new ListViewItem(exam.ID.ToString());
                item.SubItems.Add(exam.Lesson?.Name);
                item.SubItems.Add(exam.Duration.ToString());
                item.SubItems.Add(exam.Student?.Name);
                item.SubItems.Add(exam.Note.ToString());
                item.SubItems.Add(exam.ExamDate.ToString());
                item.SubItems.Add(exam.IsSecondary ? "2. Sınav" : "1. Sınav");
                lwExam.Items.Add(item);
            }
        }
        private void Exam_form_Load(object sender, EventArgs e)
        {
            GetAllExams();
            cbLesson.DataSource = null;
            cbStudent.DataSource = null;
            cbStudent.DisplayMember = "Name";
            cbLesson.DisplayMember = "Name";
            cbLesson.ValueMember = "ID";
            cbStudent.ValueMember = "ID";
            cbLesson.DataSource = _lessonServices.GetAll();
            cbStudent.DataSource = _studentServices.GetAll();
            cbLesson.SelectedIndex = -1;
            cbStudent.SelectedIndex = -1;
        }

        private void lwExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwExam.SelectedItems.Count > 0)
            {
                int selectedExamId = Convert.ToInt32(lwExam.SelectedItems[0].Text);
                var selectedExam = _examServices.GetById(selectedExamId);
                if (selectedExam != null)
                {
                    cbLesson.SelectedValue = selectedExam.LessonID;
                    cbStudent.SelectedValue = selectedExam.StudentID;
                    tbDurarion.Text = selectedExam.Duration.ToString();
                    tbNote.Text = selectedExam.Note.ToString();
                    dtExamDate.Value = selectedExam.ExamDate;
                    cbSecondExam.Checked = selectedExam.IsSecondary;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Exam exam = new()
            {
                LessonID = (int)cbLesson.SelectedValue,
                StudentID = (int)cbStudent.SelectedValue,
                Duration = int.Parse(tbDurarion.Text),
                Note = float.Parse(tbNote.Text),
                ExamDate = dtExamDate.Value,
                IsSecondary = cbSecondExam.Checked
            };
            _examServices.Create(exam);
            GetAllExams();
        }
    }
}
