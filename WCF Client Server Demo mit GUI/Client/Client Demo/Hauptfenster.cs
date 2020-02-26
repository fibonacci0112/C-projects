using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace Client_Demo
{
    /*
     * Interessant ist hier nur die Klasse CallbackHandler, die den CallbackContract des WCF-Service implementiert und 
     * somit die vom Server kommenden Nachrichten empfängt, sobald via Anmelden() am Server angemeldet wurde. 
     * Hier sieht man auch schon, dass bei der Generierung des IServerDuplexCallback am Client nur mehr eine Methode 
     * OnMessageReceived() vorhanden ist, während im selben Interface am Server durch das AsyncPattern noch die 
     * beiden Methoden BeginOnMessageReceived() und EndMessageReceived() definiert wurden.
     * Ganz wichtig ist hier, dass ConcurrencyMode.Reentrant verwendet wird, und der WPF-eigene SynchronizationContext 
     * deaktiviert wurde! Letzterer ist der Grund für unzählige Postings auf StackOverflow, bei denen über 
     * “hängende” Benutzeroberflächen geklagt wird. Grund dafür ist, dass die Callback-Methode am Client in einem 
     * eigenen Thread ausgeführt wird und man die GUI bekanntlich nur im GUI-Thread ändern darf. 
     * Um dieses Problem zu vereinfachen hätte WPF diesen SynchronizationContext eingeführt um dem Programmierer 
     * den manuellen BeginInvoke-Aufruf zu ersparen, nur leider funktioniert der in vielen Situation nicht ordentlich. 
     * Deshalb verlassen wir uns hier besser auf die bekannten Methoden und verwenden im Event-Handler der 
     * MainWindow-Klasse BeginInvoke() um den WCF-Thread mit dem GUI-Thread zu synchronisieren.
     */
    public partial class Hauptfenster : Form
    {
        private Guid guid;
        private ServerDuplexClient client = null;

        public Hauptfenster()
        {
            InitializeComponent();

            guid = Guid.NewGuid();

            this.Text = "Client Demo";
            lblGuid.Text = guid.ToString();
            lblNachricht.Text = String.Empty;
            btnAnmelden.Text = "Anmelden";
            btnAbmelden.Text = "Abmelden";

            // callback initialisieren
            CallbackHandler callback = new CallbackHandler();
       //     callback.MessageReceived += new CallbackHandler.MessageReceivedEventHandler(callback_OnMessageReceivedEvent);
            callback.MessageReceived += Callback_OnMessageReceivedEvent;
            InstanceContext callbackInstanceContext = new InstanceContext(callback);

            // Erstellen des WCF-Proxys
            client = new ServerDuplexClient(callbackInstanceContext);
        }


        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            client.Anmelden(guid);
        }


        private void btnAbmelden_Click(object sender, EventArgs e)
        {
            client.Abmelden(guid);
        }


        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }


        void Callback_OnMessageReceivedEvent(string text)
        {
            this.BeginInvoke((Action)(() =>
            {
                lblNachricht.Text = text;
            }));
        }
    }
}
