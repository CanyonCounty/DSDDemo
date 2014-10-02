using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Threading;
using DSDDemo.Permits;

namespace DSDDemo
{
    public partial class frmMain : Form
    {
        SearchField search;
        AssemblyFilter<BasePermit> af;
        DrawPermitPanel dp;
        string searchValue = "";

        public frmMain()
        {
            InitializeComponent();
            
            search = new SearchField(panelMain, searchBox);

            af = new AssemblyFilter<BasePermit>(permitList);
            af.Bind(); // Moved from constructor to avoid null below
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasePermit permit = af.GetItem(permitList.SelectedItem);

            dp = new DrawPermitPanel(panelMain, permit);
            dp.Draw(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (searchBox.Text != "")
                searchValue = searchBox.Text;

            search.Clear();

            bool drawAll = false;
            if (buttonShow.Text == "Show All")
            {
                buttonShow.Text = "Filtered";
                drawAll = false;
            }
            else
            {
                buttonShow.Text = "Show All";
                drawAll = true;
            }

            dp.Draw(drawAll);
            if (drawAll)
            {
                if (searchValue != "")
                    searchBox.Text = searchValue;
            }
        }
    }
}
