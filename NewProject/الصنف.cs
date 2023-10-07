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
	public partial class Form3 : Form
	{
		Model1 Ent = new Model1();

		public Form3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			loadData();
			foreach (Unit dpt in Ent.Units)
			{
				comboBox1.Items.Add(dpt.Name);
			}

		}
		private void loadData()
		{
			var st = from p in Ent.Products
					 select new
					 {
						 ID = p.ProductID,
						 Code = p.Code,
						 Name = p.Name,
						 Unit = p.FK_UnitID
					 };
			dataGridView1.DataSource = st.ToList();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Product pr = new Product();
			if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
			{
				Product n = Ent.Products.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					pr.ProductID = int.Parse(textBox1.Text);
					pr.Code = textBox2.Text;
					pr.Name = textBox3.Text;
					Unit Emp = (from d in Ent.Units
									where d.Name == comboBox1.Text
									select d).FirstOrDefault();
					pr.FK_UnitID = Emp.UnitID;
					Ent.Products.Add(pr);
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
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
			Product ch = Ent.Products.Find(int.Parse(textBox1.Text));
			if (ch != null)
			{
				if (textBox3.Text != "" && comboBox1.Text!="")
				{
					ch.Code = textBox2.Text;
					ch.Name = textBox3.Text;
					Unit Emp = (from d in Ent.Units
									where d.Name == comboBox1.Text
									select d).FirstOrDefault();
					ch.FK_UnitID = Emp.UnitID;
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
					dataGridView1.DataSource = null;
					loadData();
				}
				else
				{
					MessageBox.Show("there are missing inputs ");
				}
			}
			else
			{
				MessageBox.Show("No Data");
			}
		}

		

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
	}
}
