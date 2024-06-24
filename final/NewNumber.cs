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
    public partial class NewNumber : Form
    {
        string connectionString = "Data Source=HOME-PC\\SQLEXPRESS1;Initial Catalog=rosles;Integrated Security=True";
        public NewNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MonthCalendar date = new MonthCalendar();
            date.Show();
        }

        private void NewNumber_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox с именами сотрудников
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name FROM EquipmentType";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["Name"].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке типов оборудования: " + ex.Message);
                    }
                }
            }
        }
    }
}
