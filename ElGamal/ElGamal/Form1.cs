using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElGamal
{
    public partial class Form1 : Form
    {
        static private BigInteger p = 11, x = 8;
        static private int g = 2, y = 3;
        private ElGamal _elGamal = new ElGamal();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = _elGamal.Encrypt(p, g, y, textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = _elGamal.Deencrypt(p, x, textBox2.Text);
        }
    }
}
