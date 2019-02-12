using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace examplePaint
{
    public partial class Form1 : Form
    {
        FigurRektangel rekt;
        FigurCircel circ;
        public Form1()
        {
            InitializeComponent();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rekt = new FigurRektangel();
            this.Controls.Add(rekt);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            circ = new FigurCircel("pen");
            this.Controls.Add(circ);
        }
    }
}
