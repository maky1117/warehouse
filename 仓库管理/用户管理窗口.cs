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
    public partial class 用户管理窗口 : Form
    {
        public 用户管理窗口()
        {
            InitializeComponent();
        }

        private void 用户管理窗口_Load(object sender, EventArgs e)
        {
            dataManager1.TableName = "用户表";
            dataManager1.PrimaryKey = "用户ID";
            dataManager1.UniqueColumnName = "用户名";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.EnablePictureManagement = false;
            //dataManager1.DisplayColumns = new string[] { "用户名", "姓名", "性别", "联系方式", "角色","启禁标志" };
            dataManager1.DisplayColumns = new List<DisplayColumn>();
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "用户名", 所在表 = "用户表", 提取列 = "用户名", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "姓名", 所在表 = "用户表", 提取列 = "姓名", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "性别", 所在表 = "用户表", 提取列 = "性别", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "联系方式", 所在表 = "用户表", 提取列 = "联系方式", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "角色", 所在表 = "用户表", 提取列 = "角色", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn { 显示名称 = "启禁标志", 所在表 = "用户表", 提取列 = "启禁标志", 控件类型 = "check" });
            dataManager1.Show();
        }
    }
}
