namespace 仓库管理
{
    partial class 入库历史查询窗口
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
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.查询button = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.操作结束时间textBox = new System.Windows.Forms.TextBox();
            this.操作开始时间textBox = new System.Windows.Forms.TextBox();
            this.操作用户textBox = new System.Windows.Forms.TextBox();
            this.复位Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.操作textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "操作结束时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "操作开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "操作用户";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(28, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(124, 256);
            this.listBox1.TabIndex = 32;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // 查询button
            // 
            this.查询button.Location = new System.Drawing.Point(613, 44);
            this.查询button.Name = "查询button";
            this.查询button.Size = new System.Drawing.Size(75, 23);
            this.查询button.TabIndex = 30;
            this.查询button.Text = "查询";
            this.查询button.UseVisualStyleBackColor = true;
            this.查询button.Click += new System.EventHandler(this.查询button_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(90, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 12);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "操作";
            // 
            // 操作结束时间textBox
            // 
            this.操作结束时间textBox.Location = new System.Drawing.Point(498, 46);
            this.操作结束时间textBox.Name = "操作结束时间textBox";
            this.操作结束时间textBox.Size = new System.Drawing.Size(100, 21);
            this.操作结束时间textBox.TabIndex = 28;
            // 
            // 操作开始时间textBox
            // 
            this.操作开始时间textBox.Location = new System.Drawing.Point(369, 46);
            this.操作开始时间textBox.Name = "操作开始时间textBox";
            this.操作开始时间textBox.Size = new System.Drawing.Size(100, 21);
            this.操作开始时间textBox.TabIndex = 27;
            // 
            // 操作用户textBox
            // 
            this.操作用户textBox.Location = new System.Drawing.Point(233, 46);
            this.操作用户textBox.Name = "操作用户textBox";
            this.操作用户textBox.Size = new System.Drawing.Size(100, 21);
            this.操作用户textBox.TabIndex = 25;
            this.操作用户textBox.Enter += new System.EventHandler(this.操作用户textBox_Enter);
            // 
            // 复位Button
            // 
            this.复位Button.Location = new System.Drawing.Point(44, 399);
            this.复位Button.Name = "复位Button";
            this.复位Button.Size = new System.Drawing.Size(75, 23);
            this.复位Button.TabIndex = 23;
            this.复位Button.Text = "复位";
            this.复位Button.UseVisualStyleBackColor = true;
            this.复位Button.Click += new System.EventHandler(this.复位Button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(169, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(584, 255);
            this.dataGridView1.TabIndex = 22;
            // 
            // 操作textBox
            // 
            this.操作textBox.Location = new System.Drawing.Point(92, 46);
            this.操作textBox.Name = "操作textBox";
            this.操作textBox.Size = new System.Drawing.Size(100, 21);
            this.操作textBox.TabIndex = 42;
            this.操作textBox.Enter += new System.EventHandler(this.操作textBox_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "label7";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(44, 114);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(124, 256);
            this.listBox2.TabIndex = 46;
            this.listBox2.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
            // 
            // 入库历史查询窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.操作textBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.查询button);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.操作结束时间textBox);
            this.Controls.Add(this.操作开始时间textBox);
            this.Controls.Add(this.操作用户textBox);
            this.Controls.Add(this.复位Button);
            this.Controls.Add(this.dataGridView1);
            this.Name = "入库历史查询窗口";
            this.Text = "入库历史查询窗口";
            this.Load += new System.EventHandler(this.入库历史查询窗口_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button 查询button;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox 操作结束时间textBox;
        private System.Windows.Forms.TextBox 操作开始时间textBox;
        private System.Windows.Forms.TextBox 操作用户textBox;
        private System.Windows.Forms.Button 复位Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox 操作textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox2;
    }
}