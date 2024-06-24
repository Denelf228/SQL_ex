using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RoleSelectionForm roleSelectionForm = new RoleSelectionForm();
            if (roleSelectionForm.ShowDialog() == DialogResult.OK)
            {
                string selectedRole = roleSelectionForm.SelectedRole;
                Application.Run(new Form2(selectedRole));
            }
        }
    }
}
