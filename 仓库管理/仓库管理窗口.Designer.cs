namespace 仓库管理
{
    partial class 仓库管理窗口
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
            this.管理货架btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataManager1
            // 
            this.dataManager1.DisplayColumns = null;
            this.dataManager1.EnablePictureManagement = false;
            this.dataManager1.Location = new System.Drawing.Point(12, 12);
            this.dataManager1.Name = "dataManager1";
            this.dataManager1.PrimaryKey = null;
            this.dataManager1.Size = new System.Drawing.Size(718, 432);
            this.dataManager1.TabIndex = 0;
            this.dataManager1.TableName = null;
            this.dataManager1.UniqueColumnName = "";
            this.dataManager1.WhereClause = null;
            // 
            // 管理货架btn
            // 
            this.管理货架btn.Location = new System.Drawing.Point(621, 357);
            this.管理货架btn.Name = "管理货架btn";
            this.管理货架btn.Size = new System.Drawing.Size(75, 60);
            this.管理货架btn.TabIndex = 30;
            this.管理货架btn.Text = "管理货架";
            this.管理货架btn.UseVisualStyleBackColor = true;
            this.管理货架btn.Click += new System.EventHandler(this.管理货架btn_Click);
            // 
            // 仓库管理窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.管理货架btn);
            this.Controls.Add(this.dataManager1);
            this.Name = "仓库管理窗口";
            this.Text = "仓库管理窗口";
            this.Load += new System.EventHandler(this.仓库管理窗口_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataManager dataManager1;
        private System.Windows.Forms.Button 管理货架btn;
    }
}