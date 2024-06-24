namespace final
{
    partial class oborudovanie
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView table_oborud;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.table_oborud = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.table_oborud)).BeginInit();
            this.SuspendLayout();

            // 
            // table_oborud
            // 
            this.table_oborud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_oborud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_oborud.Location = new System.Drawing.Point(0, 0);
            this.table_oborud.Name = "table_oborud";
            this.table_oborud.Size = new System.Drawing.Size(800, 450);
            this.table_oborud.TabIndex = 0;

            // 
            // oborudovanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.table_oborud);
            this.Name = "oborudovanie";
            this.Text = "Оборудование";
            ((System.ComponentModel.ISupportInitialize)(this.table_oborud)).EndInit();
            this.ResumeLayout(false);
        }
    }
}