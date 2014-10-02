using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DSDDemo
{
    // Just makes it easier to find a set of controls that match a name
    // The default Find method only returns an exact match
    // - 11/27/2009 - kw
    class BetterPanel : Panel
    {
        public Control[] FindControls(string startsWith)
        {
            ArrayList controls = new ArrayList();
            // Hopefully none of the control names have a space in them
            // so we'll remove them before the search
            string needle = startsWith.Replace(" ", "");
            foreach (Control control in Controls)
            {
                //string name = control.Name.Replace(" ", "");
                string name = control.Name;
                if (name.ToUpper().Contains(needle.ToUpper()))
                    controls.Add(control);
            }

            return (Control[])controls.ToArray(typeof(Control));
        }
    }
}
