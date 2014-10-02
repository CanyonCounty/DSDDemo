using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace DSDDemo
{
    class SearchField
    {
        BetterPanel panel;
        TextBox search;
        Color defColor;
        Color highlite = Color.Cornsilk;

        public SearchField(BetterPanel panel, TextBox search)
        {
            this.panel = panel;
            this.search = search;
            defColor = panel.BackColor;

            // EVENTS
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.panel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel_ControlChanged);
            this.panel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel_ControlChanged);
        }
        
        private void panel_ControlChanged(object sender, ControlEventArgs e)
        {
            search.Enabled = panel.Controls.Count > 0;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {            
            // Clear all the old ones first
            panel.Visible = false;
            foreach (Control control in panel.Controls)
            {
                control.BackColor = defColor;
                control.Visible = false;
            }
            panel.Visible = true;

            string text = (sender as TextBox).Text;
            //Text = panelMain.Controls.Count.ToString();
            if (!String.IsNullOrEmpty(text))
            {
                ShowControl(text, true);
            }
            else
            {
                panel.Visible = false;
                foreach (Control control in panel.Controls)
                {
                    control.BackColor = defColor;
                    control.Visible = true;
                }
                panel.Visible = true;
                //ShowControl(first.FieldName, false);
                // TODO: Fix this!
                //MessageBox.Show("First? " + panel.Controls[panel.Controls.Count -1].Name);
                
                panel.ScrollControlIntoView(panel.Controls[panel.Controls.Count - 1]);
            }
        }
        
        private void ShowControl(string text, bool color)
        {
            //Control[] ctl = panelMain.Controls.Find(text, false);
            Control[] ctl = panel.FindControls(text);
            //MessageBox.Show(ctl.ToString());
            //panelMain.ScrollControlIntoView(ctl);
            foreach (Control control in ctl)
            {
                //MessageBox.Show(control.Name);
                if (color == true) control.BackColor = highlite;

                control.Visible = true;
                //control.Focus();
                panel.ScrollControlIntoView(control);
            }
        }

        public Color Highlight { 
            get {return highlite;}
            set { highlite = value; }
        }

        public void Clear()
        {
            search.Text = "";
        }
    }
}
