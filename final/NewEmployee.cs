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
    public partial class NewEmployee : Form
    {
        string connectionString = "Data Source=HOME-PC\\SQLEXPRESS1;Initial Catalog=rosles;Integrated Security=True";
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}