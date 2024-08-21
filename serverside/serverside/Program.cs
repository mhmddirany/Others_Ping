using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataBase;
using System.Threading;

// https://www.c-sharpcorner.com/article/socket-programming-in-C-Sharp/


// Socket Listener acts as a server and listens to the incoming
// messages on the specified port and protocol.
public class Serverside
{
    
    public static int Main(String[] args)
    {
        StartServer();
        return 0;
    }

    public static void StartServer()
    {
        // Get Host IP Address that is used to establish a connection
        // In this case, we get one IP address of localhost that is IP : 127.0.0.1
        // If a host has multiple addresses, you will get a list of addresses
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        try
        {

            // Create a Socket that will use Tcp protocol
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method
            listener.Bind(localEndPoint);
            // Specify how many requests a Socket can listen before it gives Server busy response.
            // We will listen 10 requests at a time
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");
            //Socket handler = listener.Accept();
            //Console.WriteLine("connection made");

            // Incoming data from the client.

            while (true)
            {
                Socket handler = listener.Accept();
                Console.WriteLine("connection made");
                Thread newThread = new Thread(new ParameterizedThreadStart(HandleNewSocket));
                newThread.Start(handler);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\n Press any key to continue...");
        Console.ReadKey();
    }

    static void HandleNewSocket(object? handlerObject)
    {
        Socket handler = handlerObject as Socket;

        string data = null;
        byte[] bytes = null;

        while (true)
        {
            Console.WriteLine("testing...");
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            string[] substrings = data.Split('*');
            //string code = substrings[0];
            string username="";
            //string password=substrings[2];
            //Console.WriteLine($"{substrings[0]} {substrings[1]} {substrings[2]}");
            Console.WriteLine(data);
            DataClass dataClass = new DataClass();
            if (substrings[0] == "200")
            {
                int i = dataClass.AccountSearch(substrings[1], substrings[2]);
                if (i == 1)
                {
                    username = substrings[1];
                    Console.WriteLine("success" + username);
                    byte[] msg = Encoding.ASCII.GetBytes("successfully logged in");
                    handler.Send(msg);
                    int exist = dataClass.SearchTable(username);
                    if (exist == 0)
                    {
                        dataClass.CreateTable(username);
                        Console.WriteLine("table created");
                    }
                    
                }
                else
                {
                    Console.WriteLine("username/password is wrong");
                    byte[] msg = Encoding.ASCII.GetBytes("username/password is wrong");
                    handler.Send(msg);
                }
            }
            else if (substrings[0] == "201")
            {
                int i = dataClass.AccountSearch(substrings[1], substrings[2]);
                if (i == 1)
                {
                    Console.WriteLine("account not created");
                    byte[] msg = Encoding.ASCII.GetBytes("account already exist");
                    handler.Send(msg);
                }
                else
                {
                    dataClass.DatabaseInsert(substrings[1], substrings[2]);
                    byte[] msg = Encoding.ASCII.GetBytes("account has been created");
                    handler.Send(msg);
                }
            }
            else if (substrings[0] == "100")
            {
                dataClass.TestsInsert(substrings[1], data);
                string DataToSend = dataClass.PingAverage(substrings[1]).ToString() 
                    + "*" + dataClass.DownloadSpeedAverage(substrings[1]).ToString() 
                    + "*" + dataClass.UploadSpeedAverage(substrings[1]).ToString()
                    + "*" + dataClass.PingVariance(substrings[1]).ToString();
                byte[] msg = Encoding.ASCII.GetBytes(DataToSend);
                handler.Send(msg);
            }
            else if (substrings[0] == "405")
            {
                Console.WriteLine("Closing Connection1...");
                break;
            }
            else if (substrings[0] == "404")
            {
                dataClass.DeleteTable(substrings[1]);
                Console.WriteLine("Closing Connection2...");
                break;
            }
        }
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }
}