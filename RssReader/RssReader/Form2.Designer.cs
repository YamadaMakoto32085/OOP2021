
namespace RssReader
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btBack = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(13, 13);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 0;
            this.btBack.Text = "戻る";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btGo
            // 
            this.btGo.Location = new System.Drawing.Point(126, 13);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(75, 23);
            this.btGo.TabIndex = 1;
            this.btGo.Text = "進む";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(13, 52);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(818, 658);
            this.wbBrowser.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 722);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.btBack);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.WebBrowser wbBrowser;
    }
}