using NTierArchitecture.Business.Services;
using NTierArchitecture.Domain.Entities;
namespace NTierArchitecture.Presentation.Forms;

public partial class ClassForm : Form
{

    private readonly ClassServices _classServices;
    public ClassForm(ClassServices classServices)
    {
        InitializeComponent();
        _classServices = classServices;
    }

    int selectedClassId = 0;
    private void GetClasses()
    {
        lvClass.Items.Clear();
        _classServices.GetAll()?.ToList().ForEach(c =>
        {
            lvClass.Items.Add(c.ID.ToString());
            lvClass.Items[lvClass.Items.Count - 1].SubItems.Add(c.Name);
            lvClass.Items[lvClass.Items.Count - 1].SubItems.Add(c.Capacity.ToString());
            lvClass.Items[lvClass.Items.Count - 1].SubItems.Add(c.CreateDate.ToString());
            lvClass.Items[lvClass.Items.Count - 1].SubItems.Add(c.IsActive.ToString());
            lvClass.Items[lvClass.Items.Count - 1].SubItems.Add(c.UpdateDate.ToString());
        });

    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Class newClass = new()
        {
            Name = tbClass.Text,
            Capacity = Convert.ToInt32(tbCapacity.Text)
        };
        _classServices.Create(newClass);
        GetClasses();
    }

    private void ClassForm_Load(object sender, EventArgs e)
    {
        GetClasses();
    }

    private void lvClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvClass.SelectedItems.Count > 0)
        {
            selectedClassId = Convert.ToInt32(lvClass.SelectedItems[0].Text);
            lbSelectedClass.Text = $"Selected Class: {lvClass.SelectedItems[0].SubItems[1].Text}";
            tbCapacity.Text = lvClass.SelectedItems[0].SubItems[2].Text;
            tbClass.Text = lvClass.SelectedItems[0].SubItems[1].Text;
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (selectedClassId > 0)
        {
            _classServices.DeleteById(selectedClassId);
            GetClasses();
            selectedClassId = 0;
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (selectedClassId > 0)
        {
            Class updatedClass = new()
            {
                ID = selectedClassId,
                Name = tbClass.Text,
                Capacity = Convert.ToInt32(tbCapacity.Text)
            };
            _classServices.Update(updatedClass);
            GetClasses();
        }   
    }
}
