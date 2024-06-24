using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class prisvoenie : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];
        //string connectionString = "Data Source=HOME-PC\\SQLEXPRESS1;Initial Catalog=test;Integrated Security=True";

        public prisvoenie()
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

            // Заполнение ComboBox с инвентарными номерами из таблицы EquipmentList
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT InventoryNumber FROM Warehouse ";

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
                string query = "SELECT EquipmentType.Name FROM Warehouse INNER JOIN EquipmentType ON Warehouse.EquipmentTypeID = EquipmentType.ID WHERE InventoryNumber = @InventoryNumber";

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
            //DialogResult = DialogResult.OK;

            // Получаем данные из текстовых полей
            string fullName = comboBoxFullName.SelectedItem.ToString();
            string inventoryNumber = comboBoxInventoryNumber.SelectedItem.ToString();
            string selectedEquipmentType = txtEquipmentType.Text;

            // Подключение к базе данных и выполнение запроса на поиск ID сотрудника и ID типа оборудования
            int employeeID = 0;
            int equipmentTypeID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Запрос на поиск ID сотрудника
                string employeeQuery = "SELECT ID FROM Employees WHERE FullName = @FullName";
                using (SqlCommand employeeCommand = new SqlCommand(employeeQuery, connection))
                {
                    employeeCommand.Parameters.AddWithValue("@FullName", fullName);
                    connection.Open();
                    var result = employeeCommand.ExecuteScalar();
                    if (result != null)
                    {
                        employeeID = (int)result;

                        // Запрос на поиск ID типа оборудования
                        string equipmentTypeQuery = "SELECT ID FROM EquipmentType WHERE Name = @EquipmentType";
                        using (SqlCommand equipmentTypeCommand = new SqlCommand(equipmentTypeQuery, connection))
                        {
                            equipmentTypeCommand.Parameters.AddWithValue("@EquipmentType", selectedEquipmentType);
                            var equipmentTypeResult = equipmentTypeCommand.ExecuteScalar();
                            if (equipmentTypeResult != null)
                            {
                                equipmentTypeID = (int)equipmentTypeResult;

                                // Теперь у нас есть ID сотрудника и ID типа оборудования, которые нужно вставить в таблицу "EmployeeEquipmentRelation"
                                string insertQuery = "INSERT INTO EmployeeEquipmentRelation (EmployeeID, InventoryNumber, EquipmentTypeID) VALUES (@EmployeeID, @InventoryNumber, @EquipmentTypeID)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                    insertCommand.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);
                                    insertCommand.Parameters.AddWithValue("@EquipmentTypeID", equipmentTypeID);

                                    int rowsAffected = insertCommand.ExecuteNonQuery();
                                }
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Тип оборудования не найден.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник с таким именем не найден.");
                    }
                }
            }

        }

        /*//в этой функции почему-то я когда добавляю оно не обновляет таблицу 
        string fullName = comboBoxFullName.SelectedItem.ToString();
        string inventoryNumber = comboBoxInventoryNumber.SelectedItem.ToString();

        int employeeID = 0;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
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
                    MessageBox.Show("Данный инвентарный номер присвоен другому сотруднику. Выберете другой номер");
                }
            }
        }*/
    }
    }

