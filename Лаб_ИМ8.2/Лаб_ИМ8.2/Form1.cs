using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Лаб_ИМ8._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] y_mass = new string[3] { "Конечно!", "Сто процентов!", "Однозначно да"};
        string[] n_mass = new string[3] { "Ни за что!", "Точно нет!", "Это плохо кончится"};
        string[] mb_mass = new string[3] { "Наверное", "Может быть", "50/50" };
        double[] probabilities = new double[3] { 0.25, 0.25, 0.50 };

        Random random = new Random();
        int variation;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            double probability = random.NextDouble();

            int answer = 0;
            while (probability >= 0)
            {
                probability -= probabilities[answer];
                answer++;
            }
            answer--;

            variation = random.Next(0, 3);
            switch (answer)
            {
                case 0:
                    listBox1.Items.Add(n_mass[variation]);
                    break;
                case 1:
                    listBox1.Items.Add(y_mass[variation]);
                    break;
                case 2:
                    listBox1.Items.Add(mb_mass[variation]);
                    break;
            }
        }
    }
}
