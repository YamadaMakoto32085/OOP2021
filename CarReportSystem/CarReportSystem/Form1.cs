using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    [Serializable]
    public partial class fmMain : Form {
        BindingList<CarReport> listCarReport = new BindingList<CarReport>();

        public fmMain() {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e) {
            Application.Exit(); //アプリケーション終了
        }

        //画像開くボタン
        private void btPictureOpen_Click(object sender, EventArgs e) {
            if(ofdPictureOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPictureOpen.FileName);
            }
        }

        //画像削除ボタン
        private void btPictureDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //選択されているメーカーの列挙型を返す
        private CarReport.MakerGroup selectedGroup() {
            foreach(var rb in gbMaker.Controls) {
                if (((RadioButton)rb).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((string)((RadioButton)rb).Tag));
                }
            }
            return CarReport.MakerGroup.その他;
        }

        //コンボボックスに記録者をセットする
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }
        }
        //コンボボックスに車名をセットする
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void dgvRegistData_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;
            
            //選択された行のデータを取得
            CarReport selectedCar = listCarReport[e.RowIndex];

            //取得したデータ項目を各コントロールへ設定
            dtpDate.Value = selectedCar.Date;
            cbAuthor.Text = selectedCar.Auther;
            setMakerRadioButton(selectedCar.Maker);
            cbCarName.Text = selectedCar.CarName;
            tbReport.Text = selectedCar.Report;
            pbPicture.Image = selectedCar.Picture;
        }

        private void setMakerRadioButton(CarReport.MakerGroup mg) {
            switch (mg) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.外国車:
                    rbImport.Checked = true;
                    break;
                default:    //その他
                    rbOther.Checked = true;
                    break;
            }
        }
        //更新イベントボタン処理
        private void btUpdate_Click(object sender, EventArgs e) {
            if (carReportDataGridView.CurrentRow == null) return;

            carReportDataGridView.CurrentRow.Cells[1].Value = dtpDate.Value;    //日付
            carReportDataGridView.CurrentRow.Cells[2].Value = cbAuthor.Text;    //記録者
            carReportDataGridView.CurrentRow.Cells[3].Value = selectedGroup();  //メーカー
            carReportDataGridView.CurrentRow.Cells[4].Value = cbCarName.Text;   //車名
            carReportDataGridView.CurrentRow.Cells[5].Value = tbReport.Text;    //レポート
            carReportDataGridView.CurrentRow.Cells[6].Value = ImageToByteArray(pbPicture.Image);  //画像

            //データベースへ反映
            this.Validate();
            this.carReportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202112DataSet);
#if false
            if(sfdFileSave.ShowDialog() == DialogResult.OK) {
                //バイナリ形式でシリアル化
                var bf = new BinaryFormatter();
                using (FileStream fs = File.Open(sfdFileSave.FileName, FileMode.Create)) {
                    bf.Serialize(fs, listCarReport);
                }
            }
#endif
        }

        private void btConnect_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202112DataSet.CarReport' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableAdapter.Fill(this.infosys202112DataSet.CarReport);

            //読み込んだデータを各コンボボックスに登録する
            foreach (var item in listCarReport)
            {
                setCbAuthor(item.Auther);
                setCbCarName(item.CarName);
            }
            for (int i = 0; i < carReportDataGridView.RowCount; i++)
            {
                setCbAuthor(carReportDataGridView.Rows[i].Cells[1].Value.ToString());
                setCbCarName(carReportDataGridView.Rows[i].Cells[3].Value.ToString());
            }

#if false
            if(ofdFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式で逆シリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(ofdFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        //逆シリアル化して読み込む
                        listCarReport = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRegistData.DataSource = null;
                        dgvRegistData.DataSource = listCarReport;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                //読み込んだデータを各コンボボックスに登録する
                foreach(var item in listCarReport) {
                    setCbAuthor(item.Auther);
                    setCbCarName(item.CarName);
                }
                //for (int i = 0; i < dgvRegistData.RowCount; i++) {
                //    setCbAuthor(dgvRegistData.Rows[i].Cells[1].Value.ToString());
                //    setCbCarName(dgvRegistData.Rows[i].Cells[1].Value.ToString());
                //}
            }
#endif
        }

        private void fmMain_Load(object sender, EventArgs e) {
            carReportDataGridView.Columns[0].Visible = false;
            carReportDataGridView.Columns[1].HeaderText = "日付";
            carReportDataGridView.Columns[2].HeaderText = "記録者";
            carReportDataGridView.Columns[3].HeaderText = "メーカー";
            carReportDataGridView.Columns[4].HeaderText = "車名";
            carReportDataGridView.Columns[5].HeaderText = "レポート";
            carReportDataGridView.Columns[6].Visible = false;
        }

        private void carReportBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carReportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202112DataSet);

        }

        private void carReportDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (carReportDataGridView.CurrentRow == null) return;
            try
            {
                ssErrorLavel.Text = "";
                dtpDate.Value = (DateTime)carReportDataGridView.CurrentRow.Cells[1].Value;  //日付
                cbAuthor.Text = carReportDataGridView.CurrentRow.Cells[2].Value.ToString(); //記録者
                cbCarName.Text = carReportDataGridView.CurrentRow.Cells[4].Value.ToString();//車名
                tbReport.Text = carReportDataGridView.CurrentRow.Cells[5].Value.ToString(); //レポート
                //メーカー(文字列 → 列挙型)
                var mk = (CarReport.MakerGroup)Enum.Parse(typeof(CarReport.MakerGroup), carReportDataGridView.CurrentRow.Cells[3].Value.ToString());
                setMakerRadioButton(mk);
                pbPicture.Image = ByteArrayToImage((byte[])carReportDataGridView.CurrentRow.Cells[6].Value);
            }
            catch (InvalidCastException)
            {
                pbPicture.Image = null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ssErrorLavel.Text = ex.Message;
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b)
        {
            Image img = null;
            if (b.Length > 0)
            {
                ImageConverter imgconv = new ImageConverter();
                img = (Image)imgconv.ConvertFrom(b);
            }
            return img;
        }
        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void carReportDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        //新規追加ボタン押下
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            cbCarName.Text = "";
            tbReport.Text = "";
            setMakerRadioButton(CarReport.MakerGroup.その他);
            pbPicture.Image = null;
        }
    }
}
