using System.Windows.Forms;

namespace ContactAppUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = GitHubLinkLabel.Text;
            System.Diagnostics.Process.Start(url);
        }
        private void DiscordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = DiscordLink.Text;
            System.Diagnostics.Process.Start(url);
        }

        private void EmaleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://mail.ru";
            System.Diagnostics.Process.Start(url);
        }

        private void AboutForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
