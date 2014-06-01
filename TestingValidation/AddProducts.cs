namespace TestingValidation
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Anyo.WindowsForms.Validation;
    using System.Diagnostics;

    public partial class AddProducts : Form
    {
        private Validation addProductValidation;
        private DataTable dataTableProducts = new DataTable();

        public AddProducts()
        {
            InitializeComponent();
            this.addProductValidation = new Validation();

            this.addProductValidation.KindOfValidation(this.ProductName_txt, CheckThatInput.IsText);

            this.addProductValidation.KindOfValidation(this.Categories_comboBox, CheckThatInput.IsText);
            this.addProductValidation.KindOfValidation(this.Vendor_comboBox, CheckThatInput.IsText);
            this.addProductValidation.KindOfValidation(this.Stores_comboBox, CheckThatInput.IsText);
            this.addProductValidation.KindOfValidation(this.Towns_comboBox, CheckThatInput.IsText);

            this.addProductValidation.KindOfValidation(this.UnitPrice_txt, CheckThatInput.IsDecimal);
            this.addProductValidation.KindOfValidation(this.Quantity_txt, CheckThatInput.IsInteger);

            this.addProductValidation.DeactivateControlsDuringValidating(this.insert_btn);
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            this.addProductValidation.RestartValidation();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            this.addProductValidation.RestartValidation();
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            this.addProductValidation.RestartValidation();
        }

        private void AddProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
