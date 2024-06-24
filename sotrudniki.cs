using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class sotrudniki : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];
        private ExcelExporterEmplouee excelExporter;
        private string userRole;

        public sotrudniki(string role)
        {
            userRole = role;
            excelExporter = new ExcelExporterEmplouee();
            InitializeComponent();
            InitializeDataGridView();
            AddButtonsToFlowLayoutPanel();

            // Добавление FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanel);
        }

        private void sotrudniki_Load(object sender, EventArgs e)
        {
            LoadEmployeesData();
            ApplyRolePermissions();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSotrudniki.BorderStyle = BorderStyle.None;
            dataGridViewSotrudniki.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewSotrudniki.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewSotrudniki.BackgroundColor = Color.White;
            dataGridViewSotrudniki.GridColor = Color.FromArgb(210, 210, 210);
            dataGridViewSotrudniki.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewSotrudniki.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSotrudniki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSotrudniki.AutoResizeColumns();

            // Настройка заголовков столбцов
            dataGridViewSotrudniki.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridViewSotrudniki.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewSotrudniki.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void LoadEmployeesData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID AS 'Порядковый номер', FullName AS 'Имя', Position AS 'Должность', Office AS 'Кабинет' FROM Employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewSotrudniki.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных сотрудников: " + ex.Message);
            }
        }

        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(10)
        };

        private void AddButtonsToFlowLayoutPanel()
        {
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

            Button btnExcelReport = new Button
            {
                Text = "Excel",
                Size = new Size(100, 30)
            };
            btnExcelReport.Click += BtnReportExcel_Click;

            flowLayoutPanel.Controls.Add(btnAdd);
            flowLayoutPanel.Controls.Add(btnChange);
            flowLayoutPanel.Controls.Add(btnDelete);
            flowLayoutPanel.Controls.Add(btnExcelReport);
        }

        private void ApplyRolePermissions()
        {
            if (userRole != "Администратор")
            {
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is Button button && (button.Text == "Добавить" || button.Text == "Изменить" || button.Text == "Удалить"))
                    {
                        button.Enabled = false;
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            if (addEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO Employees (FullName, Position, Office) VALUES (@FullName, @Position, @Office)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FullName", addEmployeeForm.txtFullName.Text);
                        command.Parameters.AddWithValue("@Position", addEmployeeForm.txtPosition.Text);
                        command.Parameters.AddWithValue("@Office", addEmployeeForm.txtOffice.Text);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }
            LoadEmployeesData();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
                int index = dataGridViewSotrudniki.CurrentRow.Index;

                if (dataGridViewSotrudniki[0, index].Value != null && int.TryParse(dataGridViewSotrudniki[0, index].Value.ToString(), out int ID))
                {
                    addEmployeeForm.txtFullName.Text = Convert.ToString(dataGridViewSotrudniki[1, index].Value);
                    addEmployeeForm.txtPosition.Text = Convert.ToString(dataGridViewSotrudniki[2, index].Value);
                    addEmployeeForm.txtOffice.Text = Convert.ToString(dataGridViewSotrudniki[3, index].Value);

                    if (addEmployeeForm.ShowDialog() == DialogResult.OK)
                    {
                        string script = "UPDATE Employees SET " +
                        "FullName = @FullName, " +
                        "Position = @Position, " +
                        "Office = @Office " +
                        "WHERE ID = @ID";

                        connection.Open();
                        using (SqlCommand sql = new SqlCommand(script, connection))
                        {
                            sql.Parameters.AddWithValue("@FullName", addEmployeeForm.txtFullName.Text);
                            sql.Parameters.AddWithValue("@Position", addEmployeeForm.txtPosition.Text);
                            sql.Parameters.AddWithValue("@Office", addEmployeeForm.txtOffice.Text);
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
            LoadEmployeesData();
        }

        private void BtnReportExcel_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(dataGridViewSotrudniki);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSotrudniki.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dataGridViewSotrudniki.SelectedRows[0].Cells["Айди"].Value);
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Employees WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", employeeId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            LoadEmployeesData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }

        private void dataGridViewSotrudniki_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridViewSotrudniki.Columns["Айди"] != null)
                dataGridViewSotrudniki.Columns["Айди"].HeaderText = "Порядковый номер";
            if (dataGridViewSotrudniki.Columns["Имя"] != null)
                dataGridViewSotrudniki.Columns["Имя"].HeaderText = "Имя";
            if (dataGridViewSotrudniki.Columns["Должность"] != null)
                dataGridViewSotrudniki.Columns["Должность"].HeaderText = "Должность";
            if (dataGridViewSotrudniki.Columns["Кабинет"] != null)
                dataGridViewSotrudniki.Columns["Кабинет"].HeaderText = "Кабинет";
        }

        private void dataGridViewSotrudniki_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
