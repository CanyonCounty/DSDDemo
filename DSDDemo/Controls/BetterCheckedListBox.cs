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
    // Text property is used like CommaText via TStringList in Delphi.
    // this.Text = "One, Two, Three" - One, Two and Three will be checked in the Items
    // string res = this.Text - will contail a comma separated values that are checked

    class BetterCheckedListBox: CheckedListBox
    {
        private List<string> stringList;
        private char[] param;
        private bool _flag;

        public BetterCheckedListBox()
        {
            param = new char[] { ',' };

            stringList = new List<string>();

            this.ItemCheck += new ItemCheckEventHandler(BetterCheckedListBox_ItemCheck);
        }

        private void BetterCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_flag)
            {
                if (e.NewValue == CheckState.Checked)
                    stringList.Add(Items[e.Index].ToString().Trim());
                else
                    stringList.Remove(Items[e.Index].ToString().Trim());
            }
        }

        public override string Text { get { return GetText(); } set { SetText(value); } }

        private string GetText()
        {
            string text = "";
            foreach (string str in stringList)
                text += str + ",";

            text = text.Trim(param);

            return text;
        }

        private void SetText(string value)
        {
            // UnCheck Everything
            _flag = true;
            for (int i = 0; i < Items.Count; i++)
                this.SetItemChecked(i, false);
            stringList.Clear();

            if (!string.IsNullOrEmpty(value))
            {
                string[] things = value.Split(',');
                foreach (string thing in things)
                {
                    // only add if it's not already there?
                    if (stringList.IndexOf(thing) == -1)
                    {
                        stringList.Add(thing.Trim());
                    }
                    int index = this.Items.IndexOf(thing.Trim());
                    if (index > -1)
                        this.SetItemChecked(index, true);
                }
            }
            _flag = false;
        }

    }
}
