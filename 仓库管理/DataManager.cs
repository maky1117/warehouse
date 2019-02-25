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
using System.Data.SqlClient;

namespace 仓库管理
{
    public partial class DataManager : UserControl
    {
        string tableName;
        string whereClause;
        string primaryKey;
        string unique_column_name;
        bool enablePictureManagement;//是否启用图片管理        
        DataTable org_dt;
        
        //int displayColumnCount;
        int max_label_width;
        List<Control> labeledControlList;
        //List<Tuple<string, string>> column_type_list;
        //List<Tuple<string, string>> db_column_type_list;
        //List<string> 显示列;
        //List<string> 提交列;
        bool isShowed=false;
        int _scrollValue;//获取dataGridView1滚动位置   

        //public List<Tuple<string,string,string>> JoinTables;//join的表名，join表的ID列，被join表的ID列
        public List<DisplayColumn> DisplayColumns;
        public string[] ControlList;
        public DataManager()
        {
            InitializeComponent();
            unique_column_name = "";
            enablePictureManagement = false;
            org_dt = new DataTable();
            _scrollValue = 0;
        }
        public DataManager(string tableName) : this()
        {
            TableName = tableName;
        }
        public string TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }
        public string PrimaryKey
        {
            get
            {
                return this.primaryKey;
            }
            set
            {
                this.primaryKey = value;
            }
        }
        public string UniqueColumnName
        {
            get
            {
                return this.unique_column_name;
            }
            set
            {
                this.unique_column_name = value;
            }
        }
        public bool EnablePictureManagement
        {
            get
            {
                return this.enablePictureManagement;
            }
            set
            {
                this.enablePictureManagement = value;
            }
        }
        public string WhereClause
        {
            get
            {
                return this.whereClause;
            }
            set
            {
                this.whereClause = value;
            }
        }
        /// <summary>
        /// 显示数据的主函数
        /// </summary>
        public new void Show()
        {
            try
            {
                GetDataTableFromSqlDB();
                initControlAndEvent();
                showOnDataGridView(true);
                    //如果没有选中，则选中第一项
                if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public object GetSelectedObjectID()
        {
            return dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[primaryKey].Value;
        }
        private void GetDataTableFromSqlDB()
        {
            SqlHelper sh = new SqlHelper();
            List<string> select列 = new List<string>();
            List<string> Tables = new List<string>();
            string joinClause = "";

            select列.Add(tableName + "." + primaryKey);//主键
            for (int i = 0; i < DisplayColumns.Count; i++)
            {
                select列.Add(string.Format("{0}={1}.{2}", DisplayColumns[i].显示名称, DisplayColumns[i].所在表, DisplayColumns[i].提取列));
                if (DisplayColumns[i].所在表 != tableName&&!Tables.Contains(DisplayColumns[i].所在表))
                {
                    joinClause += string.Format(" left join {0} on {0}.{1}={2}.{3} ", DisplayColumns[i].所在表, DisplayColumns[i].链接ID, tableName, DisplayColumns[i].被链接ID);
                    Tables.Add(DisplayColumns[i].所在表);
                }
            }
            whereClause = whereClause.Replace("where ", "where "+tableName + ".");
            string sqlText = string.Format("select {0} from {1} {2} {3}", string.Join(",",select列), tableName,joinClause, whereClause);// where 删除标志=0
            org_dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];//org_dt保存当前表的状态            
        }
        /// <summary>
        /// 根据displayColumns，初始化输入控件组，同时为控件添加事件处理函数
        /// </summary>
        private void initControlAndEvent()
        {
                //记录最长的控件的宽度
            max_label_width = 0;
                //根据字段名称和类型来创建对应的控件组，bit类型的创建LabeledCheckBox，其他的则创建LabeledTextBox
            labeledControlList = new List<Control>();
                //Tab键顺序
            int tabIndex = 0;
            for(int i=0;i<DisplayColumns.Count;i++)
            {
                if (DisplayColumns[i].控件类型!=null)
                {
                    Control labeledControl = new Control();
                    if (DisplayColumns[i].控件类型 == "combo")
                    {
                        labeledControl = new LabeledComboBox(DisplayColumns[i].链接ID, DisplayColumns[i].提取列, DisplayColumns[i].所在表, "and 删除标志=0");
                        ((LabeledComboBox)labeledControl).Label = DisplayColumns[i].显示名称;
                        ((LabeledComboBox)labeledControl).Name = DisplayColumns[i].显示名称 + "combo";
                    }
                    else if (DisplayColumns[i].控件类型 == "check")
                    {
                        labeledControl = new LabeledCheckBox();
                        ((LabeledCheckBox)labeledControl).Label = DisplayColumns[i].显示名称;
                        ((LabeledCheckBox)labeledControl).Name = DisplayColumns[i].显示名称 + "check";
                    }
                    else if (DisplayColumns[i].控件类型 == "input")
                    {
                        labeledControl = new LabeledTextBox();
                        ((LabeledTextBox)labeledControl).Label = DisplayColumns[i].显示名称;
                        ((LabeledTextBox)labeledControl).Name = DisplayColumns[i].显示名称 + "input";
                    }
                    labeledControl.TabIndex = tabIndex++;

                    if (labeledControl.Width > max_label_width)
                    {
                        max_label_width = labeledControl.Width;
                    }
                    labeledControlList.Add(labeledControl);
                }
            }

            添加btn.TabIndex = tabIndex++;
            修改btn.TabIndex = tabIndex++;
            删除btn.TabIndex = tabIndex++;
            取消排序btn.TabIndex = tabIndex++;
            图片管理btn.TabIndex = tabIndex++;
                //根据记录的最大控件宽度，使控件间隔整齐
            List<Control>.Enumerator le = labeledControlList.GetEnumerator();
            while (le.MoveNext())
            {
                le.Current.Width = max_label_width;
                flowLayoutPanel1.Controls.Add(le.Current);
            }
                //是否显示图片管理按钮
            图片管理btn.Visible=pic_count_lbl.Visible= enablePictureManagement;

            dataGridView1.SelectionChanged += (sender, e) =>
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;


                    for (int i = 0; i < DisplayColumns.Count;i++ )
                    {
                        string value = Convert.ToString(dataGridView1.Rows[rowIndex].Cells[DisplayColumns[i].显示名称].Value);
                        if (DisplayColumns[i].控件类型 == "check")
                        {
                            ((LabeledCheckBox)flowLayoutPanel1.Controls.Find(DisplayColumns[i].显示名称+"check",false)[0]).Value = Convert.ToBoolean(value);
                        }
                        else if (DisplayColumns[i].控件类型 == "input")
                        {
                            ((LabeledTextBox)flowLayoutPanel1.Controls.Find(DisplayColumns[i].显示名称 + "input", false)[0]).Value = Convert.ToString(value);
                        }
                        else if (DisplayColumns[i].控件类型 == "combo")
                        {
                            ((LabeledComboBox)flowLayoutPanel1.Controls.Find(DisplayColumns[i].显示名称 + "combo", false)[0]).Value = Convert.ToString(value);
                        }
                    }
                }
            };
            dataGridView1.Scroll += (sender, e) =>
            {
                _scrollValue = e.NewValue;
            };
            添加btn.Click += (sender, e) =>
            {
                Dictionary<string, string> values = GetInputValues();
                SqlHelper add_sh = new SqlHelper();
                string add_sqlText = string.Format("insert into {0}({1})values('{2}')", tableName, string.Join(",", DisplayColumns.Select(r => r.显示名称)), string.Join("','", values.Select(r => r.Value)));
                if (unique_column_name != "")
                {
                    if (values[unique_column_name] == "")
                    {
                        MessageBox.Show(unique_column_name + "不准为空");
                    }
                    else if (!isValueUnique(unique_column_name))
                    {
                        string duplicate_value = ((LabeledTextBox)flowLayoutPanel1.Controls.Find(unique_column_name + "input", false)[0]).Value;
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            if (Convert.ToString(r.Cells[unique_column_name].Value) == duplicate_value)
                            {
                                r.Selected = true;
                                MessageBox.Show("存在重复的" + unique_column_name + "：" + duplicate_value + "！！");
                            }
                        }
                    }
                    else
                    {
                        //以下通过获取sql返回print信息来做判断，sql表中需有相应的insert触发器产生print输出，否则不会执行事件函数
                        int? result = add_sh.IUDReturnInt(add_sqlText, null, CommandType.Text);
                        MessageBox.Show(string.Format("成功添加{0}：{1}", unique_column_name, values[DisplayColumns[0].显示名称]));
                        GetDataTableFromSqlDB();
                        showOnDataGridView(true);
                        dataGridView1.ClearSelection();
                        try
                        {
                            foreach (DataGridViewRow r in dataGridView1.Rows)
                            {
                                if (Convert.ToString(r.Cells[unique_column_name].Value) == values[DisplayColumns[0].显示名称])
                                {
                                    dataGridView1.ClearSelection();
                                    r.Selected = true;
                                }
                            }
                        }
                        catch (ArgumentOutOfRangeException ee)
                        {

                        }
                    }
                }
            };
            修改btn.Click += (sender, e) =>
            {
                if (dataGridView1.SelectedCells.Count == 0)
                {
                    MessageBox.Show("没有选择内容！");
                }
                else
                {
                    bool proceed = true;
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                        //把输入控件的值加入到values字典，字典的key是表中对应的列名，value是输入控件的值
                    Dictionary<string, string> values = GetInputValues();
                        //MessageBox的消息字串
                    List<string> updateString = new List<string>();
                        //把values字典中的key和value取出分别生成k_list和v_list两个数组
                    List<string> k_list = values.Select(r => r.Key).ToList<string>();
                    List<string> v_list = values.Select(r => r.Value).ToList<string>();
                        //根据选中行的用户ID，查找org_dt中相同用户ID的行，并取值插入org_dt_v_list数组
                    List<string> org_dt_v_list = new List<string>();
                        //设置PrimaryKey，否则org_dt.Rows.Find会报该表无主键的错
                    org_dt.PrimaryKey = new DataColumn[] { org_dt.Columns[primaryKey] };
                    DataRow org_dt_row=org_dt.Rows.Find(dataGridView1.Rows[rowIndex].Cells[primaryKey].Value);
                        //根据显示列来从org_dt中选取值
                    foreach (DisplayColumn dc in DisplayColumns)
                    {
                        org_dt_v_list.Add(Convert.ToString(org_dt_row.ItemArray[org_dt.Columns[dc.显示名称].Ordinal]));
                    }
                        //输入框的值集和org_dt中对应行的值集对比
                    for (int i = 0; i < DisplayColumns.Count; i++)
                    {
                        string k = k_list[i];
                        string v = v_list[i];                       
                        if (v!=org_dt_v_list[i])
                        {
                            updateString.Add(k + "='" + v + "'");
                        }
                    }
                    if (updateString.Count == 0)
                    {
                        MessageBox.Show("没有修改任何内容！");
                        proceed = false;
                    }
                    else if (unique_column_name != "")
                    {

                        if (values[unique_column_name] == "")
                        {
                            MessageBox.Show(unique_column_name + "不准为空");
                            proceed = false;
                        }
                        else if (!isValueUnique(unique_column_name))
                        {
                            string input_value = ((LabeledTextBox)flowLayoutPanel1.Controls.Find(unique_column_name + "input", false)[0]).Value;
                            string current_value = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[unique_column_name].Value);
                            foreach (DataGridViewRow r in dataGridView1.Rows)
                            {
                                if (r.Index != dataGridView1.SelectedCells[0].RowIndex && Convert.ToString(r.Cells[unique_column_name].Value) == input_value)
                                {
                                    MessageBox.Show(string.Format("不允许把{0}：“{1}”修改为“{2}”！！" + Environment.NewLine + "原因：存在重复的{0}！", unique_column_name, current_value, input_value));
                                    dataGridView1.ClearSelection();
                                    r.Selected = true;
                                    proceed = false;
                                }
                            }
                        }                        
                    }
                    if (proceed)
                    {
                        if (MessageBox.Show("修改" + unique_column_name + "：“" + Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[unique_column_name].Value) + "”" + Environment.NewLine + "┏-修改内容-┓" + Environment.NewLine + string.Join(Environment.NewLine, updateString), "确认修改", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            SqlHelper mod_sh = new SqlHelper();
                            string mod_sqlText = string.Format("update {0} set {1} where {2}={3}", tableName, string.Join(",", updateString), org_dt.Columns[primaryKey].ColumnName, dataGridView1.Rows[rowIndex].Cells[primaryKey].Value);
                            int? result = mod_sh.IUDReturnInt(mod_sqlText, null, CommandType.Text);
                            if (result > 0)
                            {
                                MessageBox.Show(string.Format("成功修改{0}：{1}", DisplayColumns[0].显示名称, values[DisplayColumns[0].显示名称]));
                                //刷新org_dt，同时也刷新dataGridView显示
                                GetDataTableFromSqlDB();
                                showOnDataGridView(true);
                                //清除所有选择，否则左上角的格会被选中，不好看
                                dataGridView1.ClearSelection();
                                try
                                {
                                    dataGridView1.Rows[rowIndex].Selected = true;
                                }
                                catch (ArgumentOutOfRangeException ee)
                                {

                                }
                            }
                        }
                    }
                }
            };
            删除btn.Click += (sender, e) =>
            {
                Dictionary<string, string> values = GetInputValues();
                if (dataGridView1.SelectedCells.Count == 0)
                {
                    MessageBox.Show("没有选择内容！");
                }
                else if(MessageBox.Show("删除" + unique_column_name + "：" + values[DisplayColumns[0].显示名称], "确认删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    SqlHelper del_sh = new SqlHelper();
                    string del_sqlText = string.Format("update {0} set 删除标志=1 where {1}={2}",tableName, org_dt.Columns[primaryKey].ColumnName, dataGridView1.Rows[rowIndex].Cells[primaryKey].Value);
                    int? result = del_sh.IUDReturnInt(del_sqlText, null, CommandType.Text);
                    if (result > 0)
                    {
                        MessageBox.Show(string.Format("成功删除{0}：{1}", DisplayColumns[0].显示名称, values[DisplayColumns[0].显示名称]));
                        GetDataTableFromSqlDB();
                        showOnDataGridView(true);
                        dataGridView1.ClearSelection();
                        try
                        {
                            dataGridView1.Rows[rowIndex - 1].Selected = true;
                        }
                        catch (ArgumentOutOfRangeException ee)
                        {
                            
                        }
                    }
                }
            };
            取消排序btn.Click += (sender, e) =>
            {
                showOnDataGridView(false);
            };
            if (enablePictureManagement)
            {
                图片管理btn.Click += (sender, e) =>
                  {
                      if (dataGridView1.SelectedCells.Count > 0)
                      {
                          int rowindex = dataGridView1.SelectedCells[0].RowIndex;
                          int object_id_value = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[primaryKey].Value);
                            //primaryKey是org_dt的主键，unique_column_name一般是也应该是对象的名称
                          图片管理窗口 pzck = new 图片管理窗口(object_id_value,tableName,primaryKey,unique_column_name);
                          pzck.ShowDialog();
                            //窗口关闭后，刷新dataGridView
                          showOnDataGridView(true);
                            //选中原先选中行
                          dataGridView1.ClearSelection();
                          dataGridView1.Rows[rowindex].Selected = true;
                      }
                  };
                dataGridView1.SelectionChanged += (sender, e) =>
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int object_id_value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[primaryKey].Value);
                            //根据图片表上的对象ID和对象表名，把该对象的图片总数算出来
                        string sqlText = string.Format("select count(*) from 图片表 where 对象ID={0} and 对象表名='{1}'", object_id_value, tableName);
                        SqlHelper sh = new SqlHelper();
                        string pic_count = sh.selectReturnString(sqlText, null, CommandType.Text);
                        pic_count_lbl.Text = "现有图片：" + pic_count + "张";
                    }
                };
            }
        }

         /// <summary>
         /// 用于刷新dataGridView的显示
         /// </summary>
        public void showOnDataGridView(bool rememberSort)
        {
            string sortedColumnName = null;
            System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.None;
                //记住刷新前的排序
            if (dataGridView1.SortedColumn != null&&rememberSort)
            {
                sortedColumnName = dataGridView1.SortedColumn.Name;
                sortOrder = dataGridView1.SortOrder;
            }
                //刷新数据源
            dataGridView1.DataSource = org_dt.Copy();
                //设置所有列不可见
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.Visible = false;
            }
            //根据displayColumns数组来显示相应列
            foreach (DisplayColumn c in DisplayColumns)
            {
                dataGridView1.Columns[c.显示名称].Visible = true;
            }
                //应用之前的SortMode，无记录则忽略
            if (sortedColumnName != null)
            {
                ListSortDirection lsd;
                if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    lsd = ListSortDirection.Ascending;
                }else
                {
                    lsd = ListSortDirection.Descending;
                }
                dataGridView1.Sort(dataGridView1.Columns[sortedColumnName], lsd);
            }
                //设置滚动位置
            if (dataGridView1.Rows.Count > 0)
            {
                if (_scrollValue > dataGridView1.RowCount && _scrollValue != 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                }
                else
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = _scrollValue;
                }
            }
        }
        /// <summary>
        /// 把输入框的值与dataGridView中的对应字段的值集合比较是否重复
        /// </summary>
        /// <param name="column_name"></param>
        /// <returns></returns>
        private bool isValueUnique(string column_name)
        {
            Control c = flowLayoutPanel1.Controls.Find(column_name + "ltb", false)[0];
                //string exist_values = string.Join(",", (dataGridView1.DataSource as DataTable).AsEnumerable().Select(s => s.Field<string>(column_name)));
            List<string> exist_values = (dataGridView1.DataSource as DataTable).AsEnumerable().Select(s => s.Field<string>(column_name)).ToList<string>();

            if (exist_values.Contains(((LabeledTextBox)c).Value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取输入控件的值插入到Dictionary
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetInputValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            for (int i = 0; i < labeledControlList.Count; i++)
            {
                if (DisplayColumns[i].控件类型 == "check")
                {
                    values.Add(DisplayColumns[i].显示名称, Convert.ToString(((LabeledCheckBox)labeledControlList[i]).Value));
                }
                else
                {
                    values.Add(DisplayColumns[i].显示名称, ((LabeledTextBox)labeledControlList[i]).Value);
                }
            }
            return values;
        }
    }
}
