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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void المخزنToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.Tag = this;
			form2.Show();
			Hide();
		}

		private void الصنفToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form3 form3 = new Form3();
			form3.Tag = this;
			form3.Show();
			Hide();
		}

		private void الموردToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void العميلToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form5 form4 = new Form5();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form6 form4 = new Form6();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form10 form4 = new Form10();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void اذنتوريدToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form7 form4 = new Form7();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form8 form4 = new Form8();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void اذنToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form9 form4 = new Form9();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void تحويلToolStripMenuItem_Click(object sender, EventArgs e)
		{
			تحويل form4 = new تحويل();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Form11 form4 = new Form11();
			form4.Tag = this;
			form4.Show();
			Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{

			Form12 form4 = new Form12();
			form4.Tag = this;
			form4.Show();
			Hide();
		}
	}
}
