using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 仓库管理
{
    public partial class LabeledTextBox : UserControl
    {
        private string bg_text;
        public LabeledTextBox()
        {
            InitializeComponent();
            
        }
        public string Label
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                textBox1.Text= bg_text = "如：" + label1.Text;
                textBox1.ForeColor = Color.LightGray;
                textBox1.Left = label1.Right + 10;
                this.Width = textBox1.Right + 10;
            }
        }
        public string Value
        {
            get
            {
                return (textBox1.ForeColor == Color.Black) ? textBox1.Text : "";
            }
            set
            {
                textBox1.Text = value;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.ForeColor == Color.LightGray)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = bg_text;
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.ForeColor = Color.Black;
            }
        }
    }
}
