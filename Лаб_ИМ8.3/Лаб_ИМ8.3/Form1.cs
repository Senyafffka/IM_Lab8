using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб_ИМ8._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int trials;
        int[] counts;
        double[] probabilities;
        const int CountEvents = 5;

        public void Init()
        {
            trials = (int)numericUpDown6.Value;
            counts = new int[CountEvents];

            probabilities = new double[CountEvents]
            {
                (double)numericUpDown1.Value,
                (double)numericUpDown2.Value,
                (double)numericUpDown3.Value,
                (double)numericUpDown4.Value,
                1
            };
      
            for (int i = 0; i < CountEvents - 1; i++) probabilities[CountEvents - 1] -= probabilities[i];

            chart1.Series[0].Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();

            if (probabilities[4] < 0)
            {
                MessageBox.Show("Некорректно введены вероятности");
                return;
            }
            numericUpDown6.Value = (decimal)probabilities[CountEvents - 1];

            for (int i = 0; i < trials; i++)
            {
                var p = random.NextDouble();
                counts[GetEvent(p)]++;
            }

            for (int i = 0; i < CountEvents; i++)
            {
                var value = (float)counts[i] / trials;
                chart1.Series[0].Points.AddXY(i + 1, value);
            }
        }
        private int GetEvent(double p)
        {
            int i = 0;
            while (p >= 0)
            {
                p -= probabilities[i];
                i++;
            }

            return i - 1;
        }
    }
}
