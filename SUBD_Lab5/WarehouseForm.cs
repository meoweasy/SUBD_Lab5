using Logic.BindingModels;
using Logic.ViewModels;
using Logic.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace SUBD_Lab5
{
    public partial class WarehouseForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly WarehousesLogic Vlogic;
        private readonly ShopLogic Flogic;
        private int id;
        public WarehouseForm(WarehousesLogic Vlogic, ShopLogic Flogic)
        {
            InitializeComponent();
            this.Vlogic = Vlogic;
            this.Flogic = Flogic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название класса", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSchool.SelectedValue == null)
            {
                MessageBox.Show("Выберите школу", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                WarehousesBM classes = new WarehousesBM
                {
                    Id = id,
                    Name = textBoxName.Text,
                    ShopId = Convert.ToInt32(comboBoxSchool.SelectedValue),
                };

                Vlogic.CreateOrUpdate(classes);
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ClassesForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ShopVM> list = Flogic.Read(null);
                if (list != null)
                {
                    comboBoxSchool.DisplayMember = "Name";
                    comboBoxSchool.ValueMember = "Id";
                    comboBoxSchool.DataSource = list;
                    comboBoxSchool.SelectedItem = null;
                }
                if (id>0)
                {
                    var view = Vlogic.Read(new WarehousesBM { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        ShopVM city = Flogic.Read(new ShopBM { Name = view.ShopName })?[0];
                        foreach (var currentSchool in list)
                        {
                            if (currentSchool.Name == city.Name)
                            {
                                comboBoxSchool.SelectedItem = currentSchool;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

    }
}
