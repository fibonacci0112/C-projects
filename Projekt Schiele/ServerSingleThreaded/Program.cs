using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace ServerSingleThreaded
{
    class Program
    {
        private static int PORT = 1337;
        private static List<Client> clients;
        private static Spielfeld s;
        private static string[] aktuellekoordinaten;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            clients = new List<Client>();
            while (clients.Count < 2)
            {
                Console.WriteLine("Warte auf Client Nr. {0}", clients.Count + 1);
                TcpClient c = server.AcceptTcpClient();
                clients.Add(new Client(c, "" + clients.Count));
            }

            clients[0].Spieler.Partei = SendeBefehlLiesAntwort(clients[0], "klas");
            s = new Spielfeld("seaside");
            s.Name = SendeBefehlLiesAntwort(clients[0], "fena");
            Console.WriteLine("Spielfeld wird eingestellt" + s.Name);
            clients[1].Spieler.Partei = SendeBefehlLiesAntwort(clients[1], "fese" + s.Name);
            if (clients[1].Spieler.Partei == clients[0].Spieler.Partei)
            {
                Console.WriteLine("Neue Klasse einstellen");
                clients[1].Spieler.Partei = SendeBefehlLiesAntwort(clients[1], "klas" + clients[0].Spieler.Partei);
            }

            clients[1].Senden(SendeBefehlLiesAntwort(clients[0], "tabw" + clients[0].ClNummer +
                "" + clients[0].Spieler.Geld + "" + clients[0].Spieler.Bewpnkt ));
            clients[0].Senden(SendeBefehlLiesAntwort(clients[1], "tabw" + clients[1].ClNummer +
                "" + clients[1].Spieler.Geld + "" + clients[1].Spieler.Bewpnkt ));
            Console.WriteLine("Spiel startet");
            int last = 0;
            Client dran = clients[0];

            string empfangen = SendeBefehlLiesAntwort(dran, "Start");

            while (true)
            {
                switch (empfangen.Substring(0, 4))
                {
                    case "feld":            //holt koordinaten, sendet Wert
                        string parameter = "";
                        aktuellekoordinaten = (empfangen.Substring(4).Split(','));
                        switch (s.Feld[Convert.ToInt32(aktuellekoordinaten[0]), Convert.ToInt32(aktuellekoordinaten[1])])
                        {
                            case 6:
                                foreach (Spielfigur f in clients[0].Spieler.Spielfiguren1)
                                {
                                    if (f.Xposition == Convert.ToInt32(aktuellekoordinaten[0]) 
                                        && f.Yposition == Convert.ToInt32(aktuellekoordinaten[1]))
                                    {
                                        for (int i = 0; i < 7; i++)
                                        {
                                            for (int j = 0; j < 7; j++)
                                            {
                                                parameter = parameter.Insert(parameter.Length, "" + f.Bewegungsareal[j, i]);
                                            }
                                        }
                                        parameter = parameter.Insert(parameter.Length, f.ToString());
                                        break;
                                    }
                                }
                                break;
                            case 7:
                                foreach (Spielfigur f in clients[1].Spieler.Spielfiguren1)
                                {
                                    if (f.Xposition == Convert.ToInt32(aktuellekoordinaten[0]) 
                                        && f.Yposition == Convert.ToInt32(aktuellekoordinaten[1]))
                                    {
                                        for (int i = 0; i < 7; i++)
                                        {
                                            for (int j = 0; j < 7; j++)
                                            {
                                                parameter = parameter.Insert(parameter.Length, "" + f.Bewegungsareal[j, i]);
                                            }
                                        }
                                        parameter = parameter.Insert(parameter.Length, f.ToString());
                                        break;
                                    }
                                }

                                break;
                            default:
                                break;
                        }
                        empfangen = SendeBefehlLiesAntwort(dran, "fewe" + Convert.ToString(s.Feld[Convert.ToInt32(aktuellekoordinaten[0]), 
                            Convert.ToInt32(aktuellekoordinaten[1])]) + parameter);
                        parameter = "";
                        break;

                    case "sege":            //setze Geld
                        SendeBefehlLiesAntwort(dran, "sege" + dran.Spieler.Geld);
                        break;

                    case "neuf":            //Neue Figur
                        Spielfigur figur = dran.Spieler.NeueFigur(Convert.ToInt32(empfangen.Substring(4, 3)), 
                            Convert.ToInt32(aktuellekoordinaten[0]), Convert.ToInt32(aktuellekoordinaten[1]));
                        s.Feld[Convert.ToInt32(aktuellekoordinaten[0]), Convert.ToInt32(aktuellekoordinaten[1])] = 6+last;
                        clients[1 - last].Senden("neuf" + figur.ToString());

                        empfangen = SendeBefehlLiesAntwort(dran, "neuf" + figur.ToString());
                        break;

                    case "weit":            //Client soll weiteren Zug machen
                        empfangen = SendeBefehlLiesAntwort(dran, "weit");
                        break;

                    case "feüb":            //gesamtes feld wird übergeben
                        int zähler=0;
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 20; j++)
                            {
                                
                                    s.Feld[j, i] = Int32.Parse(empfangen.Substring(4+zähler, 1));
                                
                                zähler++;
                            }
                        }
                        empfangen = SendeBefehlLiesAntwort(dran, "weit");
                        break;

                    case "lvlu":            //Lvlupausführen und case 5 zurückschicken
                        break;

                    case "rube":            //Zug beenden, anderer Spieler ist dran
                        last = 1 - last;
                        dran = clients[last];
                        empfangen = SendeBefehlLiesAntwort(dran, "losg");
                        break;

                    case "been":            // Spiel wird beendet

                        foreach (Client c in clients)
                        {
                            c.Senden("Spiel wird beendet");
                            c.tcp.Close();

                        }
                        Console.WriteLine("OK, das wars");
                        Console.ReadLine();
                        return;

                    default:
                        break;
                }
            }
        }

        public static string SendeBefehlLiesAntwort(Client c, string Befehl)
        {
            c.Senden(Befehl);
            return c.str.ReadLine();
        }
    }
}
