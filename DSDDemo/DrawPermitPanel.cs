using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSDDemo.Permits;

namespace DSDDemo
{
    // Hopefully this class can figure out the "right"
    // way to draw the permit fields on a panel
    class DrawPermitPanel
    {
        BetterPanel panel;
        BasePermit permit;
#if NEW        
        int curGroup = 0;
#endif

        public DrawPermitPanel(BetterPanel panel, BasePermit permit)
        {
            this.panel = panel;
            this.permit = permit;
            panel.AutoScroll = true;
            
            // Clear on create
            panel.Controls.Clear();
        }

        public void Draw(bool showAll)
        {
            panel.Visible = false;
            OutlookPanelEx own = null;

            //panel.Controls.Clear();  // only draw the items once
            if (panel.Controls.Count == 0)
            {
                List<Field> drawList = permit.GetFields();

                // LINQ ROCKS!!!
                drawList = (from f in drawList orderby f.GroupOrder, f.SortOrder select f).ToList();
                // another way to do the same as above
                //drawList = drawList.OrderBy(f => f.GroupOrder).ThenBy(f => f.SortOrder).ToList();

                if (!showAll)
                    drawList = (from f in drawList where f.Shown == true select f).ToList();

                foreach (Field f in drawList)
                {
#if NEW
                    if (f.GroupOrder != curGroup)
                    {
                        if (own != null) own.AutoSize = true;
                        own = DrawGroupPanel(f);
                    }
                    DrawField(f, own);
                    curGroup = f.GroupOrder;
#else
                    DrawField(f);
#endif
                }
                // Get the last one too
                if (own != null) own.AutoSize = true;
            }
            else
            {
                // Do the check only once, not for each item
                if (showAll)
                {
#if NEW
                    foreach(OutlookPanelEx subpanel in panel.Controls)
                    {
                        foreach(FieldPanel fp in subpanel.Controls)
#else
                        foreach (FieldPanel fp in panel.Controls)
#endif
                        {
                            //fp.Visible = fp.Field.Shown;
                            fp.Visible = true;
                        }
#if NEW
                    }
#endif

                }
                else
                {
#if NEW
                    foreach(OutlookPanelEx subpanel in panel.Controls)
                    {
                        foreach(FieldPanel fp in subpanel.Controls)
#else
                        foreach (FieldPanel fp in panel.Controls)
#endif
                        {
                            fp.Visible = fp.Field.Shown;
                        }
#if NEW
                    }
#endif
                }
            }
            panel.Visible = true;
        }

        private OutlookPanelEx DrawGroupPanel(Field field)
        {
            OutlookPanelEx owner = new OutlookPanelEx();
            owner.Parent = panel;
            owner.HeaderText = field.GroupName;
            owner.Dock = DockStyle.Top;
            //owner.AutoSize = true;
            owner.BringToFront();
            
            return owner;
        }

        private void DrawField(Field f)
        {
            FieldPanel p = new FieldPanel(f, panel);
            p.AutoSize = true;
        }

        private void DrawField(Field f, OutlookPanelEx owner)
        {
            FieldPanel p = new FieldPanel(f, owner);
            p.BackColor = System.Drawing.SystemColors.ControlLightLight;
            p.AutoSize = true;
        }

        public void ShowField(string name)
        {
            foreach (FieldPanel fp in panel.Controls)
            {
                if (fp.Field.DisplayLabel.Contains(name))
                {
                    // Not needed if we set the focus
                    //panel.ScrollControlIntoView(fp);
                    fp.Control.Focus();
                    break;
                }
            }
        }

        public FieldPanel FindFieldPanel(string name)
        {
            FieldPanel ret = null;
            foreach (FieldPanel fp in panel.Controls)
            {
                if (fp.Field.DisplayLabel.Contains(name))
                {
                    ret = fp;
                    break;
                }
            }
            return ret;
        }

        // With all the controls we're creating this can get heavy fast!
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Control c in panel.Controls)
                    c.Dispose();
            }
            // base does not implement Dispose
            //base.Dispose(disposing);
        }
    }
}
