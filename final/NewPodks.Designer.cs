namespace final
{
    partial class NewPodks
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFullName = new System.Windows.Forms.ComboBox();
            this.comboBoxInventoryNumber = new System.Windows.Forms.ComboBox();
            this.txtEquipmentType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сотрудник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "инвент. номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выдача оборудования";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(326, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Добавить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Тип оборудования";
            // 
            // comboBoxFullName
            // 
            this.comboBoxFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.comboBoxFullName.FormattingEnabled = true;
            this.comboBoxFullName.Location = new System.Drawing.Point(300, 121);
            this.comboBoxFullName.Name = "comboBoxFullName";
            this.comboBoxFullName.Size = new System.Drawing.Size(273, 33);
            this.comboBoxFullName.TabIndex = 8;
            // 
            // comboBoxInventoryNumber
            // 
            this.comboBoxInventoryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.comboBoxInventoryNumber.FormattingEnabled = true;
            this.comboBoxInventoryNumber.Location = new System.Drawing.Point(300, 166);
            this.comboBoxInventoryNumber.Name = "comboBoxInventoryNumber";
            this.comboBoxInventoryNumber.Size = new System.Drawing.Size(273, 33);
            this.comboBoxInventoryNumber.TabIndex = 9;
            // 
            // txtEquipmentType
            // 
            this.txtEquipmentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.txtEquipmentType.Location = new System.Drawing.Point(300, 209);
            this.txtEquipmentType.Name = "txtEquipmentType";
            this.txtEquipmentType.Size = new System.Drawing.Size(273, 30);
            this.txtEquipmentType.TabIndex = 10;
            // 
            // NewPodks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEquipmentType);
            this.Controls.Add(this.comboBoxInventoryNumber);
            this.Controls.Add(this.comboBoxFullName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewPodks";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFullName;
        private System.Windows.Forms.ComboBox comboBoxInventoryNumber;
        private System.Windows.Forms.TextBox txtEquipmentType;
    }
}

