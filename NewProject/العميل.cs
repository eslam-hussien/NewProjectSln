using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject
{
	public partial class Form5 : Form
	{
		Model1 Ent = new Model1();

		public Form5()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void Form5_Load(object sender, EventArgs e)
		{
			loadData();
		}
		private void loadData()
		{
			var st = from p in Ent.Customers
					 select new
					 {
						 ID = p.CustomerID,
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
			Customer sr = new Customer();
			if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "")
			{
				Customer n = Ent.Customers.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					sr.CustomerID = int.Parse(textBox1.Text);
					sr.Name = textBox2.Text;
					sr.Phone = textBox3.Text;
					sr.Fax = textBox4.Text;
					sr.Mobile = textBox5.Text;
					sr.Mail = textBox6.Text;
					sr.URL = textBox7.Text;
					Ent.Customers.Add(sr);
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
					dataGridView1.DataSource = null;
					loadData();

				}
				else
				{
					MessageBox.Show("Customer Exist");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		

		private void button3_Click(object sender, EventArgs e)
		{
			Customer sr = Ent.Customers.Find(int.Parse(textBox1.Text));
			if (sr != null)
			{
				if (textBox2.Text != "" && textBox2.Text != "" && textBox5.Text != "")
				{
					sr.CustomerID = int.Parse(textBox1.Text);
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
					MessageBox.Show("there r missing inputs ");
				}
			}
			else
			{
				MessageBox.Show("No Data");
			}
		}
	}
}
