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
	public partial class Form2 : Form
	{
		Model1 Ent = new Model1();

		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			loadData();
			foreach (Employee dpt in Ent.Employees)
			{
				comboBox1.Items.Add(dpt.Name);
			}
		}
		
		private void loadData()
		{
			var st = from p in Ent.Stores
					 join e in Ent.Employees
					 on p.EmployeeID equals e.Id
					  
					 select new
					 {
						 ID = p.StoreID,
						 Name = p.Name,
						 Address = p.Address,
						 Employee = e.Name
					 };
			dataGridView1.DataSource = st.ToList();
			
		}
		private void button2_Click(object sender, EventArgs e)
		{
			Store st = new Store();
			if (textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
			{
				Store n = Ent.Stores.Find(int.Parse(textBox1.Text));
				if (n == null)
				{
					st.StoreID = int.Parse(textBox1.Text);
					st.Name = textBox2.Text;
					st.Address = textBox3.Text;
					Employee Emp = (from d in Ent.Employees
									where d.Name == comboBox1.Text
									select d).FirstOrDefault();
					st.EmployeeID = Emp.Id;
					Ent.Stores.Add(st);
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
					dataGridView1.DataSource = null;
					loadData();

				}
				else
				{
					MessageBox.Show("Store Exist");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Store ch = Ent.Stores.Find(int.Parse(textBox1.Text));
			if (ch != null)
			{
				if (textBox2.Text != "" && comboBox1.Text!="")
				{
					ch.Name = textBox2.Text;
					ch.Address = textBox3.Text;
					Employee Emp = (from d in Ent.Employees
									where d.Name == comboBox1.Text
									select d).FirstOrDefault();
					ch.EmployeeID = Emp.Id;
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = textBox3.Text = comboBox1.Text = "";
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

		

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
				
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
