namespace 仓库管理
{
    partial class 用户管理窗口_old
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.增加btn = new System.Windows.Forms.Button();
            this.修改btn = new System.Windows.Forms.Button();
            this.用户名txtbx = new System.Windows.Forms.TextBox();
            this.姓名txtbx = new System.Windows.Forms.TextBox();
            this.性别txtbx = new System.Windows.Forms.TextBox();
            this.联系方式txtbx = new System.Windows.Forms.TextBox();
            this.密码txtbx = new System.Windows.Forms.TextBox();
            this.角色txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.删除btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 21);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 318);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // 增加btn
            // 
            this.增加btn.Location = new System.Drawing.Point(75, 437);
            this.增加btn.Name = "增加btn";
            this.增加btn.Size = new System.Drawing.Size(75, 23);
            this.增加btn.TabIndex = 1;
            this.增加btn.Text = "增加";
            this.增加btn.UseVisualStyleBackColor = true;
            this.增加btn.Click += new System.EventHandler(this.增加btn_Click);
            this.增加btn.MouseEnter += new System.EventHandler(this.增加btn_MouseEnter);
            // 
            // 修改btn
            // 
            this.修改btn.Location = new System.Drawing.Point(176, 437);
            this.修改btn.Name = "修改btn";
            this.修改btn.Size = new System.Drawing.Size(75, 23);
            this.修改btn.TabIndex = 2;
            this.修改btn.Text = "修改";
            this.修改btn.UseVisualStyleBackColor = true;
            this.修改btn.Click += new System.EventHandler(this.修改btn_Click);
            this.修改btn.MouseEnter += new System.EventHandler(this.修改btn_MouseEnter);
            // 
            // 用户名txtbx
            // 
            this.用户名txtbx.Location = new System.Drawing.Point(75, 388);
            this.用户名txtbx.Name = "用户名txtbx";
            this.用户名txtbx.Size = new System.Drawing.Size(100, 21);
            this.用户名txtbx.TabIndex = 3;
            // 
            // 姓名txtbx
            // 
            this.姓名txtbx.Location = new System.Drawing.Point(192, 388);
            this.姓名txtbx.Name = "姓名txtbx";
            this.姓名txtbx.Size = new System.Drawing.Size(100, 21);
            this.姓名txtbx.TabIndex = 4;
            // 
            // 性别txtbx
            // 
            this.性别txtbx.Location = new System.Drawing.Point(309, 388);
            this.性别txtbx.Name = "性别txtbx";
            this.性别txtbx.Size = new System.Drawing.Size(100, 21);
            this.性别txtbx.TabIndex = 5;
            // 
            // 联系方式txtbx
            // 
            this.联系方式txtbx.Location = new System.Drawing.Point(426, 388);
            this.联系方式txtbx.Name = "联系方式txtbx";
            this.联系方式txtbx.Size = new System.Drawing.Size(100, 21);
            this.联系方式txtbx.TabIndex = 6;
            // 
            // 密码txtbx
            // 
            this.密码txtbx.Location = new System.Drawing.Point(543, 388);
            this.密码txtbx.Name = "密码txtbx";
            this.密码txtbx.Size = new System.Drawing.Size(100, 21);
            this.密码txtbx.TabIndex = 7;
            // 
            // 角色txtbx
            // 
            this.角色txtbx.Location = new System.Drawing.Point(660, 388);
            this.角色txtbx.Name = "角色txtbx";
            this.角色txtbx.Size = new System.Drawing.Size(100, 21);
            this.角色txtbx.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "性别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "联系方式";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(663, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "角色";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(80, 415);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "启用";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // 删除btn
            // 
            this.删除btn.Location = new System.Drawing.Point(273, 437);
            this.删除btn.Name = "删除btn";
            this.删除btn.Size = new System.Drawing.Size(75, 23);
            this.删除btn.TabIndex = 16;
            this.删除btn.Text = "删除";
            this.删除btn.UseVisualStyleBackColor = true;
            this.删除btn.Click += new System.EventHandler(this.删除btn_Click);
            // 
            // 用户管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 477);
            this.Controls.Add(this.删除btn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.角色txtbx);
            this.Controls.Add(this.密码txtbx);
            this.Controls.Add(this.联系方式txtbx);
            this.Controls.Add(this.性别txtbx);
            this.Controls.Add(this.姓名txtbx);
            this.Controls.Add(this.用户名txtbx);
            this.Controls.Add(this.修改btn);
            this.Controls.Add(this.增加btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "用户管理窗口";
            this.Text = "用户管理窗口";
            this.Load += new System.EventHandler(this.用户管理窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 增加btn;
        private System.Windows.Forms.Button 修改btn;
        private System.Windows.Forms.TextBox 用户名txtbx;
        private System.Windows.Forms.TextBox 姓名txtbx;
        private System.Windows.Forms.TextBox 性别txtbx;
        private System.Windows.Forms.TextBox 联系方式txtbx;
        private System.Windows.Forms.TextBox 密码txtbx;
        private System.Windows.Forms.TextBox 角色txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button 删除btn;
    }
}