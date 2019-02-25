namespace 仓库管理
{
    partial class 地点管理窗口
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
            this.dataManager1 = new 仓库管理.DataManager();
            this.SuspendLayout();
            // 
            // dataManager1
            // 
            this.dataManager1.DisplayColumns = null;
            this.dataManager1.Location = new System.Drawing.Point(12, 12);
            this.dataManager1.Name = "dataManager1";
            this.dataManager1.Size = new System.Drawing.Size(654, 432);
            this.dataManager1.TabIndex = 0;
            this.dataManager1.TableName = null;
            // 
            // 地点管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 450);
            this.Controls.Add(this.dataManager1);
            this.Name = "地点管理窗口";
            this.Text = "地点管理窗口";
            this.Load += new System.EventHandler(this.地点管理窗口_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataManager dataManager1;
    }
}