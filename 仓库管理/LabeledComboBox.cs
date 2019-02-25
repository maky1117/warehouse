using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class LabeledComboBox : UserControl
    {
        DataTable dt;
        string ID列;
        string 名称列;
        string 表名;
        string whereClause;
        string controlWhereClause;//其他控件传递的约束值
        //ID列对应ValueMember，名称列对应DisplayMember，表名指取值的表，whereClause一般过滤删除标志，dynamic指是否根据其他控件动作来刷新，control指该控件,默认ID值指默认选中的值
        public LabeledComboBox(string ID列,string 名称列,string 表名,string whereClause,bool dynamic=false,Control control=null,string 默认ID值="0")
        {
            InitializeComponent();
            this.ID列 = ID列;
            this.名称列 = 名称列;
            this.表名 = 表名;
            this.whereClause = whereClause;
            //ID列 = "用户ID";
            //名称列 = "用户名";
            //表名 = "用户表";
            //默认ID值 = "0";//外部传参，选中对应的ValueMember值
            loadDataSource();
            if (dt.Rows.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (dynamic)
            {
                if (control != null)
                {
                    ((LabeledComboBox)control).addControlEvent((sender, e) =>
                    {
                        ComboBox refCbb = (ComboBox)sender;
                        controlWhereClause = " and " + ((LabeledComboBox)control).IDName + "=" + refCbb.SelectedValue;
                        loadDataSource();
                    });
                }
            }
        }
        public string Label
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                comboBox1.Left = label1.Right + 10;
                this.Width = comboBox1.Right + 10;
            }
        }
        public string Value
        {
            get
            {
                return (comboBox1.SelectedIndex>-1) ? Convert.ToString(comboBox1.SelectedValue) : "";
            }
            set
            {
                if (dt.AsEnumerable().Select(r => r.Field<string>(名称列)).ToList<string>().Contains(value))
                {
                    comboBox1.Text = value;
                }
                else
                {
                    comboBox1.Text = "";
                }
            }
        }
        public string IDName
        {
            get
            {
                return this.ID列;
            }
        }
        public void addControlEvent(EventHandler e)
        {
            comboBox1.SelectedValueChanged+=e;
        }
        private string organizeWhereClause(string w1,string w2)
        {
            if (w1 == null && w2 == null)
            {
                return "";
            }
            else
            {
                return "where 1=1 " + (w1 ?? "") + (w2 ?? "");
            }
        }
        private void loadDataSource()
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = string.Format("select {0},{1} from {2} {3}", ID列, 名称列, 表名, organizeWhereClause(whereClause, controlWhereClause));
            comboBox1.DisplayMember = 名称列;
            comboBox1.ValueMember = ID列;
            //dt = new DataTable();
            dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            comboBox1.DataSource = dt;
        }
    }
}
