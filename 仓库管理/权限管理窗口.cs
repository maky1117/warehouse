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
using static System.Windows.Forms.ListBox;

namespace 仓库管理
{
    public partial class 权限管理窗口 : Form
    {
        DataTable org_dt;
        public 权限管理窗口()
        {
            InitializeComponent();
        }

        private void 权限管理窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        private void initForm()
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = "select 用户ID,用户名 from dbo.用户表 where 删除标志=0";
            DataTable dt = new DataTable();
            dt=sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            //List<string> list = new List<string>();
            //list = ds.Tables[0].AsEnumerable().Select(x => x["用户名"].ToString()).ToList<string>();
            listBox1.DisplayMember = "用户名";
            listBox1.ValueMember = "用户ID";
            listBox1.DataSource = dt;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(DataRowView dv in listBox1.SelectedItems.Cast<DataRowView>())
            {
                list.Add(dv.Row.ItemArray[0].ToString());
            }
            SqlHelper sh = new SqlHelper();
            string sqlText = string.Format("select B.用户名,A.* from dbo.权限表 A inner join dbo.用户表 B on A.用户ID=B.用户ID where A.用户ID in('{0}')", string.Join("','", list));
            org_dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0]; 
            dataGridView1.DataSource = org_dt.Copy();
            //foreach (DataRow dr in org_dt.Rows)
            //{
            //    Label l = new Label();
            //    l.AutoSize = true;
            //    l.BackColor = System.Drawing.SystemColors.ActiveCaption;
            //    l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //    l.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //    l.Location = new System.Drawing.Point(355, 80);
            //    l.Padding = new System.Windows.Forms.Padding(4);
            //    l.Size = new System.Drawing.Size(72, 26);
            //    l.TabIndex = 4;
            //    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //    l.Text = dr.ItemArray[0].ToString();
            //    l.Name = l.Text+"lbl";
            //}

            //dataGridView2.DataSource = 旋转dt(dt);
            //dataGridView3.DataSource = 旋转dt(旋转dt(dt));
            //dataGridView4.DataSource = 旋转dt(旋转dt(旋转dt(dt)));

            //CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            //cm.SuspendBinding();
            //dataGridView1.Rows[0].Visible = false;
            //dataGridView1.Rows[1].Visible = false;
            //cm.ResumeBinding(); 
        }
        private DataTable 旋转dt(DataTable source)
        {
            DataTable result = new DataTable();

            string[,] newTable = new string[source.Columns.Count, source.Rows.Count];
            for (int i = 0; i < source.Rows.Count; i++)
            {
                for(int j = 0; j < source.Columns.Count; j++)
                {
                    newTable[j,i] = source.Rows[i].ItemArray[j].ToString();
                }
            }

            result.Columns.Add("用户名");//---
            foreach(DataRow dr in source.Rows)
            {
                result.Columns.Add(dr.ItemArray[0].ToString());
            }

            for(int i= 0;i < source.Columns.Count;i++)
            {
                object[] values = new object[source.Rows.Count+1];
                values[0] = source.Columns[i].Caption;//---
                for(int j = 0; j < source.Rows.Count; j++)
                {
                    if (i > 1)
                    {
                        values[j + 1] = Convert.ToBoolean(source.Rows[j].ItemArray[i]);
                    }
                    else
                    {
                        values[j + 1] = source.Rows[j].ItemArray[i];
                    }
                }
                result.Rows.Add(values);
            }
            result.Rows[0].Delete();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = org_dt.Copy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                List<string> list = new List<string>();
                List<Tuple<string, string, string>> plist = new List<Tuple<string, string, string>>();
                SqlHelper sh = new SqlHelper();
                int? result = sh.IUDbyDataTableReturnInt("select * from dbo.权限表", (DataTable)(dataGridView1.DataSource), null, CommandType.Text);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 2; j < dataGridView1.ColumnCount; j++)
                    {
                        bool org_value = Convert.ToBoolean(org_dt.Rows[i].ItemArray[j]);
                        bool mod_value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[j].Value);

                        if (!mod_value && org_value)
                        {
                            list.Add(Convert.ToString(org_dt.Rows[i].ItemArray[0]) + " 禁止 " + org_dt.Columns[j].ColumnName);
                        }
                        else if (mod_value && !org_value)
                        {
                            list.Add(Convert.ToString(org_dt.Rows[i].ItemArray[0]) + " 允许 " + org_dt.Columns[j].ColumnName);
                        }

                        if (org_value != mod_value)
                        {
                            plist.Add(new Tuple<string, string, string>(Convert.ToString(org_dt.Rows[i].Field<int>("用户ID")), org_dt.Columns[j].ColumnName, Convert.ToString(mod_value)));
                        }

                    }
                }
                if (list.Count > 0)
                {
                    string 操作用户ID = Form1.loginUser;
                    string 操作 = "修改";
                    string 时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 备注 = "";
                    string 详细内容 = string.Join(" | ", list);
                    string sqlText;
                    foreach (Tuple<string, string, string> t in plist)
                    {
                        sqlText = string.Format("insert into dbo.权限历史表(用户ID,操作用户ID,操作,时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", t.Item1, 操作用户ID, 操作, 时间, t.Item2, t.Item3, 备注);
                        result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    }

                    org_dt = ((DataTable)dataGridView1.DataSource).Copy();
                    MessageBox.Show(详细内容.Replace(" | ", Environment.NewLine));
                }
                else if (list.Count == 0)
                {
                    MessageBox.Show("无内容被修改！");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool value = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !value;
        }
    }
}
