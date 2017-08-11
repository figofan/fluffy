using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Tcp.Client
{
    //
    /*   Server Program    */


/*       Client Program      */
    public class clnt
    {
        public static void Main1()
        {
            try
            {
                var tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("127.0.0.1", 8001);
                // use the ipaddress as in the server program
                Console.WriteLine("Connected");
                
                while (true)
                {
                    Console.Write("you: ");
                    var str = Console.ReadLine();
                    Stream stm = tcpclnt.GetStream();

                    var asen = new ASCIIEncoding();
                    var ba = asen.GetBytes($"client: {str}");

                    stm.Write(ba, 0, ba.Length);

                    var bb = new byte[100];
                    var k = stm.Read(bb, 0, 100);
                    Console.WriteLine();

                    for (var i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(bb[i]));
                    Console.WriteLine();
                }
                
                Console.ReadKey();
                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }

    //
}