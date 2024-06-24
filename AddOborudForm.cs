using final.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace final
{
    public partial class AddOborudForm : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];

        public AddOborudForm()
        {
            InitializeComponent();
            ApplyModernDesign();
            LoadEquipmentTypes();
        }

        private void ApplyModernDesign()
        {
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadEquipmentTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ID, Name FROM EquipmentType";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    EquipmentType.DataSource = table;
                    EquipmentType.DisplayMember = "Name";
                    EquipmentType.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов оборудования: " + ex.Message);
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(txtSN.Text) ||
                string.IsNullOrWhiteSpace(txtInventoryNumber.Text) ||
                EquipmentType.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            /*{
                if (!ValidateInput())
                    return;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO EquipmentList (Name, Manufacturer, Model, SN, InventoryNumber, ProductionDate, EquipmentTypeID) VALUES (@Name, @Manufacturer, @Model, @SN, @InventoryNumber, @ProductionDate, @EquipmentTypeID)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text);
                        command.Parameters.AddWithValue("@Model", txtModel.Text);
                        command.Parameters.AddWithValue("@SN", txtSN.Text);
                        command.Parameters.AddWithValue("@InventoryNumber", txtInventoryNumber.Text);
                        command.Parameters.AddWithValue("@ProductionDate", ProductionDate.Value);
                        command.Parameters.AddWithValue("@EquipmentTypeID", EquipmentType.SelectedValue);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно добавлены.");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }*/

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MonthCalendar date = new MonthCalendar();
            date.Show();
        }
    }
}
