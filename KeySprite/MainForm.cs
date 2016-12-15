using KeySprite.HearthStone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySprite
{
    public partial class MainForm : Form
    {
        private HearthStoneGame game;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (game != null && game.Running)
            {
                game.Stop();
            }
            else
            {
                Guild g = (lbGuild.SelectedItem as Tuple<Guild, string>).Item1;
                game = new HearthStoneGame(new Logger(tbLog), g);

                game.Start();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbGuild.Items.Add(Tuple.Create<Guild, string>(Guild.FS, "法师"));
            lbGuild.Items.Add(Tuple.Create<Guild, string>(Guild.MS, "牧师"));
            lbGuild.Items.Add(Tuple.Create<Guild, string>(Guild.ZS, "战士，猎人，圣骑士，术士，德鲁伊，潜行者"));
            lbGuild.ValueMember = "Item1";
            lbGuild.DisplayMember = "Item2";
            lbGuild.SelectedIndex = 0;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Point? pt = new HearthStoneGame(new Logger(tbLog), Guild.FS).FindOneOpTauntMinionNew();
            if (pt != null)
            {
                tbLog.AppendText(pt.ToString());
                tbLog.AppendText("\r\n");
            }
        }
    }
}
