using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point click;
        Graphics g;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.Azure);
            g.DrawEllipse(Pens.Black, 100, 100, 200, 200);
            g.DrawRectangle(Pens.Black, 300,300, 200,200);
            g.DrawLine(Pens.Black, 600, 600, 700, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            g.DrawRectangle(Pens.Black, click.X, click.Y, 200, 200);
        }
    }
}
