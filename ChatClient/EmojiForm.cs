using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class EmojiForm : Form
    {
        public string SelectedEmoji { get; private set; } = "";

        public EmojiForm()
        {
            InitializeComponent();
            LoadEmoji();
        }
        private readonly string[] emojis =
        {
            "😀","😁","😂","🤣","😅","😊","😍","😘",
            "😎","😭","😡","🤔","😴","🥳","🤩","😇",

            "👍","👎","👏","🙏","💪","👌","🤝","👋",

            "❤️","💙","💚","💛","🧡","💜","🖤","🤍",

            "🔥","⭐","✨","💯","🎉","🎂","🎁","🚀",

            "🍔","🍕","☕","🍺","⚽","🏀","🎮","🎵"
        };

        private void LoadEmoji()
        {
            foreach (string emoji in emojis)
            {
                Button btn = new Button();

                btn.Width = 45;
                btn.Height = 45;

                btn.Font = new Font("Segoe UI Emoji", 16);

                btn.Text = emoji;

                btn.Click += Emoji_Click;

                flpEmoji.Controls.Add(btn);
            }
        }
        private void Emoji_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender!;

            SelectedEmoji = btn.Text;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
