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
            ((System.ComponentModel.ISupportInitialize)(this.pbSpielfeld)).BeginInit();
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
            // FrmHauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 478);
            this.Controls.Add(this.pbSpielfeld);
            this.Name = "FrmHauptfenster";
            this.Text = "FrmHauptfenster";
            this.Load += new System.EventHandler(this.FrmHauptfenster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpielfeld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSpielfeld;


    }
}