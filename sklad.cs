using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class sklad : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];
        private ToolTip toolTip;

        public sklad()
        {
            toolTip = new ToolTip();
            InitializeComponent();
            InitializeDataGridView();

            dataGridViewWarehouse.CellMouseEnter += dataGridViewWarehouse_CellMouseEnter;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadWarehouseData();
        }

        private void dataGridViewWarehouse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Проверяем, что индекс строки и столбца положительный и не превышает размер коллекции
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewWarehouse.RowCount && e.ColumnIndex < dataGridViewWarehouse.ColumnCount)
                {
                    string inventoryNumber = dataGridViewWarehouse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    if (!string.IsNullOrEmpty(inventoryNumber))
                    {
                        string query = "SELECT * FROM EquipmentList WHERE InventoryNumber = @InventoryNumber";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@InventoryNumber", inventoryNumber);

                            try
                            {
                                connection.Open();
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    string toolTipText = $"Name: {reader["Name"]}\n" +
                                                         $"Manufacturer: {reader["Manufacturer"]}\n" +
                                                         $"Model: {reader["Model"]}\n" +
                                                         $"SN: {reader["SN"]}\n" +
                                                         $"ProductionDate: {Convert.ToDateTime(reader["ProductionDate"]).ToShortDateString()}\n" +
                                                         $"EquipmentTypeID: {reader["EquipmentTypeID"]}";

                                    // Показ всплывающего окна на 10 секунд
                                    toolTip.Show(toolTipText, dataGridViewWarehouse, dataGridViewWarehouse.PointToClient(Cursor.Position), 10000);
                                }
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    // Скрыть всплывающее окно, если индекс за пределами диапазона
                    toolTip.Hide(dataGridViewWarehouse);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }
        }

        private void InitializeDataGridView()
        {
            dataGridViewWarehouse.BorderStyle = BorderStyle.None;
            dataGridViewWarehouse.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewWarehouse.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewWarehouse.BackgroundColor = Color.White;
            dataGridViewWarehouse.GridColor = Color.FromArgb(210, 210, 210);
            dataGridViewWarehouse.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.DarkBlue,
                ForeColor = Color.White
            };
            dataGridViewWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWarehouse.AutoResizeColumns();
        }

        private void LoadWarehouseData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT EquipmentTypeID AS 'Порядковый номер', InventoryNumber AS 'Инвентарный номер', DateAdded AS 'Дата добавления' FROM Warehouse";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewWarehouse.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных склада: " + ex.Message);
            }
        }

        private void dataGridViewWarehouse_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewWarehouse.Columns["EquipmentTypeID"].HeaderText = "Порядковый номер";
            dataGridViewWarehouse.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridViewWarehouse.Columns["Дата добавления"].HeaderText = "Дата добавления";
        }
    }
}
