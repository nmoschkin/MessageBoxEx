using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTools.MessageBoxEx;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    bool remind;

        //    var res = MessageBoxEx.Show(
        //        "An upgrade to this product is available.\r\nWould you like to upgrade, now?",
        //        "Upgrade",
        //        "Remind me, later.",
        //        MessageBoxExType.YesNo,
        //        MessageBoxExIcons.Information, out remind);


        //    if (remind)
        //    {
        //        if (res == MessageBoxExResult.No)
        //            MessageBoxEx.Show("You will be reminded, later.");

        //    }
        //    else
        //    {
        //        MessageBoxEx.Show("We won't bother you, again.");

        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            bool remind;

            MessageBoxEx.ResourceTextConfig.CultureInfo = new System.Globalization.CultureInfo("fr");

            var res = MessageBoxEx.Show(
                "Une mise à niveau de ce produit est disponible.\r\nSouhaitez-vous mettre à niveau maintenant?",
                "Faire mise a niveau",
                "Rappelle-moi plus tard.",
                MessageBoxExType.YesNo,
                MessageBoxExIcons.Information, out remind);


            if (remind)
            {
                if (res == MessageBoxExResult.No)
                    MessageBoxEx.Show("You will be reminded, later.");

            }
            else
            {
                MessageBoxEx.Show("We won't bother you, again.");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cfg = new MessageBoxExConfig()
            {
                Icon = MessageBoxExIcons.Custom,
                CustomIcon = Resources.Nurse,
                OptionTextUrl = "https://outlook.com/",
                OptionText = "Go To Your Calendar",
                Message = "There is an incoming message from you Doctor.",
                Title = "New Doctor's Alert",
                MessageBoxType = MessageBoxExType.OKCancel,
                OptionMode = OptionTextMode.Url
            };

            var res = MessageBoxEx.ShowInNewProcess(cfg, false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cfg = new MessageBoxExConfig()
            {
                Icon = MessageBoxExIcons.Question,
                OptionText = "I work for a subsidiary.",
                Title = "Confirm Industry Program",
                Message = "Choose your company's default program.",
                OptionMode = OptionTextMode.Checkbox
            };

            cfg.CustomButtons.Add(new MessageBoxExButton("&Livestock", "Livestock", false));
            cfg.CustomButtons.Add(new MessageBoxExButton("&Agriculture", "Agriculture", false));
            cfg.CustomButtons.Add(new MessageBoxExButton("&Textiles", "Textiles", false));

            var button = cfg.CustomButtons[0];

            button.DropDownMenuButtons.Add(new MessageBoxExButton("&Cattle", "Cattle"));
            button.DropDownMenuButtons.Add(new MessageBoxExButton("Por&k", "Pork"));
            button.DropDownMenuButtons.Add(new MessageBoxExButton("&Poultry", "Poultry"));
            button.DropDownMenuButtons.Add(new MessageBoxExButton("&Husbandry / Other", "Husbandry / Other"));
            button.DropDownPlacement = DropDownPlacement.Right;

            var res = MessageBoxEx.ShowInNewProcess(cfg, false);


            string s = "We have recorded your company's program as '" + (string)cfg.CustomResult + "'";
            
            if (cfg.OptionResult)
            {
                s += "\r\nWe have recorded that you work for a subsidiary.";
            }
            else
            {
                s += "\r\nWe have recorded that you do not work for a subsidiary.";
            }

            MessageBoxEx.Show(s, "Details Recorded", MessageBoxExType.OK, MessageBoxExIcons.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("DataTools.MessageBoxEx supports a number of features:");
            sb.AppendLine("");
            sb.AppendLine("* Custom Buttons");
            sb.AppendLine("* Custom Icons");
            sb.AppendLine("");
            sb.AppendLine("* Control Over Sounds");
            sb.AppendLine("");
            sb.AppendLine("* Standard System Dialog Boxes");
            sb.AppendLine("");
            sb.AppendLine("* Check Boxes");
            sb.AppendLine("* Hyper Links");
            sb.AppendLine("");
            sb.AppendLine("* Drop Down Menus");
            sb.AppendLine("");
            sb.AppendLine("* Accommodation for Messages of large height, and width. (Although, we trust people to try to be brief as possible.)");
            sb.AppendLine("");
            sb.AppendLine("Copyright (C) Nathaniel Moschkin.  Licensed under the MIT license.");

            var cfg = new MessageBoxExConfig()
            {
                Icon = MessageBoxExIcons.Information,
                OptionText = "Click here to go to the MessageBoxEx GitHub!",
                OptionTextUrl = "https://github.com/ironywrit/MessageBoxEx",
                Title = "About DataTools.MessageBoxEx",
                Message = sb.ToString(),
                UrlClickDismiss = true,
                OptionMode = OptionTextMode.Url
            };

            MessageBoxEx.Show(cfg);

        }
    }
}
