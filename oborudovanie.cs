using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class oborudovanie : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];
        private ExcelExporterEquipment excelExporter;
        private string userRole;

        public oborudovanie(string role)
        {
            userRole = role;
            excelExporter = new ExcelExporterEquipment();
            InitializeComponent();
            InitializeDataGridView();
            InitializeFlowLayoutPanel();
            LoadData();
            ApplyRolePermissions();
        }

        private void InitializeDataGridView()
        {
            // Настройка DataGridView
            table_oborud.BorderStyle = BorderStyle.None;
            table_oborud.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            table_oborud.DefaultCellStyle.Font = new Font("Arial", 10);
            table_oborud.BackgroundColor = Color.White;
            table_oborud.GridColor = Color.FromArgb(210, 210, 210);
            table_oborud.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            table_oborud.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            table_oborud.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table_oborud.AutoResizeColumns();

            // Настройка заголовков столбцов
            table_oborud.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            table_oborud.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            table_oborud.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void InitializeFlowLayoutPanel()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            Button btnAdd = new Button
            {
                Text = "Добавить",
                Size = new Size(100, 30)
            };
            btnAdd.Click += BtnAdd_Click;

            Button btnChange = new Button
            {
                Text = "Изменить",
                Size = new Size(100, 30)
            };
            btnChange.Click += BtnChange_Click;

            Button btnDelete = new Button
            {
                Text = "Удалить",
                Size = new Size(100, 30)
            };
            btnDelete.Click += BtnDelete_Click;

            Button btnReportExel = new Button
            {
                Text = "Excel",
                Size = new Size(100, 30)
            };
            btnReportExel.Click += BtnReportExel_Click;

            flowLayoutPanel.Controls.Add(btnAdd);
            flowLayoutPanel.Controls.Add(btnChange);
            flowLayoutPanel.Controls.Add(btnDelete);
            flowLayoutPanel.Controls.Add(btnReportExel);

            this.Controls.Add(flowLayoutPanel);
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            e.ID AS 'Порядковый номер', 
                            e.Name AS 'Имя', 
                            e.Manufacturer AS 'Производитель', 
                            e.Model AS 'Модель', 
                            e.SN AS 'Серийный номер', 
                            e.InventoryNumber AS 'Инвентарный номер', 
                            e.ProductionDate AS 'Дата производства', 
                            et.Name AS 'Тип оборудования'
                        FROM 
                            EquipmentList e
                        INNER JOIN 
                            EquipmentType et ON e.EquipmentTypeID = et.ID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    table_oborud.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void ApplyRolePermissions()
        {
            if (userRole != "Администратор")
            {
                foreach (Control control in this.Controls)
                {
                    if (control is FlowLayoutPanel)
                    {
                        foreach (Control buttonControl in (control as FlowLayoutPanel).Controls)
                        {
                            if (buttonControl is Button && buttonControl.Text != "Excel")
                            {
                                buttonControl.Enabled = false;
                            }
                        }
                    }
                }
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddOborudForm addForm = new AddOborudForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO EquipmentList (Name, Manufacturer, Model, SN, InventoryNumber, ProductionDate, EquipmentTypeID) VALUES (@Name, @Manufacturer, @Model, @SN, @InventoryNumber, @ProductionDate, @EquipmentTypeID)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", addForm.txtName.Text);
                        command.Parameters.AddWithValue("@Manufacturer", addForm.txtManufacturer.Text);
                        command.Parameters.AddWithValue("@Model", addForm.txtModel.Text);
                        command.Parameters.AddWithValue("@SN", addForm.txtSN.Text);
                        command.Parameters.AddWithValue("@InventoryNumber", addForm.txtInventoryNumber.Text);
                        command.Parameters.AddWithValue("@ProductionDate", addForm.dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@EquipmentTypeID", addForm.EquipmentType.SelectedValue);

                        command.ExecuteNonQuery();

                        // Проверка и вставка в таблицу Warehouse
                        string checkQuery = "SELECT COUNT(*) FROM EmployeeEquipmentRelation WHERE InventoryNumber = @InventoryNumber";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@InventoryNumber", addForm.txtInventoryNumber.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            string insertWarehouseQuery = "INSERT INTO Warehouse (InventoryNumber, EquipmentTypeID, DateAdded) VALUES (@InventoryNumber, @EquipmentTypeID, GETDATE())";
                            SqlCommand insertWarehouseCommand = new SqlCommand(insertWarehouseQuery, connection);
                            insertWarehouseCommand.Parameters.AddWithValue("@InventoryNumber", addForm.txtInventoryNumber.Text);
                            insertWarehouseCommand.Parameters.AddWithValue("@EquipmentTypeID", addForm.EquipmentType.SelectedValue);
                            insertWarehouseCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Данные успешно добавлены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }
            LoadData(); // Перезагрузка данных после добавления
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                AddOborudForm addForm = new AddOborudForm();
                int index = table_oborud.CurrentRow.Index;

                if (table_oborud[0, index].Value != null && int.TryParse(table_oborud[0, index].Value.ToString(), out int ID))
                {
                    addForm.txtName.Text = Convert.ToString(table_oborud[1, index].Value);
                    addForm.txtManufacturer.Text = Convert.ToString(table_oborud[2, index].Value);
                    addForm.txtModel.Text = Convert.ToString(table_oborud[3, index].Value);
                    addForm.txtSN.Text = Convert.ToString(table_oborud[4, index].Value);
                    addForm.txtInventoryNumber.Text = Convert.ToString(table_oborud[5, index].Value);
                    addForm.dateTimePicker1.Text = Convert.ToString(table_oborud[6, index].Value);
                    addForm.EquipmentType.Text = Convert.ToString(table_oborud[7, index].Value);

                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        string script = "UPDATE EquipmentList SET " +
                            "Name = @Name, " +
                            "Manufacturer = @Manufacturer, " +
                            "Model = @Model, " +
                            "SN = @SN, " +
                            "InventoryNumber = @InventoryNumber, " +
                            "ProductionDate = @ProductionDate, " +
                            "EquipmentTypeID = @EquipmentTypeID " +
                            "WHERE ID = @ID";

                        connection.Open();
                        using (SqlCommand sql = new SqlCommand(script, connection))
                        {
                            sql.Parameters.AddWithValue("@Name", addForm.txtName.Text);
                            sql.Parameters.AddWithValue("@Manufacturer", addForm.txtManufacturer.Text);
                            sql.Parameters.AddWithValue("@Model", addForm.txtModel.Text);
                            sql.Parameters.AddWithValue("@SN", addForm.txtSN.Text);
                            sql.Parameters.AddWithValue("@InventoryNumber", addForm.txtInventoryNumber.Text);
                            sql.Parameters.AddWithValue("@ProductionDate", addForm.dateTimePicker1.Value);
                            sql.Parameters.AddWithValue("@EquipmentTypeID", addForm.EquipmentType.SelectedValue);
                            sql.Parameters.AddWithValue("@ID", ID);

                            sql.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат ID или значение отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadData(); // Перезагрузка данных после изменения
        }

        private void BtnReportExel_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(table_oborud);
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (table_oborud.SelectedRows.Count > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (DataGridViewRow row in table_oborud.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["Порядковый номер"].Value);
                            string deleteQuery = "DELETE FROM EquipmentList WHERE ID = @ID";
                            SqlCommand command = new SqlCommand(deleteQuery, connection);
                            command.Parameters.AddWithValue("@ID", id);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении данных: " + ex.Message);
                }
                LoadData(); // Перезагрузка данных после удаления
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
