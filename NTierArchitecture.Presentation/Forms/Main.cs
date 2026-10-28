
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.Presentation.Forms;

namespace NTierArchitecture.Presentation
{
    public partial class Main : Form
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public Main(IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _scopeFactory = scopeFactory;
        }

        private void OpenForm<TForm>() where TForm : Form
        {
            var scope = _scopeFactory.CreateScope();

            try
            {
                var form = scope.ServiceProvider
                    .GetRequiredService<TForm>();

                form.FormClosed += (s, e) => scope.Dispose();
                form.Show();
            }
            catch
            {
                scope.Dispose();
                throw;
            }
        }

        private void btnClassManegmentForm_Click(
            object sender, EventArgs e)
        {
            OpenForm<ClassForm>();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenForm<Student_form>();
        }

        private void btnLesson_Click(object sender, EventArgs e)
        {
            OpenForm<Lesson_form>();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            OpenForm<Teacher_form>();
        }

        private void btnDiscontinuity_Click(
            object sender, EventArgs e)
        {
            OpenForm<Discontinuity_form>();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            OpenForm<Exam_form>();
        }
    }
}
