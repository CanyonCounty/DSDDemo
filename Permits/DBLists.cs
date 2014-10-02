using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DSDDemo
{
    // single class to get lists and cache them
    // I don't know if these values ever change
    public class DBLists
    {
        Dictionary<string, ArrayList> items;

        public DBLists()
        {
            items = new Dictionary<string, ArrayList>();
        }

        public ArrayList GetList(string name, bool refresh)
        {
            if (!items.ContainsKey(name) | refresh)
            {
                ArrayList list = new ArrayList();
                FillList(name, ref list);
                items.Add(name, list);
            }
            return items[name];
        }

        private void FillList(string name, ref ArrayList list)
        {
            // just hard coded for now
            switch (name)
            {
                case "zz01":
                    list.Add("");
                    list.Add("Addition");
                    list.Add("Alteration");
                    list.Add("Conversion");
                    list.Add("Demolition");
                    list.Add("Foundation");
                    list.Add("Move On");
                    list.Add("New");
                    list.Add("Rebuild");
                    list.Add("Remodel");
                    list.Add("Renovation");
                    list.Add("Repair");
                    break;
                case "cstr":
                    list.Add("");
                    list.Add("1A");
                    list.Add("1B");
                    list.Add("IIA");
                    list.Add("IIB");
                    list.Add("IIIA");
                    list.Add("IIIB");
                    list.Add("VA");
                    list.Add("VB");
                    list.Add("Just a test value to see if it is longer than the control - I hope it is");
                    break;
                case "zz30":
                    list.Add("");
                    list.Add("AG Barn");
                    list.Add("AG Building");
                    list.Add("AG Canopy");
                    list.Add("AG Research");
                    list.Add("AG Sales Stand");
                    list.Add("AG Vet Clinic");
                    list.Add("Apartment");
                    break;
                case "zz40":
                    list.Add("Fax");
                    list.Add("Text");
                    list.Add("Email");
                    list.Add("Web Link");
                    break;
            }
        }
    }
}
