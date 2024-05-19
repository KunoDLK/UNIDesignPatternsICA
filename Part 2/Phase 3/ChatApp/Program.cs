using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

class Connection : IDisposable
{
      public TcpClient Client { get; set; }

      public Thread Thread { get; set; }

      public NetworkStream NetworkStream { get; set; }

      public Connection(IPAddress address, int portNumber)
      {
            Client = new TcpClient();
            Client.Connect(address, portNumber);
            Console.WriteLine("client connected!!");
            NetworkStream = Client.GetStream();
            Thread = new Thread(o => ReceiveData((TcpClient)o));

            Thread.Start(Client);
      }

      static void ReceiveData(TcpClient client)
      {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                  Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
      }

      public void Dispose()
      {
            Client.Client.Shutdown(SocketShutdown.Send);
            Thread.Join();
            NetworkStream.Close();
            Client.Close();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
      }

      public void SendMessage(Message message)
      {
            byte[] userToken = Encoding.ASCII.GetBytes(message.MessageUser.token.ToString());
            byte[] usernameBuffer = Encoding.ASCII.GetBytes(message.MessageUser.Name);
            byte[] messageBuffer = Encoding.ASCII.GetBytes(message.MessageText);

            int arrayPointer = 0;
            byte[] messagePacket = new byte[userToken.Length + usernameBuffer.Length + messageBuffer.Length];

            System.Array.Copy(userToken, 0, messagePacket, arrayPointer, userToken.Length);
            arrayPointer += userToken.Length;
            System.Array.Copy(usernameBuffer, 0, messagePacket, arrayPointer, usernameBuffer.Length);
            arrayPointer += usernameBuffer.Length;
            System.Array.Copy(messageBuffer, 0, messagePacket, arrayPointer, messageBuffer.Length);

            NetworkStream.Write(messagePacket, 0, messagePacket.Length);
      }
}

class Program
{
      public static User? User { get; set; }

      public static Connection? Connection { get; set; }

      static void Main(string[] args)
      {
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();

            User = new User(name);

            Connection = new Connection(IPAddress.Parse("127.0.0.1"), 3200);

            string input;
            while (!(input = Console.ReadLine()).Equals("exit"))
            {
                  Connection.SendMessage(new Message(User, input));
            }
      }
}

public class User
{
      public Guid token { get; set; }
      public string Name { get; set; }

      public User(string name)
      {
            this.Name = name;
            this.token = Guid.NewGuid();
      }
}

public class Message
{
      public User MessageUser { get; set; }

      public string MessageText { get; set; }

      public Message(User user, string message)
      {
            MessageUser = user;
            MessageText = message;
      }
}