﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SendMail
{
    public partial class ConfigForm : Form
    {
        private Settings settings = Settings.getInstance();

        public ConfigForm()
        {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            tbHost.Text = settings.sHost();  //ホスト名
            tbPort.Text = settings.sPort();  //ポート番号
            tbUserName.Text = settings.sMailAddr();  //ユーザ名
            tbPass.Text = settings.sPass();  //パスワード
            cbSsl.Checked = settings.bSsl();  //SSL
            tbSender.Text = settings.sMailAddr();  //送信元
        }
        //OKボタン
        private void btOk_Click(object sender, EventArgs e)
        {
            btApply_Click(sender, e); //適用ボタンの処理を呼び出し
            this.Close();
        }

        //適用ボタン
        private void btApply_Click(object sender, EventArgs e)
        {
            //Settingsオブジェクトに入力データを渡して登録を行う
            settings.setSendConfig(tbHost.Text, int.Parse(tbPort.Text),
                                   tbUserName.Text, tbPass.Text, cbSsl.Checked);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //設定画面をロードすると一度だけ実行されるイベントハンドラ
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            tbHost.Text = settings.Host;
            tbPort.Text = settings.Port.ToString();
            tbUserName.Text = settings.MailAddr;
            tbPass.Text = settings.Pass;
            cbSsl.Checked = settings.Ssl;
            tbSender.Text = settings.MailAddr;
        }
    }
}
