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
	public partial class Form4 : Form
	{
		Model1 Ent = new Model1();
		public Form4()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			loadData();

		}
		private void loadData()
		{
			var st = from p in Ent.Suppliers
					 select new
					 {
						 ID = p.SupplierID,
						 Name = p.Name,
						 Phone = p.Phone,
						 Fax = p.Fax,
						 Mobile = p.Mobile,
						 Mail = p.Mail,
						 URL = p.URL
					 };
			dataGridView1.DataSource = st.ToList();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Supplier sr = new Supplier();
			if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "" )
			{
				Supplier n = Ent.Suppliers.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					sr.SupplierID = int.Parse(textBox1.Text);
					sr.Name = textBox2.Text;
					sr.Phone = textBox3.Text;
					sr.Fax = textBox4.Text;
					sr.Mobile = textBox5.Text;
					sr.Mail = textBox6.Text;
					sr.URL = textBox7.Text;
					Ent.Suppliers.Add(sr);
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text= textBox6.Text= textBox7.Text= "";
					dataGridView1.DataSource = null;
					loadData();

				}
				else
				{
					MessageBox.Show("Product Exist");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		
		private void button3_Click(object sender, EventArgs e)
		{
			Supplier sr = Ent.Suppliers.Find(int.Parse(textBox1.Text));
			if (sr != null)
			{
				if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "")
				{
					sr.SupplierID = int.Parse(textBox1.Text);
					sr.Name = textBox2.Text;
					sr.Phone = textBox3.Text;
					sr.Fax = textBox4.Text;
					sr.Mobile = textBox5.Text;
					sr.Mail = textBox6.Text;
					sr.URL = textBox7.Text;
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
					dataGridView1.DataSource = null;
					loadData();
				}
				else
				{
					MessageBox.Show("there are missing inputs");
				}
			}
			else
			{
				MessageBox.Show("No Data");
			}
		}
	}
}
