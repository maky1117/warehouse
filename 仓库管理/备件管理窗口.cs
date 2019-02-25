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
    public partial class 备件管理窗口 : Form
    {
        public 备件管理窗口()
        {
            InitializeComponent();
        }

        private void 备件管理窗口_Load(object sender, EventArgs e)
        {
            dataManager1.TableName = "备件表";
            dataManager1.PrimaryKey = "备件ID";
            dataManager1.UniqueColumnName = "备件名称";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.EnablePictureManagement = false;
            //dataManager1.DisplayColumns = new string[] { "备件名称", "品牌", "单位", "成本价", "类别名称"};
            dataManager1.DisplayColumns = new List<DisplayColumn>();
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "备件名称", 所在表 = "备件表", 提取列 = "备件名称", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "品牌", 所在表 = "备件表", 提取列 = "品牌", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "单位", 所在表 = "备件表", 提取列 = "单位", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "成本价", 所在表 = "备件表", 提取列 = "成本价", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "类别名称", 所在表 = "备件表", 提取列 = "类别名称", 控件类型 = "input" });
            dataManager1.Show();
            dataManager1.Show();
        }
    }
}
