
using NTierArchitecture.Business.Services;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Presentation.Forms
{
    public partial class Discontinuity_form : Form
    {
        DiscontinuityServices _discontinuityServices = new(new DiscontinuityRepostory(new AppDbContext()));
        StudentServices _studentServices = new(new StudentRepostory(new AppDbContext()));
        public Discontinuity_form()
        {
            InitializeComponent();
        }
        Discontinuity selectedDiscontinuity = new();
        private void GetDiscontinuities()
        {
            lwDiscontinuity.Items.Clear();
            _discontinuityServices?.GetAll()?.ToList().ForEach(c =>
            {
                lwDiscontinuity.Items.Add(c.ID.ToString());
                lwDiscontinuity.Items[lwDiscontinuity.Items.Count - 1].SubItems.Add(c.Student.Name);
                lwDiscontinuity.Items[lwDiscontinuity.Items.Count - 1].SubItems.Add(c.DateofDiscontinuity.ToString());
                lwDiscontinuity.Items[lwDiscontinuity.Items.Count - 1].SubItems.Add(c.Excuse ? "Özürsüz" : "Özürsüz");
                lwDiscontinuity.Items[lwDiscontinuity.Items.Count - 1].SubItems.Add(c.Days.ToString());
            });
        }
        private void Discontinuity_form_Load(object sender, EventArgs e)
        {
            GetDiscontinuities();
            cbStudent.Items.Clear();
            cbStudent.DataSource = null;
            cbStudent.DisplayMember = "Name";
            cbStudent.ValueMember = "ID";
            cbStudent.DataSource = _studentServices.GetAll();
            cbStudent.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Discontinuity newDiscontinuity = new()
            {
                StudentID = Convert.ToInt32(cbStudent.SelectedValue),
                DateofDiscontinuity = dtDiscontinuityDate.Value,
                Days = Convert.ToInt32(tbDiscontinuityDays.Text),
                Excuse = rbExcuse1.Checked
            };
            _discontinuityServices.Create(newDiscontinuity);
            GetDiscontinuities();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lwDiscontinuity.SelectedItems.Count > 0)
            {
                int selectedDiscontinuityId = Convert.ToInt32(lwDiscontinuity.SelectedItems[0].Text);
                _discontinuityServices.DeleteById(selectedDiscontinuityId);
                GetDiscontinuities();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lwDiscontinuity.SelectedItems.Count > 0)
            {
                int selectedDiscontinuityId = Convert.ToInt32(lwDiscontinuity.SelectedItems[0].Text);
                var selectedDiscontinuity = _discontinuityServices.GetById(selectedDiscontinuityId);
                if (selectedDiscontinuity != null)
                {
                    selectedDiscontinuity.StudentID = Convert.ToInt32(cbStudent.SelectedValue);
                    selectedDiscontinuity.DateofDiscontinuity = dtDiscontinuityDate.Value;
                    selectedDiscontinuity.Days = Convert.ToInt32(tbDiscontinuityDays.Text);
                    selectedDiscontinuity.Excuse = rbExcuse1.Checked;
                    _discontinuityServices.Update(selectedDiscontinuity);
                    GetDiscontinuities();
                }
            }
        }

        private void lwDiscontinuity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lwDiscontinuity.SelectedItems.Count > 0)
            {
                int selectedDiscontinuityId = Convert.ToInt32(lwDiscontinuity.SelectedItems[0].Text);
                var selectedDiscontinuity = _discontinuityServices.GetById(selectedDiscontinuityId);
                if (selectedDiscontinuity != null)
                {
                    cbStudent.SelectedValue = selectedDiscontinuity.StudentID;
                    dtDiscontinuityDate.Value = selectedDiscontinuity.DateofDiscontinuity;
                    tbDiscontinuityDays.Text = selectedDiscontinuity.Days.ToString();
                    rbExcuse1.Checked = selectedDiscontinuity.Excuse;
                    rbExcuse2.Checked = !selectedDiscontinuity.Excuse;
                }
            }
        }
    }
}
