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
    public partial class Form21 : Form
    {
      
        public Form21()
        {
            InitializeComponent();
       
        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }
        

        private void Form21_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
