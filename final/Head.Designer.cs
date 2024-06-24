namespace final
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roslesDataSet = new final.roslesDataSet();
            this.equipmentTypeTableAdapter = new final.roslesDataSetTableAdapters.EquipmentTypeTableAdapter();
            this.equipmentListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentListTableAdapter = new final.roslesDataSetTableAdapters.EquipmentListTableAdapter();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.officeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeesTableAdapter = new final.roslesDataSetTableAdapters.EmployeesTableAdapter();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.inventoryNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentTypeIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warehouseTableAdapter = new final.roslesDataSetTableAdapters.WarehouseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roslesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.equipmentTypeBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(800, 450);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // equipmentTypeBindingSource
            // 
            this.equipmentTypeBindingSource.DataMember = "EquipmentType";
            this.equipmentTypeBindingSource.DataSource = this.roslesDataSet;
            // 
            // roslesDataSet
            // 
            this.roslesDataSet.DataSetName = "roslesDataSet";
            this.roslesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // equipmentTypeTableAdapter
            // 
            this.equipmentTypeTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentListBindingSource
            // 
            this.equipmentListBindingSource.DataMember = "EquipmentList";
            this.equipmentListBindingSource.DataSource = this.roslesDataSet;
            // 
            // equipmentListTableAdapter
            // 
            this.equipmentListTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn1,
            this.manufacturerDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.sNDataGridViewTextBoxColumn,
            this.inventoryNumberDataGridViewTextBoxColumn,
            this.productionDateDataGridViewTextBoxColumn,
            this.equipmentTypeIDDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.equipmentListBindingSource1;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(800, 450);
            this.dataGridView3.TabIndex = 2;
            this.dataGridView3.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.Width = 125;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.Width = 125;
            // 
            // sNDataGridViewTextBoxColumn
            // 
            this.sNDataGridViewTextBoxColumn.DataPropertyName = "SN";
            this.sNDataGridViewTextBoxColumn.HeaderText = "SN";
            this.sNDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sNDataGridViewTextBoxColumn.Name = "sNDataGridViewTextBoxColumn";
            this.sNDataGridViewTextBoxColumn.Width = 125;
            // 
            // inventoryNumberDataGridViewTextBoxColumn
            // 
            this.inventoryNumberDataGridViewTextBoxColumn.DataPropertyName = "InventoryNumber";
            this.inventoryNumberDataGridViewTextBoxColumn.HeaderText = "InventoryNumber";
            this.inventoryNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.inventoryNumberDataGridViewTextBoxColumn.Name = "inventoryNumberDataGridViewTextBoxColumn";
            this.inventoryNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // productionDateDataGridViewTextBoxColumn
            // 
            this.productionDateDataGridViewTextBoxColumn.DataPropertyName = "ProductionDate";
            this.productionDateDataGridViewTextBoxColumn.HeaderText = "ProductionDate";
            this.productionDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productionDateDataGridViewTextBoxColumn.Name = "productionDateDataGridViewTextBoxColumn";
            this.productionDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // equipmentTypeIDDataGridViewTextBoxColumn
            // 
            this.equipmentTypeIDDataGridViewTextBoxColumn.DataPropertyName = "EquipmentTypeID";
            this.equipmentTypeIDDataGridViewTextBoxColumn.HeaderText = "EquipmentTypeID";
            this.equipmentTypeIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.equipmentTypeIDDataGridViewTextBoxColumn.Name = "equipmentTypeIDDataGridViewTextBoxColumn";
            this.equipmentTypeIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // equipmentListBindingSource1
            // 
            this.equipmentListBindingSource1.DataMember = "EquipmentList";
            this.equipmentListBindingSource1.DataSource = this.roslesDataSet;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.fullNameDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.officeDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.employeesBindingSource;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(800, 450);
            this.dataGridView4.TabIndex = 3;
            this.dataGridView4.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // officeDataGridViewTextBoxColumn
            // 
            this.officeDataGridViewTextBoxColumn.DataPropertyName = "Office";
            this.officeDataGridViewTextBoxColumn.HeaderText = "Office";
            this.officeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.officeDataGridViewTextBoxColumn.Name = "officeDataGridViewTextBoxColumn";
            this.officeDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.roslesDataSet;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AutoGenerateColumns = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inventoryNumberDataGridViewTextBoxColumn1,
            this.equipmentTypeIDDataGridViewTextBoxColumn1,
            this.dateAddedDataGridViewTextBoxColumn});
            this.dataGridView5.DataSource = this.warehouseBindingSource;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.ShowEditingIcon = false;
            this.dataGridView5.Size = new System.Drawing.Size(800, 450);
            this.dataGridView5.TabIndex = 4;
            this.dataGridView5.Visible = false;
            // 
            // inventoryNumberDataGridViewTextBoxColumn1
            // 
            this.inventoryNumberDataGridViewTextBoxColumn1.DataPropertyName = "InventoryNumber";
            this.inventoryNumberDataGridViewTextBoxColumn1.HeaderText = "InventoryNumber";
            this.inventoryNumberDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.inventoryNumberDataGridViewTextBoxColumn1.Name = "inventoryNumberDataGridViewTextBoxColumn1";
            this.inventoryNumberDataGridViewTextBoxColumn1.Width = 125;
            // 
            // equipmentTypeIDDataGridViewTextBoxColumn1
            // 
            this.equipmentTypeIDDataGridViewTextBoxColumn1.DataPropertyName = "EquipmentTypeID";
            this.equipmentTypeIDDataGridViewTextBoxColumn1.HeaderText = "EquipmentTypeID";
            this.equipmentTypeIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.equipmentTypeIDDataGridViewTextBoxColumn1.Name = "equipmentTypeIDDataGridViewTextBoxColumn1";
            this.equipmentTypeIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dateAddedDataGridViewTextBoxColumn
            // 
            this.dateAddedDataGridViewTextBoxColumn.DataPropertyName = "DateAdded";
            this.dateAddedDataGridViewTextBoxColumn.HeaderText = "DateAdded";
            this.dateAddedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateAddedDataGridViewTextBoxColumn.Name = "dateAddedDataGridViewTextBoxColumn";
            this.dateAddedDataGridViewTextBoxColumn.Width = 125;
            // 
            // warehouseBindingSource
            // 
            this.warehouseBindingSource.DataMember = "Warehouse";
            this.warehouseBindingSource.DataSource = this.roslesDataSet;
            // 
            // warehouseTableAdapter
            // 
            this.warehouseTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Главный экран";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roslesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private roslesDataSet roslesDataSet;
        private System.Windows.Forms.BindingSource equipmentTypeBindingSource;
        private roslesDataSetTableAdapters.EquipmentTypeTableAdapter equipmentTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource equipmentListBindingSource;
        private roslesDataSetTableAdapters.EquipmentListTableAdapter equipmentListTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource equipmentListBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private roslesDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn officeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.BindingSource warehouseBindingSource;
        private roslesDataSetTableAdapters.WarehouseTableAdapter warehouseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentTypeIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAddedDataGridViewTextBoxColumn;
    }
}