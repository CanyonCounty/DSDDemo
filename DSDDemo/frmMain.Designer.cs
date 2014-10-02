﻿namespace DSDDemo
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
            this.label2 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMain = new DSDDemo.BetterPanel();
            this.buttonShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
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
            this.permitList.Location = new System.Drawing.Point(82, 10);
            this.permitList.Name = "permitList";
            this.permitList.Size = new System.Drawing.Size(200, 21);
            this.permitList.Sorted = true;
            this.permitList.TabIndex = 1;
            this.permitList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Count:";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Enabled = false;
            this.searchBox.Location = new System.Drawing.Point(280, 55);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(96, 20);
            this.searchBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(377, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoScroll = true;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(12, 81);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(389, 173);
            this.panelMain.TabIndex = 0;
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(16, 48);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(106, 23);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "Show All";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 266);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.permitList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMain);
            this.Name = "frmMain";
            this.Text = "Data Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSDDemo.BetterPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox permitList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonShow;
    }
}
