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
using MaterialSkin;
using MaterialSkin.Controls;

namespace final
{
    public partial class Form2 : Form
    {
        private Button btnNewInvNumber;
        private Button pictureBox2;
        private Button pictureBox3; 
        private Button pictureBox4;
        private Button pictureBox5;
        private Button pictureBox6;
        private Button btnChangeInvNumber;
        private Button btnChangeEmployee;
        private Button btnNewEmployee;
        private Button btnDelPodkl;
        private Button btnDelInvNumber;
        private Button btnDelEmployee;
        private Button btnAdd;
        private Button btnLoad;
        private Button btnNewTypeEquipment;
        private Splitter splitter1;

        string connectionString = "Data Source=HOME-PC\\SQLEXPRESS1;Initial Catalog=rosles;Integrated Security=True";

        public Form2()
        {
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

            pictureBox2 = new Button();
            pictureBox2.Width = 150;
            pictureBox2.Height = 30;
            pictureBox2.Text = "Тип оборудования";
            //pictureBox2.Image = Image.FromFile("type_obor.png"); // Укажите путь к изображению
            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Click += new EventHandler(pictureBox2_Click);
            flowLayoutPanel.Controls.Add(pictureBox2);

            pictureBox3 = new Button();
            pictureBox3.Width = 50;
            pictureBox3.Height = 30;
            pictureBox3.Text = "Склад";
            //pictureBox3.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\warehouse.jpg"); // Укажите путь к изображению
            //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Click += new EventHandler(pictureBox3_Click);
            flowLayoutPanel.Controls.Add(pictureBox3);

            pictureBox4 = new Button();
            pictureBox4.Width = 150;
            pictureBox4.Height = 30;
            pictureBox4.Text = "Присвоенные номера";
            //pictureBox4.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-новая-таблица-50.png"); // Укажите путь к изображению
            //pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Click += new EventHandler(pictureBox4_Click);
            flowLayoutPanel.Controls.Add(pictureBox4);

            pictureBox5 = new Button();
            pictureBox5.Width = 100;
            pictureBox5.Height = 30;
            pictureBox5.Text = "Инв. Номера";
            //pictureBox5.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\obr_list.png"); // Укажите путь к изображению
            //pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Click += new EventHandler(pictureBox5_Click);
            flowLayoutPanel.Controls.Add(pictureBox5);

            pictureBox6 = new Button();
            pictureBox6.Width = 80;
            pictureBox6.Height = 30;
            pictureBox6.Text = "Сотрудники";
            //pictureBox6.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\emplouee.png"); // Укажите путь к изображению
            //pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.Click += new EventHandler(pictureBox6_Click);
            flowLayoutPanel.Controls.Add(pictureBox6);

            splitter1 = new Splitter();
            splitter1.BackColor = Color.Black;

            btnNewInvNumber = new Button();
            btnNewInvNumber.Width = 70;
            btnNewInvNumber.Height = 30;
            btnNewInvNumber.Text = "Добавить";
            //btnNewInvNumber.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-добавить-50.png"); // Укажите путь к изображению
            //btnNewInvNumber.SizeMode = PictureBoxSizeMode.StretchImage;
            btnNewInvNumber.Visible = false;
            btnNewInvNumber.Click += new EventHandler(btnNewInvNumber_Click);
            flowLayoutPanel.Controls.Add(btnNewInvNumber);

            btnChangeInvNumber = new Button();
            btnChangeInvNumber.Width = 70;
            btnChangeInvNumber.Height = 30;
            btnChangeInvNumber.Text = "Изменить";
            // btnChangeInvNumber.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-редактировать-свойство-50.png"); // Укажите путь к изображению
            //btnChangeInvNumber.SizeMode = PictureBoxSizeMode.StretchImage;
            btnChangeInvNumber.Visible = false;
            btnChangeInvNumber.Click += new EventHandler(btnChangeInvNumber_Click);
            flowLayoutPanel.Controls.Add(btnChangeInvNumber);

            btnChangeEmployee = new Button();
            btnChangeEmployee.Width = 70;
            btnChangeEmployee.Height = 30;
            btnChangeEmployee.Text = "Изменить";
            //btnChangeEmployee.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-редактировать-свойство-50.png"); // Укажите путь к изображению
            //btnChangeEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            btnChangeEmployee.Visible = false;
            btnChangeEmployee.Click += new EventHandler(btnChangeEmployee_Click);
            flowLayoutPanel.Controls.Add(btnChangeEmployee);

            btnNewEmployee = new Button();
            btnNewEmployee.Width = 70;
            btnNewEmployee.Height = 30;
            btnNewEmployee.Text = "Добавить";
            //btnNewEmployee.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-добавить-пользователя-50.png"); // Укажите путь к изображению
            //btnNewEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            btnNewEmployee.Visible = false;
            btnNewEmployee.Click += new EventHandler(btnNewEmployee_Click);
            flowLayoutPanel.Controls.Add(btnNewEmployee);

            btnDelPodkl = new Button();
            btnDelPodkl.Width = 70;
            btnDelPodkl.Height = 30;
            btnDelPodkl.Text = "Удалить";
            //btnDelPodkl.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-удалить-50.png"); // Укажите путь к изображению
            //btnDelPodkl.SizeMode = PictureBoxSizeMode.StretchImage;
            btnDelPodkl.Visible = true;
            btnDelPodkl.Click += new EventHandler(btnDelPodkl_Click);
            flowLayoutPanel.Controls.Add(btnDelPodkl);

            btnDelInvNumber = new Button();
            btnDelInvNumber.Width = 70;
            btnDelInvNumber.Height = 30;
            btnDelInvNumber.Text = "Удалить";
            //btnDelInvNumber.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-удалить-50.png"); // Укажите путь к изображению
            //btnDelInvNumber.SizeMode = PictureBoxSizeMode.StretchImage;
            btnDelInvNumber.Visible = false;
            btnDelInvNumber.Click += new EventHandler(btnDelInvNumber_Click);
            flowLayoutPanel.Controls.Add(btnDelInvNumber);

            btnDelEmployee = new Button();
            btnDelEmployee.Width = 70;
            btnDelEmployee.Height = 30;
            btnDelEmployee.Text = "Удалить";
            //btnDelEmployee.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-удалить-50.png"); // Укажите путь к изображению
            //btnDelEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            btnDelEmployee.Visible = false;
            btnDelEmployee.Click += new EventHandler(btnDelEmployee_Click);
            flowLayoutPanel.Controls.Add(btnDelEmployee);

            btnAdd = new Button();
            btnAdd.Width = 70;
            btnAdd.Height = 30;
            btnAdd.Text = "Присвоить";
            //btnAdd.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\inv_nomer.png"); // Укажите путь к изображению
            //btnAdd.SizeMode = PictureBoxSizeMode.StretchImage;
            btnAdd.Visible = true;
            btnAdd.Click += new EventHandler(btnAdd_Click);
            flowLayoutPanel.Controls.Add(btnAdd);

            btnLoad = new Button();
            btnLoad.Width = 70;
            btnLoad.Height = 30;
            btnLoad.Text = "Обновить";
            //btnLoad.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-обновить-30.png"); // Укажите путь к изображению
            //btnLoad.SizeMode = PictureBoxSizeMode.StretchImage;
            btnLoad.Visible = false;
            btnLoad.Click += new EventHandler(btnLoad_Click);
            flowLayoutPanel.Controls.Add(btnLoad);

            btnNewTypeEquipment = new Button();
            btnNewTypeEquipment.Width = 70;
            btnNewTypeEquipment.Height = 30;
            btnNewTypeEquipment.Text = "Добавить";
            //btnNewTypeEquipment.Image = Image.FromFile("D:\\Колледж\\Производственная практика\\РосЛесИнфорг\\final\\final\\Resources\\icons8-добавить-50.png"); // Укажите путь к изображению
            //btnNewTypeEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
            btnNewTypeEquipment.Visible = false;
            btnNewTypeEquipment.Click += new EventHandler(btnNewTypeEquipment_Click);
            flowLayoutPanel.Controls.Add(btnNewTypeEquipment);

            // Добавление FlowLayoutPanel на форму
            Controls.Add(flowLayoutPanel);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "roslesDataSet.Warehouse". При необходимости она может быть перемещена или удалена.
            this.warehouseTableAdapter.Fill(this.roslesDataSet.Warehouse);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "roslesDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.roslesDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "roslesDataSet.EquipmentList". При необходимости она может быть перемещена или удалена.
            this.equipmentListTableAdapter.Fill(this.roslesDataSet.EquipmentList);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "roslesDataSet.EquipmentType". При необходимости она может быть перемещена или удалена.
            this.equipmentTypeTableAdapter.Fill(this.roslesDataSet.EquipmentType);

            dataGridView1.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            // Настройка заголовков столбцов
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView1.AutoResizeColumns();

            dataGridView2.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            // Настройка заголовков столбцов
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView2.AutoResizeColumns();

            dataGridView3.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView3.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            // Настройка заголовков столбцов
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView3.AutoResizeColumns();

            dataGridView4.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView4.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            // Настройка заголовков столбцов
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView4.AutoResizeColumns();

            dataGridView5.BorderStyle = BorderStyle.None; // Удаление границ
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Цвет фона чередующихся строк
            dataGridView5.DefaultCellStyle.Font = new Font("Arial", 10); // Шрифт ячеек

            // Настройка заголовков столбцов
            dataGridView5.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Жирный шрифт для заголовков
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue; // Цвет фона заголовков
            dataGridView5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Цвет текста заголовков
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Автоматическое масштабирование столбцов
            dataGridView5.AutoResizeColumns();

            // Загрузка данных из базы данных при загрузке формы
            LoadData();
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox2, "Тип оборудования");
            ToolTip t1 = new ToolTip();
            t1.SetToolTip(pictureBox6, "Сотрудники");
            ToolTip t2 = new ToolTip();
            t2.SetToolTip(pictureBox4, "Присвоение инвентарного номера сотруднику");
            ToolTip t3 = new ToolTip();
            t3.SetToolTip(pictureBox3, "Склад");
            ToolTip t4 = new ToolTip();
            t4.SetToolTip(pictureBox5, "Инвентарный номер");
            ToolTip t5 = new ToolTip();
            t5.SetToolTip(btnAdd, "Присвоить номер");
            ToolTip t6 = new ToolTip();
            t6.SetToolTip(btnDelPodkl, "Переместить номер на склад");
            ToolTip t7 = new ToolTip();
            t7.SetToolTip(btnNewInvNumber, "Добавить инвентарный номер");
            ToolTip t8 = new ToolTip();
            t8.SetToolTip(btnNewEmployee, "Добавить сотрудника");
            ToolTip t9 = new ToolTip();
            t9.SetToolTip(btnChangeInvNumber, "Изменить данные о инвентарном номере");
            ToolTip t10 = new ToolTip();
            t10.SetToolTip(btnChangeEmployee, "Изменить данные о сотруднике");
            ToolTip t11 = new ToolTip();
            t11.SetToolTip(btnDelEmployee, "Удалить сотрудника");
            ToolTip t12 = new ToolTip();
            t12.SetToolTip(btnDelInvNumber, "Удалить инвентарный номер");
            ToolTip t13 = new ToolTip();
            t13.SetToolTip(btnLoad, "Обновить склад");
            ToolTip t14 = new ToolTip();
            t14.SetToolTip(btnNewTypeEquipment, "Новый тип оборудования");
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Запрос для извлечения данных из таблицы EmployeeEquipmentRelation
                    string query = @"SELECT EER.ID AS 'ID', E.FullName AS 'Сотрудник', EER.InventoryNumber AS 'Инвентарный номер', ET.Name AS 'Тип оборудования'
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

        private void btnLoad_Click(object sender, EventArgs e)
        { 
            LoadData();
        }
            private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Тип оборудования
            dataGridView1.Visible = false;  //свойство скрывает таблицы и кнопки
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            btnDelPodkl.Visible = false;
            btnNewInvNumber.Visible = false;
            btnNewEmployee.Visible = false;
            btnChangeInvNumber.Visible = false;
            btnChangeEmployee.Visible = false;
            btnDelEmployee.Visible = false;
            btnDelInvNumber.Visible = false;
            btnAdd.Visible = false;
            btnLoad.Visible = false;
            btnNewTypeEquipment.Visible = true;
            this.Text = "Тип оборудования";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Склад
            dataGridView1.Visible = false;  //свойство скрывает таблицы и кнопки
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
            btnDelPodkl.Visible = false;
            btnNewInvNumber.Visible = false;
            btnNewEmployee.Visible = false;
            btnChangeInvNumber.Visible = false;
            btnChangeEmployee.Visible = false;
            btnDelEmployee.Visible = false;
            btnDelInvNumber.Visible = false;
            btnAdd.Visible = false;
            btnLoad.Visible = true;
            btnNewTypeEquipment.Visible = false;
            this.Text = "Склад";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Присвоенные инвентарные номера
            dataGridView1.Visible = true;  //свойство скрывает таблицы и кнопки
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            btnDelPodkl.Visible = true;
            btnNewInvNumber.Visible = false;
            btnNewEmployee.Visible = false;
            btnChangeInvNumber.Visible = false;
            btnChangeEmployee.Visible = false;
            btnDelEmployee.Visible = false;
            btnDelInvNumber.Visible = false;
            btnAdd.Visible = true;
            btnLoad.Visible = true;
            btnNewTypeEquipment.Visible = false;
            this.Text = "Присвоение инвентраного номера";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Инвентарные номера
            dataGridView1.Visible = false;  //свойство скрывает таблицы и кнопки
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            btnDelPodkl.Visible = false;
            btnNewInvNumber.Visible = true;
            btnNewEmployee.Visible = false;
            btnChangeInvNumber.Visible = true;
            btnChangeEmployee.Visible = false;
            btnDelEmployee.Visible = false;
            btnDelInvNumber.Visible = true;
            btnAdd.Visible = false;
            btnLoad.Visible = false;
            btnNewTypeEquipment.Visible = false;
            this.Text = "Инвентарные номера";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Сотрудники
            dataGridView1.Visible = false;  //свойство скрывает таблицы и кнопки
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            dataGridView5.Visible = false;
            btnDelPodkl.Visible = false;
            btnNewInvNumber.Visible = false;
            btnNewEmployee.Visible = true;
            btnChangeInvNumber.Visible = false;
            btnChangeEmployee.Visible = true;
            btnDelEmployee.Visible = true;
            btnDelInvNumber.Visible = false;
            btnAdd.Visible = false;
            btnLoad.Visible = false;
            btnNewTypeEquipment.Visible = false;
            this.Text = "Сотрудники";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewPodks form1 = new NewPodks();
            form1.ShowDialog(); // Открыть Form1 как модальное окно
            LoadData(); // После закрытия Form1 обновить данные на Form2
        }

        private void btnNewInvNumber_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Запрос для добавления новой строки в таблицу
                    NewNumber new1 = new NewNumber();
                    if (new1.ShowDialog() == DialogResult.OK)
                    {
                        string script = "insert into EquipmentList values ('" + new1.textBox1.Text + "', '" + new1.textBox2.Text + "', '" + new1.textBox3.Text + "', '" + new1.textBox4.Text + "', '" + new1.textBox5.Text + "', '" + new1.dateTimePicker1.Text + "', '" + new1.comboBox1.Text + "')";
                        connection.Open();
                        SqlCommand sql = new SqlCommand(script, connection);
                        sql.ExecuteNonQuery();
                        connection.Close();

                        this.equipmentListTableAdapter.Fill(this.roslesDataSet.EquipmentList);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void btnChangeInvNumber_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    NewNumber new1 = new NewNumber();
                    int index = dataGridView3.CurrentRow.Index;

                    // Проверяем, что значение в dataGridView4[0, index].Value не null и может быть преобразовано в int
                    if (dataGridView3[0, index].Value != null && int.TryParse(dataGridView4[0, index].Value.ToString(), out int ID))
                    {
                        new1.textBox1.Text = Convert.ToString(dataGridView3[1, index].Value);
                        new1.textBox2.Text = Convert.ToString(dataGridView3[2, index].Value);
                        new1.textBox3.Text = Convert.ToString(dataGridView3[3, index].Value);
                        new1.textBox4.Text = Convert.ToString(dataGridView3[4, index].Value);
                        new1.textBox5.Text = Convert.ToString(dataGridView3[5, index].Value);
                        new1.dateTimePicker1.Text = Convert.ToString(dataGridView3[6, index].Value);
                        new1.comboBox1.Text = Convert.ToString(dataGridView3[7, index].Value);

                        if (new1.ShowDialog() == DialogResult.OK)
                        {
                            string script = "UPDATE EquipmentList SET " +
                                "Name = @Name, " +
                                "Manufacturer = @Manufacturer, " +
                                "Model = @Model, " +
                                "SN = @SN, " +
                                "InventoryNumber = @InventoryNumber, " +
                                "ProductionDate = @ProductionDate, " +
                                "EquipmentTypeID = @EquipmentTypeID " +
                                "WHERE ID = @ID";

                            connection.Open();
                            using (SqlCommand sql = new SqlCommand(script, connection))
                            {
                                sql.Parameters.AddWithValue("@Name", new1.textBox1.Text);
                                sql.Parameters.AddWithValue("@Manufacturer", new1.textBox2.Text);
                                sql.Parameters.AddWithValue("@Model", new1.textBox3.Text);
                                sql.Parameters.AddWithValue("@SN", new1.textBox4.Text);
                                sql.Parameters.AddWithValue("@InventoryNumber", new1.textBox5.Text);
                                sql.Parameters.AddWithValue("@ProductionDate", new1.dateTimePicker1.Text);
                                sql.Parameters.AddWithValue("@EquipmentTypeID", new1.comboBox1.Text);
                                sql.Parameters.AddWithValue("@ID", ID);

                                sql.ExecuteNonQuery();
                            }
                            connection.Close();

                            this.equipmentListTableAdapter.Fill(this.roslesDataSet.EquipmentList);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат ID или значение отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void btnChangeEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                NewEmployee new1 = new NewEmployee();
                int index = dataGridView4.CurrentRow.Index;
                int id_servise = Convert.ToInt32(dataGridView4[0, index].Value);
                new1.textBox1.Text = Convert.ToString(dataGridView4[1, index].Value);
                new1.textBox2.Text = Convert.ToString(dataGridView4[2, index].Value);
                new1.textBox3.Text = Convert.ToString(dataGridView4[3, index].Value);

                if (new1.ShowDialog() == DialogResult.OK)
                {
                    string script = "update Employees set FullName= '" + new1.textBox1.Text + "', Position= '" + new1.textBox2.Text + "', Office='" + new1.textBox3.Text + "' where ID= " + id_servise;
                    connection.Open();
                    SqlCommand sql = new SqlCommand(script, connection);
                    sql.ExecuteNonQuery();
                    connection.Close();

                    this.employeesTableAdapter.Fill(this.roslesDataSet.Employees);
                }
            }
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Запрос для добавления новой строки в таблицу
                    NewEmployee new1 = new NewEmployee();
                    if (new1.ShowDialog() == DialogResult.OK)
                    {
                        string script = "insert into Employees values ('" + new1.textBox1.Text + "', '" + new1.textBox2.Text + "', '" + new1.textBox3.Text + "')";
                        connection.Open();
                        SqlCommand sql = new SqlCommand(script, connection);
                        sql.ExecuteNonQuery();
                        connection.Close();

                        this.employeesTableAdapter.Fill(this.roslesDataSet.Employees);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void btnDelPodkl_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int index = dataGridView1.CurrentRow.Index;

            // Проверяем, что значение в dataGridView1[0, index].Value не null и может быть преобразовано в int
            if (dataGridView1[0, index].Value != null && int.TryParse(dataGridView1[0, index].Value.ToString(), out int id_Material))
            {
                string script1 = "DELETE FROM EmployeeEquipmentRelation WHERE ID = @ID";

                connection.Open();

                using (SqlCommand sql = new SqlCommand(script1, connection))
                {
                    // Используем параметр для id_Material
                    sql.Parameters.AddWithValue("@ID", id_Material);

                    sql.ExecuteNonQuery();
                }

                MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Неверный формат ID или значение отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void btnDelInvNumber_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int index = dataGridView3.CurrentRow.Index;

            // Проверяем, что значение в dataGridView1[0, index].Value не null и может быть преобразовано в int
            if (dataGridView3[0, index].Value != null && int.TryParse(dataGridView3[0, index].Value.ToString(), out int id_Material))
            {
                string script1 = "DELETE FROM EquipmentList WHERE ID = @ID";

                connection.Open();

                using (SqlCommand sql = new SqlCommand(script1, connection))
                {
                    // Используем параметр для id_Material
                    sql.Parameters.AddWithValue("@ID", id_Material);

                    sql.ExecuteNonQuery();
                }

                MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Неверный формат ID или значение отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.equipmentListTableAdapter.Fill(this.roslesDataSet.EquipmentList);
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int index = dataGridView4.CurrentRow.Index;
                int id_adm = Convert.ToInt32(dataGridView4[0, index].Value);
                string script = "delete from Employees where ID=" + id_adm;
                connection.Open();
                SqlCommand sql = new SqlCommand(script, connection);
                sql.ExecuteNonQuery();
                connection.Close();

                this.employeesTableAdapter.Fill(this.roslesDataSet.Employees);
            }
        }

        private void btnNewTypeEquipment_Click(object obj, EventArgs e) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Запрос для добавления новой строки в таблицу
                    NewEquipmentType new1 = new NewEquipmentType();
                    if (new1.ShowDialog() == DialogResult.OK)
                    {
                        string script = "insert into EquipmentType values ('" + new1.textBox1.Text + "')";
                        connection.Open();
                        SqlCommand sql = new SqlCommand(script, connection);
                        sql.ExecuteNonQuery();
                        connection.Close();

                        this.equipmentTypeTableAdapter.Fill(this.roslesDataSet.EquipmentType);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }



        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView1.Columns["Сотрудник"].HeaderText = "Сотрудник";
            dataGridView1.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridView1.Columns["Тип оборудования"].HeaderText = "Тип оборудования";
        }
        private void dataGridView4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView4.Columns["Полиное имя"].HeaderText = "Полное имя";
            dataGridView4.Columns["Должность"].HeaderText = "Должность";
            dataGridView4.Columns["Кабинет"].HeaderText = "Кабинет";
        }
        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView1.Columns["Сотрудник"].HeaderText = "Сотрудник";
            dataGridView1.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridView1.Columns["Тип оборудования"].HeaderText = "Тип оборудования";
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView1.Columns["Сотрудник"].HeaderText = "Сотрудник";
            dataGridView1.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridView1.Columns["Тип оборудования"].HeaderText = "Тип оборудования";
        }
        private void dataGridView5_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Изменение заголовков столбцов на русский язык
            dataGridView1.Columns["Сотрудник"].HeaderText = "Сотрудник";
            dataGridView1.Columns["Инвентарный номер"].HeaderText = "Инвентарный номер";
            dataGridView1.Columns["Тип оборудования"].HeaderText = "Тип оборудования";
        }
    }
}
