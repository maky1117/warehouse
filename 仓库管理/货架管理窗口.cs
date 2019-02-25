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
    public partial class 货架管理窗口 : Form
    {
        private string 仓库ID;
        private DataTable org_dt;
        public 货架管理窗口()
        {
            InitializeComponent();
        }
        public 货架管理窗口(string 仓库ID):this()
        {
            this.仓库ID = 仓库ID;
        }

        private void 货架管理窗口_Load(object sender, EventArgs e)
        {
            refreshTable();
            refreshCombo();            
        }
        private void refreshCombo()
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = "select 仓库ID,仓库名称 from dbo.仓库表 where 删除标志=0";
            DataTable dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            仓库cmbbx.DataSource = dt;
            仓库cmbbx.ValueMember = "仓库ID";
            仓库cmbbx.DisplayMember = "仓库名称";
            仓库cmbbx.SelectedValue = 仓库ID;
            updateDataGridViewBy仓库ID();
        }
        private void refreshTable()
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = "select A.货架ID,A.货架名称,B.仓库名称,B.仓库ID from dbo.货架表 A inner join dbo.仓库表 B on A.仓库ID=B.仓库ID where A.删除标志=0";
            org_dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
        }
        private void updateDataGridViewBy仓库ID()
        {
            int 仓库ID = Convert.ToInt32(仓库cmbbx.SelectedValue);
            var query = from 货架 in org_dt.AsEnumerable()
                        where 货架.Field<int>("仓库ID") == 仓库ID
                        select 货架;
            dataGridView1.DataSource = query.AsDataView();
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private void 添加btn_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string 货架名称 = 货架名称txtbx.Text;
            string 仓库ID = 仓库cmbbx.SelectedValue.ToString();
            string sqlText = string.Format("insert into dbo.货架表(货架名称,仓库ID) values('{0}','{1}')", 货架名称, 仓库ID);
            int? result=sh.IUDReturnInt(sqlText, null, CommandType.Text);
            if (result > 0)
            {
                string 仓库名称 = 仓库cmbbx.Text;
                MessageBox.Show(仓库名称 + "新增了货架：" + 货架名称);
                refreshTable();
                updateDataGridViewBy仓库ID();
            }
        }

        private void 仓库cmbbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDataGridViewBy仓库ID();
        }

        private void 修改btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("未选择货架！");
            }
            else
            {
                string 货架ID = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[dataGridView1.Columns["货架ID"].Index].Value.ToString();
                if (MessageBox.Show(string.Format("是否把货架ID：{0}名称改为{1}？", 货架ID, 货架名称txtbx.Text), "修改货架名称", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SqlHelper sh = new SqlHelper();
                    string sqlText = string.Format("update dbo.货架表 set 货架名称='{0}' where 货架ID={1}",货架名称txtbx.Text,货架ID);
                    int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    if (result > 0)
                    {
                        refreshTable();
                        updateDataGridViewBy仓库ID();
                    }
                }
            }
        }
        private void 删除btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("未选择货架！");
            }
            else
            {
                string 货架ID = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[dataGridView1.Columns["货架ID"].Index].Value.ToString();
                if (MessageBox.Show("是否删除货架ID：" + 货架ID + "？", "删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SqlHelper sh = new SqlHelper();
                    string sqlText = "update dbo.货架表 set 删除标志=1 where 删除标志=0 and 货架ID=" + 货架ID;
                    int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    if (result > 0)
                    {
                        refreshTable();
                        updateDataGridViewBy仓库ID();
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = 0;
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                }
                string 货架名称 = dataGridView1.Rows[rowIndex].Cells[dataGridView1.Columns["货架名称"].Index].Value.ToString();
                货架名称txtbx.Text = 货架名称;
            }
        }


    }
}
