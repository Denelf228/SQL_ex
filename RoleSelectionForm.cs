using System;
using System.Windows.Forms;

namespace final
{
    public partial class RoleSelectionForm : Form
    {
        public string SelectedRole { get; private set; }

        public RoleSelectionForm()
        {
            InitializeComponent();

            // Настройка FlowLayoutPanel для кнопок выбора роли
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10)
            };

            // Добавление кнопок для выбора роли
            Button btnAdmin = new Button { Text = "Администратор", AutoSize = true };
            btnAdmin.Click += new EventHandler(btnAdmin_Click);
            flowLayoutPanel.Controls.Add(btnAdmin);

            Button btnUser = new Button { Text = "Пользователь", AutoSize = true };
            btnUser.Click += new EventHandler(btnUser_Click);
            flowLayoutPanel.Controls.Add(btnUser);

            // Добавление FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanel);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            SelectedRole = "Администратор";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SelectedRole = "Пользователь";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
