using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace DSDDemo
{
    enum SearchFieldMode
    {
        Contains,
        Equals,
        StartsWith
    }

    class SearchField
    {
        private BetterPanel panel;
        private TextBox search;
        private Color defColor;
        private Color highlite = Color.Cornsilk;
        private string searchText = "";

        public SearchFieldMode Mode { get; set; }

        public SearchField(BetterPanel panel, TextBox search)
        {
            this.panel = panel;
            this.search = search;
            defColor = panel.BackColor;
            Mode = SearchFieldMode.Contains;

            // EVENTS
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.panel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel_ControlChanged);
            this.panel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel_ControlChanged);
        }
        
        private void panel_ControlChanged(object sender, ControlEventArgs e)
        {
            search.Enabled = panel.Controls.Count > 0;
        }

        //private void search_TextChangedOld(object sender, EventArgs e)
        //{            
        //    // Clear all the old ones first
        //    panel.Visible = false;
        //    foreach (Control control in panel.Controls)
        //    {
        //        control.BackColor = defColor;
        //        control.Visible = false;
        //    }

        //    string text = (sender as TextBox).Text;
        //    //Text = panelMain.Controls.Count.ToString();
        //    if (!String.IsNullOrEmpty(text))
        //    {
        //        ShowControl(text, true);
        //    }
        //    else
        //    {
        //        //panel.Visible = false;
        //        foreach (Control control in panel.Controls)
        //        {
        //            control.BackColor = defColor;
        //            control.Visible = true;
        //        }
        //        //panel.Visible = true;
        //        //ShowControl(first.FieldName, false);
        //        //MessageBox.Show("First? " + panel.Controls[panel.Controls.Count -1].Name);
        //        if (panel.Controls.Count > 0)
        //            panel.ScrollControlIntoView(panel.Controls[panel.Controls.Count - 1]);
        //    }

        //    panel.Visible = true;
        //}

        private void search_TextChanged(object sender, EventArgs e)
        {
            //string text = (sender as TextBox).Text;
            searchText = search.Text;
            panel.Visible = false;
            if (!String.IsNullOrEmpty(searchText))
            {
                // Filter
#if NEW
                foreach (OutlookPanelEx subpanel in panel.Controls)
                {
                    foreach (FieldPanel control in subpanel.Controls)
#else
                    foreach(FieldPanel control in panel.Controls)
#endif
                    {
                        if (SearchCompare(control.Field))
                        {
                            control.BackColor = highlite;
                            control.Visible = true;
                        }
                        else
                        {
                            control.BackColor = defColor;
                            control.Visible = false;
                        }
                    }
#if NEW
                }
#endif
            }
            else
            {
                // Show All
#if NEW
                foreach (OutlookPanelEx subpanel in panel.Controls)
                {
                    foreach (FieldPanel control in subpanel.Controls)
#else
                    foreach (FieldPanel control in panel.Controls)
#endif
                    {
                        control.BackColor = defColor;
                        control.Visible = true;
                    }
#if NEW
                }
#endif
            }
            panel.Visible = true;
        }

        // Make compare modes - Equals - Exact - Contains - etc.
        // compare to additional meta data, tags?
        private bool SearchCompare(Field compare)
        {
            bool res = false;
            switch (Mode)
            {
                case SearchFieldMode.Contains:
                    res = compare.DisplayLabel.ToUpper().Contains(searchText.ToUpper());
                    break;
                case SearchFieldMode.Equals:
                    res = compare.DisplayLabel.ToUpper().Equals(searchText.ToUpper());
                    break;
                case SearchFieldMode.StartsWith:
                    res = compare.DisplayLabel.ToUpper().StartsWith(searchText.ToUpper());
                    break;
            }
            return res;
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
