using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class 出库登记窗口 : Form
    {
        private string imgSaveUrl;
        private bool isPicSubmitted = false;//如未提交并关闭窗口，则把图片删除
        private DataTable org_dt;
        public 出库登记窗口()
        {
            InitializeComponent();
        }
        private void 出库登记窗口_Load(object sender, EventArgs e)
        {
            initForm();
        }
        private string captureAndSaveImage(string dir)
        {
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string imageurl = dir + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                while (File.Exists(imageurl + ".jpg"))
                {
                    imageurl += "_1";
                }
                imageurl += ".jpg";
                axLiteArrayCtrl1.Capture(0, imageurl);
                MessageBox.Show("\"" + imageurl + "\"保存成功");
                return imageurl;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
        private void initForm()
        {
            axLiteArrayCtrl1.StartPreview(0);
            initComboBoxes();
        }
        private void initComboBoxes()
        {
            SqlHelper sh = new SqlHelper();
            string sqlText = "select 仓库ID,仓库名称 from dbo.仓库表 where 删除标志=0";
            DataTable dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            仓库cmbbx.DisplayMember = "仓库名称";
            仓库cmbbx.ValueMember = "仓库ID";
            仓库cmbbx.DataSource = dt;
            仓库cmbbx.SelectedIndex = 0;

            //sqlText = "select 备件ID,备件名称 from dbo.备件表 where 删除标志=0";
            //dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            //备件cmbbx.DisplayMember = "备件名称";
            //备件cmbbx.ValueMember = "备件ID";
            //备件cmbbx.DataSource = dt;
            //备件cmbbx.SelectedIndex = 0;
        }
        private void 拍照btn_Click(object sender, EventArgs e)
        {
            if (imgSaveUrl != null && isPicSubmitted == false)
            {
                File.Delete(imgSaveUrl);//未提交前拍多次均把上一次图片删掉
            }
            else if (isPicSubmitted)
            {
                isPicSubmitted = false;
            }
            string imageurl = captureAndSaveImage("出库");
            imgSaveUrl = imageurl;
            FileStream fs = new FileStream(imageurl, FileMode.Open, FileAccess.Read);//通过转成filestream文件流的方式，避免对文件资源的锁定占用
            pictureBox1.Image = Image.FromStream(fs);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            fs.Close();
            fs.Dispose();

        }

        private void 提交btn_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string 仓库ID = Convert.ToString(仓库cmbbx.SelectedValue);
            string 备件ID = Convert.ToString(备件txtbx.Text);
            string 数量 = 数量txtbx.Text;
            //string 出库时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
            string 备注 = 备注rtbbx.Text;
            string 图片 = imgSaveUrl;
            string sqlText = string.Format("insert into dbo.出库表(仓库ID,备件ID,数量,备注,图片) values('{0}','{1}','{2}','{3}','{4}')", 仓库ID, 备件ID, 数量, 备注, 图片);
            int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);

            if (result > 0)
            {
                isPicSubmitted = true;
                sqlText = string.Format("select 单位 from dbo.备件表 where 备件ID='{0}'", 备件ID);
                string 单位 = sh.selectReturnString(sqlText, null, CommandType.Text);
                MessageBox.Show(仓库cmbbx.Text + " 出库 " + 备件txtbx.Text + "：" + 数量 + 单位);

                string 出库ID = sh.selectReturnString("select max(出库ID) from dbo.出库表", null, CommandType.Text);
                string 操作用户ID = Form1.loginUser;
                string 操作 = "添加";
                string 操作时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                string 字段 = "出库ID";
                string 值 = 出库ID;
                备注 = "";
                sqlText = string.Format("insert into dbo.出库历史表(出库ID,操作用户ID,操作,操作时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 出库ID, 操作用户ID, 操作, 操作时间, 字段, 值, 备注);
                result = sh.IUDReturnInt(sqlText, null, CommandType.Text);

                List<Tuple<string, string>> clist = new List<Tuple<string, string>>();
                clist.Add(new Tuple<string, string>("仓库", 仓库cmbbx.Text));
                clist.Add(new Tuple<string, string>("备件", 备件txtbx.Text));
                clist.Add(new Tuple<string, string>("数量", 数量txtbx.Text));
                clist.Add(new Tuple<string, string>("图片", imgSaveUrl));
                clist.Add(new Tuple<string, string>("备注", 备注rtbbx.Text));
                foreach (Tuple<string, string> c in clist)
                {
                    字段 = c.Item1;
                    值 = c.Item2;
                    sqlText = string.Format("insert into dbo.出库历史表(出库ID,操作用户ID,操作,操作时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 出库ID, 操作用户ID, 操作, 操作时间, 字段, 值, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                }
            }
        }

        private void 清空btn_Click(object sender, EventArgs e)
        {
            数量txtbx.Text = 备注rtbbx.Text = "";
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            if (!isPicSubmitted)
            {
                File.Delete(imgSaveUrl);
            }
        }

        private void 数量txtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void 入库登记窗口_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isPicSubmitted && imgSaveUrl != null)
            {
                File.Delete(imgSaveUrl);
            }
        }

        private void 管理仓库btn_Click(object sender, EventArgs e)
        {
            仓库管理窗口_old ckglck = new 仓库管理窗口_old();
            ckglck.ShowDialog();
            initComboBoxes();
        }

        private void 管理备件btn_Click(object sender, EventArgs e)
        {
            备件管理窗口_old bjglck = new 备件管理窗口_old();
            bjglck.ShowDialog();
            initComboBoxes();
        }

        private void refreshDataGridView()
        {
            if (仓库cmbbx.SelectedValue != null)
            {
                string 仓库ID = 仓库cmbbx.SelectedValue.ToString();
                label6.Text = 仓库ID;
                SqlHelper sh = new SqlHelper();
                string sqlText = "select A.货架ID,B.货架名称,A.备件ID,D.备件名称,A.数量 from dbo.库存表 A " +
                "inner join dbo.货架表 B on B.货架ID=A.货架ID " +
                "inner join dbo.仓库表 C on C.仓库ID=B.仓库ID " +
                "inner join dbo.备件表 D on D.备件ID=A.备件ID " +
                "where C.仓库ID=" + 仓库ID;
                org_dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
                dataGridView1.DataSource = org_dt.Copy();
                dataGridView1.Columns["货架ID"].Visible = false;
                dataGridView1.Columns["备件ID"].Visible = false;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
            }
        }

        private void 仓库cmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string 备件ID=Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["备件ID"].Value);
                SqlHelper sh = new SqlHelper();
                string sqlText = "select 备件ID,备件名称 from dbo.备件表 where 删除标志=0 and 备件ID="+备件ID;
                SqlDataReader sdr = sh.selectReturnDataReader(sqlText, null, CommandType.Text);
                while (sdr.Read())
                {
                    备件txtbx.Text = Convert.ToString(sdr.GetValue(1));
                    label7.Text = Convert.ToString(sdr.GetValue(0));
                }

                sh = new SqlHelper();
                sqlText = "select 图片 from dbo.备件表 where 备件ID="+备件ID;
                //DataTable dt = new DataTable();
                //dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
                //byte[] imagebytes = (byte[])(dt.Rows[0].ItemArray[0]);
                sdr = sh.selectReturnDataReader(sqlText, null, CommandType.Text);
                while (sdr.Read())
                {
                    string imageurl = sdr["图片"].ToString();
                    FileStream fs = new FileStream(imageurl, FileMode.Open);
                    pictureBox2.Image = Bitmap.FromStream(fs);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                备件txtbx.Text = "";
                label7.Text = "";
            }
        }

        private void 管理去处btn_Click(object sender, EventArgs e)
        {
            地点管理窗口 ddglck = new 地点管理窗口();
            ddglck.ShowDialog();
        }
    }
}
