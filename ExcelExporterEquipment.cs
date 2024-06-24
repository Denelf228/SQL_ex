using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace final
{
    public class ExcelExporterEquipment
    {
        public void ExportExcel(DataGridView table_oborud)
        {
            if (table_oborud == null || table_oborud.Rows.Count <= 0)
            {
                MessageBox.Show("Данные для экспорта не обнаружены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < table_oborud.Columns.Count + 1; i++)
                {
                    excel.Cells[1, i] = table_oborud.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < table_oborud.Rows.Count; i++)
                {
                    for (int j = 0; j < table_oborud.Columns.Count; j++)
                    {
                        // Проверяем, что значение ячейки не равно null
                        if (table_oborud.Rows[i].Cells[j].Value != null)
                        {
                            excel.Cells[i + 2, j + 1] = table_oborud.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            // Записываем пустую строку, если значение ячейки равно null
                            excel.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                excel.Range[excel.Cells[1, 1], excel.Cells[1, table_oborud.Columns.Count]].Interior.Color = System.Drawing.Color.LightBlue.ToArgb();
                excel.Range[excel.Cells[1, 1], excel.Cells[table_oborud.Rows.Count + 1, table_oborud.Columns.Count]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                excel.Columns.AutoFit();
                excel.Visible = true;
                excel = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        }
}
