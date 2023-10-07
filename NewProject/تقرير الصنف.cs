using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NewProject
{
	public partial class Form8 : Form
	{Model1 Ent =new Model1();
		public Form8()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
			var st = from p in Ent.Stores
					 join o in Ent.Imports
					 on p.StoreID equals o.FK_StoreID
					 join k in Ent.ImportLogs
					 on o.ImportID equals k.FK_Import
					 join j in Ent.Products
					 on k.FK_ProductID equals j.ProductID
					 where o.Date >= dateTimePicker1.Value &&o.Date <= dateTimePicker2.Value
					

					 select new
					 {
						 
						 ProductName = j.Name,
						 StoreName = p.Name,
						 Date=o.Date,
						 Quantity=k.Quantity,
						 ProductionDate=k.ProductionDate,
						 ExpireDate=k.ExpireDate
						 
					 };
			dataGridView1.DataSource = st.ToList();
		}
		private void ExportToExcel()
		{
			// Create a new Excel application.
			Excel.Application excelApp = new Excel.Application();

			// Create a new workbook.
			Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();

			// Create a new worksheet.
			Excel.Worksheet excelWorksheet = excelWorkbook.Sheets.Add();

			// Set the Excel column headers from the DataGridView column names.
			for (int i = 0; i < dataGridView1.Columns.Count; i++)
			{
				excelWorksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
			}

			// Copy the data from the DataGridView to the Excel worksheet.
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					excelWorksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
				}
			}

			// Save the Excel file.
			excelWorkbook.SaveAs("Product_data.xlsx");

			// Close Excel and release resources.
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ExportToExcel();

		}
	}
}
