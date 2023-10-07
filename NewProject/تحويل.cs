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
	public partial class تحويل : Form
	{
		Model1 Ent = new Model1();
		public تحويل()
		{
			InitializeComponent();
		}

		private void تحويل_Load(object sender, EventArgs e)
		{

			loadData();
			comboBox1.DataSource = (from em in Ent.Products
									select new { em.ProductID, em.Name }).ToList();
			comboBox1.ValueMember = "ProductID";
			comboBox1.DisplayMember = "Name";
		}
		public void loadData()
		{

			var st = from i in Ent.Imports
					 join t in Ent.ImportLogs on i.ImportID equals t.FK_Import
					 join s in Ent.Stores on i.FK_StoreID equals s.StoreID
					 join p in Ent.Products on t.FK_ProductID equals p.ProductID

					 select new
					 {
						 ProductName = p.Name,
						 StoreName = s.Name,

					 };
			dataGridView1.DataSource = st.ToList();

		}



		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			loadData();

		}

		private void button1_Click(object sender, EventArgs e)
		{

			var st = from i in Ent.Imports
					 join t in Ent.ImportLogs on i.ImportID equals t.FK_Import
					 join s in Ent.Stores on i.FK_StoreID equals s.StoreID
					 join p in Ent.Products on t.FK_ProductID equals p.ProductID
					 where p.Name == comboBox1.Text

					 select new
					 {

						 ProductName = p.Name,
						 StoreName = s.Name,

					 };
			dataGridView1.DataSource = st.ToList();

			comboBox2.DataSource = (from i in Ent.Imports
									join t in Ent.ImportLogs on i.ImportID equals t.FK_Import
									join s in Ent.Stores on i.FK_StoreID equals s.StoreID
									join p in Ent.Products on t.FK_ProductID equals p.ProductID
									where p.Name == comboBox1.Text


									select new { s.Name, s.StoreID }).ToList();
			comboBox2.ValueMember = "StoreID";
			comboBox2.DisplayMember = "Name";

			comboBox3.DataSource = (from em in Ent.Stores
									select new { em.StoreID, em.Name }).ToList();
			comboBox3.ValueMember = "StoreID";
			comboBox3.DisplayMember = "Name";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var form1 = (Form1)Tag;
			form1.Show();
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Transfer im = new Transfer();
			var x=Ent.ImportLogs.FirstOrDefault(c => c.FK_ProductID.ToString() == comboBox1.SelectedValue.ToString() && c.Import.FK_StoreID.ToString() == comboBox2.SelectedValue.ToString());
			if (comboBox1.Text != "" && comboBox2.Text != "")
			{
				im.Quantity = x.Quantity;
				im.ProductionDate = x.ProductionDate;
				im.ExpireDate = x.ExpireDate;
				im.FK_ProductID = int.Parse(comboBox1.SelectedValue.ToString());
				im.FK_SupplierID = x.FK_SupplierID;
				im.FK_FromStoreID = int.Parse(comboBox2.SelectedValue.ToString());
				im.FK_ToStoreID = int.Parse(comboBox3.SelectedValue.ToString());

				Ent.Transfers.Add(im);
				Ent.SaveChanges();
				comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
				loadData();

			}
			else
			{
				MessageBox.Show("Empty Data");
			}

		}

	}
}

