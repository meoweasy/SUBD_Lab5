using System.Collections.Generic;
using System.ComponentModel;
using Logic.BindingModels;
using Logic.Logic;
using Logic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace SUBD_Lab5
{
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void фирмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CitysForm>();
            form.ShowDialog();
        }


        private void вакансииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ShopsForm>();
            form.ShowDialog();
        }

        private void классыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<WarehousesForm>();
            form.ShowDialog();
        }

        private void студентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ProductsForm>();
            form.ShowDialog();
        }

        private void оценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<OrdersForm>();
            form.ShowDialog();
        }
    }
}
