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
                items = xdoc.Root.Descendants("item").Select(x => new ItemData
                {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link"),
                    PubDate = (DateTime)x.Element("pubDate"),
                    Description = (string)x.Element("description")
                });
                foreach (var item in items)
                {
                    lbTitles.Items.Add(item.Title);
                }

            }

        }
        private void lbTitles_Click(object sender, EventArgs e)
        {
            string link = (items.ToArray())[lbTitles.SelectedIndex].Link; //配列に変換して[]でアクセス
            lbDescription.Text = "概要\n";
            lbDescription.Text += (items.ToArray())[lbTitles.SelectedIndex].Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wbForm = new Form2((items.ToArray())[lbTitles.SelectedIndex].Link);
            wbForm.Show();
        }
    }
}
