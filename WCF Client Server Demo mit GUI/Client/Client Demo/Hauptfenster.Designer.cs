namespace Client_Demo
{
    partial class Hauptfenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAnmelden = new System.Windows.Forms.Button();
            this.btnAbmelden = new System.Windows.Forms.Button();
            this.lblTxtGuid = new System.Windows.Forms.Label();
            this.lblGuid = new System.Windows.Forms.Label();
            this.lblTxtNachricht = new System.Windows.Forms.Label();
            this.lblNachricht = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnmelden
            // 
            this.btnAnmelden.Location = new System.Drawing.Point(28, 112);
            this.btnAnmelden.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnmelden.Name = "btnAnmelden";
            this.btnAnmelden.Size = new System.Drawing.Size(74, 19);
            this.btnAnmelden.TabIndex = 0;
            this.btnAnmelden.Text = "btnAnmelden";
            this.btnAnmelden.UseVisualStyleBackColor = true;
            this.btnAnmelden.Click += new System.EventHandler(this.btnAnmelden_Click);
            // 
            // btnAbmelden
            // 
            this.btnAbmelden.Location = new System.Drawing.Point(312, 112);
            this.btnAbmelden.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAbmelden.Name = "btnAbmelden";
            this.btnAbmelden.Size = new System.Drawing.Size(74, 19);
            this.btnAbmelden.TabIndex = 1;
            this.btnAbmelden.Text = "btnAbmelden";
            this.btnAbmelden.UseVisualStyleBackColor = true;
            this.btnAbmelden.Click += new System.EventHandler(this.btnAbmelden_Click);
            // 
            // lblTxtGuid
            // 
            this.lblTxtGuid.AutoSize = true;
            this.lblTxtGuid.Location = new System.Drawing.Point(26, 20);
            this.lblTxtGuid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTxtGuid.Name = "lblTxtGuid";
            this.lblTxtGuid.Size = new System.Drawing.Size(32, 13);
            this.lblTxtGuid.TabIndex = 2;
            this.lblTxtGuid.Text = "Guid:";
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(85, 20);
            this.lblGuid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(39, 13);
            this.lblGuid.TabIndex = 3;
            this.lblGuid.Text = "lblGuid";
            // 
            // lblTxtNachricht
            // 
            this.lblTxtNachricht.AutoSize = true;
            this.lblTxtNachricht.Location = new System.Drawing.Point(26, 55);
            this.lblTxtNachricht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTxtNachricht.Name = "lblTxtNachricht";
            this.lblTxtNachricht.Size = new System.Drawing.Size(56, 13);
            this.lblTxtNachricht.TabIndex = 4;
            this.lblTxtNachricht.Text = "Nachricht:";
            // 
            // lblNachricht
            // 
            this.lblNachricht.AutoSize = true;
            this.lblNachricht.Location = new System.Drawing.Point(85, 55);
            this.lblNachricht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNachricht.Name = "lblNachricht";
            this.lblNachricht.Size = new System.Drawing.Size(63, 13);
            this.lblNachricht.TabIndex = 5;
            this.lblNachricht.Text = "lblNachricht";
            // 
            // Hauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 150);
            this.Controls.Add(this.lblNachricht);
            this.Controls.Add(this.lblTxtNachricht);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.lblTxtGuid);
            this.Controls.Add(this.btnAbmelden);
            this.Controls.Add(this.btnAnmelden);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Hauptfenster";
            this.Text = "Hauptfenster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hauptfenster_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnmelden;
        private System.Windows.Forms.Button btnAbmelden;
        private System.Windows.Forms.Label lblTxtGuid;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.Label lblTxtNachricht;
        private System.Windows.Forms.Label lblNachricht;
    }
}

