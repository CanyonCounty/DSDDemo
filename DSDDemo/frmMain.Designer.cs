namespace DSDDemo
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.permitList = new System.Windows.Forms.ComboBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelMain = new DSDDemo.BetterPanel();
            this.searchTextBox1 = new DSDDemo.SearchTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Permit Type";
            // 
            // permitList
            // 
            this.permitList.DropDownWidth = 10;
            this.permitList.FormattingEnabled = true;
            this.permitList.Items.AddRange(new object[] {
            "Administrative Lot Split (LS)",
            "Appeal (AP)",
            "Building (BP)",
            "Canyon County Ordinance (OR)",
            "Comp Plan/Rezone (CPR)",
            "Conditional Rezone (CR)",
            "Conditional Use (CU)",
            "Conditional Use Revocation (CUR)",
            "Conditional Use Vacation (CUV)",
            "Demolition (DM)",
            "Development Permit (DP)",
            "Electrical (EL)",
            "ESA (EP)",
            "Excavating & Grading (EG)",
            "Home Business (HB)",
            "Home Occupation (HO)",
            "House Moving (HM)",
            "House Number (HN)",
            "Impact Area Agreement (IA)",
            "Mechanical (MC)",
            "Mineral Extract Short Term (MST)",
            "Parcel Inquiry (PI)",
            "Planned Unit Development (PU)",
            "Plat Vacation (PV)",
            "Private Road Name Change (PRNC)",
            "Property Line Adjustment (PLA)",
            "Property Research (PR)",
            "Public Road Name Change (RNC)",
            "Request for Extension (RFE)",
            "Rezone (RZ)",
            "Road Name (Road)",
            "Short Plat (SP)",
            "Sign (SG)",
            "Sign Variance (SV)",
            "Street Vacation (VC)",
            "Subdivision (SD)",
            "Temporary Residence Permit (TP)",
            "Waivers/Irrigation Plan (WI)",
            "Zone Compliance (ZC)",
            "Zoning Variance (ZV)"});
            this.permitList.Location = new System.Drawing.Point(82, 9);
            this.permitList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.permitList.Name = "permitList";
            this.permitList.Size = new System.Drawing.Size(200, 21);
            this.permitList.Sorted = true;
            this.permitList.TabIndex = 1;
            this.permitList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(12, 52);
            this.buttonShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(106, 22);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "Show All";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(125, 52);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(102, 22);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "Edit Shown";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(288, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoScroll = true;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(12, 82);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(489, 263);
            this.panelMain.TabIndex = 0;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox1.Cue = " Search";
            this.searchTextBox1.Location = new System.Drawing.Point(380, 54);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(121, 21);
            this.searchTextBox1.TabIndex = 9;
            this.searchTextBox1.MenuItemClicked += new DSDDemo.SearchTextBox.MenuClickedEvent(this.searchTextBox1_MenuItemClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 356);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.permitList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.searchTextBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "Data Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSDDemo.BetterPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox permitList;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button button2;
        private DSDDemo.SearchTextBox searchTextBox1;
    }
}

