using Logic.BindingModels;
using Logic.ViewModels;
using Logic.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace SUBD_Lab5
{
    public partial class ProductForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ProductLogic Vlogic;
        private readonly WarehousesLogic Flogic;
        private int id;
        public ProductForm(ProductLogic Vlogic, WarehousesLogic Flogic)
        {
            InitializeComponent();
            this.Vlogic = Vlogic;
            this.Flogic = Flogic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название школы", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClass.SelectedValue == null)
            {
                MessageBox.Show("Выберите город", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
            try
            {
                ProductBM school = new ProductBM
                {
                    Id = id,
                    Name = textBoxName.Text,
                    WarehouseId = Convert.ToInt32(comboBoxClass.SelectedValue),
                };

                Vlogic.CreateOrUpdate(school);
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

        private void StudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<WarehousesVM> list = Flogic.Read(null);
                if (list != null)
                {
                    comboBoxClass.DisplayMember = "Name";
                    comboBoxClass.ValueMember = "Id";
                    comboBoxClass.DataSource = list;
                    comboBoxClass.SelectedItem = null;
                }
                if (id>0)
                {
                    var view = Vlogic.Read(new ProductBM { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        WarehousesVM city = Flogic.Read(new WarehousesBM { Name = view.WarehouseName })?[0];
                        foreach (var currentClasses in list)
                        {
                            if (currentClasses.Name == city.Name)
                            {
                                comboBoxClass.SelectedItem = currentClasses;
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
