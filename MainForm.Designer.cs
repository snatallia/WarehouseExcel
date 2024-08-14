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
            lblText = new Label();
            lblProduct = new Label();
            SuspendLayout();
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(66, 100);
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
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.ForeColor = Color.Red;
            lblText.Location = new Point(66, 182);
            lblText.Name = "lblText";
            lblText.Size = new Size(412, 41);
            lblText.TabIndex = 2;
            lblText.Text = "Менее приоритетный товар:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(484, 182);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(0, 41);
            lblProduct.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1864, 987);
            Controls.Add(lblProduct);
            Controls.Add(lblText);
            Controls.Add(label1);
            Controls.Add(btnExcel);
            Name = "MainForm";
            Text = "Excel form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExcel;
        private Label label1;
        private Label lblText;
        private Label lblProduct;
    }
}
