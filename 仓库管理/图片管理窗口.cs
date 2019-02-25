using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelperForm;

namespace 仓库管理
{
    public partial class 图片管理窗口 : Form
    {
        List<string> add_picList;
        List<string> del_picList;
        int 对象ID;
        int 图片ID;
        string 对象表名;//图片保存的文件夹、填表项之一
        bool remindToSave = false;
        string pic_lost_hint = "（图片已丢失！）";
        DataTable dt;
        /// <summary>
        /// 构造函数，对象ID和对象表名都对应图片表中的字段，对象ID字段和对象名称字段则是对象表中的 “ID”和“名称”字段名称
        /// </summary>
        /// <param name="对象ID"></param>
        /// <param name="对象表名"></param>
        /// <param name="对象ID字段"></param>
        /// <param name="对象名称字段"></param>
        public 图片管理窗口(int 对象ID,string 对象表名, string 对象ID字段,string 对象名称字段)
        {
            InitializeComponent();
            this.对象表名 = 对象表名;
            this.对象ID = 对象ID;            
            add_picList = new List<string>();
            del_picList = new List<string>();
            SqlHelper sh = new SqlHelper();
            dt = sh.selectReturnDataSet("select 图片ID,图片路径,对象ID,对象表名 from 图片表", null, CommandType.Text).Tables[0];            
            //获取最新的图片ID
            if (dt.Rows.Count == 0)
            {
                图片ID = 0;
            }
            else
            {
                图片ID = dt.AsEnumerable().Select(s => s.Field<int>("图片ID")).Max();
            }
            
            //根据对应的对象ID，只显示相关的图片列表，之所以不在上面select语句中使用where条件，是为了查询整表的图片ID最大值
            var view = dt.AsEnumerable().Where(s => s.Field<int>("对象ID") == 对象ID);
            if (view.Count() > 0)
            {
                //如果where条件查询有内容，则拷贝回给dt，无内容CopyToDataTable会报错
                dt = view.CopyToDataTable();
            }
            else
            {
                //无内容时，则把dt的rows清空即可 
                dt.Rows.Clear();
            }
            //把where条件查询过的dt显示到dataGridView
            bindToDataGridView(dt,"对象ID","对象表名");            
            //pictureBox的SizeMode只要首次设置过即可
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //根据对象ID获取对象名称并显示在label1
            string 对象名称 = sh.selectReturnString(string.Format("select {0} from {1} where {2}='{3}'", 对象名称字段, 对象表名, 对象ID字段, 对象ID),null,CommandType.Text);
            label1.Text = 对象名称;

            //启用高拍仪
            axLiteArrayCtrl1.StartPreview(0);
        }

        /// <summary>
        /// 给新图片一个有效的保存名称和路径
        /// </summary>
        /// <returns></returns>
        private string getNewPicPath()
        {
            if (!Directory.Exists(对象表名))
            {
                Directory.CreateDirectory(对象表名);
            }
            string picFullName = 对象表名 + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            while (File.Exists(picFullName + ".jpg"))
            {
                picFullName += "_1";
            }
            return picFullName += ".jpg";            
        }
        /// <summary>
        /// 根据提供的图片路径，获取图片，并显示在提供的pictureBox
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="pb"></param>
        private void getPicAndShow(string picPath,PictureBox pb)
        {
            if (File.Exists(picPath))
            {
                FileStream fs = new FileStream(picPath, FileMode.Open, FileAccess.Read);//通过转成filestream文件流的方式，避免对文件资源的锁定占用
                pb.Image = Image.FromStream(fs);                
                fs.Close();
                fs.Dispose();
            }
            else
            {                
                pb.Image = TextToBitmap("图片丢失", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Point), Rectangle.Empty, Color.DarkRed, Color.DarkGray);
            }
        }
        /// <summary>
        /// 根据提供的图片保存路径，保存拍摄的图片
        /// </summary>
        /// <param name="savePath"></param>
        private void takePicAndSave(string savePath)
        {
            try
            {                
                //string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                //Bitmap bmp = TextToBitmap(text, new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Point), Rectangle.Empty, Color.Blue, Color.Red);
                //pictureBox1.Image = bmp;
                //bmp.Save(savePath, ImageFormat.Jpeg);
                axLiteArrayCtrl1.Capture(0, savePath);//上面四句暂时代替这句产生图片         
                MessageBox.Show("\"" + savePath + "\"保存成功");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 把dataTable绑定到dataGridView，并设置哪些栏可以显示
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="displayColumns"></param>
        private void bindToDataGridView(DataTable dataTable, params string[] hideColumns)
        {
            dataGridView1.DataSource = dataTable;

            foreach(string column in hideColumns)
            {
                dataGridView1.Columns[column].Visible = false;
            }
        }
        /// <summary>
        /// 把dataGridView上的内容Update到数据库的图片表
        /// </summary>
        private void updateDataTableToDataBase()
        {
            //停止timer，否则下面Replace回原值后，timer又给改成提示值
            timer1.Stop();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                string value = Convert.ToString(r.Cells["图片路径"].Value);
                value = value.Replace(pic_lost_hint, "");
                r.Cells["图片路径"].Value = value;
            }
            //Update到数据库
            SqlHelper sh = new SqlHelper();
            int? result = sh.IUDbyDataTableReturnInt("select 图片ID,图片路径,对象ID,对象表名 from 图片表", (DataTable)(dataGridView1.DataSource), null, CommandType.Text);
        }
        /// <summary>
        /// 点击保存并关闭按钮的保存操作函数
        /// </summary>
        private void 保存操作()
        {
            //保存到数据库
            updateDataTableToDataBase();
            //删除待删除列表中的的图片
            foreach (string pic in del_picList)
            {
                if (File.Exists(pic))
                {
                    File.Delete(pic);
                }
            }
        }
        /// <summary>
        /// 点击放弃并关闭按钮的放弃操作函数
        /// </summary>
        private void 放弃操作()
        {
            //删除新加列表中的图片
            foreach (string pic in add_picList)
            {
                if (File.Exists(pic))
                {
                    File.Delete(pic);
                }
            }
        }
        /// <summary>
        /// 把文本转换成Bitmap的功能
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="fontcolor"></param>
        /// <param name="backColor"></param>
        /// <returns></returns>
        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            //使用ClearType字体功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }
        private void 拍照btn_Click(object sender, EventArgs e)
        {
            //如果有增有减，关闭窗口会提示保存
            if (add_picList.Count + del_picList.Count > 0)
            {
                remindToSave = true;
            }
            //确定新的可用图片路径
            string newPic = getNewPicPath();

            //用该路径保存图片
            takePicAndSave(newPic);

            //把该路径添加到新加列表，以添加到dataGridView
            add_picList.Add(newPic);

            //在picturebox1显示刚拍存的照片
            getPicAndShow(newPic, pictureBox1);

            //添加行到dt
            dt.Rows.Add(++图片ID, newPic, 对象ID, 对象表名);
            //绑定到dataGridView
            bindToDataGridView(dt, "对象ID", "对象表名");

            //选中最新行
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
        }
        private void 删除btn_Click(object sender, EventArgs e)
        {
            //如果有增有减，关闭窗口会提示保存
            if (add_picList.Count + del_picList.Count > 0)
            {
                remindToSave = true;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                //获取dataGridView当前选中的行的图片路径
                string picPath = Convert.ToString(dataGridView1.Rows[rowIndex].Cells["图片路径"].Value);
                //加入待删除图片列表
                del_picList.Add(picPath);
                //删除该行
                dataGridView1.Rows.RemoveAt(rowIndex);
                if (dataGridView1.Rows.Count > 0)
                {
                    //已经是第一行就再次选中第一行，否则选中上一行
                    dataGridView1.Rows[(rowIndex==0)?rowIndex:rowIndex-1].Selected = true;
                }
                else
                {
                    //如果只剩一行，删完dataGridView成空，则清空pictureBox
                    pictureBox1.Image = null;
                }

            }
        }
        private void 保存并关闭btn_Click(object sender, EventArgs e)
        {
            保存操作();
            remindToSave = false;
            this.Close();
        }
        private void 放弃并关闭btn_Click(object sender, EventArgs e)
        {
            放弃操作();
            remindToSave = false;
            this.Close();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //根据选中行的图片路径获取图片，显示在picturebox1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string picPath = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["图片路径"].Value);
                getPicAndShow(picPath, pictureBox1);
            }
        }

        private void 拍照窗口_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (remindToSave)
            {
                DialogResult result = MessageBox.Show("是否保存？", "提醒", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }else if (result == DialogResult.Yes)
                {
                    保存操作();
                }else if (result == DialogResult.No)
                {
                    放弃操作();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dataGridView1.Rows)
            {
                string value = Convert.ToString(r.Cells["图片路径"].Value);
                if (!File.Exists(value)&&!value.Contains("图片已丢失"))
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Red;
                    r.Cells["图片路径"].Style = style;
                    r.Cells["图片路径"].Value = pic_lost_hint + value;
                }
            }
        }
    }
}
