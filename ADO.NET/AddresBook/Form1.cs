﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddresBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202112DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            personDataGridView.Columns[0].Visible = false;
            personDataGridView.Columns[1].HeaderText = "名前";
            personDataGridView.Columns[2].HeaderText = "誕生日";
            personDataGridView.Columns[3].HeaderText = "電話番号";
            personDataGridView.Columns[4].HeaderText = "備考";
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'infosys202112DataSet.Person' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.personTableAdapter.Fill(this.infosys202112DataSet.Person);
        }

        private void btNameFilter_Click(object sender, EventArgs e)
        {
            this.personTableAdapter.FillByName(this.infosys202112DataSet.Person, tbNameSearch.Text);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            personDataGridView.CurrentRow.Cells[1].Value = tbName.Text;
            personDataGridView.CurrentRow.Cells[2].Value = dtpDate.Value;
            personDataGridView.CurrentRow.Cells[3].Value = tbTelephone.Text;
            personDataGridView.CurrentRow.Cells[4].Value = tbMemo.Text;
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202112DataSet);
        }

        private void personDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //0件なら処理をしない
            if(personDataGridView.Rows.Count != 0)
            {
                tbName.Text = personDataGridView.CurrentRow.Cells[1].Value.ToString();
                dtpDate.Value = (DateTime)personDataGridView.CurrentRow.Cells[2].Value;
                tbTelephone.Text = personDataGridView.CurrentRow.Cells[3].Value.ToString();
                tbMemo.Text = personDataGridView.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btBirthdayFilter_Click(object sender, EventArgs e)
        {
            this.personTableAdapter.FillByBirthday(this.infosys202112DataSet.Person, dateTimePicker1.Text);
        }
    }
}
