namespace WindowsFormsApplication1
{
    partial class FrmHauptfenster
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
            this.pbSpielfeld = new System.Windows.Forms.PictureBox();
            this.pbVorschau = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.LvlNr = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPunkteZahl = new System.Windows.Forms.Label();
            this.lblLinien = new System.Windows.Forms.Label();
            this.lblLinienZahl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpielfeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVorschau)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSpielfeld
            // 
            this.pbSpielfeld.Location = new System.Drawing.Point(13, 13);
            this.pbSpielfeld.Name = "pbSpielfeld";
            this.pbSpielfeld.Size = new System.Drawing.Size(300, 450);
            this.pbSpielfeld.TabIndex = 0;
            this.pbSpielfeld.TabStop = false;
            this.pbSpielfeld.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSpielfeld_Paint);
            // 
            // pbVorschau
            // 
            this.pbVorschau.BackColor = System.Drawing.Color.White;
            this.pbVorschau.Location = new System.Drawing.Point(371, 50);
            this.pbVorschau.Name = "pbVorschau";
            this.pbVorschau.Size = new System.Drawing.Size(60, 90);
            this.pbVorschau.TabIndex = 1;
            this.pbVorschau.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(317, 191);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(36, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Level:";
            // 
            // LvlNr
            // 
            this.LvlNr.AutoSize = true;
            this.LvlNr.Location = new System.Drawing.Point(368, 191);
            this.LvlNr.Name = "LvlNr";
            this.LvlNr.Size = new System.Drawing.Size(42, 13);
            this.LvlNr.TabIndex = 3;
            this.LvlNr.Text = "lblLvlNr";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(317, 259);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "Score:";
            // 
            // lblPunkteZahl
            // 
            this.lblPunkteZahl.AutoSize = true;
            this.lblPunkteZahl.Location = new System.Drawing.Point(368, 259);
            this.lblPunkteZahl.Name = "lblPunkteZahl";
            this.lblPunkteZahl.Size = new System.Drawing.Size(70, 13);
            this.lblPunkteZahl.TabIndex = 5;
            this.lblPunkteZahl.Text = "lblPunktezahl";
            // 
            // lblLinien
            // 
            this.lblLinien.AutoSize = true;
            this.lblLinien.Location = new System.Drawing.Point(317, 225);
            this.lblLinien.Name = "lblLinien";
            this.lblLinien.Size = new System.Drawing.Size(38, 13);
            this.lblLinien.TabIndex = 6;
            this.lblLinien.Text = "Linien:";
            // 
            // lblLinienZahl
            // 
            this.lblLinienZahl.AutoSize = true;
            this.lblLinienZahl.Location = new System.Drawing.Point(368, 225);
            this.lblLinienZahl.Name = "lblLinienZahl";
            this.lblLinienZahl.Size = new System.Drawing.Size(64, 13);
            this.lblLinienZahl.TabIndex = 7;
            this.lblLinienZahl.Text = "lblLinienzahl";
            // 
            // FrmHauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 478);
            this.Controls.Add(this.lblLinienZahl);
            this.Controls.Add(this.lblLinien);
            this.Controls.Add(this.lblPunkteZahl);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.LvlNr);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.pbVorschau);
            this.Controls.Add(this.pbSpielfeld);
            this.Name = "FrmHauptfenster";
            this.Text = "FrmHauptfenster";
            this.Load += new System.EventHandler(this.FrmHauptfenster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpielfeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVorschau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSpielfeld;
        private System.Windows.Forms.PictureBox pbVorschau;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label LvlNr;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPunkteZahl;
        private System.Windows.Forms.Label lblLinien;
        private System.Windows.Forms.Label lblLinienZahl;


    }
}