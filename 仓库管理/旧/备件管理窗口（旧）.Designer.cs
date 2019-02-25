namespace 仓库管理
{
    partial class 备件管理窗口_old
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.类别名称txtbx = new System.Windows.Forms.TextBox();
            this.成本价txtbx = new System.Windows.Forms.TextBox();
            this.单位txtbx = new System.Windows.Forms.TextBox();
            this.备件名称txtbx = new System.Windows.Forms.TextBox();
            this.修改btn = new System.Windows.Forms.Button();
            this.增加btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.图片管理btn = new System.Windows.Forms.Button();
            this.pic_count_lbl = new System.Windows.Forms.Label();
            this.dataManager1 = new 仓库管理.DataManager();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "类别名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "成本价";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "备件名称";
            // 
            // 类别名称txtbx
            // 
            this.类别名称txtbx.Location = new System.Drawing.Point(364, 377);
            this.类别名称txtbx.Name = "类别名称txtbx";
            this.类别名称txtbx.Size = new System.Drawing.Size(100, 21);
            this.类别名称txtbx.TabIndex = 22;
            // 
            // 成本价txtbx
            // 
            this.成本价txtbx.Location = new System.Drawing.Point(247, 377);
            this.成本价txtbx.Name = "成本价txtbx";
            this.成本价txtbx.Size = new System.Drawing.Size(100, 21);
            this.成本价txtbx.TabIndex = 21;
            // 
            // 单位txtbx
            // 
            this.单位txtbx.Location = new System.Drawing.Point(130, 377);
            this.单位txtbx.Name = "单位txtbx";
            this.单位txtbx.Size = new System.Drawing.Size(100, 21);
            this.单位txtbx.TabIndex = 20;
            // 
            // 备件名称txtbx
            // 
            this.备件名称txtbx.Location = new System.Drawing.Point(13, 377);
            this.备件名称txtbx.Name = "备件名称txtbx";
            this.备件名称txtbx.Size = new System.Drawing.Size(100, 21);
            this.备件名称txtbx.TabIndex = 19;
            // 
            // 修改btn
            // 
            this.修改btn.Location = new System.Drawing.Point(104, 404);
            this.修改btn.Name = "修改btn";
            this.修改btn.Size = new System.Drawing.Size(75, 23);
            this.修改btn.TabIndex = 18;
            this.修改btn.Text = "修改";
            this.修改btn.UseVisualStyleBackColor = true;
            this.修改btn.Click += new System.EventHandler(this.修改btn_Click);
            this.修改btn.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // 增加btn
            // 
            this.增加btn.Location = new System.Drawing.Point(13, 404);
            this.增加btn.Name = "增加btn";
            this.增加btn.Size = new System.Drawing.Size(75, 23);
            this.增加btn.TabIndex = 17;
            this.增加btn.Text = "增加";
            this.增加btn.UseVisualStyleBackColor = true;
            this.增加btn.Click += new System.EventHandler(this.增加btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(557, 318);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            // 
            // 图片管理btn
            // 
            this.图片管理btn.Location = new System.Drawing.Point(196, 404);
            this.图片管理btn.Name = "图片管理btn";
            this.图片管理btn.Size = new System.Drawing.Size(75, 23);
            this.图片管理btn.TabIndex = 29;
            this.图片管理btn.Text = "图片管理";
            this.图片管理btn.UseVisualStyleBackColor = true;
            // 
            // pic_count_lbl
            // 
            this.pic_count_lbl.AutoSize = true;
            this.pic_count_lbl.Location = new System.Drawing.Point(278, 411);
            this.pic_count_lbl.Name = "pic_count_lbl";
            this.pic_count_lbl.Size = new System.Drawing.Size(83, 12);
            this.pic_count_lbl.TabIndex = 30;
            this.pic_count_lbl.Text = "pic_count_lbl";
            // 
            // dataManager1
            // 
            this.dataManager1.DisplayColumns = null;
            this.dataManager1.EnablePictureManagement = false;
            this.dataManager1.Location = new System.Drawing.Point(575, 12);
            this.dataManager1.Name = "dataManager1";
            this.dataManager1.PrimaryKey = null;
            this.dataManager1.Size = new System.Drawing.Size(715, 432);
            this.dataManager1.TabIndex = 31;
            this.dataManager1.TableName = null;
            this.dataManager1.UniqueColumnName = "";
            this.dataManager1.WhereClause = null;
            // 
            // 备件管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 453);
            this.Controls.Add(this.dataManager1);
            this.Controls.Add(this.pic_count_lbl);
            this.Controls.Add(this.图片管理btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.类别名称txtbx);
            this.Controls.Add(this.成本价txtbx);
            this.Controls.Add(this.单位txtbx);
            this.Controls.Add(this.备件名称txtbx);
            this.Controls.Add(this.修改btn);
            this.Controls.Add(this.增加btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "备件管理窗口";
            this.Text = "备件管理窗口";
            this.Load += new System.EventHandler(this.备件管理窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 类别名称txtbx;
        private System.Windows.Forms.TextBox 成本价txtbx;
        private System.Windows.Forms.TextBox 单位txtbx;
        private System.Windows.Forms.TextBox 备件名称txtbx;
        private System.Windows.Forms.Button 修改btn;
        private System.Windows.Forms.Button 增加btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 图片管理btn;
        private System.Windows.Forms.Label pic_count_lbl;
        private DataManager dataManager1;
    }
}