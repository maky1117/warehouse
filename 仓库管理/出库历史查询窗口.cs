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
    public partial class 出库历史查询窗口 : Form
    {
        public 出库历史查询窗口()
        {
            InitializeComponent();
        }

        private void 出库历史查询窗口_Load(object sender, EventArgs e)
        {
            //SqlHelper sh = new SqlHelper();
            //string sqlText = "select * from dbo.用户表";
            //DataTable orders = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            //var query =
            //from order in orders.AsEnumerable()
            // where order.Field<bool>("删除标志") == true
            // orderby order.Field<string>("用户名")
            // select new
            //{
            //    用户名 = order.Field<string>("用户名"),
            //    性别 = order.Field<string>("性别"),
            //    启禁标志 = order.Field<bool>("启禁标志"),
            //    删除标志 = order.Field<bool>("删除标志")
            //};

            //DataTable new_dt = new DataTable();
            //new_dt.Columns.Add("用户名");
            //new_dt.Columns.Add("性别");
            //new_dt.Columns.Add("启禁标志",typeof(Boolean));
            //new_dt.Columns.Add("删除标志", typeof(Boolean));
            //foreach(var a in query)
            //{
            //    new_dt.Rows.Add(a.用户名, a.性别, a.启禁标志, a.删除标志);
            //}
            //dataGridView1.DataSource = new_dt;

            initForm();
        }
        private void initForm()
        {
            listBox2.Left = listBox1.Left;
            listBox2.Visible = false;
            listBox1.Visible = true;
            SqlHelper sh = new SqlHelper();

            string sqlText = "select distinct 操作 from dbo.出库历史表";
            DataTable dt = new DataTable();
            dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "操作";
            listBox1.ValueMember = "操作";

            sqlText = "select 用户名,用户ID from dbo.用户表 where 删除标志=0";
            dt = new DataTable();
            dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            listBox2.DataSource = dt;
            listBox2.DisplayMember = "用户名";
            listBox2.ValueMember = "用户ID";
        }
        private void 操作textBox_Enter(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox2.Visible = false;
        }

        private void 操作用户textBox_Enter(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox1.Visible = false;
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            foreach (DataRowView dv in listBox1.SelectedItems.Cast<DataRowView>())
            {
                list1.Add(dv.Row.ItemArray[0].ToString());
            }
            操作textBox.Text = string.Join(",", list1);
            label6.Text = string.Join(",", list1);
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
            操作用户textBox.Text = string.Join(",", list1);
            label7.Text = string.Join(",", list2);
        }
        private void 查询button_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string 操作 = label6.Text;
            string 操作用户ID = label7.Text;
            if (string.Compare(操作开始时间textBox.Text, 操作结束时间textBox.Text) == 1)
            {
                操作开始时间textBox.Text = 操作结束时间textBox.Text;
            }
            string 操作开始时间 = 操作开始时间textBox.Text;
            string 操作结束时间 = 操作结束时间textBox.Text;
            string 时间范围 = "";
            if (操作开始时间 != "")
            {
                时间范围 += " and 操作时间 >= '" + 操作开始时间 + "'";
            }
            if (操作结束时间 != "")
            {
                时间范围 += " and (操作时间 <= '" + 操作结束时间 + "' or 操作时间 like '" + 操作结束时间 + "%')";
            }

            string sqlText = string.Format("select A.历史ID,A.操作时间,B.用户名,A.操作,A.出库ID,A.字段,A.值,A.备注 " +
            "from dbo.出库历史表 A inner join dbo.用户表 B on A.操作用户ID = B.用户ID " +
            "where 操作 in ('{0}') and 操作用户ID in ({1}) {2}", 操作.Replace(",", "','"), 操作用户ID, 时间范围);
            //string sqlText = string.Format(@"select 出库ID,A.仓库ID,A.备件ID,A.出库用户ID,A.数量,A.出库时间,A.备注 from (select 出库ID,仓库ID,备件ID,出库用户ID,数量,出库时间,备注 
            //from dbo.出库表 where 仓库ID in ({0}) and 备件ID in ({1}) and 出库用户ID in ({2}) and 出库时间 between '{3}' and '{4}')A
            //inner join dbo.仓库表 B on A.仓库ID = B.仓库ID
            //inner join dbo.备件表 C on A.备件ID = C.备件ID
            //inner join dbo.用户表 D on A.出库用户ID = D.用户ID", 仓库ID, 备件ID, 出库用户ID, 出库开始时间, 出库结束时间);
            DataTable dt = new DataTable();
            dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void 复位Button_Click(object sender, EventArgs e)
        {
            操作textBox.Text = 操作用户textBox.Text = "";
            操作开始时间textBox.Text = 操作结束时间textBox.Text = "";
            listBox1.DataSource = listBox2.DataSource = null;
            initForm();
        }
    }
}
