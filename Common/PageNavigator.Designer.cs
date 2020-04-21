namespace Common
{
    partial class PageNavigator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageNavigator));
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LastBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.UpBtn = new System.Windows.Forms.Button();
            this.FristBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PageNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new Common.textbox1(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblpagecount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Location = new System.Drawing.Point(964, 5);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(72, 33);
            this.ReturnBtn.TabIndex = 19;
            this.ReturnBtn.Text = "跳转";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(767, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "跳转到：";
            // 
            // LastBtn
            // 
            this.LastBtn.Image = ((System.Drawing.Image)(resources.GetObject("LastBtn.Image")));
            this.LastBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LastBtn.Location = new System.Drawing.Point(491, 3);
            this.LastBtn.Name = "LastBtn";
            this.LastBtn.Size = new System.Drawing.Size(88, 36);
            this.LastBtn.TabIndex = 16;
            this.LastBtn.Text = "最后页";
            this.LastBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LastBtn.UseVisualStyleBackColor = true;
            this.LastBtn.Click += new System.EventHandler(this.LastBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Image = ((System.Drawing.Image)(resources.GetObject("NextBtn.Image")));
            this.NextBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextBtn.Location = new System.Drawing.Point(377, 3);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(88, 36);
            this.NextBtn.TabIndex = 15;
            this.NextBtn.Text = "下一页";
            this.NextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // UpBtn
            // 
            this.UpBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpBtn.Image")));
            this.UpBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpBtn.Location = new System.Drawing.Point(265, 3);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(88, 36);
            this.UpBtn.TabIndex = 14;
            this.UpBtn.Text = "上一页";
            this.UpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // FristBtn
            // 
            this.FristBtn.Image = ((System.Drawing.Image)(resources.GetObject("FristBtn.Image")));
            this.FristBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FristBtn.Location = new System.Drawing.Point(155, 3);
            this.FristBtn.Name = "FristBtn";
            this.FristBtn.Size = new System.Drawing.Size(89, 36);
            this.FristBtn.TabIndex = 13;
            this.FristBtn.Text = "第一页";
            this.FristBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FristBtn.UseVisualStyleBackColor = true;
            this.FristBtn.Click += new System.EventHandler(this.FristBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(120, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "页";
            // 
            // PageNum
            // 
            this.PageNum.AutoSize = true;
            this.PageNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PageNum.ForeColor = System.Drawing.Color.Red;
            this.PageNum.Location = new System.Drawing.Point(95, 11);
            this.PageNum.Name = "PageNum";
            this.PageNum.Size = new System.Drawing.Size(19, 20);
            this.PageNum.TabIndex = 11;
            this.PageNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "当前页数：";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(847, 10);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 25);
            this.txtNum.TabIndex = 20;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(585, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "共有页数：";
            // 
            // lblpagecount
            // 
            this.lblpagecount.AutoSize = true;
            this.lblpagecount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpagecount.ForeColor = System.Drawing.Color.Red;
            this.lblpagecount.Location = new System.Drawing.Point(691, 11);
            this.lblpagecount.Name = "lblpagecount";
            this.lblpagecount.Size = new System.Drawing.Size(19, 20);
            this.lblpagecount.TabIndex = 22;
            this.lblpagecount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(716, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "页";
            // 
            // PageNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblpagecount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LastBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.UpBtn);
            this.Controls.Add(this.FristBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PageNum);
            this.Controls.Add(this.label1);
            this.Name = "PageNavigator";
            this.Size = new System.Drawing.Size(1043, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LastBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button FristBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PageNum;
        private System.Windows.Forms.Label label1;
        private textbox1 txtNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpagecount;
        private System.Windows.Forms.Label label6;
    }
}
