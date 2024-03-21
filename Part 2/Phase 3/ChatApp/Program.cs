using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
      private const int port = 8888;
      private const string serverIpAddress = "127.0.0.1";

      static void Main(string[] args)
      {
            try
            {
                  IPAddress ipAddress = IPAddress.Parse(serverIpAddress);
                  IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                  // Create a TCP/IP socket.  
                  Socket sender = new Socket(ipAddress.AddressFamily,
                      SocketType.Stream, ProtocolType.Tcp);

                  try
                  {
                        // Connect the socket to the remote endpoint. Catch any errors.  
                        sender.Connect(remoteEP);

                        Console.WriteLine("Socket connected to {0}",
                            sender.RemoteEndPoint.ToString());

                        // Create a message to send to the server.
                        Console.WriteLine("Enter a message:");
                        string message = Console.ReadLine();

                        byte[] msg = Encoding.ASCII.GetBytes(message);

                        // Send the data through the socket.  
                        int bytesSent = sender.Send(msg);

                        // Receive the response from the remote device.
                        byte[] bytes = new byte[1024];
                        int bytesRec = sender.Receive(bytes);
                        Console.WriteLine("Echoed test = {0}",
                            Encoding.ASCII.GetString(bytes, 0, bytesRec));

                        // Release the socket.  
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();

                  }
                  catch (ArgumentNullException ane)
                  {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                  }
                  catch (SocketException se)
                  {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                  }
                  catch (Exception e)
                  {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                  }
            }
            catch (Exception e)
            {
                  Console.WriteLine(e.ToString());
            }
      }
}
