using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class NewPodks : Form
    {
        string connectionString = "Data Source=HOME-PC\\SQLEXPRESS1;Initial Catalog=rosles;Integrated Security=True";


        public NewPodks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox с именами сотрудников
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName FROM Employees";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxFullName.Items.Add(reader["FullName"].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке имен сотрудников: " + ex.Message);
                    }
                }
            }

            // Заполнение ComboBox с инвентарными номерами
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT InventoryNumber FROM EquipmentList";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxInventoryNumber.Items.Add(reader["InventoryNumber"].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке инвентарных номеров: " + ex.Message);
                    }
                }
            }

            // Обработчик события для выбора инвентарного номера
            comboBoxInventoryNumber.SelectedIndexChanged += ComboBoxInventoryNumber_SelectedIndexChanged;
        }

        private void ComboBoxInventoryNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inventoryNumber = comboBoxInventoryNumber.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EquipmentType.Name FROM EquipmentList INNER JOIN EquipmentType ON EquipmentList.EquipmentTypeID = EquipmentType.ID WHERE InventoryNumber = @InventoryNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

                    try
                    {
                        connection.Open();
                        var equipmentType = command.ExecuteScalar();
                        if (equipmentType != null)
                        {
                            txtEquipmentType.Text = equipmentType.ToString(); // Отображение типа оборудования
                        }
                        else
                        {
                            txtEquipmentType.Text = "Тип оборудования не найден";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке типа оборудования: " + ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстовых полей
            string fullName = comboBoxFullName.SelectedItem.ToString();
            string inventoryNumber = comboBoxInventoryNumber.SelectedItem.ToString();

            // Подключение к базе данных и выполнение запроса на поиск ID сотрудника
            int employeeID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Запрос на поиск ID сотрудника
                string employeeQuery = "SELECT ID FROM Employees WHERE FullName = @FullName";
                using (SqlCommand employeeCommand = new SqlCommand(employeeQuery, connection))
                {
                    employeeCommand.Parameters.AddWithValue("@FullName", fullName);

                    try
                    {
                        connection.Open();
                        var result = employeeCommand.ExecuteScalar();
                        if (result != null)
                        {
                            employeeID = (int)result;

                            // Теперь у нас есть ID сотрудника, который нужно вставить в таблицу "EmployeeEquipmentRelation"
                            string insertQuery = "INSERT INTO EmployeeEquipmentRelation (EmployeeID, InventoryNumber) VALUES (@EmployeeID, @InventoryNumber)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                insertCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

                                int rowsAffected = insertCommand.ExecuteNonQuery();
                                MessageBox.Show("Данные успешно добавлены в базу данных.");
                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("Сотрудник с таким именем не найден.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выбраный инвентарный номер уже присвоен другому сотруднику, выберете другой номер.  ");
                    }
                }
               
            }
        }
    }
}
