
namespace StopWatch {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btStart = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.tmDisp = new System.Windows.Forms.Timer(this.components);
            this.lbLapDisp = new System.Windows.Forms.ListBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btLapTime = new System.Windows.Forms.Button();
            this.lbTimerDisp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStart.Location = new System.Drawing.Point(16, 67);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(96, 43);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "スタート";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btReset.Location = new System.Drawing.Point(132, 67);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(91, 43);
            this.btReset.TabIndex = 2;
            this.btReset.Text = "リセット";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // tmDisp
            // 
            this.tmDisp.Tick += new System.EventHandler(this.tmDisp_Tick);
            // 
            // lbLapDisp
            // 
            this.lbLapDisp.FormattingEnabled = true;
            this.lbLapDisp.ItemHeight = 12;
            this.lbLapDisp.Location = new System.Drawing.Point(229, 12);
            this.lbLapDisp.Name = "lbLapDisp";
            this.lbLapDisp.Size = new System.Drawing.Size(170, 148);
            this.lbLapDisp.TabIndex = 3;
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStop.Location = new System.Drawing.Point(16, 116);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(96, 39);
            this.btStop.TabIndex = 4;
            this.btStop.Text = "ストップ";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btLapTime
            // 
            this.btLapTime.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btLapTime.Location = new System.Drawing.Point(132, 116);
            this.btLapTime.Name = "btLapTime";
            this.btLapTime.Size = new System.Drawing.Size(91, 39);
            this.btLapTime.TabIndex = 5;
            this.btLapTime.Text = "ラップ";
            this.btLapTime.UseVisualStyleBackColor = true;
            this.btLapTime.Click += new System.EventHandler(this.btLapTime_Click);
            // 
            // lbTimerDisp
            // 
            this.lbTimerDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbTimerDisp.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTimerDisp.Location = new System.Drawing.Point(16, 12);
            this.lbTimerDisp.Multiline = true;
            this.lbTimerDisp.Name = "lbTimerDisp";
            this.lbTimerDisp.Size = new System.Drawing.Size(207, 49);
            this.lbTimerDisp.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 168);
            this.Controls.Add(this.lbTimerDisp);
            this.Controls.Add(this.btLapTime);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.lbLapDisp);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Timer tmDisp;
        private System.Windows.Forms.ListBox lbLapDisp;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btLapTime;
        private System.Windows.Forms.TextBox lbTimerDisp;
    }
}

