namespace BackstageManagementOfSupermarket.AdminFrm
{
    partial class FrmLogCheck
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogCheck));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.starttime = new System.Windows.Forms.DateTimePicker();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btncheck = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btncancle = new System.Windows.Forms.Button();
            this.txtwhere = new Common.textbox1(this.components);
            this.pageNav = new Common.PageNavigator();
            this.LoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginId,
            this.UserName,
            this.LogServer,
            this.LoginTime,
            this.ExitTime});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 330);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询区间：";
            // 
            // starttime
            // 
            this.starttime.Location = new System.Drawing.Point(108, 29);
            this.starttime.Name = "starttime";
            this.starttime.Size = new System.Drawing.Size(160, 25);
            this.starttime.TabIndex = 3;
            // 
            // endtime
            // 
            this.endtime.Location = new System.Drawing.Point(310, 29);
            this.endtime.Name = "endtime";
            this.endtime.Size = new System.Drawing.Size(160, 25);
            this.endtime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(274, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "至";
            // 
            // btncheck
            // 
            this.btncheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btncheck.Image = ((System.Drawing.Image)(resources.GetObject("btncheck.Image")));
            this.btncheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncheck.Location = new System.Drawing.Point(843, 24);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(97, 32);
            this.btncheck.TabIndex = 6;
            this.btncheck.Text = "开始查询";
            this.btncheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(616, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "其他条件：";
            // 
            // btncancle
            // 
            this.btncancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btncancle.Image = ((System.Drawing.Image)(resources.GetObject("btncancle.Image")));
            this.btncancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancle.Location = new System.Drawing.Point(962, 24);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(95, 32);
            this.btncancle.TabIndex = 9;
            this.btncancle.Text = "取消查询";
            this.btncancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // txtwhere
            // 
            this.txtwhere.Location = new System.Drawing.Point(706, 26);
            this.txtwhere.Name = "txtwhere";
            this.txtwhere.Size = new System.Drawing.Size(125, 25);
            this.txtwhere.TabIndex = 8;
            this.txtwhere.Tag = "1";
            this.txtwhere.TextChanged += new System.EventHandler(this.txtwhere_TextChanged);
            // 
            // pageNav
            // 
            this.pageNav.CurrentPage = 1;
            this.pageNav.Location = new System.Drawing.Point(8, 421);
            this.pageNav.Name = "pageNav";
            this.pageNav.PageSize = 0;
            this.pageNav.ProcName = null;
            this.pageNav.RecordCount = 0;
            this.pageNav.Size = new System.Drawing.Size(1049, 45);
            this.pageNav.SortType = Common.SortType.ASC;
            this.pageNav.TabIndex = 1;
            this.pageNav.TableName = null;
            // 
            // LoginId
            // 
            this.LoginId.DataPropertyName = "Loginid";
            this.LoginId.HeaderText = "登陆账号";
            this.LoginId.MinimumWidth = 6;
            this.LoginId.Name = "LoginId";
            this.LoginId.ReadOnly = true;
            this.LoginId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LoginId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginId.Width = 140;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "SPName";
            this.UserName.HeaderText = "用户名称";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserName.Width = 150;
            // 
            // LogServer
            // 
            this.LogServer.DataPropertyName = "ServerName";
            this.LogServer.HeaderText = "登陆服务器";
            this.LogServer.MinimumWidth = 6;
            this.LogServer.Name = "LogServer";
            this.LogServer.ReadOnly = true;
            this.LogServer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogServer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LogServer.Width = 180;
            // 
            // LoginTime
            // 
            this.LoginTime.DataPropertyName = "LoginTime";
            this.LoginTime.HeaderText = "登陆时间";
            this.LoginTime.MinimumWidth = 6;
            this.LoginTime.Name = "LoginTime";
            this.LoginTime.ReadOnly = true;
            this.LoginTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LoginTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginTime.Width = 260;
            // 
            // ExitTime
            // 
            this.ExitTime.DataPropertyName = "ExitTime";
            this.ExitTime.HeaderText = "退出时间";
            this.ExitTime.MinimumWidth = 6;
            this.ExitTime.Name = "ExitTime";
            this.ExitTime.ReadOnly = true;
            this.ExitTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExitTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExitTime.Width = 260;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(476, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "是否按区间查询";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FrmLogCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1069, 478);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.txtwhere);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btncheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endtime);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pageNav);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Common.PageNavigator pageNav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker starttime;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Label label3;
        private Common.textbox1 txtwhere;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExitTime;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}