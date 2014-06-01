using System.Windows.Forms;
using System.Drawing;

namespace TestingValidation
{
    partial class AddProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddProducts_panel = new System.Windows.Forms.Panel();
            this.addProduct_label = new System.Windows.Forms.Label();
            this.clear_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.insert_btn = new Anyo.WindowsForms.Controls.Buttons.GradientButton();
            this.Towns_comboBox = new System.Windows.Forms.ComboBox();
            this.Stores_comboBox = new System.Windows.Forms.ComboBox();
            this.Categories_comboBox = new System.Windows.Forms.ComboBox();
            this.Vendor_comboBox = new System.Windows.Forms.ComboBox();
            this.Quantity_label = new System.Windows.Forms.Label();
            this.Quantity_txt = new System.Windows.Forms.TextBox();
            this.UnitPrice_txt = new System.Windows.Forms.TextBox();
            this.ProductName_txt = new System.Windows.Forms.TextBox();
            this.Town_label = new System.Windows.Forms.Label();
            this.Store_label = new System.Windows.Forms.Label();
            this.Category_label = new System.Windows.Forms.Label();
            this.UntitPrice_label = new System.Windows.Forms.Label();
            this.Vendor_label = new System.Windows.Forms.Label();
            this.ProductName_label = new System.Windows.Forms.Label();
            this.AddProducts_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddProducts_panel
            // 
            this.AddProducts_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddProducts_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AddProducts_panel.Controls.Add(this.addProduct_label);
            this.AddProducts_panel.Controls.Add(this.clear_btn);
            this.AddProducts_panel.Controls.Add(this.insert_btn);
            this.AddProducts_panel.Controls.Add(this.Towns_comboBox);
            this.AddProducts_panel.Controls.Add(this.Stores_comboBox);
            this.AddProducts_panel.Controls.Add(this.Categories_comboBox);
            this.AddProducts_panel.Controls.Add(this.Vendor_comboBox);
            this.AddProducts_panel.Controls.Add(this.Quantity_label);
            this.AddProducts_panel.Controls.Add(this.Quantity_txt);
            this.AddProducts_panel.Controls.Add(this.UnitPrice_txt);
            this.AddProducts_panel.Controls.Add(this.ProductName_txt);
            this.AddProducts_panel.Controls.Add(this.Town_label);
            this.AddProducts_panel.Controls.Add(this.Store_label);
            this.AddProducts_panel.Controls.Add(this.Category_label);
            this.AddProducts_panel.Controls.Add(this.UntitPrice_label);
            this.AddProducts_panel.Controls.Add(this.Vendor_label);
            this.AddProducts_panel.Controls.Add(this.ProductName_label);
            this.AddProducts_panel.ForeColor = System.Drawing.Color.White;
            this.AddProducts_panel.Location = new System.Drawing.Point(8, 11);
            this.AddProducts_panel.Name = "AddProducts_panel";
            this.AddProducts_panel.Size = new System.Drawing.Size(254, 340);
            this.AddProducts_panel.TabIndex = 3;
            // 
            // addProduct_label
            // 
            this.addProduct_label.AutoSize = true;
            this.addProduct_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.addProduct_label.CausesValidation = false;
            this.addProduct_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProduct_label.ForeColor = System.Drawing.Color.White;
            this.addProduct_label.Location = new System.Drawing.Point(77, 1);
            this.addProduct_label.Name = "addProduct_label";
            this.addProduct_label.Size = new System.Drawing.Size(93, 16);
            this.addProduct_label.TabIndex = 2;
            this.addProduct_label.Text = "Add Product";
            // 
            // clear_btn
            // 
            this.clear_btn.Active = true;
            this.clear_btn.BorderWidth = 1;
            this.clear_btn.ButtonRadius = 2;
            this.clear_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.clear_btn.CausesValidation = false;
            this.clear_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.clear_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.clear_btn.ClickColorB = System.Drawing.Color.Orange;
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.clear_btn.ForeColor = System.Drawing.Color.Black;
            this.clear_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.clear_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.clear_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.clear_btn.HoverColorB = System.Drawing.Color.Orange;
            this.clear_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.clear_btn.ImageCornerX = 0;
            this.clear_btn.ImageCornerY = 0;
            this.clear_btn.Location = new System.Drawing.Point(121, 244);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.NormalBorderColor = System.Drawing.Color.Black;
            this.clear_btn.NormalColorA = System.Drawing.Color.Orange;
            this.clear_btn.NormalColorB = System.Drawing.Color.PeachPuff;
            this.clear_btn.Size = new System.Drawing.Size(100, 26);
            this.clear_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.clear_btn.TabIndex = 19;
            this.clear_btn.Text = "Clear";
            this.clear_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.clear_btn.TextX = 34.59929F;
            this.clear_btn.TextY = 6.087402F;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // insert_btn
            // 
            this.insert_btn.Active = true;
            this.insert_btn.BorderWidth = 1;
            this.insert_btn.ButtonRadius = 2;
            this.insert_btn.ButtonStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.ButtonStyles.RoundedEdgesRectangel;
            this.insert_btn.ClickBorderColor = System.Drawing.Color.Cornsilk;
            this.insert_btn.ClickColorA = System.Drawing.Color.DarkOrange;
            this.insert_btn.ClickColorB = System.Drawing.Color.Orange;
            this.insert_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.insert_btn.ForeColor = System.Drawing.Color.Black;
            this.insert_btn.GradientStyle = Anyo.WindowsForms.Controls.Buttons.GradientButton.GradientStyles.Vertical;
            this.insert_btn.HoverBorderColor = System.Drawing.Color.Linen;
            this.insert_btn.HoverColorA = System.Drawing.Color.PeachPuff;
            this.insert_btn.HoverColorB = System.Drawing.Color.Orange;
            this.insert_btn.ImageAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.None;
            this.insert_btn.ImageCornerX = 0;
            this.insert_btn.ImageCornerY = 0;
            this.insert_btn.Location = new System.Drawing.Point(66, 275);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.NormalBorderColor = System.Drawing.Color.Black;
            this.insert_btn.NormalColorA = System.Drawing.Color.Orange;
            this.insert_btn.NormalColorB = System.Drawing.Color.PeachPuff;
            this.insert_btn.Size = new System.Drawing.Size(157, 26);
            this.insert_btn.SmoothingQuality = Anyo.WindowsForms.Controls.Buttons.GradientButton.SmoothingQualities.AntiAlias;
            this.insert_btn.TabIndex = 6;
            this.insert_btn.Text = "Save";
            this.insert_btn.TextAlignment = Anyo.WindowsForms.Controls.Buttons.GradientButton.Alignment.Center;
            this.insert_btn.TextX = 63.25456F;
            this.insert_btn.TextY = 6.087402F;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // Towns_comboBox
            // 
            this.Towns_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Towns_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Towns_comboBox.FormattingEnabled = true;
            this.Towns_comboBox.Location = new System.Drawing.Point(93, 214);
            this.Towns_comboBox.Name = "Towns_comboBox";
            this.Towns_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Towns_comboBox.Size = new System.Drawing.Size(130, 21);
            this.Towns_comboBox.TabIndex = 18;
            // 
            // Stores_comboBox
            // 
            this.Stores_comboBox.AllowDrop = true;
            this.Stores_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Stores_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Stores_comboBox.DropDownWidth = 115;
            this.Stores_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stores_comboBox.FormattingEnabled = true;
            this.Stores_comboBox.Location = new System.Drawing.Point(93, 182);
            this.Stores_comboBox.Name = "Stores_comboBox";
            this.Stores_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Stores_comboBox.Size = new System.Drawing.Size(130, 21);
            this.Stores_comboBox.TabIndex = 17;
            // 
            // Categories_comboBox
            // 
            this.Categories_comboBox.AllowDrop = true;
            this.Categories_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Categories_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Categories_comboBox.FormattingEnabled = true;
            this.Categories_comboBox.Location = new System.Drawing.Point(93, 56);
            this.Categories_comboBox.Name = "Categories_comboBox";
            this.Categories_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Categories_comboBox.Size = new System.Drawing.Size(130, 21);
            this.Categories_comboBox.TabIndex = 16;
            // 
            // Vendor_comboBox
            // 
            this.Vendor_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Vendor_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Vendor_comboBox.FormattingEnabled = true;
            this.Vendor_comboBox.Location = new System.Drawing.Point(93, 88);
            this.Vendor_comboBox.Name = "Vendor_comboBox";
            this.Vendor_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Vendor_comboBox.Size = new System.Drawing.Size(130, 21);
            this.Vendor_comboBox.TabIndex = 7;
            // 
            // Quantity_label
            // 
            this.Quantity_label.AutoSize = true;
            this.Quantity_label.Location = new System.Drawing.Point(42, 153);
            this.Quantity_label.Name = "Quantity_label";
            this.Quantity_label.Size = new System.Drawing.Size(46, 13);
            this.Quantity_label.TabIndex = 3;
            this.Quantity_label.Text = "Quantity";
            // 
            // Quantity_txt
            // 
            this.Quantity_txt.Location = new System.Drawing.Point(94, 151);
            this.Quantity_txt.Name = "Quantity_txt";
            this.Quantity_txt.Size = new System.Drawing.Size(115, 20);
            this.Quantity_txt.TabIndex = 11;
            // 
            // UnitPrice_txt
            // 
            this.UnitPrice_txt.Location = new System.Drawing.Point(94, 120);
            this.UnitPrice_txt.Name = "UnitPrice_txt";
            this.UnitPrice_txt.Size = new System.Drawing.Size(115, 20);
            this.UnitPrice_txt.TabIndex = 10;
            // 
            // ProductName_txt
            // 
            this.ProductName_txt.Location = new System.Drawing.Point(93, 25);
            this.ProductName_txt.Name = "ProductName_txt";
            this.ProductName_txt.Size = new System.Drawing.Size(115, 20);
            this.ProductName_txt.TabIndex = 5;
            // 
            // Town_label
            // 
            this.Town_label.AutoSize = true;
            this.Town_label.Location = new System.Drawing.Point(52, 218);
            this.Town_label.Name = "Town_label";
            this.Town_label.Size = new System.Drawing.Size(34, 13);
            this.Town_label.TabIndex = 6;
            this.Town_label.Text = "Town";
            // 
            // Store_label
            // 
            this.Store_label.AutoSize = true;
            this.Store_label.Location = new System.Drawing.Point(55, 185);
            this.Store_label.Name = "Store_label";
            this.Store_label.Size = new System.Drawing.Size(32, 13);
            this.Store_label.TabIndex = 14;
            this.Store_label.Text = "Store";
            // 
            // Category_label
            // 
            this.Category_label.AutoSize = true;
            this.Category_label.Location = new System.Drawing.Point(38, 58);
            this.Category_label.Name = "Category_label";
            this.Category_label.Size = new System.Drawing.Size(49, 13);
            this.Category_label.TabIndex = 4;
            this.Category_label.Text = "Category";
            // 
            // UntitPrice_label
            // 
            this.UntitPrice_label.AutoSize = true;
            this.UntitPrice_label.Location = new System.Drawing.Point(36, 122);
            this.UntitPrice_label.Name = "UntitPrice_label";
            this.UntitPrice_label.Size = new System.Drawing.Size(52, 13);
            this.UntitPrice_label.TabIndex = 2;
            this.UntitPrice_label.Text = "Unit price";
            // 
            // Vendor_label
            // 
            this.Vendor_label.AutoSize = true;
            this.Vendor_label.Location = new System.Drawing.Point(46, 91);
            this.Vendor_label.Name = "Vendor_label";
            this.Vendor_label.Size = new System.Drawing.Size(41, 13);
            this.Vendor_label.TabIndex = 1;
            this.Vendor_label.Text = "Vendor";
            // 
            // ProductName_label
            // 
            this.ProductName_label.AutoSize = true;
            this.ProductName_label.Location = new System.Drawing.Point(13, 27);
            this.ProductName_label.Name = "ProductName_label";
            this.ProductName_label.Size = new System.Drawing.Size(75, 13);
            this.ProductName_label.TabIndex = 0;
            this.ProductName_label.Text = "Product Name";
            // 
            // AddProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(797, 386);
            this.Controls.Add(this.AddProducts_panel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(180, 280);
            this.Name = "AddProducts";
            this.Text = "AddProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProducts_FormClosed);
            this.Load += new System.EventHandler(this.AddProducts_Load);
            this.AddProducts_panel.ResumeLayout(false);
            this.AddProducts_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddProducts_panel;
        private System.Windows.Forms.TextBox Quantity_txt;
        private System.Windows.Forms.TextBox UnitPrice_txt;
        private System.Windows.Forms.TextBox ProductName_txt;
        private System.Windows.Forms.Label Town_label;
        private System.Windows.Forms.Label Store_label;
        private System.Windows.Forms.Label Category_label;
        private System.Windows.Forms.Label Quantity_label;
        private System.Windows.Forms.Label UntitPrice_label;
        private System.Windows.Forms.Label Vendor_label;
        private System.Windows.Forms.Label ProductName_label;
        private System.Windows.Forms.ComboBox Vendor_comboBox;
        private System.Windows.Forms.ComboBox Categories_comboBox;
        private System.Windows.Forms.ComboBox Towns_comboBox;
        private System.Windows.Forms.ComboBox Stores_comboBox;
        private Anyo.WindowsForms.Controls.Buttons.GradientButton insert_btn;
        private System.Windows.Forms.Label addProduct_label;
        private Anyo.WindowsForms.Controls.Buttons.GradientButton clear_btn;
    }
}