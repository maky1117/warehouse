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
    public partial class 备件管理窗口_old : Form
    {
        public int _scrollValue = 0;//获取dataGridView1滚动位置
        public 备件管理窗口_old()
        {
            InitializeComponent();
        }
        private void 备件管理窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        /// <summary>
        /// 填充dataGridView1数据
        /// </summary>
        public void initForm()
        {
            SqlHelper sh = new SqlHelper();
            DataSet ds = sh.selectReturnDataSet("select 备件ID,备件名称,单位,成本价,类别名称 from dbo.备件表 where 删除标志=0", null, CommandType.Text);
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
            initPicMgmt("备件表", "备件ID", "备件名称");

            dataManager1.TableName = "备件表";
            dataManager1.PrimaryKey = "备件ID";
            dataManager1.UniqueColumnName = "备件名称";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.EnablePictureManagement = true;
            //dataManager1.DisplayColumns = new string[] { "备件名称", "单位", "成本价", "类别名称" };
            dataManager1.Show();
        }
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 增加btn_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = string.Format("insert into dbo.备件表(备件名称,单位,成本价,类别名称)values('{0}','{1}','{2}','{3}')", 备件名称txtbx.Text, 单位txtbx.Text, 成本价txtbx.Text, 类别名称txtbx.Text);
            try
            {
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    string 备件名称 = 备件名称txtbx.Text;
                    MessageBox.Show("添加“" + 备件名称 + "”成功！");
                    initForm();
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Selected = true;

                    string 详细内容 = "备件ID：" + sh.selectReturnString("select max(备件ID) from dbo.备件表", null, CommandType.Text) + " | 备件名：" + 备件名称;
                    string 用户ID = Form1.loginUser;
                    string 动作 = "添加";
                    string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 备注 = "";
                    sqlText = string.Format("insert into dbo.备件历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                }
            }
            catch (Exception ee)
            {
                if (ee.Message.Contains("重复"))
                {
                    MessageBox.Show("备件名称“" + 备件名称txtbx.Text + "”已存在！");
                }
            }
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改btn_Click(object sender, EventArgs e)
        {
            grab备件名称for备件名称txtbx();
            SqlHelper sh = new SqlHelper();
            int index = dataGridView1.SelectedCells[0].RowIndex;
            string 备件ID = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string 备件名称 = 备件名称txtbx.Text;
            string 单位 = 单位txtbx.Text;
            string 成本价 = 成本价txtbx.Text;
            string 类别名称 = 类别名称txtbx.Text;
            string 详细内容 = return修改内容(index);
            string sqlText = string.Format("update dbo.备件表 set 备件名称='{0}',单位='{1}',成本价='{2}',类别名称='{3}' where 备件ID='{4}'", 备件名称, 单位, 成本价, 类别名称, 备件ID);
            try
            {
                if (详细内容 == "")
                {
                    MessageBox.Show("无内容被修改！");
                }
                else if (MessageBox.Show("修改备件：“" + 备件名称 + "”" + Environment.NewLine + "┏-修改内容-┓" + Environment.NewLine + 详细内容.Replace("|", Environment.NewLine), "确认修改", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                        sqlText = string.Format("insert into dbo.备件历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
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
            string 表_单位 = dc[2].Value.ToString();
            string 表_成本价 = dc[3].Value.ToString();
            string 表_类别名称 = dc[4].Value.ToString();
            if (单位txtbx.Text != 表_单位)
            {
                result.Add(string.Format("单位：\"{0}\"->\"{1}\"", 表_单位, 单位txtbx.Text));
            }
            if (成本价txtbx.Text != 表_成本价)
            {
                result.Add(string.Format("成本价：\"{0}\"->\"{1}\"", 表_成本价, 成本价txtbx.Text));
            }
            if (类别名称txtbx.Text != 表_类别名称)
            {
                result.Add(string.Format("类别名称：\"{0}\"->\"{1}\"", 表_类别名称, 类别名称txtbx.Text));
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
            grab备件名称for备件名称txtbx();
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
            备件名称txtbx.Text = dc[1].Value.ToString();
            单位txtbx.Text = dc[2].Value.ToString();
            成本价txtbx.Text = dc[3].Value.ToString();
            类别名称txtbx.Text = dc[4].Value.ToString();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection dc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells;
            string 备件ID = Convert.ToString(dc[0].Value);
            string 备件名称 = Convert.ToString(dc[1].Value);
            if (MessageBox.Show("是否删除“" + 备件名称 + "”?", "删除记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper sh = new SqlHelper();
                string sqlText = string.Format("update dbo.备件表 set 删除标志=1 where 备件ID='{0}' and 删除标志=0", 备件ID);
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    MessageBox.Show("删除“" + 备件名称 + "”成功");
                    initForm();

                    string 详细内容 = "备件ID：" + 备件ID + " | 备件名：" + 备件名称;
                    string 用户ID = Form1.loginUser;
                    string 动作 = "删除";
                    string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 备注 = "";
                    sqlText = string.Format("insert into dbo.备件历史表(用户ID,动作,时间,详细内容,备注)values('{0}','{1}','{2}','{3}','{4}')", 用户ID, 动作, 时间, 详细内容, 备注);
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

        private void grab备件名称for备件名称txtbx()
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            备件名称txtbx.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
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
        private void initPicMgmt(string object_table_name,string object_id_key,string object_name_key)
        {
            图片管理btn.Click += (sender, e) =>
            {
                //获取dataGridView选中项的备件ID，做对象ID传入
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int object_id_value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[object_id_key].Value);
                    图片管理窗口 pzck = new 图片管理窗口(object_id_value, object_table_name, object_id_key, object_name_key);
                    pzck.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请选择一个"+object_table_name.Replace("表","")+"！");
                }
            };
            dataGridView1.SelectionChanged += (sender, e) =>
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int object_id_value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[object_id_key].Value);
                    //根据图片表上的对象ID和对象表名，把该对象的图片总数算出来
                    string sqlText = string.Format("select count(*) from 图片表 where 对象ID={0} and 对象表名='{1}'",object_id_value,object_table_name);
                    SqlHelper sh = new SqlHelper();
                    string pic_count = sh.selectReturnString(sqlText, null, CommandType.Text);
                    pic_count_lbl.Text = "现有图片：" + pic_count+"张";
                }
            };
        }
    }
}
