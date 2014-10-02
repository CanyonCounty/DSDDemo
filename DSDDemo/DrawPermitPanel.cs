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

        public DrawPermitPanel(BetterPanel panel, BasePermit permit)
        {
            this.panel = panel;
            this.permit = permit;
        }

        public void Draw(bool showAll)
        {
            // Clean up all the old ones
            panel.Visible = false;
            panel.Controls.Clear();

            List<Field> drawList = permit.GetFields();
            
            // LINQ ROCKS!!!
            drawList = (from f in drawList orderby f.GroupOrder, f.SortOrder select f).ToList();
            // another way to do the same as above
            //drawList = drawList.OrderBy(f => f.GroupOrder).ThenBy(f => f.SortOrder).ToList();

            if (!showAll)
                drawList = (from f in drawList where f.Shown == true select f).ToList();

            foreach (Field f in drawList)
            {
                // Broke this out in case I wanted to do something else
                DrawField(f);
            }
            panel.Visible = true;
        }

        private void DrawField(Field f)
        {
            Panel p;
            Label l;
            TextBox t;
            p = new Panel();
            p.Parent = panel;
            p.Height = 30;
            p.Width = panel.Width - 22;
            p.Top = (panel.Controls.Count - 1) * p.Height;
            p.Name = f.FieldName;
            p.Dock = DockStyle.Top;
            p.BringToFront(); // If you'd like to remove this like talk to Ken first!

            l = new Label();
            l.Parent = p;
            l.Text = f.DisplayLabel;
            l.AutoSize = true;
            l.Top = 10;

            t = new TextBox();
            t.Parent = p;
            t.Width = p.Width - l.Width - 20;
            t.Left = l.Width + 10;
            t.Top = 5;
            t.TabStop = true;
            t.TabIndex = panel.Controls.Count;// +1;
            //t.Text = t.TabIndex.ToString() + " " + p.Name;

            t.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            foreach (Control ctl in panel.Controls)
            {
                // When or if the scroll bar shows up, it hoses the placement of additional panels
                // This fixes it
                ctl.Width = panel.Width - 22;
            }
        }
    }
}
