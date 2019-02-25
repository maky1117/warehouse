using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 仓库管理
{
    public partial class 地点管理窗口 : Form
    {
        public 地点管理窗口()
        {
            InitializeComponent();
        }

        private void 地点管理窗口_Load(object sender, EventArgs e)
        {
            dataManager1.TableName = "地点表";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.PrimaryKey = "地点ID";
            //dataManager1.DisplayColumns = new string[] { "地点名称", "地点类别","备注" };
            dataManager1.DisplayColumns = new List<DisplayColumn>();
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "地点名称", 所在表 = "地点表", 提取列 = "地点名称", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "地点类别", 所在表 = "地点表", 提取列 = "地点类别", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "备注", 所在表 = "地点表", 提取列 = "备注", 控件类型 = "input" });
            dataManager1.Show();
        }
    }
}
