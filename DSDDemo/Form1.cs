using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DSDDemo
{
    public partial class frmMain : Form
    {
        private List<PermitItem> PI;
        Random max;
        Color defColor;
        string first;
        BuildingPermit bp;

        public frmMain()
        {
            InitializeComponent();
            
            PI = new List<PermitItem>();
            max = new Random();
            defColor = panelMain.BackColor;
            first = "";
            bp = new BuildingPermit();

            //Assembly assembly = Assembly.GetEntryAssembly();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            comboBox1.Items.Clear();
            Dictionary<string, BasePermit> dic = new Dictionary<string, BasePermit>();

            foreach (Type tp in types)
            {
                if (tp.BaseType == typeof(BasePermit))
                {
                    Type t = assembly.GetType("DSDDemo." + tp.Name);
                    BasePermit permit = (BasePermit)Activator.CreateInstance(t);
                    dic.Add(permit.DisplayLabel(), permit);
                    
                    //comboBox1.Items.Add(permit.DisplayLabel());
                }
            }

            comboBox1.DataSource = new BindingSource(dic, null);
            comboBox1.DisplayMember = "Key";

        }
        /*
        private int GetItemCount(string name)
        {
            int count = -1;

            for (int i = 0; i < PI.Count(); i++)
            {
                if (PI[i].Name == name)
                {
                    count = PI[i].Count;
                    break;
                }
            }

            if (count == -1)
            {
                PermitItem pi = new PermitItem();
                pi.Name = name;
                count = max.Next(10, 60);
                pi.Count = count;
                PI.Add(pi);
            }

            return count;
        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, BasePermit> Item = (KeyValuePair<string, BasePermit>)comboBox1.SelectedItem;

            // Clean up all the old ones
            panelMain.Controls.Clear();
            panelMain.Visible = false;

            Type type = Item.Value.GetType();
            PropertyInfo[] info = type.GetProperties();
            //MemberInfo[] info = type.GetMembers();
            //FieldInfo[] fi = type.GetFields();

            int i = 0;
            int top = 0;
            Panel p;
            Label l;
            TextBox t;

            BasePermit permit = Item.Value;
            foreach (Field f in permit.FieldList)
            {
                p = new Panel();
                p.Parent = panelMain;
                p.Dock = DockStyle.Top;
                p.BorderStyle = BorderStyle.Fixed3D; // just to see it for now
                p.Height = 30;
                p.Width = panelMain.Width - 20;
                p.Top = top;
                p.Name = f.FieldName;

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

                p.AutoSize = true; // Do this last
                top += p.Height;

            }
            /*
            foreach (PropertyInfo pi in info)
            //foreach (MemberInfo pi in info)
            {
                if (pi.PropertyType == typeof(Field))
                //if (pi.MemberType.GetType() == typeof(Field))
                {
                    //Text = pi.Name;
                    BasePermit permit = Item.Value;
                    i++;
                    if (i == 1) first = pi.ToString();

                    p = new Panel();
                    p.Parent = panelMain;
                    p.Dock = DockStyle.Top;
                    //p.BorderStyle = BorderStyle.Fixed3D; // just to see it for now
                    p.Height = 30;
                    p.Width = panelMain.Width - 20;
                    p.Top = top;
                    p.Name = pi.ToString().Replace("System.String ", ""); // i.ToString();

                    l = new Label();
                    l.Parent = p;
                    //if (i < 10)
                    //    pad = " ";
                    //else
                    //    pad = "";
                    //l.Text = pad + i.ToString() + " " + item;
                    l.Text = p.Name.ToString().Replace("_", " "); //i.ToString() + " " + item;
                    l.AutoSize = true;
                    l.Top = 10;

                    t = new TextBox();
                    t.Parent = p;
                    t.Width = p.Width - l.Width - 20;
                    t.Left = l.Width + 10;
                    t.Top = 5;

                    p.AutoSize = true; // Do this last
                    top += p.Height;
                }

            }
            */
            /*

            // I don't care what they are at this point
            Panel p;
            Label l;
            TextBox t;
            string pad = "";
            //Random max = new Random();
            //for (int i = max.Next(20); i > 0; i--)
            int max = GetItemCount(item);
            label2.Text = "Count: " + max.ToString();
            int top = 0;
            for (int i = max; i > 0; i--)
            //for (int i = 1; i < max+1; i++)
            {
                if (i == 1)
                    first = i.ToString();

                p = new Panel();
                p.Parent = panelMain;
                p.Dock = DockStyle.Top;
                p.BorderStyle = BorderStyle.Fixed3D; // just to see it for now
                p.Height = 30;
                p.Width = panelMain.Width - 20;
                p.Top = top;
                p.Name = i.ToString();
                
                l = new Label();
                l.Parent = p;
                if (i < 10)
                    pad = " ";
                else
                    pad = "";
                l.Text = pad + i.ToString() + " " + item;
                l.AutoSize = true;
                l.Top = 10;

                t = new TextBox();
                t.Parent = p;
                t.Width = p.Width - l.Width - 20;
                t.Left = l.Width + 10;
                t.Top = 5;

                p.AutoSize = true; // Do this last
                top += p.Height;
            }
            */

            panelMain.Visible = true;
            textBox1.Enabled = true;
            
        }

        private void ShowControl(string text, bool color)
        {
            //Control[] ctl = panelMain.Controls.Find(text, false);
            Control[] ctl = panelMain.FindControls(text);
            //MessageBox.Show(ctl.ToString());
            //panelMain.ScrollControlIntoView(ctl);
            foreach (Control control in ctl)
            {
                //MessageBox.Show(control.Name);
                if (color == true) control.BackColor = Color.Cornsilk;

                control.Visible = true;
                panelMain.ScrollControlIntoView(control);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Clear all the old ones first
            panelMain.Visible = false;
            foreach (Control control in panelMain.Controls)
            {
                control.BackColor = defColor;
                control.Visible = false;
            }
            panelMain.Visible = true;

            string text = (sender as TextBox).Text;
            //Text = panelMain.Controls.Count.ToString();
            if (!String.IsNullOrEmpty(text))
            {
                ShowControl(text, true);
            }
            else
            {
                panelMain.Visible = false;
                foreach (Control control in panelMain.Controls)
                {
                    control.BackColor = defColor;
                    control.Visible = true;
                }
                panelMain.Visible = true;
                ShowControl(first, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
    
    public class PermitItem
    {
        private int count;
        private string name;

        public int Count { get { return count; } set { count = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
