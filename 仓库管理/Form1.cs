using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using SqlHelperForm;
using System.Data.SqlClient;

namespace 仓库管理
{
    public struct DisplayColumn
    {        
        public string 提取列;
        public string 所在表;
        public string 控件类型;
        public string 控制控件;
        public string 显示名称;
        public string 链接ID;
        public string 被链接ID;
    }
    public partial class Form1 : Form
    {
        public static string loginUser="40";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //登录对话框 dldhk = new 登录对话框();
            //dldhk.ShowDialog();
            //ShowMenuByUserAuthority();
            dataManager1.TableName = "仓库表";
            dataManager1.PrimaryKey = "仓库ID";
            dataManager1.UniqueColumnName = "仓库名称";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.EnablePictureManagement = false;
            //dataManager1.DisplayColumns = new string[] { "用户名", "性别", "删除标志", "联系方式", "密码", "启禁标志" };

            //select A.仓库名称, A.仓库位置, A.仓管员ID,仓管员=B.用户名, B.联系方式 from 仓库表 A inner join 用户表 B on A.仓管员ID =B.用户ID
            dataManager1.DisplayColumns = new List<DisplayColumn>();
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称="仓库名称", 所在表="仓库表", 提取列 = "仓库名称", 控件类型 ="input"});
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "仓管员姓名", 所在表 = "用户表", 提取列 = "用户名",链接ID="用户ID",被链接ID="仓管员ID", 控件类型 = "combo" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "仓库名称", 所在表 = "用户表", 提取列 = "联系方式", 链接ID = "用户ID", 被链接ID = "仓管员ID", 控件类型 =null });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "仓库位置", 所在表 = "仓库表", 提取列 = "仓库位置", 控件类型 = "input" });

            //new object[] { "仓库名称", "仓库位置", new DoubleColumn(){ ValueMember = "仓管员ID", DisplayMember = "仓管员", TableFor="用户表",ValueMemberFor = "用户ID", DisplayMemberFor= "用户名"} };
            //SqlCommand cmd = new SqlCommand();
            //cmd.
            dataManager1.Show();
            //DoubleColumn dd = (DoubleColumn)dataManager1.DisplayColumns[2];
            //LabeledComboBox lcb1 = new LabeledComboBox(dd.getID(), dd.get名称(), dd.getB表名称(), "and 删除标志=0");
            //dataGridView1.SelectionChanged += (d_sender, d_e) =>
            //{
            //    if (dataGridView1.SelectedCells.Count > 0)
            //    {
            //        lcb.Value = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[unique_column_name].Value);
            //    }
            //};
            //flowLayoutPanel1.Controls.Add(lcb1);
            //LabeledComboBox lcb2 = new LabeledComboBox("货架ID", "货架名称", "货架表", "and 删除标志=0",true,lcb1);
            //flowLayoutPanel1.Controls.Add(lcb2);
        }
        /// <summary>
        /// 根据用户权限显示菜单选项
        /// </summary>
        private void ShowMenuByUserAuthority()
        {
            SqlHelper sh = new SqlHelper();
            DataTable dt = sh.selectReturnDataSet("select * from dbo.权限表 where 用户名='"+loginUser+"'", null, CommandType.Text).Tables[0];
            try
            {
                foreach (ToolStripMenuItem t1 in menuStrip1.Items)
                {
                    if (Convert.ToBoolean(dt.Rows[0].ItemArray[dt.Columns[t1.Text].Ordinal]))
                    {
                        t1.Visible = true;
                    }
                    else
                    {
                        t1.Visible = false;
                    }
                    foreach (Object t2 in t1.DropDownItems)
                    {
                        if (t2 is ToolStripMenuItem)
                        {
                            ToolStripMenuItem t = (ToolStripMenuItem)t2;
                            if (Convert.ToBoolean(dt.Rows[0].ItemArray[dt.Columns[t.Text].Ordinal]))
                            {
                                t.Visible = true;
                            }
                            else
                            {
                                t.Visible = false;
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登录对话框 dldhk = new 登录对话框();
            dldhk.ShowDialog();
            ShowMenuByUserAuthority();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户管理窗口 yhglck = new 用户管理窗口();
            yhglck.StartPosition = FormStartPosition.CenterScreen;
            yhglck.ShowDialog();
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            权限管理窗口 qxglck = new 权限管理窗口();
            qxglck.StartPosition = FormStartPosition.CenterScreen;
            qxglck.ShowDialog();
        }

        private void 入库登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            入库登记窗口 ykdjck = new 入库登记窗口();
            ykdjck.StartPosition = FormStartPosition.CenterScreen;
            ykdjck.ShowDialog();
        }

        private void 入库修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            入库修改窗口 rkxgck = new 入库修改窗口();
            rkxgck.StartPosition = FormStartPosition.CenterScreen;
            rkxgck.ShowDialog();
        }

        private void 出库登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            出库登记窗口 ckdjck = new 出库登记窗口();
            ckdjck.StartPosition = FormStartPosition.CenterScreen;
            ckdjck.ShowDialog();
        }

        private void 出库修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            出库修改窗口 ckxgck = new 出库修改窗口();
            ckxgck.StartPosition = FormStartPosition.CenterScreen;
            ckxgck.ShowDialog();
        }

        private void 仓库管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            仓库管理窗口 ckglck = new 仓库管理窗口();
            ckglck.StartPosition = FormStartPosition.CenterScreen;
            ckglck.ShowDialog();
        }

        private void 备件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            备件管理窗口 bjglck = new 备件管理窗口();
            bjglck.StartPosition = FormStartPosition.CenterScreen;
            bjglck.ShowDialog();
        }

        private void 入库查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            入库历史查询窗口 rklscxck = new 入库历史查询窗口();
            rklscxck.StartPosition = FormStartPosition.CenterScreen;
            rklscxck.ShowDialog();
        }

        private void 出库查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            出库历史查询窗口 cklscxck = new 出库历史查询窗口();
            cklscxck.StartPosition = FormStartPosition.CenterScreen;
            cklscxck.ShowDialog();
        }
    }
}
