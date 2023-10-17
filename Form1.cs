public Form1()
{
    InitializeComponent();
}

private void Form1_Load(object sender, EventArgs e)
{
    Browser.Url = new Uri("https://www.google.com/ ");
}

private void BtnHome_Click(object sender, EventArgs e)
{
    Browser.Url = new Uri("https://www.google.com/ ");
}

private void BtnBack_Click(object sender, EventArgs e)
{
    Browser.GoBack();
}

private void BtnNext_Click(object sender, EventArgs e)
{
    Browser.GoForward();
}

private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
{

}

private void Browser_Navigated(object sender, EventArgs e)
{
    txtUrl.Text = Browser.Url.ToString();

    BtnBack.Enabled = Browser.CanGoBack;
    BtnNext.Enabled = Browser.CanGoForward;
}

private void TxtUrl_KeyDown(object sender, KeyEventArgs e)
{
    if(e.KeyCode.Equals(Keys.Enter))
    {
        Browser.Url = new Uri(txtUrl.Text);
    }
}

private void FirstFavorite_DoubleClick(object sender, EventArgs e)
{
    string url = FirstFavorite.Items[FirstFavorite.SelectedIndex].ToString();
    Browser.Url = new Uri(url);
}
