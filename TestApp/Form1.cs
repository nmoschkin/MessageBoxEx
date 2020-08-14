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

        private void button1_Click(object sender, EventArgs e)
        {
            bool remind;

            var res = MessageBoxEx.Show(
                "An upgrade to this product is available.\r\nWould you like to upgrade, now?",
                "Upgrade",
                "Remind me, later.",
                MessageBoxExButtonSet.YesNo,
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
                Icon = MessageBoxExIcons.Information,
                OptionTextUrl = "https://www.google.com/",
                OptionText = "Go To Google",
                Message = "There is an incoming message for you from Google.",
                Title = "New Message",
                MessageBoxType = MessageBoxExButtonSet.OK,
                OptionMode = OptionTextMode.Url
            };

            var res = MessageBoxEx.Show(cfg);


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

            var res = MessageBoxEx.Show(cfg);

            string s = "We have recorded your company's program as '" + (string)cfg.CustomResult + "'";
            
            if (cfg.OptionResult)
            {
                s += "\r\nWe have recorded that you work for a subsidiary.";
            }
            else
            {
                s += "\r\nWe have recorded that you do not work for a subsidiary.";
            }

            MessageBoxEx.Show(s, "Details Recorded", MessageBoxExButtonSet.OK, MessageBoxExIcons.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBoxEx.Show("You need permission to access this device.", "Access Denied", MessageBoxExButtonSet.AbortRetryIgnore, MessageBoxExIcons.Shield);

        }
    }
}
