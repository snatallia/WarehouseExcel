namespace WarehouseExcel
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnExcel = new Button();
            label1 = new Label();
            lblProduct = new Label();
            dgvProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(594, 38);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(395, 58);
            btnExcel.TabIndex = 0;
            btnExcel.Text = "Выбрать";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 38);
            label1.Name = "label1";
            label1.Size = new Size(514, 41);
            label1.TabIndex = 1;
            label1.Text = "Выберите файл со списком товаров";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 12F);
            lblProduct.Location = new Point(54, 108);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(0, 54);
            lblProduct.TabIndex = 3;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(81, 225);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 102;
            dgvProducts.Size = new Size(1510, 820);
            dgvProducts.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 1071);
            Controls.Add(dgvProducts);
            Controls.Add(lblProduct);
            Controls.Add(label1);
            Controls.Add(btnExcel);
            Name = "MainForm";
            Text = "Excel form";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExcel;
        private Label label1;
        private Label lblProduct;
        private DataGridView dgvProducts;
    }
}
