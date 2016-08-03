#region Imports

using System;
using System.Windows.Forms;

#endregion

namespace ParvoICUStatsAnalyser
{
    public partial class PageRipper : Form
    {
        #region Member Variables

        private readonly string[] _mResultDocumentTexts;
        private readonly HtmlAgilityPack.HtmlDocument[] _mResultHtmlDocuments;
        private readonly string[] _mUrls;
        private int _mCurrentIndex;
        private bool _mDone;

        #endregion

        #region Accessors

        public string[] Urls
        {
            get { return _mUrls; }
        }

        public string[] ResultDocumentTexts
        {
            get { return _mResultDocumentTexts; }
        }

        public HtmlAgilityPack.HtmlDocument[] ResultHtmlDocuments
        {
            get { return _mResultHtmlDocuments; }
        }

        public bool Done
        {
            get { return _mDone; }
        }

        public int CurrentIndex
        {
            get { return _mCurrentIndex; }
        }

        #endregion

        #region Constructor

        public PageRipper(string[] urls)
        {
            InitializeComponent();

            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;

            _mDone = false;
            _mCurrentIndex = 0;
            _mUrls = urls;
            _mResultDocumentTexts = new string[urls.Length];
            _mResultHtmlDocuments = new HtmlAgilityPack.HtmlDocument[urls.Length];

            progressBar.Maximum = urls.Length;
        }

        #endregion

        #region Event Callbacks

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath == @"/sms3/forms/signinout.aspx")
            {
                if (webBrowser.Document != null)
                {
                    var shelderIdTextBox = webBrowser.Document.GetElementById("cphSearchArea_txtShelterPetFinderId");
                    var usernameTextBox = webBrowser.Document.GetElementById("cphSearchArea_txtUserName");
                    var passwordTextBox = webBrowser.Document.GetElementById("cphSearchArea_txtPassword");
                    var signInButton = webBrowser.Document.GetElementById("cphSearchArea_btn_SignIn");

                    if (shelderIdTextBox != null)
                        shelderIdTextBox.SetAttribute("value", "");
                    if (usernameTextBox != null)
                        usernameTextBox.SetAttribute("value", "");
                    if (passwordTextBox != null)
                        passwordTextBox.SetAttribute("value", "");
                    if (signInButton != null)
                        signInButton.InvokeMember("click");
                }
            }
            else if (e.Url.AbsolutePath == @"/sms3/forms/default.aspx")
            {
                webBrowser.Navigate(_mUrls[_mCurrentIndex]);

                _mCurrentIndex++;

                progressBar.Value = _mCurrentIndex;
                label_progress.Text = progressBar.Value + "/" + progressBar.Maximum;
            }
            else
            {
                _mResultDocumentTexts[_mCurrentIndex - 1] = webBrowser.DocumentText;
                _mResultHtmlDocuments[_mCurrentIndex - 1] = new HtmlAgilityPack.HtmlDocument();
                _mResultHtmlDocuments[_mCurrentIndex - 1].LoadHtml(webBrowser.DocumentText);

                if (_mCurrentIndex == _mUrls.Length)
                {
                    _mDone = true;
                    Close();
                    return;
                }

                webBrowser.Navigate(_mUrls[_mCurrentIndex]);

                _mCurrentIndex++;

                progressBar.Value = _mCurrentIndex;
                label_progress.Text = progressBar.Value + "/" + progressBar.Maximum;
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            if (_mUrls.Length == 0)
            {
                Close();
                return;
            }

            webBrowser.Navigate(
                @"http://sms.petpoint.com/sms3/forms/signinout.aspx?ReturnUrl=%2fsms3%2fforms%2fdefault.aspx");
        }

        #endregion
    }
}