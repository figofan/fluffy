using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tcp.Server
{
    public class serv
    {
        public static void Main1()
        {
            try
            {
                var ipAd = IPAddress.Parse("127.0.0.1");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                var myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start(10);

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                var s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                while (true)
                {
                    var b = new byte[100];
                    var k = s.Receive(b);
                   
                    for (var i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));
                    Console.WriteLine();

                    Console.Write("you: ");
                    var str = Console.ReadLine();
                    var asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes($"server:{str}"));
                    Console.WriteLine();
                    //Console.WriteLine("\nSent Acknowledgement");
                }
                
                Console.ReadKey();
                /* clean up */
                s.Close();
                myList.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}