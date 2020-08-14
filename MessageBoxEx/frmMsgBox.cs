using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;

namespace DataTools.MessageBoxEx
{
    internal partial class frmMsgBox : Form
    {
        private readonly int MinDlgWidth = 117;

        private readonly int VerticalMargin = 15;

        private readonly int HorizonalMargin = 30;

        private readonly int RMarginLabelImage = 62;

        private readonly int RMarginImage = 22;

        private readonly int ButtonAreaHeight = 42;

        private readonly int ButtonSpacing = 8;

        private readonly int BaseHeight = 158;

        private readonly Size ButtonSize = new Size(76, 24);

        private CheckBox chkOption = new CheckBox();

        private List<MessageBoxExButton> buttons = new List<MessageBoxExButton>();

        public MessageBoxExResult Result { get; private set; }

        public string CustomResult { get; set; }

        public frmMsgBox()
        {
            InitializeComponent();
        }

        private void ClearButtons()
        {
            pnlButtons.Controls.Clear();
            this.buttons.Clear();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (var b in buttons)
            {
                if (b.IsDefault)
                {
                    b.Button.Focus();
                    return;
                }
            }
        }
        public void SetButtons(IEnumerable<MessageBoxExButton> buttons)
        {
            ClearButtons();

            foreach (var b in buttons)
            {
                var btn = new Button()
                {
                    Size = ButtonSize,
                    Text = b.Message,
                    BackColor = SystemColors.Control,
                    Visible = true
                };

                if (b.Image != null)
                {
                    btn.Image = ScaleBitmap(b.Image, 16, 16);

                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.TextAlign = ContentAlignment.TopCenter;
                    btn.Width += 28;
                    btn.Padding = new Padding(0);
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                pnlButtons.Controls.Add(btn);

                b.Button = btn;
                btn.Visible = true;
                btn.Enabled = true;
                btn.Click += Btn_Click;

                this.buttons.Add(b);
            }



        }

        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (var b in buttons)
            {
                if (b.Button == sender)
                {
                    Result = b.Result;
                    CustomResult = b.CustomResult;

                    if (string.IsNullOrEmpty(b.CustomResult))
                        CustomResult = b.Result.ToString();

                    this.Close();
                }
            }
        }

        public void SetMessage(string message)
        {
            lblMessage.Text = message;
        }

        public void SetIcon(Bitmap icon)
        {
            pbIcon.Visible = (icon != null);
            pbIcon.Image = icon;
        }

        public bool OptionResult
        {
            get => chkOption.Checked;
        }

        public void SetOption(bool visible, string message = null)
        {

            if (visible)
            {
                chkOption.Text = message;
                pnlButtons.Controls.Add(chkOption);
            }
            else
            {
                pnlButtons.Controls.Remove(chkOption);
            }

        }

        internal void FormatBox()
        {
            int btnsTotal = 0;

            int lblStart;

            this.Height = BaseHeight;
            
            int ly = (this.Height / 2) - (lblMessage.Height / 2) - ButtonAreaHeight;

            if (ly < 0)
            {
                this.Height += (-2 * ly) + (VerticalMargin * 2);
                ly = (this.Height / 2) - (lblMessage.Height / 2) - ButtonAreaHeight;
            }


            int py = (this.Height / 2) - (pbIcon.Height / 2) - ButtonAreaHeight;
            int by = (21 - (ButtonSize.Height / 2));
            int bx = 0;
            int msgTotal = 0;
            int bw;

            if (pbIcon.Image == null)
            {
                msgTotal += 60;
                lblStart = HorizonalMargin;
            }
            else
            {
                msgTotal += RMarginLabelImage + 15;
                lblStart = RMarginLabelImage;
            }

            msgTotal += lblMessage.Width;
            lblMessage.Left = lblStart;
            lblMessage.Top = ly;

            pbIcon.Top = py;
            pbIcon.Left = RMarginImage;

            foreach (var b in buttons)
            {
                btnsTotal += b.Button.Width + 8;
                b.Button.Top = by;
            }

            if (pnlButtons.Controls.Contains(chkOption))
            {
                chkOption.AutoSize = true;

                btnsTotal += chkOption.Width + 32;

                chkOption.Left = 16;
                chkOption.Top = (21 - (chkOption.Height / 2));

                chkOption.Visible = true;

            }

            if (btnsTotal > msgTotal)
                bw = btnsTotal + 30;
            else 
                bw = msgTotal + 30;

            if (bw < MinDlgWidth)
                bw = MinDlgWidth;

            this.Width = bw;

            bx = pnlButtons.Width;

            foreach (var b in buttons)
            {
                bx -= (b.Button.Width + ButtonSpacing);

                b.Button.Left = bx;
                b.Button.BringToFront();
                b.Button.Visible = true;

            }



        }


        private Bitmap ScaleBitmap(Bitmap image, int cx, int cy)
        {

            var bmp = new Bitmap((int)cx, (int)cy);
            var graph = Graphics.FromImage(bmp);

            // uncomment for higher quality output
            
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            graph.DrawImage(image, 0, 0, cx, cy);

            graph.Dispose();
            
            return bmp;

        }


    }
}
