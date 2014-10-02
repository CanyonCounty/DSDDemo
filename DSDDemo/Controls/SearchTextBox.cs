using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace DSDDemo
{
    public class SearchTextBox : TextBox
    {
        private string mCue;
        private PictureBox pb;
        private ContextMenuStrip menu;
        private Image loupe;
        private Image cancel;
        EventHandler click;
        
        [Category("Appearance")]
        [Description("The cue (help) text associated with the control.")]
        public string Cue
        {
            get { return mCue; }
            set
            {
                mCue = value;
                if (String.IsNullOrEmpty(mCue)) mCue = " Search";
                updateCue();
            }
        }

        public delegate void MenuClickedEvent(object sender, EventArgs e, string menuText);
        
        [Description("Returns the text of the menu clicked.")]
        public event MenuClickedEvent MenuItemClicked;

        private void updateCue()
        {
            if (!this.IsHandleCreated || string.IsNullOrEmpty(mCue)) return;

            IntPtr mem = Marshal.StringToHGlobalUni(mCue);
            SendMessage(this.Handle, 0x1501, (IntPtr)1, mem);
            Marshal.FreeHGlobal(mem);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //this.BorderStyle = BorderStyle.FixedSingle;

            loupe = LoupeImage();
            cancel = CancelImage();

            SetMargin(1, 20);
            pb = new PictureBox();
            pb.Parent = this;
            if (this.BorderStyle == BorderStyle.FixedSingle) pb.Top = 1;
            else pb.Top = 0;
            pb.Left = this.Width - 25;
            pb.BackColor = this.BackColor;
            //pb.Size = new Size(20, 18);
            pb.Size = new Size(19, 16);
            pb.Click += new System.EventHandler(this.pb_Click);
            pb.Cursor = Cursors.Default;
            pb.Image = loupe;

            this.TextChanged += new System.EventHandler(this.text_TextChanged);
            click = new System.EventHandler(this.menu_Click);
            menu = new ContextMenuStrip();

            updateCue();
        }

        // I don't care what they want to set it to, I'm not going to allow it.
        [Browsable(false)]
        private new bool Multiline { get { return false; } set { base.Multiline = false; } }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            pb.BackColor = this.BackColor;
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if (value == false) pb.BackColor = SystemColors.Control;
                else pb.BackColor = SystemColors.Window;
            }
        }

        // http://www.developerfusion.com/code/167/margins-in-a-textbox/
        // Make the margin so the search "icons" don't cover up entered text
        private void SetMargin(int left, int right)
        {
            int EM_SETMARGINS = 0xD3;
            int EC_LEFTMARGIN = 0x01;
            int EC_RIGHTMARGIN = 0x02;

            // right needs to be in the hi-word, so multiply by 65536
            long value = 65536 * right + left;
            IntPtr ptr = new IntPtr(EC_LEFTMARGIN | EC_RIGHTMARGIN);
            SendMessage(this.Handle, EM_SETMARGINS, ptr, (IntPtr)value);
        }

        private Image CancelImage()
        {
            // Trust me, it's a picture of an X - Ken Wilcox - Dec 3, 2009
            byte[] cancelData = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0,
                0, 0, 23, 0, 0, 0, 20, 8, 6, 0, 0, 0, 102, 190, 166, 14, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174,
                206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 32, 99, 72,
                82, 77, 0, 0, 122, 38, 0, 0, 128, 132, 0, 0, 250, 0, 0, 0, 128, 232, 0, 0, 117, 48, 0, 0, 234,
                96, 0, 0, 58, 152, 0, 0, 23, 112, 156, 186, 81, 60, 0, 0, 0, 174, 73, 68, 65, 84, 72, 75, 99,
                252, 255, 255, 63, 3, 205, 0, 200, 112, 90, 97, 154, 25, 12, 14, 17, 90, 185, 122, 212, 112,
                156, 65, 75, 48, 204, 147, 151, 93, 251, 223, 179, 235, 30, 48, 8, 17, 169, 10, 196, 7, 137,
                19, 138, 47, 130, 134, 247, 108, 187, 246, 223, 176, 105, 239, 127, 16, 13, 50, 12, 157, 143,
                207, 2, 130, 134, 131, 52, 183, 172, 59, 247, 223, 176, 116, 237, 127, 100, 154, 144, 171, 73,
                74, 45, 45, 203, 142, 253, 215, 204, 156, 243, 31, 68, 19, 99, 48, 209, 134, 183, 204, 219, 251,
                95, 51, 178, 231, 63, 50, 77, 140, 5, 4, 131, 165, 122, 218, 214, 255, 138, 190, 213, 255, 65,
                52, 200, 64, 116, 62, 69, 97, 30, 148, 219, 243, 191, 122, 210, 90, 148, 160, 0, 241, 65, 226,
                132, 92, 79, 208, 229, 132, 12, 160, 200, 229, 163, 134, 83, 61, 252, 169, 110, 32, 114, 28, 1,
                0, 50, 4, 19, 20, 116, 246, 116, 241, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
            MemoryStream ms = new MemoryStream(cancelData);
            return Image.FromStream(ms);
        }

        private Image LoupeImage()
        {
            // Trust me, it's a picture of a loupe (magnifing glass) - Ken Wilcox - Dec 3, 2009
            byte[] loupeData = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0,
                0, 23, 0, 0, 0, 20, 8, 6, 0, 0, 0, 102, 190, 166, 14, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206,
                28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 32, 99, 72, 82,
                77, 0, 0, 122, 38, 0, 0, 128, 132, 0, 0, 250, 0, 0, 0, 128, 232, 0, 0, 117, 48, 0, 0, 234, 96,
                0, 0, 58, 152, 0, 0, 23, 112, 156, 186, 81, 60, 0, 0, 1, 55, 73, 68, 65, 84, 72, 75, 99, 252,
                255, 255, 63, 3, 205, 0, 200, 112, 90, 97, 154, 25, 12, 14, 17, 82, 93, 61, 231, 246, 251, 255,
                75, 239, 191, 7, 106, 35, 236, 99, 162, 13, 207, 94, 118, 237, 191, 97, 215, 49, 20, 92, 189,
                233, 26, 94, 75, 136, 50, 60, 123, 209, 185, 255, 134, 77, 123, 255, 103, 47, 59, 247, 255, 216,
                245, 247, 255, 247, 94, 126, 254, 63, 121, 30, 68, 172, 122, 29, 110, 11, 136, 50, 220, 178, 18,
                104, 48, 208, 48, 244, 160, 136, 234, 59, 246, 31, 36, 135, 43, 136, 8, 26, 62, 103, 215, 189,
                255, 150, 133, 91, 255, 239, 61, 255, 28, 195, 144, 165, 251, 112, 203, 17, 21, 161, 75, 65,
                134, 231, 110, 253, 191, 245, 56, 166, 225, 115, 182, 93, 3, 203, 29, 3, 6, 19, 54, 215, 19,
                116, 57, 72, 147, 101, 230, 218, 255, 65, 88, 188, 239, 4, 244, 145, 19, 208, 112, 178, 131,
                5, 164, 17, 100, 0, 200, 2, 144, 97, 83, 128, 17, 216, 179, 234, 26, 216, 80, 144, 216, 214,
                227, 247, 200, 55, 220, 11, 104, 160, 101, 234, 218, 255, 201, 93, 123, 193, 52, 12, 131, 12,
                223, 122, 24, 183, 193, 4, 195, 220, 41, 115, 233, 127, 195, 216, 57, 255, 91, 102, 29, 131,
                187, 238, 220, 245, 231, 255, 175, 221, 199, 30, 198, 232, 193, 131, 51, 204, 45, 99, 123, 254,
                107, 250, 182, 252, 175, 158, 132, 59, 76, 9, 229, 82, 172, 134, 47, 221, 116, 236, 191, 162,
                77, 246, 255, 226, 174, 165, 68, 101, 115, 146, 35, 116, 239, 62, 68, 80, 16, 114, 33, 201, 134,
                147, 107, 32, 178, 62, 162, 210, 57, 185, 22, 13, 93, 195, 1, 146, 217, 13, 114, 148, 158, 36,
                251, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
            MemoryStream ms = new MemoryStream(loupeData);
            return Image.FromStream(ms);
        }

        public static byte[] ImageToBytes(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            byte[] data = ms.ToArray();
            //foreach (byte d in data)
            //{
            //    textBox1.Text += d.ToString() + ",";
            //}
            return data;
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Text))
                pb.Image = loupe;
            else
                pb.Image = cancel;
        }

        private void pb_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Text))
                menu.Show(Control.MousePosition);
            else
                this.Text = "";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (sender as ToolStripMenuItem);
            // Uncheck everyone
            foreach(ToolStripMenuItem i in menu.Items)
                i.Checked = false;
            // Check me!
            item.Checked = true;
            string s = item.Text;
            
            if (s == "Default") s = "Search";
            Cue = " " + s;
            //updateCue();

            MenuItemClicked(sender, e, s);
        }

        public void AddMenuItem(string text)
        {
            AddMenuItem(text, false);
        }

        public void AddMenuItem(string text, bool selected)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)menu.Items.Add(text, null, click);
            if (selected)
            {
                foreach (ToolStripMenuItem i in menu.Items)
                    i.Checked = false;
                
                item.Checked = true;
            }
        }

        // P/Invoke
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
