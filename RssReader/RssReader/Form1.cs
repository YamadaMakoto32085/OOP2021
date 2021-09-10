using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader
{
    public partial class Form1 : Form
    {
        IEnumerable<ItemData> items = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            setRssTitle(tbUrl.Text);
        }

        //指定したURL先からXMLデータを取得し、title要素を取得し、リストボックスへセットする
        private void setRssTitle(string uri)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");

                var stream = wc.OpenRead(uri);

                XDocument xdoc = XDocument.Load(stream);
                var items = xdoc.Root.Descendants("item");
                foreach (var item in items)
                {
                    lbTitles.Items.Add(item.Element("title").Value);
                }

            }

        }
        private void lbTitles_Click(object sender, EventArgs e)
        {
            string link = (items.ToArray())[lbTitles.SelectedIndex].Link; //配列に変換して[]でアクセス
            wbBrowser.Url = new Uri(link);
        }
    }
}
