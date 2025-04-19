using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_интерактивного_обучающего_пособия
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14(); // Открываем следующую форму
            form14.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15(); // Открываем следующую форму
            form15.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(); // Открываем следующую форму
            form16.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17(); // Открываем следующую форму
            form17.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18(); // Открываем следующую форму
            form18.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19(); // Открываем следующую форму
            form19.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20(); // Открываем следующую форму
            form20.Show();
            this.Hide();
        }

        private void Form13_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12(); // Переход на Form4
            form12.Show();
            this.Hide();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form21 form21 = new Form21(); // Переход на Form4
            form21.Show();
            this.Hide();
        }
    }
}
