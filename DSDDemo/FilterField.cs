using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace DSDDemo
{
    // ties controls together
    class FilterField
    {
        Button toggle;
        TextBox search;
        DrawPermitPanel panel;
        bool filtered = false;
        string searchValue = ""; // What the user is/was searching for

        public DrawPermitPanel Panel { set { panel = value; } }

        public bool Filtered { 
            get { return filtered; }
            set
            {
                filtered = value;
                if (filtered)
                    toggle.Text = "Show All";
                else
                    toggle.Text = "Filter";
                if (panel != null)
                    panel.Draw(!filtered);
            }
        }

        //void RemoveClickEvent(Button b)
        //{
        //    FieldInfo f1 = typeof(Control).GetField("EventClick",
        //        BindingFlags.Static | BindingFlags.NonPublic);
        //    object obj = f1.GetValue(b);
        //    PropertyInfo pi = button1.GetType().GetProperty("Events",
        //        BindingFlags.NonPublic | BindingFlags.Instance);
        //    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
        //    list.RemoveHandler(obj, list[obj]);
        //}

        public FilterField(Button toggle, TextBox search)
        {
            this.toggle = toggle;
            this.search = search;
            
            //RemoveClickEvent(toggle);
            this.toggle.Click += null; // clear out the old ones
            this.toggle.Click += new System.EventHandler(this.toggle_Click);
            toggle.Text = "Filter";
            if (panel != null)
                panel.Draw(!filtered); // Default to showing everything
            //Filtered = false;
        }

        private void toggle_Click(object sender, EventArgs e)
        {
            // WHY THE HECK IS THIS FIRING TWICE!!!!!!!!!
            
            //throw new Exception("toggle_Click");
            //MessageBox.Show("toggle_Click");
            searchValue = search.Text;
            search.Text = "";

            Filtered = !filtered;

            //filtered = !filtered;
            //if (filtered)
            //{
            //    toggle.Text = "Filter";
            //}
            //else
            //{
            //    toggle.Text = "Show All";
            //}

            //panel.Draw(filtered);
            
            search.Text = searchValue;
        }
    }
}
