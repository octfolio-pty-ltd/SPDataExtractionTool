namespace SharepointDataImport
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.gbSharepoint = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDomain = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.gbLists = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnGetListInfo = new System.Windows.Forms.Button();
			this.lbAvailableLists = new System.Windows.Forms.ListBox();
			this.gbFields = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblSelectedList = new System.Windows.Forms.Label();
			this.btnExtractInfo = new System.Windows.Forms.Button();
			this.lbFields = new System.Windows.Forms.ListBox();
			this.bgWorker = new System.ComponentModel.BackgroundWorker();
			this.pbBar = new System.Windows.Forms.ProgressBar();
			this.chkIncludeFiles = new System.Windows.Forms.CheckBox();
			this.gbSharepoint.SuspendLayout();
			this.gbLists.SuspendLayout();
			this.gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbSharepoint
			// 
			this.gbSharepoint.Controls.Add(this.label5);
			this.gbSharepoint.Controls.Add(this.btnConnect);
			this.gbSharepoint.Controls.Add(this.txtServer);
			this.gbSharepoint.Controls.Add(this.label4);
			this.gbSharepoint.Controls.Add(this.label1);
			this.gbSharepoint.Controls.Add(this.label2);
			this.gbSharepoint.Controls.Add(this.label3);
			this.gbSharepoint.Controls.Add(this.txtDomain);
			this.gbSharepoint.Controls.Add(this.txtUser);
			this.gbSharepoint.Controls.Add(this.txtPassword);
			this.gbSharepoint.Location = new System.Drawing.Point(12, 12);
			this.gbSharepoint.Name = "gbSharepoint";
			this.gbSharepoint.Size = new System.Drawing.Size(166, 396);
			this.gbSharepoint.TabIndex = 2;
			this.gbSharepoint.TabStop = false;
			this.gbSharepoint.Text = "Sharepoint parameters";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(4, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(161, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "1. Provide connection info.";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(85, 364);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(9, 75);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(151, 20);
			this.txtServer.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "URL Site";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Domain";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 157);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "User";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Password";
			// 
			// txtDomain
			// 
			this.txtDomain.Location = new System.Drawing.Point(9, 124);
			this.txtDomain.Name = "txtDomain";
			this.txtDomain.Size = new System.Drawing.Size(151, 20);
			this.txtDomain.TabIndex = 6;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(9, 173);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(151, 20);
			this.txtUser.TabIndex = 7;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(9, 224);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(151, 20);
			this.txtPassword.TabIndex = 8;
			// 
			// gbLists
			// 
			this.gbLists.Controls.Add(this.label6);
			this.gbLists.Controls.Add(this.btnGetListInfo);
			this.gbLists.Controls.Add(this.lbAvailableLists);
			this.gbLists.Location = new System.Drawing.Point(184, 12);
			this.gbLists.Name = "gbLists";
			this.gbLists.Size = new System.Drawing.Size(356, 396);
			this.gbLists.TabIndex = 3;
			this.gbLists.TabStop = false;
			this.gbLists.Text = "Available Lists";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(135, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "2. Select list to import.";
			// 
			// btnGetListInfo
			// 
			this.btnGetListInfo.Location = new System.Drawing.Point(275, 364);
			this.btnGetListInfo.Name = "btnGetListInfo";
			this.btnGetListInfo.Size = new System.Drawing.Size(75, 23);
			this.btnGetListInfo.TabIndex = 11;
			this.btnGetListInfo.Text = "Select";
			this.btnGetListInfo.UseVisualStyleBackColor = true;
			this.btnGetListInfo.Click += new System.EventHandler(this.btnGetListInfo_Click);
			// 
			// lbAvailableLists
			// 
			this.lbAvailableLists.FormattingEnabled = true;
			this.lbAvailableLists.Location = new System.Drawing.Point(6, 45);
			this.lbAvailableLists.Name = "lbAvailableLists";
			this.lbAvailableLists.Size = new System.Drawing.Size(344, 277);
			this.lbAvailableLists.TabIndex = 4;
			// 
			// gbFields
			// 
			this.gbFields.Controls.Add(this.chkIncludeFiles);
			this.gbFields.Controls.Add(this.label8);
			this.gbFields.Controls.Add(this.label7);
			this.gbFields.Controls.Add(this.lblSelectedList);
			this.gbFields.Controls.Add(this.btnExtractInfo);
			this.gbFields.Controls.Add(this.lbFields);
			this.gbFields.Location = new System.Drawing.Point(546, 12);
			this.gbFields.Name = "gbFields";
			this.gbFields.Size = new System.Drawing.Size(379, 396);
			this.gbFields.TabIndex = 4;
			this.gbFields.TabStop = false;
			this.gbFields.Text = "Available Fields";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(3, 348);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(371, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "* Select \'Encoded Absolute URL\' to include files from \'Libraries\'.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(3, 325);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(310, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "* Select \'Attachments\' field to download attachments.";
			// 
			// lblSelectedList
			// 
			this.lblSelectedList.AutoSize = true;
			this.lblSelectedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSelectedList.Location = new System.Drawing.Point(6, 29);
			this.lblSelectedList.Name = "lblSelectedList";
			this.lblSelectedList.Size = new System.Drawing.Size(172, 13);
			this.lblSelectedList.TabIndex = 14;
			this.lblSelectedList.Text = "3. Select columns to include.";
			// 
			// btnExtractInfo
			// 
			this.btnExtractInfo.Location = new System.Drawing.Point(298, 364);
			this.btnExtractInfo.Name = "btnExtractInfo";
			this.btnExtractInfo.Size = new System.Drawing.Size(75, 23);
			this.btnExtractInfo.TabIndex = 1;
			this.btnExtractInfo.Text = "Extract info";
			this.btnExtractInfo.UseVisualStyleBackColor = true;
			this.btnExtractInfo.Click += new System.EventHandler(this.btnExtractInfo_Click);
			// 
			// lbFields
			// 
			this.lbFields.FormattingEnabled = true;
			this.lbFields.Location = new System.Drawing.Point(6, 45);
			this.lbFields.Name = "lbFields";
			this.lbFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbFields.Size = new System.Drawing.Size(367, 277);
			this.lbFields.TabIndex = 0;
			// 
			// bgWorker
			// 
			this.bgWorker.WorkerReportsProgress = true;
			this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
			this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorker_ProgressChanged);
			this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
			// 
			// pbBar
			// 
			this.pbBar.Location = new System.Drawing.Point(12, 414);
			this.pbBar.Name = "pbBar";
			this.pbBar.Size = new System.Drawing.Size(913, 23);
			this.pbBar.TabIndex = 5;
			// 
			// chkIncludeFiles
			// 
			this.chkIncludeFiles.AutoSize = true;
			this.chkIncludeFiles.Checked = true;
			this.chkIncludeFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeFiles.Location = new System.Drawing.Point(9, 368);
			this.chkIncludeFiles.Name = "chkIncludeFiles";
			this.chkIncludeFiles.Size = new System.Drawing.Size(149, 17);
			this.chkIncludeFiles.TabIndex = 13;
			this.chkIncludeFiles.Text = "Download files if selected.";
			this.chkIncludeFiles.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 446);
			this.Controls.Add(this.pbBar);
			this.Controls.Add(this.gbFields);
			this.Controls.Add(this.gbLists);
			this.Controls.Add(this.gbSharepoint);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sharepoint Data Extract Tool - OCT";
			this.gbSharepoint.ResumeLayout(false);
			this.gbSharepoint.PerformLayout();
			this.gbLists.ResumeLayout(false);
			this.gbLists.PerformLayout();
			this.gbFields.ResumeLayout(false);
			this.gbFields.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox gbSharepoint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDomain;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gbLists;
		private System.Windows.Forms.ListBox lbAvailableLists;
		private System.Windows.Forms.Button btnGetListInfo;
		private System.Windows.Forms.GroupBox gbFields;
		private System.Windows.Forms.Button btnExtractInfo;
		private System.Windows.Forms.ListBox lbFields;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblSelectedList;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pbBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkIncludeFiles;
    }
}

