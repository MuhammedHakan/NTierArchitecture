using NTierArchitecture.Presentation.Forms;

namespace NTierArchitecture.Presentation
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnClassManegmentForm_Click(object sender, EventArgs e)
        {
            ClassForm classForm = new();
            classForm.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student_form studentForm = new();
            studentForm.Show();
        }

        private void btnLesson_Click(object sender, EventArgs e)
        {
            Lesson_form lessonForm = new(); lessonForm.Show();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            Teacher_form teacherForm = new(); teacherForm.Show();
        }

        private void btnDiscontinuity_Click(object sender, EventArgs e)
        {
            Discontinuity_form disconyinuityForm = new(); disconyinuityForm.Show();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            Exam_form examForm = new(); examForm.Show();
        }
    }
}
