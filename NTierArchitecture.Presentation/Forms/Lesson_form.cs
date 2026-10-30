using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Presentation.Forms
{
    public partial class Lesson_form : Form
    {
        private readonly LessonServices _lessonServices;
        public Lesson_form(LessonServices _lessonServices)
        {
            InitializeComponent();
            this._lessonServices = _lessonServices;
        }

        private void GetLessons()
        {
            lwLesson.Items.Clear();
            _lessonServices?.GetAll()?.ToList().ForEach(c =>
            {
                lwLesson.Items.Add(c.ID.ToString());
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.Name);
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.WeeklyHour.ToString());
            });

        }
        private void lwLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwLesson.SelectedItems.Count > 0)
            {
                int selectedLessonId = Convert.ToInt32(lwLesson.SelectedItems[0].Text);
                Lesson selectedLesson = _lessonServices.GetById(selectedLessonId);
                if (selectedLesson != null)
                {
                    tbLessonName.Text = selectedLesson.Name;
                    tbWeeklyHour.Text = selectedLesson.WeeklyHour.ToString();
                }
            }
        }

        private void Lesson_form_Load(object sender, EventArgs e)
        {
            GetLessons();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Lesson newLesson = new()
                {
                    Name = tbLessonName.Text,
                    WeeklyHour = Convert.ToInt32(tbWeeklyHour.Text)
                };
                _lessonServices.Create(newLesson);
                GetLessons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lwLesson.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected lesson?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int selectedLessonId = Convert.ToInt32(lwLesson.SelectedItems[0].Text);
                        _lessonServices.DeleteById(selectedLessonId);
                        GetLessons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedLessonId = Convert.ToInt32(lwLesson.SelectedItems[0].Text);
                Lesson lessonToUpdate = _lessonServices.GetById(selectedLessonId);
                if (lessonToUpdate != null)
                {
                    lessonToUpdate.Name = tbLessonName.Text;
                    lessonToUpdate.WeeklyHour = Convert.ToInt32(tbWeeklyHour.Text);
                    _lessonServices.Update(lessonToUpdate);
                    GetLessons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
