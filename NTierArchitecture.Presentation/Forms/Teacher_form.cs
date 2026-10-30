using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Presentation.Forms
{
    public partial class Teacher_form : Form
    {
        private readonly TeacherServices _teacherServices;
        private readonly LessonServices _lessonServices;
        public Teacher_form(TeacherServices teacherServices, LessonServices lessonServices)
        {
            InitializeComponent();
            _teacherServices = teacherServices;
            _lessonServices = lessonServices;
        }
        private void GetAllTeachers()
        {
            lwTeacher.Items.Clear();
            _teacherServices?.GetAll()?.ToList().ForEach(c =>
            {
                lwTeacher.Items.Add(c.ID.ToString());
                lwTeacher.Items[lwTeacher.Items.Count - 1].SubItems.Add(c.Name);
                lwTeacher.Items[lwTeacher.Items.Count - 1].SubItems.Add(c.Phone);
                lwTeacher.Items[lwTeacher.Items.Count - 1].SubItems.Add(c.Lesson?.Name);
                lwTeacher.Items[lwTeacher.Items.Count - 1].SubItems.Add(c.Branch ? "Sayısal" : "Sözel");
            });
        }

        private void lwTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwTeacher.SelectedItems.Count > 0)
            {
                int selectedTeacherId = Convert.ToInt32(lwTeacher.SelectedItems[0].Text);
                var selectedTeacher = _teacherServices.GetById(selectedTeacherId);
                if (selectedTeacher != null)
                {
                    tbName.Text = selectedTeacher.Name;
                    tbPhone.Text = selectedTeacher.Phone;
                    cbLesson.SelectedValue = selectedTeacher.LessonID;
                    rbBranch1.Checked = selectedTeacher.Branch;
                    rbBranch2.Checked = !selectedTeacher.Branch;
                }
            }
        }

        private void Teacher_form_Load(object sender, EventArgs e)
        {
            GetAllTeachers();
            cbLesson.Items.Clear();
            cbLesson.DataSource = null;
            cbLesson.DisplayMember = "Name";
            cbLesson.ValueMember = "ID";
            cbLesson.DataSource = _lessonServices.GetAll();
            cbLesson.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher newTeacher = new()
                {
                    Name = tbName.Text,
                    Phone = tbPhone.Text,
                    LessonID = Convert.ToInt32(cbLesson.SelectedValue),
                    Branch = rbBranch1.Checked
                };
                _teacherServices.Create(newTeacher);
                GetAllTeachers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lwTeacher.SelectedItems.Count > 0)
                {
                    int selectedTeacherId = Convert.ToInt32(lwTeacher.SelectedItems[0].Text);
                    _teacherServices.DeleteById(selectedTeacherId);
                    GetAllTeachers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lwTeacher.SelectedItems.Count > 0)
                {
                    int selectedTeacherId = Convert.ToInt32(lwTeacher.SelectedItems[0].Text);
                    var selectedTeacher = _teacherServices.GetById(selectedTeacherId);
                    if (selectedTeacher != null)
                    {
                        selectedTeacher.Name = tbName.Text;
                        selectedTeacher.Phone = tbPhone.Text;
                        selectedTeacher.LessonID = Convert.ToInt32(cbLesson.SelectedValue);
                        selectedTeacher.Branch = rbBranch1.Checked;
                        _teacherServices.Update(selectedTeacher);
                        GetAllTeachers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
