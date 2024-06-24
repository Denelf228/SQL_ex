using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace final
{
    public class ExcelExporterForm2
    {
        public void ExportExcel(DataGridView dataGridView1)
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Данные для экспорта не обнаружены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    excel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Проверяем, что значение ячейки не равно null
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            excel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            // Записываем пустую строку, если значение ячейки равно null
                            excel.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                excel.Range[excel.Cells[1, 1], excel.Cells[1, dataGridView1.Columns.Count]].Interior.Color = System.Drawing.Color.LightBlue.ToArgb();
                excel.Range[excel.Cells[1, 1], excel.Cells[dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                excel.Columns.AutoFit();
                excel.Visible = true;
                excel = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            /*if (dataGridView1 == null || dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Данные для экспорта не обнаружены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    excel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        excel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                excel.Range[excel.Cells[1, 1], excel.Cells[1, dataGridView1.Columns.Count]].Interior.Color = System.Drawing.Color.LightBlue.ToArgb();
                excel.Range[excel.Cells[1, 1], excel.Cells[dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                excel.Columns.AutoFit();
                excel.Visible = true;
                excel = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }
    }
}
