namespace final
{
    partial class sklad
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
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.RowHeadersWidth = 51;
            this.dataGridViewWarehouse.RowTemplate.Height = 24;
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewWarehouse.TabIndex = 0;
            // 
            // sklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewWarehouse);
            this.Name = "sklad";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
    }
}