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
    public partial class 入库修改窗口 : Form
    {
        DataTable org_dt;
        public 入库修改窗口()
        {
            InitializeComponent();
        }
        private void 入库修改窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        private void initForm()
        {
            listBox3.Left = listBox2.Left = listBox1.Left;
            listBox3.Visible = listBox2.Visible = false;
            listBox1.Visible = true;

            SqlHelper sh = new SqlHelper();
            string sqlText = "select 仓库名称,仓库ID from dbo.仓库表 where 删除标志=0";
            DataSet ds = new DataSet();
            ds = sh.selectReturnDataSet(sqlText, null, CommandType.Text);
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "仓库名称";
            listBox1.ValueMember = "仓库ID";

            sqlText = "select 备件名称,备件ID from dbo.备件表 where 删除标志=0";
            ds = new DataSet();
            ds = sh.selectReturnDataSet(sqlText, null, CommandType.Text);
            listBox2.DataSource = ds.Tables[0];
            listBox2.DisplayMember = "备件名称";
            listBox2.ValueMember = "备件ID";

            sqlText = "select 用户名,用户ID from dbo.用户表 where 删除标志=0";
            ds = new DataSet();
            ds = sh.selectReturnDataSet(sqlText, null, CommandType.Text);
            listBox3.DataSource = ds.Tables[0];
            listBox3.DisplayMember = "用户名";
            listBox3.ValueMember = "用户ID";
        }
        private void 仓库textBox_Enter(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox2.Visible = listBox3.Visible = false;

        }

        private void 备件textBox_Enter(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox1.Visible = listBox3.Visible = false;

            
        }

        private void 入库人textBox_Enter(object sender, EventArgs e)
        {
            listBox3.Visible = true;
            listBox1.Visible = listBox2.Visible = false;

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            foreach (DataRowView dv in listBox1.SelectedItems.Cast<DataRowView>())
            {
                list1.Add(dv.Row.ItemArray[0].ToString());
                list2.Add(dv.Row.ItemArray[1].ToString());
            }
            仓库textBox.Text = string.Join(",", list1);
            label6.Text = string.Join(",", list2);
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            foreach (DataRowView dv in listBox2.SelectedItems.Cast<DataRowView>())
            {
                list1.Add(dv.Row.ItemArray[0].ToString());
                list2.Add(dv.Row.ItemArray[1].ToString());
            }
            备件textBox.Text = string.Join(",", list1);
            label7.Text = string.Join(",", list2);
        }

        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            foreach (DataRowView dv in listBox3.SelectedItems.Cast<DataRowView>())
            {
                list1.Add(dv.Row.ItemArray[0].ToString());
                list2.Add(dv.Row.ItemArray[1].ToString());
            }
            入库人textBox.Text = string.Join(",", list1);
            label8.Text = string.Join(",", list2);
        }

        private void 查询button_Click(object sender, EventArgs e)
        {
            开始查询();
        }
        private void 开始查询()
        {
            SqlHelper sh = new SqlHelper();
            string 仓库ID = label6.Text;
            string 备件ID = label7.Text;
            string 入库用户ID = label8.Text;
            if (string.Compare(入库开始时间textBox.Text, 入库结束时间textBox.Text) == 1)
            {
                入库开始时间textBox.Text = 入库结束时间textBox.Text;
            }
            string 入库开始时间 = 入库开始时间textBox.Text;
            string 入库结束时间 = 入库结束时间textBox.Text;
            string 时间范围 = "";
            if (入库开始时间 != "")
            {
                时间范围 += " and B.操作时间 >= '" + 入库开始时间 + "'";
            }
            if (入库结束时间 != "")
            {
                时间范围 += " and (B.操作时间 <= '" + 入库结束时间 + "' or B.操作时间 like '" + 入库结束时间 + "%')";
            }

            string sqlText = string.Format("select A.入库ID,D.仓库名称,C.货架名称,E.备件名称,F.用户名,A.数量,B.操作时间,A.备注 " +
            "from dbo.入库表 A " +
            "inner join dbo.入库历史表 B on B.入库ID = A.入库ID " +
            "inner join dbo.货架表 C on C.货架ID = A.货架ID " +
            "inner join dbo.仓库表 D on D.仓库ID = C.仓库ID " +
            "inner join dbo.备件表 E on E.备件ID = A.备件ID " +
            "inner join dbo.用户表 F on F.用户ID = B.操作用户ID " +
            "where D.仓库ID in ({0}) and A.备件ID in ({1}) and B.操作用户ID in ({2}) and A.删除标志=0 and B.操作='添加' and B.字段='入库ID' {3}", 仓库ID, 备件ID, 入库用户ID, 时间范围);

            DataTable dt = new DataTable();
            org_dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            dataGridView1.DataSource = org_dt.Copy();

            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name != "数量" && c.Name != "备注")
                {
                    c.ReadOnly = true;
                }
            }
        }

        private void 复位Button_Click(object sender, EventArgs e)
        {
            仓库textBox.Text = 备件textBox.Text = 入库人textBox.Text="";
            入库开始时间textBox.Text=入库结束时间textBox.Text= "";
            listBox1.DataSource = listBox2.DataSource = listBox3.DataSource = null;
            dataGridView1.DataSource = null;
            initForm();
        }

        private void 保存修改button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                List<string> list = new List<string>();
                List<Tuple<string,string,string>> plist = new List<Tuple<string, string, string>> ();
                SqlHelper sh = new SqlHelper();
                int? result = sh.IUDbyDataTableReturnInt("select 入库ID,数量,备注 from dbo.入库表", (DataTable)(dataGridView1.DataSource), null, CommandType.Text);
                string org_value, mod_value, 入库ID;
                bool IDTitle;//该值用于首次添加ID标题值
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    IDTitle = true;
                    for (int j = 2; j < dataGridView1.ColumnCount; j++)
                    {
                        org_value = Convert.ToString(org_dt.Rows[i].ItemArray[j]);
                        mod_value = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                        if (mod_value != org_value)
                        {
                            入库ID = Convert.ToString(org_dt.Rows[i].Field<int>("入库ID"));
                            if (IDTitle)
                            {
                                list.Add("  入库ID："+入库ID);
                                IDTitle = false;
                            }
                            list.Add(string.Format("{0}：\"{1}\"->\"{2}\"", org_dt.Columns[j].ColumnName, org_value, mod_value));
                            plist.Add(new Tuple<string, string, string>(入库ID, org_dt.Columns[j].ColumnName, mod_value));
                        }
                    }
                }
                if (list.Count > 0)
                {
                    string 操作用户ID = Form1.loginUser;
                    string 操作 = "修改";
                    string 操作时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 详细内容 = string.Join(Environment.NewLine, list);
                    string 备注 = "";
                    string sqlText,字段,值;
                    foreach (Tuple<string, string, string> t in plist)
                    {
                        入库ID = t.Item1;
                        字段 = t.Item2;
                        值 = t.Item3;
                        sqlText = string.Format("insert into dbo.入库历史表(入库ID,操作用户ID,操作,操作时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 入库ID, 操作用户ID, 操作, 操作时间, 字段, 值, 备注);
                        result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    }
                    MessageBox.Show(详细内容);
                    org_dt = ((DataTable)dataGridView1.DataSource).Copy();
                }
                else if (list.Count == 0)
                {
                    MessageBox.Show("无内容被修改！");
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection dc = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells;
            string 入库ID = Convert.ToString(dc[0].Value);
            if (MessageBox.Show("是否删除“入库ID：" + 入库ID + "”?", "删除记录", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlHelper sh = new SqlHelper();
                string sqlText = string.Format("update dbo.入库表 set 删除标志=1 where 入库ID='{0}' and 删除标志=0", 入库ID);
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                if (result > 0)
                {
                    MessageBox.Show("删除“入库ID：" + 入库ID + "”成功");
                    
                    string 操作用户ID = Form1.loginUser;
                    string 操作 = "删除";
                    string 操作时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 详细内容 = "入库ID：" + 入库ID;
                    string 备注 = "";
                    sqlText = string.Format("insert into dbo.入库历史表(入库ID,操作用户ID,操作,操作时间,备注)values('{0}','{1}','{2}','{3}','{4}')", 入库ID, 操作用户ID, 操作, 操作时间, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);

                    开始查询();//刷新表格显示
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl CellEdit = null;
            if (this.dataGridView1.CurrentCell.OwningColumn.HeaderText == "数量")//获取当前处于活动状态的单元格索引
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
            }
        }

        private void Cells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "数量")
            {
                if (e.KeyChar != '\b')//允许输入退格键
                {
                    if ((e.KeyChar < '0') || (e.KeyChar > '9'))//允许输入0-9数字
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
