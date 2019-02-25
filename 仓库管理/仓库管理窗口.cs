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
    public partial class 仓库管理窗口 : Form
    {
        public 仓库管理窗口()
        {
            InitializeComponent();
        }

        private void 仓库管理窗口_Load(object sender, EventArgs e)
        {
            dataManager1.TableName = "仓库表";
            dataManager1.PrimaryKey = "仓库ID";
            dataManager1.UniqueColumnName = "仓库名称";
            dataManager1.WhereClause = "where 删除标志=0";
            dataManager1.EnablePictureManagement = false;
            //dataManager1.DisplayColumns = new string[] { "仓库名称", "仓库位置", "仓管员", "联系方式"};
            dataManager1.DisplayColumns = new List<DisplayColumn>();
            dataManager1.DisplayColumns.Add(new DisplayColumn() { 显示名称 = "仓库名称", 所在表 = "仓库表", 控件类型 = "input" });
            dataManager1.DisplayColumns.Add(new DisplayColumn() { 显示名称 = "仓管员姓名", 所在表 = "用户表", 提取列 = "用户名", 控件类型 = "combo" });
            dataManager1.DisplayColumns.Add(new DisplayColumn() { 显示名称 = "仓库名称", 所在表 = "用户表", 提取列 = "联系方式" });
            dataManager1.DisplayColumns.Add(new DisplayColumn() { 显示名称 = "仓库位置", 所在表 = "仓库表", 控件类型 = "input" });
            dataManager1.Show();
        }

        private void 管理货架btn_Click(object sender, EventArgs e)
        {
            货架管理窗口 hjglck = new 货架管理窗口(Convert.ToString(dataManager1.GetSelectedObjectID()));
            hjglck.StartPosition = FormStartPosition.CenterScreen;
            hjglck.ShowDialog();
        }
    }
}
