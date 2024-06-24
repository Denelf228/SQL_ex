using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class typeOborud : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];
        private string userRole;

        public typeOborud(string role)
        {
            userRole = role;
            InitializeComponent();
            ApplyModernDesign();
            InitializeLayout();
            ApplyRolePermissions(); // Применяем права доступа в зависимости от роли пользователя
        }

        private void ApplyModernDesign()
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeLayout()
        {
            // Настройка FlowLayoutPanel для кнопок
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            // Добавление кнопок в FlowLayoutPanel
            Button btnAdd = new Button { Text = "Добавить" };
            btnAdd.Click += new EventHandler(btnAdd_Click);
            flowLayoutPanel.Controls.Add(btnAdd);

            Button btnDelete = new Button { Text = "Удалить" };
            btnDelete.Click += new EventHandler(btnDelete_Click);
            flowLayoutPanel.Controls.Add(btnDelete);

            // Добавление FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanel);

            // Настройка DataGridView
            type.Dock = DockStyle.Fill;
            type.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            type.BackgroundColor = Color.White;
            type.GridColor = Color.FromArgb(210, 210, 210);
            type.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.DarkBlue,
                ForeColor = Color.White
            };
            type.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            type.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 10)
            };

            // Загрузка данных при загрузке формы
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID AS 'Порядковый номер', Name AS 'Название' FROM EquipmentType";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    type.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void ApplyRolePermissions()
        {
            // Проверяем роль пользователя
            if (userRole != "Администратор")
            {
                // Отключаем кнопки
                foreach (Control control in this.Controls)
                {
                    if (control is FlowLayoutPanel)
                    {
                        foreach (Control buttonControl in (control as FlowLayoutPanel).Controls)
                        {
                            if (buttonControl is Button)
                            {
                                buttonControl.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Введите название нового типа оборудования:", "Добавить тип оборудования", "");

            if (!string.IsNullOrWhiteSpace(newName))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO EquipmentType (Name) VALUES (@Name)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", newName);
                        command.ExecuteNonQuery();
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении типа оборудования: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (type.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(type.SelectedRows[0].Cells["Порядковый номер"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM EquipmentType WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", selectedId);
                        command.ExecuteNonQuery();
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении типа оборудования: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void typeOborud_Load(object sender, EventArgs e)
        {

        }
    }
}
