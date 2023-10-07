using NewProject;
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
	public partial class Form7 : Form
	{
		Model1 Ent = new Model1();

		public Form7()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}



		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}

		private void label7_Click_1(object sender, EventArgs e)
		{

		}

		private void Form7_Load(object sender, EventArgs e)
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
			var st = from i in Ent.Imports
					 join t in Ent.ImportLogs on i.ImportID equals t.FK_Import
					 join s in Ent.Stores on i.FK_StoreID equals s.StoreID
					 join su in Ent.Suppliers on t.FK_SupplierID equals su.SupplierID
					 join p in Ent.Products on t.FK_ProductID equals p.ProductID
					 orderby i.ImportID


					 select new
					 {

						 ID = i.ImportID,
						 StoreName = s.Name,
						 SerialNumber = i.Serial,
						 SerialDate = i.Date,
						 ProductName = p.Name,
						 Quantity = t.Quantity,
						 SupplierName = su.Name,
						 ProductionDate = t.ProductionDate,
						 ExpireDate = t.ExpireDate
					 };
			dataGridView1.DataSource = st.ToList();

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}


		private void button2_Click_1(object sender, EventArgs e)
		{
			Import im = new Import();



			if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && dateTimePicker1.Text != "" && textBox4.Text != "" && comboBox2.Text != "" && dateTimePicker2.Text != "" && dateTimePicker3.Text != "")
			{
				Import n = Ent.Imports.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					im.ImportID = int.Parse(textBox1.Text);
					im.FK_StoreID = (int?)comboBox1.SelectedValue;
					im.Serial = textBox3.Text;
					im.Date = dateTimePicker1.Value;
					im.ImportLogs.Add(new ImportLog
					{
						FK_ProductID = (int)comboBox3.SelectedValue,
						Quantity = int.Parse(textBox4.Text),
						FK_SupplierID = (int)comboBox2.SelectedValue,
						ProductionDate = dateTimePicker2.Value,
						ExpireDate = dateTimePicker3.Value,
					});
					Ent.Imports.Add(im);
					Ent.SaveChanges();
					textBox1.Text = comboBox1.Text = textBox3.Text = textBox4.Text = dateTimePicker1.Text = textBox4.Text = comboBox2.Text = dateTimePicker2.Text = dateTimePicker3.Text = "";
					dataGridView1.DataSource = null;
					loadData();

				}
				else
				{
					MessageBox.Show("import Exist");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Import im = Ent.Imports.Find(int.Parse(textBox1.Text));
			if (im != null)
			{
				if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && dateTimePicker1.Text != "" && textBox4.Text != "" && comboBox2.Text != "" && dateTimePicker2.Text != "" && dateTimePicker3.Text != "")
				{
					im.ImportID = int.Parse(textBox1.Text);
					im.FK_StoreID = int.Parse(comboBox1.Text);
					im.Serial = textBox3.Text;
					im.Date = dateTimePicker1.Value;
					im.ImportLogs.Equals(new ImportLog
					{
						FK_ProductID = int.Parse(comboBox3.Text),
						Quantity = int.Parse(textBox4.Text),
						FK_SupplierID = int.Parse(comboBox2.Text),
						ProductionDate = dateTimePicker2.Value,
						ExpireDate = dateTimePicker3.Value,
					});
					Ent.SaveChanges();
					textBox1.Text = comboBox1.Text = textBox3.Text = textBox4.Text = dateTimePicker1.Text = textBox4.Text = comboBox2.Text = dateTimePicker2.Text = dateTimePicker3.Text = "";
					dataGridView1.DataSource = null;
					loadData();
				}
				else
				{
					MessageBox.Show("there r missing inputs ");
				}
			}
			else
			{
				MessageBox.Show("No Data");
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
	}
}
