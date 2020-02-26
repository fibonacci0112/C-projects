using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/Server");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(Server), baseAddress);

            try
            {
                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(
                    typeof(IServerDuplex),
                    new WSDualHttpBinding(),
                    "Server");


                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
                Console.ReadLine();
            }

        }
    }
}



/*
 * Visual Studio als Administrator starten
 * Verweis hinzufügen: System.ServiceModel
 * Server starten
 * 
 * 
 * Eingabeaufforderung als Administrator starten.
 * Dann die folgenden Befehle eingebe
 * netsh http add urlacl url=http://+:80/MyUri user=Ralph
 * netsh http add iplisten ipaddress=0.0.0.0:8000
 * 
 * Danach exe als Administrator starten
 * Test im Browser mit: http://localhost:8000/Server
 * 
 * 
 * Client:
 * app.config und Proxy erzeugen:
 * Unter Visual Studio Tools -> Visual Studio Eingabeaufforderung als Administrator starten
 * dann z.B. in Verzeichnis D: wechseln
 * dorthin werden dann die generierten Dateien geschrieben
 * svcutil.exe /language:cs /out:GeneratedProxy.cs /config:app.config http://localhost:8000/Server
 * Das Clientprojekt erzeugen und ihm using System.ServiceModel; hinzufügen
 * Die generierten Dateien in das Clientprojekt kopieren und dem Projekt hinzufügen
 * Dem Clientprojekt den Verweis hinzufügen: System.ServiceModel
 */

