using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Presentation.Forms
{
    public partial class Student_form : Form
    {
        StudentServices _studentServices = new(new StudentRepostory(new AppDbContext()));
        ClassServices _classServices = new(new ClassRepostory(new AppDbContext()));
        public Student_form()
        {
            InitializeComponent();
        }
        Student selectedStudent = new();
        private void GetStudents()
        {
            lwLesson.Items.Clear();
            _studentServices?.GetAll()?.ToList().ForEach(c =>
            {
                lwLesson.Items.Add(c.ID.ToString());
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.Name);
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.Phone);
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.Class?.Name);
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.DateOfBirth.ToString());
                lwLesson.Items[lwLesson.Items.Count - 1].SubItems.Add(c.Gender ? "Erkek" : "Kız");
            });

        }
        private void Student_form_Load(object sender, EventArgs e)
        {
            GetStudents();
            cbStudentClass.Items.Clear();
            cbStudentClass.DataSource = null;
            cbStudentClass.DisplayMember = "Name";
            cbStudentClass.ValueMember = "ID";
            cbStudentClass.DataSource = _classServices.GetAll();
            cbStudentClass.SelectedIndex = -1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student newStudent = new()
            {
                Name = tbStudentName.Text,
                Phone = tbStudent.Text,
                ClassID = Convert.ToInt32(cbStudentClass.SelectedValue),
                DateOfBirth = dateTimePicker1.Value,
                Gender = rbStudentMale.Checked
            };
            _studentServices.Create(newStudent);
            GetStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lwLesson.SelectedItems.Count > 0)
            {
                Student selectedStudent = _studentServices.GetById(Convert.ToInt32(lwLesson.SelectedItems[0].Text));
                _studentServices.DeleteById(selectedStudent!.ID);
                GetStudents();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (selectedStudent != null)
                {
                    selectedStudent.Name = tbStudentName.Text;
                    selectedStudent.Phone = tbStudent.Text;
                    selectedStudent.ClassID = Convert.ToInt32(cbStudentClass.SelectedValue);
                    selectedStudent.DateOfBirth = dateTimePicker1.Value;
                    selectedStudent.Gender = rbStudentMale.Checked;
                    _studentServices.Update(selectedStudent);
                    GetStudents();
                }

            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        private void lwStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwLesson.SelectedItems.Count > 0) selectedStudent = _studentServices.GetById(Convert.ToInt32(lwLesson.SelectedItems[0].Text));
            if (selectedStudent != null)
            {
                tbStudentName.Text = selectedStudent.Name;
                tbStudent.Text = selectedStudent.Phone;
                cbStudentClass.SelectedValue = selectedStudent.ClassID;
                dateTimePicker1.Value = selectedStudent.DateOfBirth;
                rbStudentMale.Checked = selectedStudent.Gender;
                rbStudentFemale.Checked = !selectedStudent.Gender;
            }
        }
    }
}
