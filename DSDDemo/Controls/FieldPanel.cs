using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace DSDDemo
{
    // Give it a field Object and it properly displays it
    // it handles data changes
    class FieldPanel: Panel
    {
        private Field field;
        public Field Field { get { return field; } }
        private Label label;
        //private TextBox t;
        private CheckBox cb;
        //private ComboBox 
        private Control control;
        public Control Control { get { return control; } }
        public bool IsDirty { get { return !Field.OriginalValue.Equals(Field.CurrentValue); } }

        public FieldPanel(Field field, OutlookPanelEx parent)
        {
            this.field = field;

            //p = new Panel();
            this.Parent = parent;
            this.Height = 60;
            this.Width = parent.Width - 22;
            this.Top = (parent.Controls.Count - 1) * this.Height;
            this.Name = field.FieldName;
            this.Dock = DockStyle.Top;
            this.BringToFront(); // If you'd like to remove this like talk to Ken first!

            label = new Label();
            label.Parent = this;
            label.Text = field.DisplayLabel;
            //label.Text += "(" + field.GroupOrder.ToString() + "." + field.SortOrder.ToString() + ")";
            label.AutoSize = true;
            label.Top = 10;

            switch (field.FieldType)
            {
                case FieldTypes.Lookup:
                    control = MakeComboBox(field);
                    break;
                case FieldTypes.Many:
                    control = MakeCheckedListBox(field);
                    break;
                case FieldTypes.Memo:
                    control = MakeMemo(field);
                    break;

                default:
                    control = MakeTextBox(field);
                    break;

            }

            cb = new CheckBox();
            cb.Parent = this;
            cb.Text = "";
            cb.AutoSize = true;
            cb.Left = label.Width + control.Width;//this.Width - cb.Width - 5;
            cb.Top = 10;
            cb.Visible = false;
            cb.Enabled = !field.Required;
            cb.Checked = field.Shown;
            cb.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);

            //control.Width = this.Width - label.Width - cb.Width - 20;
        }

        public FieldPanel(Field field, BetterPanel parent)
        {
            this.field = field;

            //p = new Panel();
            this.Parent = parent;
            this.Height = 60;
            this.Width = parent.Width - 22;
            this.Top = (parent.Controls.Count - 1) * this.Height;
            this.Name = field.FieldName;
            this.Dock = DockStyle.Top;
            this.BringToFront(); // If you'd like to remove this like talk to Ken first!

            label = new Label();
            label.Parent = this;
            label.Text = field.DisplayLabel;
            //label.Text += "(" + field.GroupOrder.ToString() + "." + field.SortOrder.ToString() + ")";
            label.AutoSize = true;
            label.Top = 10;

            switch (field.FieldType)
            {
                case FieldTypes.Lookup:
                    control = MakeComboBox(field);
                    break;
                case FieldTypes.Many:
                    control = MakeCheckedListBox(field);
                    break;
                case FieldTypes.Memo:
                    control = MakeMemo(field);
                    break;

                default:
                    control = MakeTextBox(field);
                    break;

            }

            cb = new CheckBox();
            cb.Parent = this;
            cb.Text = "";
            cb.AutoSize = true;
            cb.Left = label.Width + control.Width;//this.Width - cb.Width - 5;
            cb.Top = 10;
            cb.Visible = false;
            cb.Enabled = !field.Required;
            cb.Checked = field.Shown;
            cb.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);

            //control.Width = this.Width - label.Width - cb.Width - 20;
        }

        private Control MakeMemo(Field field)
        {
            TextBox c = new TextBox();
            c.Parent = this;
            c.Width = this.Width - label.Width - 20;
            c.Left = label.Width + 10;
            c.Top = 5;
            c.TabStop = true;
            c.TabIndex = Parent.Controls.Count;// +1;
            c.Multiline = true;
            c.WordWrap = true;
            c.ScrollBars = ScrollBars.Vertical;
            
            c.Height = 60; // TODO - set the right memo height?
            c.Text = field.OriginalValue;

            // TODO - add double click to show memo window?
            c.TextChanged += new System.EventHandler(this.t_TextChanged);

            c.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            return c;

        }

        private Control MakeCheckedListBox(Field field)
        {
            BetterCheckedListBox c = new BetterCheckedListBox();
            //ListBox c = new ListBox();
            c.Parent = this;
            c.Width = this.Width - label.Width - 20;
            c.Left = label.Width + 10;
            c.Top = 5;
            c.TabStop = true;
            c.TabIndex = Parent.Controls.Count;// +1;
            c.Items.AddRange(field.LookupValues.ToArray());
            c.Height = 20 * c.Items.Count; // TODO - set the right checklist box height?
            c.Text = field.OriginalValue;
            
            c.CheckOnClick = true;
            c.ItemCheck += new ItemCheckEventHandler(this.c_ItemCheck);

            c.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            return c;
        }

        private Control MakeComboBox(Field field)
        {
            BetterComboBox c = new BetterComboBox();
            c.Parent = this;
            c.Width = this.Width - label.Width - 20;
            c.Left = label.Width + 10;
            c.Top = 5;
            c.TabStop = true;
            c.TabIndex = Parent.Controls.Count;// +1;
            c.Items.AddRange(field.LookupValues.ToArray());
            c.DropDownStyle = ComboBoxStyle.DropDownList; // Can only select a value
            c.Text = field.OriginalValue;

            //c.TextChanged += new System.EventHandler(this.t_TextChanged);
            c.SelectedIndexChanged += new System.EventHandler(this.c_SelectedIndexChanged);

            c.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            
            return c;
        }

        private Control MakeTextBox(Field field)
        {
            TextBox t = new TextBox();
            t.Parent = this;
            t.Width = this.Width - label.Width - 20;
            t.Left = label.Width + 10;
            t.Top = 5;
            t.TabStop = true;
            t.TabIndex = Parent.Controls.Count;// +1;
            t.Text = field.OriginalValue;
            t.TextChanged += new System.EventHandler(this.t_TextChanged);

            t.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            return t;
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            field.Shown = (sender as CheckBox).Checked;
        }

        public void ToggleCheckBox()
        {
            cb.Visible = !cb.Visible;
            if (cb.Visible)
            {
                control.Width = this.Width - label.Width - cb.Width - 20;
            }
            else
            {
                control.Width = this.Width - label.Width - 20;
            }
        }

        private void t_TextChanged(object sender, EventArgs e)
        {
            field.CurrentValue = (sender as Control).Text;
            if (field.CurrentValue != field.OriginalValue)
                (sender as Control).ForeColor = Color.Red;
            else
                (sender as Control).ForeColor = Color.Black;
        }

        private void c_SelectedIndexChanged(object sender, EventArgs e)
        {
            field.CurrentValue = (sender as Control).Text;
            if (field.CurrentValue != field.OriginalValue)
                (sender as Control).ForeColor = Color.Red;
            else
                (sender as Control).ForeColor = Color.Black;
        }

        private void c_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            field.CurrentValue = (sender as Control).Text;
            if (field.CurrentValue != field.OriginalValue)
                (sender as Control).ForeColor = Color.Red;
            else
                (sender as Control).ForeColor = Color.Black;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Control c in this.Controls)
                    c.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
