using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class 入库登记窗口 : Form
    {
        private string imgSaveUrl;
        private bool isPicSubmitted=false;//如未提交并关闭窗口，则把图片删除
        public 入库登记窗口()
        {
            InitializeComponent();
        }
        private void 入库登记窗口_Load(object sender, EventArgs e)
        {
            initForm();
            //SqlHelper sh = new SqlHelper();
            //string sqlText = "select 图片 from dbo.入库表 where 仓库编号=0";
            ////DataTable dt = new DataTable();
            ////dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            ////byte[] imagebytes = (byte[])(dt.Rows[0].ItemArray[0]);
            //SqlDataReader sdr = sh.selectReturnDataReader(sqlText, null, CommandType.Text);
            //while (sdr.Read())
            //{
            //    string imageurl = sdr["图片"].ToString();
            //    FileStream fs = new FileStream(imageurl, FileMode.Open);
            //    pictureBox2.Image = Bitmap.FromStream(fs);
            //    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //}
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
                MessageBox.Show("\""+imageurl+"\"保存成功");
                return imageurl;
            }catch(Exception e)
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

            sqlText = "select 备件ID,备件名称 from dbo.备件表 where 删除标志=0";
            dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            备件cmbbx.DisplayMember = "备件名称";
            备件cmbbx.ValueMember = "备件ID";
            备件cmbbx.DataSource = dt;
            仓库cmbbx.SelectedIndex = 0;
        }
        private void 拍照btn_Click(object sender, EventArgs e)
        {
            if (imgSaveUrl != null && isPicSubmitted == false)
            {
                File.Delete(imgSaveUrl);//未提交前拍多次均把上一次图片删掉
            }else if (isPicSubmitted)
            {
                isPicSubmitted = false;
            }
            string imageurl=captureAndSaveImage("入库");
            imgSaveUrl = imageurl;
            FileStream fs = new FileStream(imageurl, FileMode.Open, FileAccess.Read);//通过转成filestream文件流的方式，避免对文件资源的锁定占用
            pictureBox1.Image = Image.FromStream(fs);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            fs.Close();
            fs.Dispose();
            
        }

        private void 提交btn_Click(object sender, EventArgs e)
        {
            if (数量txtbx.Text == "")
            {
                MessageBox.Show("未填写数量！");
            }
            else
            {
                SqlHelper sh = new SqlHelper();
                string 货架ID = Convert.ToString(货架cmbbx.SelectedValue);
                string 备件ID = Convert.ToString(备件cmbbx.SelectedValue);
                string 数量 = 数量txtbx.Text;
                //string 入库时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                string 备注 = 备注rtbbx.Text;
                string 图片 = imgSaveUrl;
                string sqlText = string.Format("insert into dbo.入库表(货架ID,备件ID,数量,备注,图片) values('{0}','{1}','{2}','{3}','{4}')", 货架ID, 备件ID, 数量, 备注, 图片);
                int? result = sh.IUDReturnInt(sqlText, null, CommandType.Text);

                if (result > 0)
                {
                    isPicSubmitted = true;
                    sqlText = string.Format("select 单位 from dbo.备件表 where 备件ID='{0}'", 备件ID);
                    string 单位 = sh.selectReturnString(sqlText, null, CommandType.Text);
                    MessageBox.Show(仓库cmbbx.Text + "-" + 货架cmbbx.Text + " 入库 " + 备件cmbbx.Text + "：" + 数量 + 单位);

                    string 入库ID = sh.selectReturnString("select max(入库ID) from dbo.入库表", null, CommandType.Text);
                    string 操作用户ID = Form1.loginUser;
                    string 操作 = "添加";
                    string 操作时间 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string 字段 = "入库ID";
                    string 值 = 入库ID;
                    备注 = "";
                    sqlText = string.Format("insert into dbo.入库历史表(入库ID,操作用户ID,操作,操作时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 入库ID, 操作用户ID, 操作, 操作时间, 字段, 值, 备注);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);

                    List<Tuple<string, string>> clist = new List<Tuple<string, string>>();
                    clist.Add(new Tuple<string, string>("货架", 货架cmbbx.Text));
                    clist.Add(new Tuple<string, string>("备件", 备件cmbbx.Text));
                    clist.Add(new Tuple<string, string>("数量", 数量txtbx.Text));
                    clist.Add(new Tuple<string, string>("图片", imgSaveUrl));
                    clist.Add(new Tuple<string, string>("备注", 备注rtbbx.Text));
                    foreach (Tuple<string, string> c in clist)
                    {
                        字段 = c.Item1;
                        值 = c.Item2;
                        sqlText = string.Format("insert into dbo.入库历史表(入库ID,操作用户ID,操作,操作时间,字段,值,备注)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 入库ID, 操作用户ID, 操作, 操作时间, 字段, 值, 备注);
                        result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    }

                    sqlText = string.Format("insert into dbo.库存表(货架ID,备件ID,数量) values('{0}','{1}','{2}')", 货架ID, 备件ID, 数量);
                    result = sh.IUDReturnInt(sqlText, null, CommandType.Text);
                    refreshDataGridView();
                    清空Inputs();
                }
            }
        }

        private void 清空btn_Click(object sender, EventArgs e)
        {
            清空Inputs();
        }
        private void 清空Inputs()
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
            imgSaveUrl = "";
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

        private void 货架cmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string 货架ID = 货架cmbbx.SelectedValue.ToString();
            label7.Text = 货架ID;
            SqlHelper sh = new SqlHelper();
            string sqlText = "select 货架ID,备件ID,数量 from dbo.库存表 where 货架ID=" + 货架ID;
            DataTable dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            dataGridView1.DataSource = dt;
        }
        private void refreshDataGridView()
        {
            string 仓库ID = 仓库cmbbx.SelectedValue.ToString();
            label6.Text = 仓库ID;
            SqlHelper sh = new SqlHelper();
            string sqlText = "select 货架ID,货架名称 from dbo.货架表 where 删除标志=0 and 仓库ID=" + 仓库ID;
            DataTable dt = sh.selectReturnDataSet(sqlText, null, CommandType.Text).Tables[0];
            货架cmbbx.DisplayMember = "货架名称";
            货架cmbbx.ValueMember = "货架ID";
            货架cmbbx.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                货架cmbbx.SelectedIndex = 0;
            }
        }

        private void 仓库cmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void 备件cmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string 备件ID = 备件cmbbx.SelectedValue.ToString();
            label8.Text = 备件ID;
        }
    }
}
