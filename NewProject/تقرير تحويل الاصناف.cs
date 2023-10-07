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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewProject
{
	public partial class Form10 : Form
	{Model1 Ent=new Model1();
		public Form10()
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
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					excelWorksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
				}
			}

			// Save the Excel file.
			excelWorkbook.SaveAs("Transfer_data.xlsx");

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
			var st = from i in Ent.Transfers
					 join p in Ent.Products on i.FK_ProductID equals p.ProductID
					 join su in Ent.Suppliers on i.FK_SupplierID equals su.SupplierID
					 join s in Ent.Stores on i.FK_ToStoreID equals s.StoreID
					 join se in Ent.Stores on i.FK_FromStoreID equals se.StoreID

					 
					 

					 select new
					 {

						 ProductName = p.Name,
						 Quantity = i.Quantity,
						 ProductionDate=i.ProductionDate,
						 ExpireDate=i.ExpireDate,
						 Supplier=su.Name,
						 From=se.Name,
						 To =s.Name,
					 };
			dataGridView1.DataSource = st.ToList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ExportToExcel();
		}
	}
}
