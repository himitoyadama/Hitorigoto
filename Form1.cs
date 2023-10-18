using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ブラウザの作成
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Browser.Url = new Uri("https://www.google.com/ ");
            {
                FavoriteData data = new FavoriteData();
                data.Title = "google";
                data.Url = "https://www.google.com/";

                FirstFavorite.Items.Add(data);
            }
            
            {
                FavoriteData data = new FavoriteData();
                data.Title = "google";
                data.Url = "http://goo.ne.jp/";

                FirstFavorite.Items.Add(data);
            }

            
            


            
           
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
            FavoriteData data = (FavoriteData)FirstFavorite.Items[FirstFavorite.SelectedIndex];
            
            Browser.Url = new Uri(data.Url);
        }

        private void AddFavorite_Click(object sender, EventArgs e)
        {
            /*FavoriteData data = (FavoriteData)FirstFavorite.Items[FirstFavorite.SelectedIndex];
            Browser.Url = new Uri(data.Url);*/

            FavoriteData data = new FavoriteData();
            data.Title = Browser.DocumentTitle;
            data.Url = Browser.Url.ToString();

            FirstFavorite.Items.Add(data);
        }

        private void DeleteFavorite_Click(object sender, EventArgs e)
        {
            FavoriteData data = (FavoriteData)FirstFavorite.Items[FirstFavorite.SelectedIndex];

            FirstFavorite.Items.Remove(data);
        }
    }
    public class FavoriteData
    {
        public string Title = "";
        public string Url = "";

        public override string ToString() {
        return Title;
        }
    }
}
