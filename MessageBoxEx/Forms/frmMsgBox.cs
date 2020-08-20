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
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

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

        private Label lblUrl = new Label();

        private List<MessageBoxExButton> buttons = new List<MessageBoxExButton>();

        private bool resultsSet = false;
        private WebBrowser browser;

        private bool urlClickClose = false;

        public bool Dismissed { get; private set; }

        public MessageBoxExResult Result { get; private set; }

        public object CustomResult { get; set; }

        public frmMsgBox()
        {
            InitializeComponent();

            lblUrl.ForeColor = Color.Blue;
            lblUrl.Font = new Font(lblUrl.Font, FontStyle.Underline);
            lblUrl.Cursor = Cursors.Hand;
            lblUrl.Click += LblUrl_Click;

            // InitBrowser();
        }

        private void LblUrl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start((string)lblUrl.Tag);

            if (urlClickClose) this.Close();
        }

        private void ClearButtons()
        {
            pnlButtons.Controls.Clear();

            foreach (var b in this.buttons)
            {
                if (b.Button != null)
                {
                    b.Button.KeyDown -= Btn_KeyDown;
                    b.Button.Click -= Btn_Click;
                    b.Button.Dispose();
                    
                    b.Button = null;
                    b.Container = null;
                    b.ContextMenu = null;
                }
            }

            this.buttons.Clear();
            GC.Collect(0);
        }
        
        protected override void OnShown(EventArgs e)
        {
            resultsSet = false;

            foreach (var b in buttons)
            {
                if (b.IsDefault)
                {
                    b.Button.Focus();
                    return;
                }
            }

            base.OnShown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!resultsSet)
            {
                Dismissed = true;

                foreach (var b in buttons)
                {
                    if (b.IsDefault)
                    {
                        SetResult(b);
                        break;
                    }
                }

                // still not set? use the first one.
                if (!resultsSet)
                {
                    SetResult(buttons[0]);
                }
            }
            else
            {
                Dismissed = false;
            }

            base.OnClosing(e);
        }

        public void SetButtons(IEnumerable<MessageBoxExButton> buttons)
        {
            ClearButtons();
            Size containerSize;

            foreach (var exBtn in buttons)
            {
                this.buttons.Add(exBtn);

                containerSize = ButtonSize;

                var container = new PictureBox()
                {
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Transparent,
                    Tag = exBtn
                };

                var btn = new Button()
                {
                    Size = ButtonSize,
                    Text = exBtn.Message,
                    Padding = new Padding(0),
                    Margin = new Padding(0),
                    BackColor = SystemColors.Control,
                    Visible = true,
                    Left = 0,
                    Top = 0,
                    Tag = exBtn
                };

                if (exBtn.Image != null)
                {
                    btn.Image = ScaleBitmap(exBtn.Image, 16, 16);

                    btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                    btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                    btn.Width += 28;
                    btn.Padding = new Padding(0);
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                }

                exBtn.Button = btn;
                exBtn.Container = container;

                btn.Visible = true;
                btn.Enabled = true;
                btn.Click += Btn_Click;
                btn.KeyDown += Btn_KeyDown;

                container.Controls.Add(btn);

                if (exBtn.DropDownPlacement != DropDownPlacement.None && exBtn.DropDownMenuButtons?.Count > 0)
                {

                    if (exBtn.DropDownPlacement == DropDownPlacement.Left)
                    {
                        btn.Left = 16;
                    }

                    containerSize.Width += 16;

                    btn = new Button()
                    {
                        Text = "▼",
                        Font = new Font(new FontFamily("Segoe UI"), 5.0F, FontStyle.Bold),
                        BackColor = SystemColors.Control,
                        Padding = new Padding(0),
                        Margin = new Padding(0),
                        Visible = true,
                        Width = 16,
                        Height = ButtonSize.Height,
                        ContextMenu = new ContextMenu(),
                        TabStop = false,
                        Left = 0,
                        Top = 0,
                        Tag = exBtn
                    };

                    if (exBtn.DropDownPlacement == DropDownPlacement.Right)
                    {
                        btn.Left = ButtonSize.Width;
                    }

                    btn.Visible = true;
                    btn.Enabled = true;
                    btn.Click += Btn_Click;

                    container.Controls.Add(btn);

                    exBtn.ContextMenu = btn.ContextMenu;

                    foreach (var subBtn in exBtn.DropDownMenuButtons)
                    {
                        this.buttons.Add(subBtn);

                        var cm = new MenuItem
                        {
                            Text = subBtn.Message,
                            Visible = true,
                            Tag = subBtn
                        };

                        cm.Click += Btn_Click;
                        btn.ContextMenu.MenuItems.Add(cm);

                        if (subBtn.Image != null)
                        {
                            //cm.Im= ScaleBitmap(b.Image, 16, 16);

                            //btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                            //btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                            //btn.Width += 28;
                            //btn.Padding = new Padding(0);
                            //btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                        }

                    }

                }

                container.Size = containerSize;
                pnlButtons.Controls.Add(container);
            }



        }

        private void Btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                if (sender is Button ctrl && ctrl.Tag is MessageBoxExButton b)
                {
                    if (b.ContextMenu != null)
                    {
                        OpenButtonMenu(b);
                    }
                }
            }
            if (e.KeyCode == Keys.Return && e.Modifiers == Keys.Control)
            {
                if (pnlButtons.Controls.Contains(lblUrl)) 
                {
                    this.LblUrl_Click(this, new EventArgs());
                }
                e.SuppressKeyPress = true;
            }
        }

        private void OpenButtonMenu(MessageBoxExButton b)
        {
            if (b.Button is Button btnCtl)
            {

                if (b.DropDownPlacement == DropDownPlacement.Left)
                {
                    b.ContextMenu.Show(btnCtl, new Point(0, btnCtl.Height));
                }
                else if (b.DropDownPlacement == DropDownPlacement.Right)
                {
                    b.ContextMenu.Show(btnCtl, new Point(btnCtl.Width, btnCtl.Height), LeftRightAlignment.Left);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender is Button btnCtl && btnCtl.Tag is MessageBoxExButton b)
            {
                if (b.ContextMenu != null && btnCtl.ContextMenu != null)
                {
                    OpenButtonMenu(b);
                }
                else
                {
                    SetResult(b);
                    this.Close();
                }

            }
            else if (sender is MenuItem item && item.Tag is MessageBoxExButton b2)
            {
                SetResult(b2);
                this.Close();
            }
        }

        private void SetResult(MessageBoxExButton result)
        {

            Result = result.Result;
            CustomResult = result.CustomResult;

            if (result.CustomResult == null)
                CustomResult = result.Result.ToString();

            resultsSet = true;

        }

        private bool docLoaded = false;

        public void SetMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;


        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            docLoaded = true;

            browser.Width = browser.Document.Body.ScrollRectangle.Width;
            browser.Height = browser.Document.Body.ScrollRectangle.Height;
            browser.Visible = true;

            FormatBox();


        }

        public void SetIcon(Bitmap icon)
        {
            pbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIcon.Visible = (icon != null);
            pbIcon.Image = icon;
        }

        public bool OptionResult
        {
            get => chkOption.Checked;
            set => chkOption.Checked = value;
        }

        public void SetOption(bool visible, string message = null)
        {

            if (visible)
            {
                SetUrl(false);
                chkOption.Text = message;
                pnlButtons.Controls.Add(chkOption);
            }
            else
            {
                chkOption.Text = "";
                pnlButtons.Controls.Remove(chkOption);
            }

        }

        public void SetUrl(bool visible, string message = null, string url = null, bool urlClickDismiss = false)
        {
            if (visible)
            {
                SetOption(false);
                urlClickClose = urlClickDismiss;

                lblUrl.Text = message;
                lblUrl.Tag = url;

                pnlButtons.Controls.Add(lblUrl);
            }
            else
            {
                lblUrl.Text = "";
                lblUrl.Tag = null;

                pnlButtons.Controls.Remove(lblUrl);
            }

        }

        internal void FormatBox()
        {
            int btnsTotal = 0;

            int lblStart;

            this.Height = BaseHeight;


            Control msgCtrl;

            msgCtrl = lblMessage;
                        
            int ly = (this.Height / 2) - (msgCtrl.Height / 2) - ButtonAreaHeight;

            if (ly < 0)
            {
                this.Height += (-2 * ly) + (VerticalMargin * 2);
                ly = (this.Height / 2) - (msgCtrl.Height / 2) - ButtonAreaHeight;
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

            msgTotal += msgCtrl.Width;
            msgCtrl.Left = lblStart;
            msgCtrl.Top = ly;

            pbIcon.Top = py;
            pbIcon.Left = RMarginImage;

            foreach (var b in buttons)
            {
                if (b.Container == null) continue;

                btnsTotal += b.Container.Width;
                b.Container.Top = by;
            }

            if (pnlButtons.Controls.Contains(chkOption))
            {
                chkOption.AutoSize = true;

                btnsTotal += chkOption.Width + 32;

                chkOption.Left = 16;
                chkOption.Top = (21 - (chkOption.Height / 2));

                chkOption.Visible = true;

            }
            else if (pnlButtons.Controls.Contains(lblUrl))
            {
                lblUrl.AutoSize = true;

                btnsTotal += lblUrl.Width + 32;

                lblUrl.Left = 16;
                lblUrl.Top = (21 - (lblUrl.Height / 2));

                lblUrl.Visible = true;

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
                if (b.Container == null) continue;

                bx -= (b.Container.Width + ButtonSpacing);

                b.Container.Left = bx;
                b.Container.BringToFront();
                b.Container.Visible = true;

            }



        }

        public Bitmap ScaleBitmap(Bitmap image, int cx, int cy)
        {

            var bmp = new Bitmap((int)cx, (int)cy);
            var graph = Graphics.FromImage(bmp);
            
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            graph.DrawImage(image, 0, 0, cx, cy);

            graph.Dispose();
            
            return bmp;

        }

    }
}
