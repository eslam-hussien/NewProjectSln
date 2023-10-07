using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel =Microsoft.Office.Interop.Excel;

namespace NewProject
{
	public partial class Form6 : Form
	{
		Model1 Ent = new Model1();

		public Form6()
		{
			InitializeComponent();
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
		for (int i = 0; i < dataGridView1.Rows.Count ; i++)
		{
			for (int j = 0; j < dataGridView1.Columns.Count; j++)
			{
				excelWorksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
			}
		}

		// Save the Excel file.
		excelWorkbook.SaveAs("Store_data.xlsx");

		// Close Excel and release resources.
		excelApp.Quit();
		System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
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
					 join a in Ent.Employees
					 on p.EmployeeID equals a.Id
					 join o in Ent.Imports
					 on p.StoreID equals o.FK_StoreID
					 join w in Ent.Exports
					 on p.StoreID equals w.FK_StoreID
					 join k in Ent.ImportLogs
					 on o.ImportID equals k.FK_Import
					 join j in Ent.Products
					 on k.FK_ProductID equals j.ProductID
					 join r in Ent.ExportLogs
					 on w.ExportID equals r.FK_ExportID

					 select new
					 {
						 ID = p.StoreID,
						 StoreName = p.Name,
						 Address = p.Address,
						 Employee =a.Name,
						 ProductName=j.Name,
						 ProductCode=j.Code,
						 ImportSerial=o.Serial,
						 ImportDate=o.Date,
						 ProductionDate=k.ProductionDate,
						 ExpireDate=k.ExpireDate,
						 ImportQuantity=k.Quantity,
						 ExportSerial = w.Serial,
						 ExportDate = w.Date,
						 ExportQuantity = r.Quantity,
					 };
			dataGridView1.DataSource = st.ToList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ExportToExcel();

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
