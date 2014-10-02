using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSDDemo
{
    public partial class HackForm : Form
    {
        FilterField ff;
        DrawPermitPanel dp;
        bool filtered = false;

        public HackForm()
        {
            InitializeComponent();
        }

        private void HackForm_Load(object sender, EventArgs e)
        {
            Permits.BuildingPermit permit = new DSDDemo.Permits.BuildingPermit();
            dp = new DrawPermitPanel(panel1, permit);
            ff = new FilterField(button2, textBox1);
            ff.Panel = dp;
            ff.Filtered = false;
            SearchField search = new SearchField(panel1, textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filtered = ff.Filtered;
            Button buttonEdit = (sender as Button);
            if (buttonEdit.Text == "Edit Shown")
            {
                buttonEdit.Text = "Done";
                ff.Filtered = false; // show everything
            }
            else
            {
                buttonEdit.Text = "Edit Shown";
            }

            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is FieldPanel)
                    (ctl as FieldPanel).ToggleCheckBox();
            }

        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string items = "";
            foreach (object item in checkedListBox1.CheckedItems)
            {
                items += item.ToString() + ",";
            }
            items = items.TrimEnd(new char[] { ',' });
            MessageBox.Show(items);
        }

    }
}
