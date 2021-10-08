using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SendMail
{
    public class Settings
    {
        private static Settings instance = null;

        //送信データ設定済み
        public static bool Set { get; private set; } = true;

        public int Port { get; set; }  //ポート番号
        public string Host { get; set; }     //ホスト名
        public string MailAddr { get; set; } //メールアドレス
        public string Pass { get; set; }     //パスワード
        public bool Ssl { get; set; }  //SSL

        //コンストラクタ
        private Settings()
        {
            
        }

        //インスタンスの取得
        public static Settings getInstance()
        {
            if(instance == null)
            {
                instance = new Settings();

                //XMLファイルを読み込み(逆シリアル化) [P303参照]
                try
                {
                    using (var reader = XmlReader.Create("mailsetting.xml"))
                    {
                        var serializer = new DataContractSerializer(typeof(Settings));
                        var readSettings = serializer.ReadObject(reader) as Settings;

                        instance.Host = readSettings.Host;
                        instance.Port = readSettings.Port;
                        instance.MailAddr = readSettings.MailAddr;
                        instance.Pass = readSettings.Pass;
                        instance.Ssl = readSettings.Ssl;
                    }
                }
                //ファイルがない場合(初回起動時)
                catch (Exception ex)
                {
                    Set = false;  //データ未設定
                }
            }
            return instance;
        }

        //送信データ登録
        public bool setSendConfig(string host, int port, string mailAddr, string pass, bool ssl)
        {
            Host = host;
            Port = port;
            MailAddr = mailAddr;
            Pass = pass;
            Ssl = ssl;

            //XMLファイルへ書き出し(シリアル化) [P302参照]
            var xws = new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = "   ",
            };

            using (var writer = XmlWriter.Create("mailsetting.xml", xws))
            {
                var serializer = new DataContractSerializer(this.GetType());
                serializer.WriteObject(writer, this);
            }

            Set = true;

            return true; //登録完了
        }

        //初期値
        public string sHost()
        {
            return "smtp.gmail.com";
        }

        public string sPort()
        {
            return 587.ToString();
        }

        public string sMailAddr()
        {
            return "ojsinfosys01@gmail.com";
        }

        public string sPass()
        {
            return "Infosys2019";
        }

        public bool bSsl()
        {
            return true;
        }
    }
}
