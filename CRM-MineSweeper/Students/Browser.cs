using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void webAddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                navigate();
            }
        }
        private void navigate()
        {
            String webAddress = webAddressTextBox.Text;
            if (!webAddress.Contains("http://") && !webAddress.Contains("https://"))
            {
                webAddress = "http://" + webAddress;
            }
            webBrowser.Navigate(webAddress);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String title = webBrowser.Document.Title;
            this.Text = title;
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
            homeButton_Click(homeButton, null);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            webAddressTextBox.Text = "www.google.com";
            navigate();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            navigate();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webAddressTextBox.Text = e.Url.AbsoluteUri;
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.CurrentProgress < e.MaximumProgress)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress/1024);
                progressBar1.Value = Convert.ToInt32(e.CurrentProgress/1024);
            }
            else
            {
                progressBar1.Value = 0;
            }
            
        }

        private void webAddressTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
