using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSDDemo
{
    // seriously this is getting nuts!!!
    // WHAT IT FIXES - Who wants to iterate over items in a check list box?
    // I mean really?
    // Text property is used like CommaText in Delphi.
    // this.Text = "One, Two, Three" - One, Two and Three will be checked in the Items
    // string res = this.Text - will contail a comma separated values that are checked

    class BetterCheckedListBox: CheckedListBox
    {
        private string text;
        private List<string> stringList;
        private char[] param;

        public BetterCheckedListBox()
        {
            text = "";
            param = new char[] { ',' };

            stringList = new List<string>();

            this.ItemCheck += new ItemCheckEventHandler(BetterCheckedListBox_ItemCheck);
        }

        void BetterCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            text = "";

            if (e.NewValue == CheckState.Checked)
                stringList.Add(Items[e.Index].ToString());
            else
                stringList.Remove(Items[e.Index].ToString());

            foreach (string str in stringList)
                text += str + ",";
            
            text = text.TrimEnd(param);
        }

        public override string Text { get { return GetText(); } set { SetText(value); } }

        private string GetText()
        {
            return text;
        }

        private void SetText(string value)
        {
            // UnCheck Everything
            for (int i = 0; i < Items.Count; i++)
                this.SetItemChecked(i, false);
            stringList.Clear();

            if (!string.IsNullOrEmpty(value))
            {
                string[] things = value.Split(',');
                foreach (string thing in things)
                {
                    stringList.Add(thing);
                    int index = this.Items.IndexOf(thing);
                    if (index > -1)
                        this.SetItemChecked(index, true);
                }
            }
        }

    }
}
