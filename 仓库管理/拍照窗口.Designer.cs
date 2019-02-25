namespace 仓库管理
{
    partial class 拍照窗口
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(拍照窗口));
            this.axLiteArrayCtrl1 = new AxLiteArrayCtrlLib.AxLiteArrayCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLiteArrayCtrl1
            // 
            this.axLiteArrayCtrl1.Enabled = true;
            this.axLiteArrayCtrl1.Location = new System.Drawing.Point(29, 12);
            this.axLiteArrayCtrl1.Name = "axLiteArrayCtrl1";
            this.axLiteArrayCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLiteArrayCtrl1.OcxState")));
            this.axLiteArrayCtrl1.Size = new System.Drawing.Size(390, 231);
            this.axLiteArrayCtrl1.TabIndex = 0;
            // 
            // 拍照窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axLiteArrayCtrl1);
            this.Name = "拍照窗口";
            this.Text = "拍照窗口";
            ((System.ComponentModel.ISupportInitialize)(this.axLiteArrayCtrl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxLiteArrayCtrlLib.AxLiteArrayCtrl axLiteArrayCtrl1;
    }
}