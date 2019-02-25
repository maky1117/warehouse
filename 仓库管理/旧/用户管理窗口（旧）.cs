using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class 用户管理窗口_old : Form
    {
        public int _scrollValue = 0;//获取dataGridView1滚动位置
        public 用户管理窗口_old()
        {
            InitializeComponent();
        }
        private void 用户管理窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        /// <summary>
        /// 填充dataGridView1数据
        /// </summary>
        private void initForm()
        {
            SqlHelper sh = new SqlHelper();
            DataTable dt = sh.selectReturnDataSet("select 用户ID,用户名,姓名,性别,联系方式,密码,角色,启禁标志 from dbo.用户表 where 删除标志=0", null, CommandType.Text).Tables[0];
            dataGridView1.DataSource = dt;
            foreach(DataGridViewColumn dc in dataGridView1.Columns)
            {
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Rows[0].Cells[1].Selected = true;
            if (_scrollValue > dataGridView1.RowCount&&_scrollValue!=0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount;
            }
            else
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = _scrollValue;
            }
        }
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 增加btn_Click(object sender, EventArgs e)
        {
            check启用();
            SqlHelper sh = new SqlHelper();
            string 用户名 = 用户名txtbx.Text;
            string 姓名 = 姓名txtbx.Text;
            string 性别= 性别txtbx.Text;
            string 联系方式= 联系方式txtbx.Text;
            string 密码= 密码txtbx.Text;
            string 角色= 角色txtbx.Text;
            string sqlText = string.Format("insert into dbo.用户表(用户名,姓名,性别,联系方式,密码,角色)values('{0}','{1}','{2}','{3}','{4}','{5}')", 用户名, 姓名, 性别, 联系方式, 密码, 角色);
            try
            {
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    MessageBox.Show("添加“" + 用户名 + "”成功！");
                    initForm();
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Selected = true;

                    //string 详细内容 = "用户ID：" + sh.selectReturnString("select max(用户ID) from dbo.用户表",null,CommandType.Text) + " | 用户名：" +用户名;
                    writeHistory("添加","",-1);

                }
            }catch(Exception ee)
            {
                if (ee.Message.Contains("重复"))
                {
                    MessageBox.Show("用户名“"+用户名txtbx.Text+"”已存在！");
                }
            }
        }
        private void writeHistory(string 操作,string 用户ID,int rowIndex)
        {
            SqlHelper sh = new SqlHelper();
            string 操作用户ID = Form1.loginUser;            
            string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
            string 备注 = "";
            string 字段, 值, sqlText;
            int? result;
            if (操作 == "添加")
            {
                用户ID = sh.selectReturnString("select max(用户ID) from dbo.用户表", null, CommandType.Text);
                字段 = "用户ID";
                值 = 用户ID;
                sqlText = string.Format("insert into dbo.用户历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 用户ID, 操作用户ID, 操作, 时间, 字段, 值, 备注);
                result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                TextBox[] inputBoxes = { 用户名txtbx, 姓名txtbx, 性别txtbx, 联系方式txtbx, 密码txtbx, 角色txtbx };
                foreach (TextBox tb in inputBoxes)
                {
                    字段 = tb.Name.Substring(0, tb.Name.Length - 5);
                    值 = tb.Text;
                    sqlText = string.Format("insert into dbo.用户历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 用户ID, 操作用户ID, 操作, 时间, 字段, 值, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                }
            }else if (操作 == "修改")
            {
                object[] inputBoxes = { 用户名txtbx, 姓名txtbx, 性别txtbx, 联系方式txtbx, 密码txtbx, 角色txtbx,checkBox1 };
                DataGridViewCellCollection dc = dataGridView1.Rows[rowIndex].Cells;
                for(int i = 1; i < inputBoxes.Length; i++)
                {
                    if (i == inputBoxes.Length - 1)
                    {
                        bool checkValue = ((CheckBox)inputBoxes[i]).Checked;
                        if (checkValue != Convert.ToBoolean(dc[i + 1].Value))
                        {
                            字段 = "启禁标志";
                            值 = Convert.ToString(checkValue);
                            sqlText = string.Format("insert into dbo.用户历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 用户ID, 操作用户ID, 操作, 时间, 字段, 值, 备注);
                            result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                        }
                    }
                    else
                    {
                        string inputName= ((TextBox)inputBoxes[i]).Name;
                        string inputValue = ((TextBox)inputBoxes[i]).Text;
                        if (inputValue != dc[i + 1].Value.ToString())
                        {
                            字段 = inputName.Substring(0,inputName.Length-5);
                            值 = inputValue;
                            sqlText = string.Format("insert into dbo.用户历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 用户ID, 操作用户ID, 操作, 时间, 字段, 值, 备注);
                            result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                        }
                    }
                    
                }
            }
            else if (操作 == "删除")
            {
                字段 = "用户ID";
                值 = 用户ID;
                sqlText = string.Format("insert into dbo.用户历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 用户ID, 操作用户ID, 操作, 时间, 字段, 值, 备注);
                result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
            }
        }
        /// <summary>
        /// 鼠标移动到增加按钮上时，勾选启用勾选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 增加btn_MouseEnter(object sender, EventArgs e)
        {
            check启用();
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改btn_Click(object sender, EventArgs e)
        {
            grab用户名for用户名txtbx();
            SqlHelper sh = new SqlHelper();
            int index = dataGridView1.SelectedCells[0].RowIndex;
            string 用户ID = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string 用户名 = 用户名txtbx.Text;
            string 姓名 = 姓名txtbx.Text;
            string 性别 = 性别txtbx.Text;
            string 联系方式 = 联系方式txtbx.Text;
            string 密码 = 密码txtbx.Text;
            string 角色 = 角色txtbx.Text;
            string 详细内容 = return修改内容(index);
            string 启禁标志 = (checkBox1.Checked) ? "1" : "0";
            string sqlText = string.Format("update dbo.用户表 set 姓名='{0}',性别='{1}',联系方式='{2}',密码='{3}',角色='{4}',启禁标志='{5}' where 用户ID='{6}'", 姓名, 性别, 联系方式, 密码, 角色,启禁标志, 用户ID);
            try
            {
                if (详细内容 == "")
                {
                    MessageBox.Show("无内容被修改！");
                }
                else if (MessageBox.Show("修改用户：“" + 用户名 + "”" + Environment.NewLine + "┏-修改内容-┓" + Environment.NewLine + 详细内容.Replace("|", Environment.NewLine), "确认修改", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    if (result > 0)
                    {
                        writeHistory("修改", 用户ID,index);
                        initForm();
                        dataGridView1.Rows[index].Cells[1].Selected = true;
                    }
                }
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 返回修改内容的字符串
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private string return修改内容(int rowIndex)
        {
            List<string> result=new List<string>();
            DataGridViewCellCollection dc = dataGridView1.Rows[rowIndex].Cells;
            string 表_姓名 = dc[2].Value.ToString();
            string 表_性别 = dc[3].Value.ToString();
            string 表_联系方式 = dc[4].Value.ToString();
            string 表_密码 = dc[5].Value.ToString();
            string 表_角色 = dc[6].Value.ToString();
            bool 表_启禁标志 = Convert.ToBoolean(dc[7].Value.ToString());
            if (姓名txtbx.Text != 表_姓名)
            {
                result.Add(string.Format("姓名：\"{0}\"->\"{1}\"", 表_姓名, 姓名txtbx.Text));
            }
            if (性别txtbx.Text != 表_性别)
            {
                result.Add(string.Format("性别：\"{0}\"->\"{1}\"", 表_性别, 性别txtbx.Text));
            }
            if (联系方式txtbx.Text != 表_联系方式)
            {
                result.Add(string.Format("联系方式：\"{0}\"->\"{1}\"", 表_联系方式, 联系方式txtbx.Text));
            }
            if (密码txtbx.Text != 表_密码)
            {
                result.Add(string.Format("密码：\"{0}\"->\"{1}\"", 表_密码, 密码txtbx.Text));
            }
            if (角色txtbx.Text != 表_角色)
            {
                result.Add(string.Format("角色：\"{0}\"->\"{1}\"", 表_角色, 角色txtbx.Text));
            }
            if (checkBox1.Checked != 表_启禁标志)
            {
                result.Add(string.Format("启禁标志：\"{0}\"->\"{1}\"", (表_启禁标志) ? "1" : "0", (checkBox1.Checked) ? "1" : "0"));
            }
            return string.Join(" | ",result);
        }
        /// <summary>
        /// 鼠标移动到修改按钮上时，用户名对话框显示当前选中用户名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改btn_MouseEnter(object sender, EventArgs e)
        {
            grab用户名for用户名txtbx();
        }

        /// <summary>
        /// 获取dataGridView1的当前滚动位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            _scrollValue = e.NewValue;
        }

        private void grab用户名for用户名txtbx()
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            用户名txtbx.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }
        private void check启用()
        {
            checkBox1.Checked = true;
        }
        private void 删除btn_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection dc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells;
            string 用户ID = Convert.ToString(dc[0].Value);
            string 用户名 = Convert.ToString(dc[1].Value);
            if (MessageBox.Show("是否删除“" + 用户名 + "”?", "删除记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper sh = new SqlHelper();
                string sqlText = string.Format("update dbo.用户表 set 删除标志=1 where 用户ID='{0}' and 删除标志=0", 用户ID);
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    MessageBox.Show("删除“" + 用户名 + "”成功");
                    initForm();

                    writeHistory("删除", 用户ID, -1);
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    DataGridViewCellCollection dc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells;
                    用户名txtbx.Text = dc[1].Value.ToString();
                    姓名txtbx.Text = dc[2].Value.ToString();
                    性别txtbx.Text = dc[3].Value.ToString();
                    联系方式txtbx.Text = dc[4].Value.ToString();
                    密码txtbx.Text = dc[5].Value.ToString();
                    角色txtbx.Text = dc[6].Value.ToString();
                    checkBox1.Checked = Convert.ToBoolean(dc[7].Value);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
