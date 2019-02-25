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
    public partial class 仓库管理窗口_old : Form
    {
        public int _scrollValue = 0;//获取dataGridView1滚动位置
        public 仓库管理窗口_old()
        {
            InitializeComponent();
        }
        private void 仓库管理窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        /// <summary>
        /// 填充dataGridView1数据
        /// </summary>
        public void initForm()
        {
            SqlHelper sh = new SqlHelper();
            DataSet ds = sh.selectReturnDataSet("select 仓库ID,仓库名称,仓库位置,仓管员,联系方式 from dbo.仓库表 where 删除标志=0", null, CommandType.Text);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (_scrollValue > dataGridView1.RowCount && _scrollValue != 0)
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
        private void button1_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();            
            string sqlText = string.Format("insert into dbo.仓库表(仓库名称,仓库位置,仓管员,联系方式)values('{0}','{1}','{2}','{3}')", 仓库名称txtbx.Text, 仓库位置txtbx.Text, 仓管员txtbx.Text, 联系方式txtbx.Text);
            try
            {
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    string 仓库名称 = 仓库名称txtbx.Text;
                    MessageBox.Show("添加“" + 仓库名称 + "”成功！");
                    initForm();
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Selected = true;

                    string 详细内容 = "仓库ID：" + sh.selectReturnString("select max(仓库ID) from dbo.仓库表", null, CommandType.Text) + " | 仓库名：" + 仓库名称;
                    string 用户ID = Form1.loginUser;
                    string 动作 = "添加";
                    string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");                    
                    string 备注 = "";
                    sqlText = string.Format("insert into dbo.仓库历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                }
            }
            catch (Exception ee)
            {
                if (ee.Message.Contains("重复"))
                {
                    MessageBox.Show("仓库名称“" + 仓库名称txtbx.Text + "”已存在！");
                }
            }
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            grab仓库名称for仓库名称txtbx();
            SqlHelper sh = new SqlHelper();
            int index = dataGridView1.SelectedCells[0].RowIndex;
            string 仓库ID = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string 仓库名称 = 仓库名称txtbx.Text;
            string 仓库位置 = 仓库位置txtbx.Text;
            string 仓管员 = 仓管员txtbx.Text;
            string 联系方式 = 联系方式txtbx.Text;
            string 详细内容 = return修改内容(index);
            string sqlText = string.Format("update dbo.仓库表 set 仓库名称='{0}',仓库位置='{1}',仓管员='{2}',联系方式='{3}' where 仓库ID='{4}'", 仓库名称,仓库位置, 仓管员, 联系方式, 仓库ID);
            try
            {
                if (详细内容 == "")
                {
                    MessageBox.Show("无内容被修改！");
                }
                else if (MessageBox.Show("修改仓库：“" + 仓库名称 + "”" + Environment.NewLine + "┏-修改内容-┓" + Environment.NewLine + 详细内容.Replace("|", Environment.NewLine), "确认修改", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    if (result > 0)
                    {
                        initForm();
                        dataGridView1.Rows[index].Cells[1].Selected = true;

                        string 用户ID = Form1.loginUser;
                        string 动作 = "修改";
                        string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string 备注 = "";
                        sqlText = string.Format("insert into dbo.仓库历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
                        result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    }
                }
            }
            catch (Exception ee)
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
            List<string> result = new List<string>();
            DataGridViewCellCollection dc = dataGridView1.Rows[rowIndex].Cells;
            string 表_仓库位置 = dc[2].Value.ToString();
            string 表_仓管员 = dc[3].Value.ToString();
            string 表_联系方式 = dc[4].Value.ToString();
            if (仓库位置txtbx.Text != 表_仓库位置)
            {
                result.Add(string.Format("仓库位置：\"{0}\"->\"{1}\"", 表_仓库位置, 仓库位置txtbx.Text));
            }
            if (仓管员txtbx.Text != 表_仓管员)
            {
                result.Add(string.Format("仓管员：\"{0}\"->\"{1}\"", 表_仓管员, 仓管员txtbx.Text));
            }
            if (联系方式txtbx.Text != 表_联系方式)
            {
                result.Add(string.Format("联系方式：\"{0}\"->\"{1}\"", 表_联系方式, 联系方式txtbx.Text));
            }
            return string.Join(" | ", result);
        }
        /// <summary>
        /// 鼠标移动到修改按钮上时，用户名对话框显示当前选中用户名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            grab仓库名称for仓库名称txtbx();
        }

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //SqlHelper sh = new SqlHelper();
            //string sqlText = string.Format("select 用户名,姓名,性别,联系方式,密码,角色,启禁标志 from dbo.用户表 where 用户名='{0}'", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value));
            //SqlDataReader sdr = sh.selectReturnDataReader(sqlText, null, CommandType.Text);

            DataGridViewCellCollection dc = dataGridView1.Rows[e.RowIndex].Cells;
            仓库名称txtbx.Text = dc[1].Value.ToString();
            仓库位置txtbx.Text = dc[2].Value.ToString();
            仓管员txtbx.Text = dc[3].Value.ToString();
            联系方式txtbx.Text = dc[4].Value.ToString();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection dc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells;
            string 仓库ID = Convert.ToString(dc[0].Value);
            string 仓库名称 = Convert.ToString(dc[1].Value);
            if (MessageBox.Show("是否删除“" + 仓库名称 + "”?", "删除记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper sh = new SqlHelper();
                string sqlText = string.Format("update dbo.仓库表 set 删除标志=1 where 仓库ID='{0}' and 删除标志=0", 仓库ID);
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    MessageBox.Show("删除“" + 仓库名称 + "”成功");
                    initForm();

                    string 详细内容 = "仓库ID：" + 仓库ID + " | 仓库名：" + 仓库名称;
                    string 用户ID = Form1.loginUser;
                    string 动作 = "删除";
                    string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 备注 = "";                    
                    sqlText = string.Format("insert into dbo.仓库历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                }
            }
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

        private void grab仓库名称for仓库名称txtbx()
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            仓库名称txtbx.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex + " " + e.ColumnIndex);
            //if (e.ColumnIndex == 6)
            //{
            //    bool v = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            //    dataGridView1.Rows[e.RowIndex].Cells[6].Value = !v;
            //}
        }

        private void 管理货架btn_Click(object sender, EventArgs e)
        {
            string 仓库ID = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
            货架管理窗口 hjglck = new 货架管理窗口(仓库ID);
            hjglck.ShowDialog();
        }
    }
}
