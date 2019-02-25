namespace 仓库管理
{
    partial class 货架管理窗口
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
            this.仓库cmbbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.货架名称txtbx = new System.Windows.Forms.TextBox();
            this.添加btn = new System.Windows.Forms.Button();
            this.修改btn = new System.Windows.Forms.Button();
            this.删除btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // 仓库cmbbx
            // 
            this.仓库cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.仓库cmbbx.FormattingEnabled = true;
            this.仓库cmbbx.Location = new System.Drawing.Point(79, 34);
            this.仓库cmbbx.Name = "仓库cmbbx";
            this.仓库cmbbx.Size = new System.Drawing.Size(116, 20);
            this.仓库cmbbx.TabIndex = 0;
            this.仓库cmbbx.SelectionChangeCommitted += new System.EventHandler(this.仓库cmbbx_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "仓库";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(217, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(388, 330);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "货架名称";
            // 
            // 货架名称txtbx
            // 
            this.货架名称txtbx.Location = new System.Drawing.Point(79, 72);
            this.货架名称txtbx.Name = "货架名称txtbx";
            this.货架名称txtbx.Size = new System.Drawing.Size(116, 21);
            this.货架名称txtbx.TabIndex = 4;
            // 
            // 添加btn
            // 
            this.添加btn.Location = new System.Drawing.Point(26, 119);
            this.添加btn.Name = "添加btn";
            this.添加btn.Size = new System.Drawing.Size(75, 23);
            this.添加btn.TabIndex = 5;
            this.添加btn.Text = "添加";
            this.添加btn.UseVisualStyleBackColor = true;
            this.添加btn.Click += new System.EventHandler(this.添加btn_Click);
            // 
            // 修改btn
            // 
            this.修改btn.Location = new System.Drawing.Point(120, 119);
            this.修改btn.Name = "修改btn";
            this.修改btn.Size = new System.Drawing.Size(75, 23);
            this.修改btn.TabIndex = 6;
            this.修改btn.Text = "修改";
            this.修改btn.UseVisualStyleBackColor = true;
            this.修改btn.Click += new System.EventHandler(this.修改btn_Click);
            // 
            // 删除btn
            // 
            this.删除btn.Location = new System.Drawing.Point(120, 169);
            this.删除btn.Name = "删除btn";
            this.删除btn.Size = new System.Drawing.Size(75, 23);
            this.删除btn.TabIndex = 7;
            this.删除btn.Text = "删除";
            this.删除btn.UseVisualStyleBackColor = true;
            this.删除btn.Click += new System.EventHandler(this.删除btn_Click);
            // 
            // 货架管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 401);
            this.Controls.Add(this.删除btn);
            this.Controls.Add(this.修改btn);
            this.Controls.Add(this.添加btn);
            this.Controls.Add(this.货架名称txtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.仓库cmbbx);
            this.Name = "货架管理窗口";
            this.Text = "货架管理窗口";
            this.Load += new System.EventHandler(this.货架管理窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox 仓库cmbbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox 货架名称txtbx;
        private System.Windows.Forms.Button 添加btn;
        private System.Windows.Forms.Button 修改btn;
        private System.Windows.Forms.Button 删除btn;
    }
}