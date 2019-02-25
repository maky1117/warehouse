namespace 仓库管理
{
    partial class 入库登记窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(入库登记窗口));
            this.仓库cmbbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.备件cmbbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.数量txtbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.备注rtbbx = new System.Windows.Forms.RichTextBox();
            this.axLiteArrayCtrl1 = new AxLiteArrayCtrlLib.AxLiteArrayCtrl();
            this.拍照btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.提交btn = new System.Windows.Forms.Button();
            this.清空btn = new System.Windows.Forms.Button();
            this.管理仓库btn = new System.Windows.Forms.Button();
            this.管理备件btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.货架cmbbx = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // 仓库cmbbx
            // 
            this.仓库cmbbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.仓库cmbbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.仓库cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.仓库cmbbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.仓库cmbbx.FormattingEnabled = true;
            this.仓库cmbbx.Location = new System.Drawing.Point(134, 232);
            this.仓库cmbbx.Name = "仓库cmbbx";
            this.仓库cmbbx.Size = new System.Drawing.Size(121, 22);
            this.仓库cmbbx.TabIndex = 0;
            this.仓库cmbbx.SelectedIndexChanged += new System.EventHandler(this.仓库cmbbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(89, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "仓库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(65, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "备件类型";
            // 
            // 备件cmbbx
            // 
            this.备件cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.备件cmbbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.备件cmbbx.FormattingEnabled = true;
            this.备件cmbbx.Location = new System.Drawing.Point(134, 298);
            this.备件cmbbx.Name = "备件cmbbx";
            this.备件cmbbx.Size = new System.Drawing.Size(121, 22);
            this.备件cmbbx.TabIndex = 2;
            this.备件cmbbx.SelectedIndexChanged += new System.EventHandler(this.备件cmbbx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(89, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "数量";
            // 
            // 数量txtbx
            // 
            this.数量txtbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数量txtbx.Location = new System.Drawing.Point(134, 331);
            this.数量txtbx.Name = "数量txtbx";
            this.数量txtbx.Size = new System.Drawing.Size(121, 23);
            this.数量txtbx.TabIndex = 5;
            this.数量txtbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.数量txtbx_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(89, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
            // 
            // 备注rtbbx
            // 
            this.备注rtbbx.Font = new System.Drawing.Font("宋体", 10F);
            this.备注rtbbx.Location = new System.Drawing.Point(134, 361);
            this.备注rtbbx.Name = "备注rtbbx";
            this.备注rtbbx.Size = new System.Drawing.Size(121, 77);
            this.备注rtbbx.TabIndex = 7;
            this.备注rtbbx.Text = "";
            // 
            // axLiteArrayCtrl1
            // 
            this.axLiteArrayCtrl1.Enabled = true;
            this.axLiteArrayCtrl1.Location = new System.Drawing.Point(13, 12);
            this.axLiteArrayCtrl1.Name = "axLiteArrayCtrl1";
            this.axLiteArrayCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLiteArrayCtrl1.OcxState")));
            this.axLiteArrayCtrl1.Size = new System.Drawing.Size(335, 197);
            this.axLiteArrayCtrl1.TabIndex = 8;
            // 
            // 拍照btn
            // 
            this.拍照btn.Location = new System.Drawing.Point(201, 462);
            this.拍照btn.Name = "拍照btn";
            this.拍照btn.Size = new System.Drawing.Size(75, 23);
            this.拍照btn.TabIndex = 9;
            this.拍照btn.Text = "拍照";
            this.拍照btn.UseVisualStyleBackColor = true;
            this.拍照btn.Click += new System.EventHandler(this.拍照btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(354, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 197);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // 提交btn
            // 
            this.提交btn.Location = new System.Drawing.Point(320, 462);
            this.提交btn.Name = "提交btn";
            this.提交btn.Size = new System.Drawing.Size(75, 23);
            this.提交btn.TabIndex = 11;
            this.提交btn.Text = "提交";
            this.提交btn.UseVisualStyleBackColor = true;
            this.提交btn.Click += new System.EventHandler(this.提交btn_Click);
            // 
            // 清空btn
            // 
            this.清空btn.Location = new System.Drawing.Point(439, 462);
            this.清空btn.Name = "清空btn";
            this.清空btn.Size = new System.Drawing.Size(75, 23);
            this.清空btn.TabIndex = 14;
            this.清空btn.Text = "清空";
            this.清空btn.UseVisualStyleBackColor = true;
            this.清空btn.Click += new System.EventHandler(this.清空btn_Click);
            // 
            // 管理仓库btn
            // 
            this.管理仓库btn.Location = new System.Drawing.Point(262, 231);
            this.管理仓库btn.Name = "管理仓库btn";
            this.管理仓库btn.Size = new System.Drawing.Size(75, 23);
            this.管理仓库btn.TabIndex = 15;
            this.管理仓库btn.Text = "管理仓库";
            this.管理仓库btn.UseVisualStyleBackColor = true;
            this.管理仓库btn.Click += new System.EventHandler(this.管理仓库btn_Click);
            // 
            // 管理备件btn
            // 
            this.管理备件btn.Location = new System.Drawing.Point(262, 298);
            this.管理备件btn.Name = "管理备件btn";
            this.管理备件btn.Size = new System.Drawing.Size(75, 23);
            this.管理备件btn.TabIndex = 16;
            this.管理备件btn.Text = "管理备件";
            this.管理备件btn.UseVisualStyleBackColor = true;
            this.管理备件btn.Click += new System.EventHandler(this.管理备件btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(89, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "货架";
            // 
            // 货架cmbbx
            // 
            this.货架cmbbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.货架cmbbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.货架cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.货架cmbbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.货架cmbbx.FormattingEnabled = true;
            this.货架cmbbx.Location = new System.Drawing.Point(134, 265);
            this.货架cmbbx.Name = "货架cmbbx";
            this.货架cmbbx.Size = new System.Drawing.Size(121, 22);
            this.货架cmbbx.TabIndex = 17;
            this.货架cmbbx.SelectedIndexChanged += new System.EventHandler(this.货架cmbbx_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(354, 232);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(335, 206);
            this.dataGridView1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "label8";
            // 
            // 入库登记窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 494);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.货架cmbbx);
            this.Controls.Add(this.管理备件btn);
            this.Controls.Add(this.管理仓库btn);
            this.Controls.Add(this.清空btn);
            this.Controls.Add(this.提交btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.拍照btn);
            this.Controls.Add(this.axLiteArrayCtrl1);
            this.Controls.Add(this.备注rtbbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.数量txtbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.备件cmbbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.仓库cmbbx);
            this.Name = "入库登记窗口";
            this.Text = "入库登记窗口";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.入库登记窗口_FormClosed);
            this.Load += new System.EventHandler(this.入库登记窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox 仓库cmbbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox 备件cmbbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox 数量txtbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox 备注rtbbx;
        private AxLiteArrayCtrlLib.AxLiteArrayCtrl axLiteArrayCtrl1;
        private System.Windows.Forms.Button 拍照btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button 提交btn;
        private System.Windows.Forms.Button 清空btn;
        private System.Windows.Forms.Button 管理仓库btn;
        private System.Windows.Forms.Button 管理备件btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox 货架cmbbx;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}