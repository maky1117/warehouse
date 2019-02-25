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
    public partial class LabeledCheckBox : UserControl
    {
        public LabeledCheckBox()
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
            }
        }
        public bool Value
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
            }
        }
    }
}
