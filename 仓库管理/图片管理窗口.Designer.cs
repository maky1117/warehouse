namespace 仓库管理
{
    partial class 图片管理窗口
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(图片管理窗口));
            this.axLiteArrayCtrl1 = new AxLiteArrayCtrlLib.AxLiteArrayCtrl();
            this.拍照btn = new System.Windows.Forms.Button();
            this.删除btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.放弃并关闭btn = new System.Windows.Forms.Button();
            this.保存并关闭btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLiteArrayCtrl1
            // 
            this.axLiteArrayCtrl1.Enabled = true;
            this.axLiteArrayCtrl1.Location = new System.Drawing.Point(20, 20);
            this.axLiteArrayCtrl1.Name = "axLiteArrayCtrl1";
            this.axLiteArrayCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLiteArrayCtrl1.OcxState")));
            this.axLiteArrayCtrl1.Size = new System.Drawing.Size(335, 197);
            this.axLiteArrayCtrl1.TabIndex = 31;
            // 
            // 拍照btn
            // 
            this.拍照btn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.拍照btn.Location = new System.Drawing.Point(427, 62);
            this.拍照btn.Name = "拍照btn";
            this.拍照btn.Size = new System.Drawing.Size(75, 46);
            this.拍照btn.TabIndex = 33;
            this.拍照btn.Text = "拍照";
            this.拍照btn.UseVisualStyleBackColor = true;
            this.拍照btn.Click += new System.EventHandler(this.拍照btn_Click);
            // 
            // 删除btn
            // 
            this.删除btn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.删除btn.Location = new System.Drawing.Point(427, 124);
            this.删除btn.Name = "删除btn";
            this.删除btn.Size = new System.Drawing.Size(75, 46);
            this.删除btn.TabIndex = 35;
            this.删除btn.Text = "删除";
            this.删除btn.UseVisualStyleBackColor = true;
            this.删除btn.Click += new System.EventHandler(this.删除btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(335, 196);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.放弃并关闭btn);
            this.groupBox1.Controls.Add(this.保存并关闭btn);
            this.groupBox1.Controls.Add(this.axLiteArrayCtrl1);
            this.groupBox1.Controls.Add(this.拍照btn);
            this.groupBox1.Controls.Add(this.删除btn);
            this.groupBox1.Location = new System.Drawing.Point(52, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 229);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片采集";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(396, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 38;
            this.label1.Text = "label1";
            // 
            // 放弃并关闭btn
            // 
            this.放弃并关闭btn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.放弃并关闭btn.Location = new System.Drawing.Point(536, 124);
            this.放弃并关闭btn.Name = "放弃并关闭btn";
            this.放弃并关闭btn.Size = new System.Drawing.Size(127, 46);
            this.放弃并关闭btn.TabIndex = 37;
            this.放弃并关闭btn.Text = "放弃并关闭";
            this.放弃并关闭btn.UseVisualStyleBackColor = true;
            this.放弃并关闭btn.Click += new System.EventHandler(this.放弃并关闭btn_Click);
            // 
            // 保存并关闭btn
            // 
            this.保存并关闭btn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.保存并关闭btn.Location = new System.Drawing.Point(536, 62);
            this.保存并关闭btn.Name = "保存并关闭btn";
            this.保存并关闭btn.Size = new System.Drawing.Size(127, 46);
            this.保存并关闭btn.TabIndex = 36;
            this.保存并关闭btn.Text = "保存并关闭";
            this.保存并关闭btn.UseVisualStyleBackColor = true;
            this.保存并关闭btn.Click += new System.EventHandler(this.保存并关闭btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(52, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 226);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片查询";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(370, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 197);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 拍照窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 543);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "拍照窗口";
            this.Text = "拍照窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.拍照窗口_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxLiteArrayCtrlLib.AxLiteArrayCtrl axLiteArrayCtrl1;
        private System.Windows.Forms.Button 拍照btn;
        private System.Windows.Forms.Button 删除btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button 放弃并关闭btn;
        private System.Windows.Forms.Button 保存并关闭btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}