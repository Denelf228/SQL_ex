using final.Properties;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class AddEmployeeForm : Form
    {
        string connectionString = (string)Settings.Default["connectionString"];

        public AddEmployeeForm()
        {
            InitializeComponent();
            ApplyModernDesign();
        }

        private void ApplyModernDesign()
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                string.IsNullOrWhiteSpace(txtOffice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

                        string query = "INSERT INTO Employees (FullName, Position, Office) VALUES (@FullName, @Position, @Office)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Position", txtPosition.Text);
                        command.Parameters.AddWithValue("@Office", txtOffice.Text);

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
            DialogResult = DialogResult.Cancel;
        }
    }
}
