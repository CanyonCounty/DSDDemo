using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using DSDDemo.Permits;

namespace DSDDemo
{
    public partial class frmMain : Form, IMessageFilter
    {
        SearchField search;
        AssemblyFilter<BasePermit> af;
        DrawPermitPanel dp;
        FilterField fieldFilter;

        public frmMain()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasePermit permit = af.GetItem(permitList.SelectedItem);
            //if (dp != null) dp.Dispose();
            dp = new DrawPermitPanel(panelMain, permit);
            fieldFilter.Panel = dp;
            fieldFilter.Filtered = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (buttonEdit.Text == "Edit Shown")
            {
                buttonEdit.Text = "Done";
                fieldFilter.Filtered = false; // show everything
            }
            else
            {
                buttonEdit.Text = "Edit Shown";
            }
            
#if NEW
            foreach (OutlookPanelEx panel in panelMain.Controls)
            {
                foreach (FieldPanel ctl in panel.Controls)
                {
#else
                foreach (Control ctl in panelMain.Controls)
#endif
                    {
                        if (ctl is FieldPanel)
                            (ctl as FieldPanel).ToggleCheckBox();
                    }
#if NEW
                }
            }
#endif
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fieldFilter = new FilterField(buttonShow, searchTextBox1);
            af = new AssemblyFilter<BasePermit>(permitList);
            // Moved from constructor to avoid null below
            // SelectedIndexChanged was firing before constructor completed
            af.Bind();

#if NEW
                panelMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
#endif

            //search = new SearchField(panelMain, searchBox);
            search = new SearchField(panelMain, searchTextBox1);

            // This is only allowed in code since you may want to populate it via
            // a code enum, database entries, etc.
            // That and I didn't want to create a designer
            searchTextBox1.AddMenuItem("Contains", true);
            searchTextBox1.AddMenuItem("Exact");
            searchTextBox1.AddMenuItem("Starts With");

            //System.Diagnostics.FileVersionInfo finfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            //this.Text += " " + finfo.FileVersion.ToString();
            this.Text += " " + Application.ProductVersion.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Find Control based on nearest Display Label
            // Currently it only finds the first one, and not any others
            // I don't think this is an issue, the user can filter
            // I'll be finding an exact one for validation
            //dp.FindField("Project Type");

            searchTextBox1.Enabled = !searchTextBox1.Enabled;
        }

        private void searchTextBox1_MenuItemClicked(object sender, EventArgs e, string menuText)
        {
            switch (menuText)
            {
                case "Contains":
                    search.Mode = SearchFieldMode.Contains;
                    break;
                case "Exact":
                    search.Mode = SearchFieldMode.Equals;
                    break;
                case "Starts With":
                    search.Mode = SearchFieldMode.StartsWith;
                    break;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool broke = false;
#if NEW
            foreach(OutlookPanelEx panelOwner in panelMain.Controls)
            {
                foreach(FieldPanel panel in panelOwner.Controls)
#else
            foreach (FieldPanel panel in panelMain.Controls)
#endif
            {
                if (broke) break; // Sloppy, but works 
                broke = false;
                if (panel.IsDirty)
                {
                    MessageBox.Show(panel.Field.DisplayLabel + " has been changed");
                    panel.Visible = true; // make sure it's shown
                    panel.Focus();
                    panel.Control.Focus();
                    e.Cancel = true;
                    broke = true;
                    break;
                }
                
            }
#if NEW
                }
#endif
                
        }

        //Externs
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        //Handle MouseWheel
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x20a)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;
        }
    }



}