namespace final
{
    partial class typeOborud
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
            this.type = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.type)).BeginInit();
            this.SuspendLayout();
            // 
            // type
            // 
            this.type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type.Location = new System.Drawing.Point(0, 0);
            this.type.Name = "type";
            this.type.RowHeadersWidth = 51;
            this.type.RowTemplate.Height = 24;
            this.type.Size = new System.Drawing.Size(800, 450);
            this.type.TabIndex = 0;
            // 
            // typeOborud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.type);
            this.Name = "typeOborud";
            this.Text = "Типы оборудования";
            this.Load += new System.EventHandler(this.typeOborud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.type)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView type;
    }
}
