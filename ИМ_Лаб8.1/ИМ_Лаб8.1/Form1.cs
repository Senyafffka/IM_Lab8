using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИМ_Лаб8._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        const double p = 80;    

        private void button1_Click(object sender, EventArgs e)
        {
            if (rnd.Next(0, 101) < p) {
                label2.Text = "Да";
            }
            else
            {
                label2.Text = "Нет";
            }
        }
    }
}
