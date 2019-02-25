using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class 登录对话框 : Form
    {
        private bool loginState = false;
        public 登录对话框()
        {
            InitializeComponent();
        }

        private void 登录对话框_Load(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            DataSet ds=sh.selectReturnDataSet("select 用户名 from dbo.用户表", null, CommandType.Text);
            comboBox1.DisplayMember = "用户名";
            comboBox1.ValueMember = "用户名";
            comboBox1.DataSource = ds.Tables[0];
        }

        private void 登录对话框_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loginState)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string get_ps = sh.selectReturnString("select 密码 from dbo.用户表", null, CommandType.Text);
            if (textBox1.Text != get_ps)
            {
                MessageBox.Show("密码错误！");
            }
            else
            {
                Form1.loginUser = comboBox1.Text;
                loginState = true;
                this.Close();
            }
        }
    }
}
