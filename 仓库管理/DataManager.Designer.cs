namespace 仓库管理
{
    partial class DataManager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.添加btn = new System.Windows.Forms.Button();
            this.修改btn = new System.Windows.Forms.Button();
            this.删除btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pic_count_lbl = new System.Windows.Forms.Label();
            this.图片管理btn = new System.Windows.Forms.Button();
            this.取消排序btn = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 9);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(692, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // 添加btn
            // 
            this.添加btn.Location = new System.Drawing.Point(10, 362);
            this.添加btn.Name = "添加btn";
            this.添加btn.Size = new System.Drawing.Size(75, 27);
            this.添加btn.TabIndex = 1;
            this.添加btn.Text = "添加";
            this.添加btn.UseVisualStyleBackColor = true;
            // 
            // 修改btn
            // 
            this.修改btn.Location = new System.Drawing.Point(108, 362);
            this.修改btn.Name = "修改btn";
            this.修改btn.Size = new System.Drawing.Size(75, 27);
            this.修改btn.TabIndex = 2;
            this.修改btn.Text = "修改";
            this.修改btn.UseVisualStyleBackColor = true;
            // 
            // 删除btn
            // 
            this.删除btn.Location = new System.Drawing.Point(206, 362);
            this.删除btn.Name = "删除btn";
            this.删除btn.Size = new System.Drawing.Size(75, 27);
            this.删除btn.TabIndex = 3;
            this.删除btn.Text = "删除";
            this.删除btn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 285);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(692, 71);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // pic_count_lbl
            // 
            this.pic_count_lbl.AutoSize = true;
            this.pic_count_lbl.Location = new System.Drawing.Point(491, 369);
            this.pic_count_lbl.Name = "pic_count_lbl";
            this.pic_count_lbl.Size = new System.Drawing.Size(83, 12);
            this.pic_count_lbl.TabIndex = 32;
            this.pic_count_lbl.Text = "pic_count_lbl";
            // 
            // 图片管理btn
            // 
            this.图片管理btn.Location = new System.Drawing.Point(402, 362);
            this.图片管理btn.Name = "图片管理btn";
            this.图片管理btn.Size = new System.Drawing.Size(75, 27);
            this.图片管理btn.TabIndex = 31;
            this.图片管理btn.Text = "图片管理";
            this.图片管理btn.UseVisualStyleBackColor = true;
            // 
            // 取消排序btn
            // 
            this.取消排序btn.Location = new System.Drawing.Point(304, 362);
            this.取消排序btn.Name = "取消排序btn";
            this.取消排序btn.Size = new System.Drawing.Size(75, 27);
            this.取消排序btn.TabIndex = 33;
            this.取消排序btn.Text = "取消排序";
            this.取消排序btn.UseVisualStyleBackColor = true;
            // 
            // DataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.取消排序btn);
            this.Controls.Add(this.pic_count_lbl);
            this.Controls.Add(this.图片管理btn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.删除btn);
            this.Controls.Add(this.修改btn);
            this.Controls.Add(this.添加btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataManager";
            this.Size = new System.Drawing.Size(718, 432);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 添加btn;
        private System.Windows.Forms.Button 修改btn;
        private System.Windows.Forms.Button 删除btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label pic_count_lbl;
        private System.Windows.Forms.Button 图片管理btn;
        private System.Windows.Forms.Button 取消排序btn;
    }
}
