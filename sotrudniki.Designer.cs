namespace final
{
    partial class sotrudniki
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
            this.dataGridViewSotrudniki = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSotrudniki)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSotrudniki
            // 
            this.dataGridViewSotrudniki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSotrudniki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSotrudniki.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSotrudniki.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewSotrudniki.Name = "dataGridViewSotrudniki";
            this.dataGridViewSotrudniki.RowHeadersWidth = 51;
            this.dataGridViewSotrudniki.Size = new System.Drawing.Size(1067, 554);
            this.dataGridViewSotrudniki.TabIndex = 0;
            this.dataGridViewSotrudniki.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSotrudniki_CellContentClick);
            this.dataGridViewSotrudniki.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewSotrudniki_DataBindingComplete);
            // 
            // sotrudniki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridViewSotrudniki);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "sotrudniki";
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.sotrudniki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSotrudniki)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSotrudniki;
    }
}