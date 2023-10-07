using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewProject
{
	public partial class Form9 : Form
	{
		Model1 Ent =new Model1();
		public Form9()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

	

		private void Form9_Load(object sender, EventArgs e)
		{
			loadData();



			comboBox1.DataSource = (from em in Ent.Stores
									select new { em.StoreID, em.Name }).ToList();
			comboBox1.ValueMember = "StoreID";
			comboBox1.DisplayMember = "Name";

			comboBox2.DataSource = (from em in Ent.Suppliers
									select new { em.SupplierID, em.Name }).ToList();
			comboBox2.ValueMember = "SupplierID";
			comboBox2.DisplayMember = "Name";
			comboBox3.DataSource = (from em in Ent.Products
									select new { em.ProductID, em.Name }).ToList();
			comboBox3.ValueMember = "ProductID";
			comboBox3.DisplayMember = "Name";
		}
		public void loadData()
		{
			var st = from i in Ent.Exports
					 join t in Ent.ExportLogs on i.ExportID equals t.FK_ExportID
					 join s in Ent.Stores on i.FK_StoreID equals s.StoreID
					 join su in Ent.Suppliers on t.FK_SupplierID equals su.SupplierID
					 join p in Ent.Products on t.FK_ProductID equals p.ProductID
					 orderby i.ExportID

					 select new
					 {

						 ID = i.ExportID,
						 StoreName = s.Name,
						 SerialNumber = i.Serial,
						 SerialDate = i.Date,
						 ProductName = p.Name,
						 Quantity = t.Quantity,
						 SupplierName = su.Name,
						
					 };
			dataGridView1.DataSource = st.ToList();

		}
		private void button2_Click(object sender, EventArgs e)
		{
			Export im = new Export();



			if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && dateTimePicker1.Text != "" && textBox4.Text != "" && comboBox2.Text != "")
			{
				Export n = Ent.Exports.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					im.ExportID = int.Parse(textBox1.Text);
					im.FK_StoreID = (int?)comboBox1.SelectedValue;
					im.Serial = textBox3.Text;
					im.Date = dateTimePicker1.Value;
					im.ExportLogs.Add(new ExportLog
					{
						FK_ProductID = (int)comboBox3.SelectedValue,
						Quantity = int.Parse(textBox4.Text),
						FK_SupplierID = (int)comboBox2.SelectedValue,
						
					});
					Ent.Exports.Add(im);
					Ent.SaveChanges();
					textBox1.Text = comboBox1.Text = textBox3.Text = textBox4.Text = dateTimePicker1.Text = textBox4.Text = comboBox2.Text = "";
					dataGridView1.DataSource = null;
					loadData();

				}
				else
				{
					MessageBox.Show("Export Exist");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}
	}
}
