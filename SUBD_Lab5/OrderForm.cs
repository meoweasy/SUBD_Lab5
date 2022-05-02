using Logic.BindingModels;
using Logic.ViewModels;
using Logic.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace SUBD_Lab5
{
    public partial class OrderForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly OrdersLogic Vlogic;
        private readonly ProductLogic Flogic;
        private int id;
        public OrderForm(OrdersLogic Vlogic, ProductLogic Flogic)
        {
            InitializeComponent();
            this.Vlogic = Vlogic;
            this.Flogic = Flogic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSubject.Text))
            {
                MessageBox.Show("Введите название предмета", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDate.Text))
            {
                MessageBox.Show("Введите дату", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Введите цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRemark.Text))
            {
                MessageBox.Show("Введите замечание", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStudent.SelectedValue == null)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }

            try
            {
                OrdersBM classes = new OrdersBM
                {
                    Id = id,
                    PeopleName = textBoxSubject.Text,
                    Date = DateTime.Parse(textBoxDate.Text),
                    ProductId = Convert.ToInt32(comboBoxStudent.SelectedValue),
                    Price = Convert.ToInt32(textBoxPrice.Text),
                    Remark = textBoxRemark.Text,
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

        private void AdvancementsForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductVM> list = Flogic.Read(null);
                if (list != null)
                {
                    comboBoxStudent.DisplayMember = "Name";
                    comboBoxStudent.ValueMember = "Id";
                    comboBoxStudent.DataSource = list;
                    comboBoxStudent.SelectedItem = null;
                }
                if (id > 0)
                {
                    var view = Vlogic.Read(new OrdersBM { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxSubject.Text = view.PeopleName;
                        textBoxDate.Text = view.Date.ToString();
                        ProductVM city = Flogic.Read(new ProductBM { Name = view.ProductName })?[0];
                        foreach (var currentStudent in list)
                        {
                            if (currentStudent.Name == city.Name)
                            {
                                comboBoxStudent.SelectedItem = currentStudent;
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
