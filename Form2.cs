using final.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace final
{
    public partial class Form2 : Form
    {
        private string currentUserRole;
        string connectionString = (string)Settings.Default["connectionString"];
        private ExcelExporterForm2 excelExporter;
        public Form2(string role)
        {
            currentUserRole = role;
            excelExporter = new ExcelExporterForm2();
            InitializeComponent();

            // Настройка FlowLayoutPanel для кнопок
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };

            // Добавление кнопок в FlowLayoutPanel
            Button btnWarehouse = new Button { Text = "Склад" };
            btnWarehouse.Click += new EventHandler(btnWarehouse_Click);
            flowLayoutPanel.Controls.Add(btnWarehouse);

            Button btnSotrudniki = new Button { Text = "Сотрудники" };
            btnSotrudniki.Click += new EventHandler(btnSotrudniki_Click);
            flowLayoutPanel.Controls.Add(btnSotrudniki);

            // Добавление новой кнопки для формы oborudovanie
            Button btnOborudovanie = new Button { Text = "Оборудование" };
            btnOborudovanie.Click += new EventHandler(btnOborudovanie_Click);
            flowLayoutPanel.Controls.Add(btnOborudovanie);

            Button btnTypeOborud = new Button { Text = "Тип оборудования" };
            btnTypeOborud.Click += new EventHandler(btnTypeOborud_Click);
            flowLayoutPanel.Controls.Add(btnTypeOborud);

            //это для разделения кнопок
            Splitter splitter1 = new Splitter();
            splitter1.BackColor = Color.Black;
            flowLayoutPanel.Controls.Add(splitter1);

            Button btnAdd = new Button { Text = "Добавить" };
            btnAdd.Click += new EventHandler(btnAdd_Click);
            flowLayoutPanel.Controls.Add(btnAdd);

            Button btnDel = new Button { Text = "Удалить" };
            btnDel.Click += new EventHandler(btnDel_Click);
            flowLayoutPanel.Controls.Add(btnDel);

            Button btnReportExel = new Button { Text = "Exel" };
            btnReportExel.Click += new EventHandler(btnReportExel_Click);
            flowLayoutPanel.Controls.Add(btnReportExel);

            // Добавление FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanel);

            if (currentUserRole == "Пользователь")
            {
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.FromArgb(210, 210, 210);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumns();
            // Настройка заголовков столбцов
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView1.AutoResizeColumns();

            // Загрузка данных из базы данных при загрузке формы
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Запрос для извлечения данных из таблицы EmployeeEquipmentRelation
                    string query = @"SELECT EER.ID AS 'Порядковый номер', E.FullName AS 'Сотрудник', EER.InventoryNumber AS 'Инвентарный номер', ET.Name AS 'Тип оборудования'
                                     FROM EmployeeEquipmentRelation EER
                                     INNER JOIN Employees E ON EER.EmployeeID = E.ID
                                     INNER JOIN EquipmentType ET ON EER.EquipmentTypeID = ET.ID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Отображение данных на DataGridView
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Администратор")
            {
                prisvoenie form1 = new prisvoenie();
                form1.ShowDialog();
                LoadData(); // Перезагрузка данных после добавления
            }
            else
            {
                MessageBox.Show("У вас нет прав для выполнения этой операции.");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Администратор")
            {
                if (dataGridView1.CurrentRow != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int index = dataGridView1.CurrentRow.Index;
                        int id_adm = Convert.ToInt32(dataGridView1[0, index].Value);
                        string script = "DELETE FROM EmployeeEquipmentRelation WHERE ID=" + id_adm;
                        connection.Open();
                        SqlCommand sql = new SqlCommand(script, connection);
                        sql.ExecuteNonQuery();
                        connection.Close();
                    }
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления.");
                }
            }
            else
            {
                MessageBox.Show("У вас нет прав для выполнения этой операции.");
            }
        }

        private void btnReportExel_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(dataGridView1);
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            sklad form3 = new sklad();
            form3.ShowDialog(); // Открыть Form3 как модальное окно
        }

        private void btnSotrudniki_Click(object sender, EventArgs e)
        {
            sotrudniki sotrudnikiForm = new sotrudniki(currentUserRole);
            sotrudnikiForm.ShowDialog(); // Открыть форму для работы со сотрудниками
        }


        private void btnOborudovanie_Click(object sender, EventArgs e)
        {
            oborudovanie oborudovanieForm = new oborudovanie(currentUserRole);
            oborudovanieForm.ShowDialog(); // Открыть форму для работы с оборудованием
        }

        private void btnTypeOborud_Click(object sender, EventArgs e)
        {
            typeOborud typeOborudForm = new typeOborud(currentUserRole);
            typeOborudForm.ShowDialog(); // Открыть форму для работы с типами оборудования
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView1.Columns["Порядковый номер"].HeaderText = "Порядковый номер";
            dataGridView1.Columns["Сотрудник"].HeaderText = "Сотрудник";
            dataGridView1.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridView1.Columns["Тип оборудования"].HeaderText = "Тип оборудования";
        }

        
    }
}
