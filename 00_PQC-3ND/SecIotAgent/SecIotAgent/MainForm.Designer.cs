namespace SecIotAgent
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl2 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.TotalLogmaterialListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.NetWorkLogmaterialListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.DeviceLogmaterialListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.EtcLogmaterialListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.materialTabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1038, 617);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.materialLabel1);
            this.tabPage1.ImageKey = "home.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1030, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 3);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(122, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Home main page";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.materialButton1);
            this.tabPage2.Controls.Add(this.materialTextBox1);
            this.tabPage2.Controls.Add(this.materialLabel5);
            this.tabPage2.Controls.Add(this.materialLabel2);
            this.tabPage2.ImageKey = "technical-support.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1030, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialButton1
            // 
            this.materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(800, 493);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton1.Size = new System.Drawing.Size(77, 36);
            this.materialButton1.TabIndex = 4;
            this.materialButton1.Text = "Update";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(185, 46);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(558, 50);
            this.materialTextBox1.TabIndex = 3;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(21, 62);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(158, 19);
            this.materialLabel5.TabIndex = 2;
            this.materialLabel5.Text = "Run WebBrowser URL:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(6, 3);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(56, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Settimg";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.materialTabSelector1);
            this.tabPage3.Controls.Add(this.materialTabControl2);
            this.tabPage3.Controls.Add(this.materialLabel3);
            this.tabPage3.ImageKey = "log.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1030, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log view";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl2;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(15, 141);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(995, 28);
            this.materialTabSelector1.TabIndex = 2;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl2
            // 
            this.materialTabControl2.Controls.Add(this.tabPage5);
            this.materialTabControl2.Controls.Add(this.tabPage6);
            this.materialTabControl2.Controls.Add(this.tabPage7);
            this.materialTabControl2.Controls.Add(this.tabPage8);
            this.materialTabControl2.Depth = 0;
            this.materialTabControl2.Location = new System.Drawing.Point(12, 175);
            this.materialTabControl2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl2.Multiline = true;
            this.materialTabControl2.Name = "materialTabControl2";
            this.materialTabControl2.SelectedIndex = 0;
            this.materialTabControl2.Size = new System.Drawing.Size(998, 367);
            this.materialTabControl2.TabIndex = 1;
            this.materialTabControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.materialTabControl2_MouseClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.TotalLogmaterialListView);
            this.tabPage5.ImageKey = "(없음)";
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(990, 334);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Total";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // TotalLogmaterialListView
            // 
            this.TotalLogmaterialListView.AutoSizeTable = false;
            this.TotalLogmaterialListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TotalLogmaterialListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalLogmaterialListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.TotalLogmaterialListView.Depth = 0;
            this.TotalLogmaterialListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalLogmaterialListView.FullRowSelect = true;
            this.TotalLogmaterialListView.Location = new System.Drawing.Point(3, 3);
            this.TotalLogmaterialListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.TotalLogmaterialListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TotalLogmaterialListView.MouseState = MaterialSkin.MouseState.OUT;
            this.TotalLogmaterialListView.Name = "TotalLogmaterialListView";
            this.TotalLogmaterialListView.OwnerDraw = true;
            this.TotalLogmaterialListView.Size = new System.Drawing.Size(984, 328);
            this.TotalLogmaterialListView.TabIndex = 0;
            this.TotalLogmaterialListView.UseCompatibleStateImageBehavior = false;
            this.TotalLogmaterialListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Log Level";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Function";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Logs";
            this.columnHeader4.Width = 300;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.NetWorkLogmaterialListView);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(990, 334);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "WebSocket";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // NetWorkLogmaterialListView
            // 
            this.NetWorkLogmaterialListView.AutoSizeTable = false;
            this.NetWorkLogmaterialListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NetWorkLogmaterialListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NetWorkLogmaterialListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader14});
            this.NetWorkLogmaterialListView.Depth = 0;
            this.NetWorkLogmaterialListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetWorkLogmaterialListView.FullRowSelect = true;
            this.NetWorkLogmaterialListView.Location = new System.Drawing.Point(3, 3);
            this.NetWorkLogmaterialListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.NetWorkLogmaterialListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NetWorkLogmaterialListView.MouseState = MaterialSkin.MouseState.OUT;
            this.NetWorkLogmaterialListView.Name = "NetWorkLogmaterialListView";
            this.NetWorkLogmaterialListView.OwnerDraw = true;
            this.NetWorkLogmaterialListView.Size = new System.Drawing.Size(984, 328);
            this.NetWorkLogmaterialListView.TabIndex = 1;
            this.NetWorkLogmaterialListView.UseCompatibleStateImageBehavior = false;
            this.NetWorkLogmaterialListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Log Level";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Function";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Logs";
            this.columnHeader14.Width = 300;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.DeviceLogmaterialListView);
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(990, 334);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Device";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // DeviceLogmaterialListView
            // 
            this.DeviceLogmaterialListView.AutoSizeTable = false;
            this.DeviceLogmaterialListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DeviceLogmaterialListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceLogmaterialListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader15,
            this.columnHeader9});
            this.DeviceLogmaterialListView.Depth = 0;
            this.DeviceLogmaterialListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceLogmaterialListView.FullRowSelect = true;
            this.DeviceLogmaterialListView.Location = new System.Drawing.Point(0, 0);
            this.DeviceLogmaterialListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.DeviceLogmaterialListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DeviceLogmaterialListView.MouseState = MaterialSkin.MouseState.OUT;
            this.DeviceLogmaterialListView.Name = "DeviceLogmaterialListView";
            this.DeviceLogmaterialListView.OwnerDraw = true;
            this.DeviceLogmaterialListView.Size = new System.Drawing.Size(990, 334);
            this.DeviceLogmaterialListView.TabIndex = 2;
            this.DeviceLogmaterialListView.UseCompatibleStateImageBehavior = false;
            this.DeviceLogmaterialListView.View = System.Windows.Forms.View.Details;
            this.DeviceLogmaterialListView.SelectedIndexChanged += new System.EventHandler(this.DeviceLogmaterialListView_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Log Level";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Function";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Logs";
            this.columnHeader9.Width = 300;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.EtcLogmaterialListView);
            this.tabPage8.Location = new System.Drawing.Point(4, 29);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(990, 334);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Etc";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // EtcLogmaterialListView
            // 
            this.EtcLogmaterialListView.AutoSizeTable = false;
            this.EtcLogmaterialListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.EtcLogmaterialListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EtcLogmaterialListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader16,
            this.columnHeader13});
            this.EtcLogmaterialListView.Depth = 0;
            this.EtcLogmaterialListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EtcLogmaterialListView.FullRowSelect = true;
            this.EtcLogmaterialListView.Location = new System.Drawing.Point(0, 0);
            this.EtcLogmaterialListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.EtcLogmaterialListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.EtcLogmaterialListView.MouseState = MaterialSkin.MouseState.OUT;
            this.EtcLogmaterialListView.Name = "EtcLogmaterialListView";
            this.EtcLogmaterialListView.OwnerDraw = true;
            this.EtcLogmaterialListView.Size = new System.Drawing.Size(990, 334);
            this.EtcLogmaterialListView.TabIndex = 2;
            this.EtcLogmaterialListView.UseCompatibleStateImageBehavior = false;
            this.EtcLogmaterialListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Date";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Log Level";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Function";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Logs";
            this.columnHeader13.Width = 300;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(3, 4);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(66, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Log View";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.materialLabel4);
            this.tabPage4.ImageKey = "add-user.png";
            this.tabPage4.Location = new System.Drawing.Point(4, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1030, 574);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Add User";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(3, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(64, 19);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Add User";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chat.png");
            this.imageList1.Images.SetKeyName(1, "communities.png");
            this.imageList1.Images.SetKeyName(2, "contact-form.png");
            this.imageList1.Images.SetKeyName(3, "online-support.png");
            this.imageList1.Images.SetKeyName(4, "responsive.png");
            this.imageList1.Images.SetKeyName(5, "technical-support.png");
            this.imageList1.Images.SetKeyName(6, "add-user.png");
            this.imageList1.Images.SetKeyName(7, "home.png");
            this.imageList1.Images.SetKeyName(8, "log.png");
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(870, 512);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.materialTabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl2;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private MaterialSkin.Controls.MaterialListView TotalLogmaterialListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private MaterialSkin.Controls.MaterialListView EtcLogmaterialListView;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private MaterialSkin.Controls.MaterialListView NetWorkLogmaterialListView;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader14;
        private MaterialSkin.Controls.MaterialListView DeviceLogmaterialListView;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}