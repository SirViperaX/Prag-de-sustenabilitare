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

namespace Lab_10._05
{
    public partial class Form1 : Form
    {
        Map demo;
        MyGraphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            demo = new Map();
            demo.Load(@"..\..\input.txt");
            g = new MyGraphics();
            g.InitGraph(pictureBox1);
            demo.Draw(g);
            g.RefreshGraph();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(demo.CountNumOf1().ToString());
            g.ClearGraph();
            demo.Tick();
            demo.Draw(g);
            g.RefreshGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
