namespace 仓库管理
{
    partial class 入库修改窗口
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
            this.复位Button = new System.Windows.Forms.Button();
            this.仓库textBox = new System.Windows.Forms.TextBox();
            this.备件textBox = new System.Windows.Forms.TextBox();
            this.入库人textBox = new System.Windows.Forms.TextBox();
            this.入库开始时间textBox = new System.Windows.Forms.TextBox();
            this.入库结束时间textBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.查询button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.保存修改button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(169, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(584, 255);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // 复位Button
            // 
            this.复位Button.Location = new System.Drawing.Point(44, 391);
            this.复位Button.Name = "复位Button";
            this.复位Button.Size = new System.Drawing.Size(75, 23);
            this.复位Button.TabIndex = 1;
            this.复位Button.Text = "复位";
            this.复位Button.UseVisualStyleBackColor = true;
            this.复位Button.Click += new System.EventHandler(this.复位Button_Click);
            // 
            // 仓库textBox
            // 
            this.仓库textBox.Location = new System.Drawing.Point(29, 39);
            this.仓库textBox.Name = "仓库textBox";
            this.仓库textBox.Size = new System.Drawing.Size(100, 21);
            this.仓库textBox.TabIndex = 2;
            this.仓库textBox.Enter += new System.EventHandler(this.仓库textBox_Enter);
            // 
            // 备件textBox
            // 
            this.备件textBox.Location = new System.Drawing.Point(170, 39);
            this.备件textBox.Name = "备件textBox";
            this.备件textBox.Size = new System.Drawing.Size(100, 21);
            this.备件textBox.TabIndex = 3;
            this.备件textBox.Enter += new System.EventHandler(this.备件textBox_Enter);
            // 
            // 入库人textBox
            // 
            this.入库人textBox.Location = new System.Drawing.Point(292, 39);
            this.入库人textBox.Name = "入库人textBox";
            this.入库人textBox.Size = new System.Drawing.Size(100, 21);
            this.入库人textBox.TabIndex = 4;
            this.入库人textBox.Enter += new System.EventHandler(this.入库人textBox_Enter);
            // 
            // 入库开始时间textBox
            // 
            this.入库开始时间textBox.Location = new System.Drawing.Point(454, 39);
            this.入库开始时间textBox.Name = "入库开始时间textBox";
            this.入库开始时间textBox.Size = new System.Drawing.Size(100, 21);
            this.入库开始时间textBox.TabIndex = 5;
            // 
            // 入库结束时间textBox
            // 
            this.入库结束时间textBox.Location = new System.Drawing.Point(583, 39);
            this.入库结束时间textBox.Name = "入库结束时间textBox";
            this.入库结束时间textBox.Size = new System.Drawing.Size(100, 21);
            this.入库结束时间textBox.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(27, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 12);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "仓库";
            // 
            // 查询button
            // 
            this.查询button.Location = new System.Drawing.Point(698, 37);
            this.查询button.Name = "查询button";
            this.查询button.Size = new System.Drawing.Size(75, 23);
            this.查询button.TabIndex = 9;
            this.查询button.Text = "查询";
            this.查询button.UseVisualStyleBackColor = true;
            this.查询button.Click += new System.EventHandler(this.查询button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "入库人";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(28, 106);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(124, 256);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "备件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "入库开始时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "入库结束时间";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(54, 106);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(124, 256);
            this.listBox2.TabIndex = 15;
            this.listBox2.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(84, 106);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox3.Size = new System.Drawing.Size(124, 256);
            this.listBox3.TabIndex = 16;
            this.listBox3.SelectedValueChanged += new System.EventHandler(this.listBox3_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "label8";
            // 
            // 保存修改button
            // 
            this.保存修改button.Location = new System.Drawing.Point(133, 391);
            this.保存修改button.Name = "保存修改button";
            this.保存修改button.Size = new System.Drawing.Size(75, 23);
            this.保存修改button.TabIndex = 20;
            this.保存修改button.Text = "保存修改";
            this.保存修改button.UseVisualStyleBackColor = true;
            this.保存修改button.Click += new System.EventHandler(this.保存修改button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // 入库修改窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 426);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.保存修改button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.查询button);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.入库结束时间textBox);
            this.Controls.Add(this.入库开始时间textBox);
            this.Controls.Add(this.入库人textBox);
            this.Controls.Add(this.备件textBox);
            this.Controls.Add(this.仓库textBox);
            this.Controls.Add(this.复位Button);
            this.Controls.Add(this.dataGridView1);
            this.Name = "入库修改窗口";
            this.Text = "入库修改窗口";
            this.Load += new System.EventHandler(this.入库修改窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 复位Button;
        private System.Windows.Forms.TextBox 仓库textBox;
        private System.Windows.Forms.TextBox 备件textBox;
        private System.Windows.Forms.TextBox 入库人textBox;
        private System.Windows.Forms.TextBox 入库开始时间textBox;
        private System.Windows.Forms.TextBox 入库结束时间textBox;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button 查询button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button 保存修改button;
        private System.Windows.Forms.Button button1;
    }
}