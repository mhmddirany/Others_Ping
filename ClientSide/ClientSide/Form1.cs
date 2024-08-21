using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientSide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] bytes = new byte[1024];
        private static IPHostEntry host = Dns.GetHostEntry("192.168.73.39");
        private static IPAddress ipAddress = host.AddressList[0];
        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
        private Socket IpSocket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (usernamebox.Text != "" && passwordbox.Text != "")
            {
                string account = "200*" + usernamebox.Text + "*" + passwordbox.Text;
                StartClient(account);
            }
        }

        public void StartClient(string s)
        {

            try
            {
                // Connect to a Remote server
                // Get Host IP Address that is used to establish a connection
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1
                // If a host has multiple addresses, you will get a list of addresses
                //IPHostEntry host = Dns.GetHostEntry("localhost");
                //IPAddress ipAddress = host.AddressList[0];
                //IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                //Socket sender = new Socket(ipAddress.AddressFamily,
                //    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    if (!IpSocket.Connected)
                    {
                        IpSocket.Connect(remoteEP);
                        MessageBox.Show("Socket connected to {0}",
                            IpSocket.RemoteEndPoint.ToString());
                    }

                    // Encode the data string into a byte array.
                    string text = s;
                    byte[] msg = Encoding.ASCII.GetBytes(text);

                    // Send the data through the socket.
                    int bytesSent = IpSocket.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = IpSocket.Receive(bytes);
                    string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    MessageBox.Show(response);

                    if (response == "successfully logged in")
                    {
                        var loggedin_form = new Thread(() => Application.Run(new loggedin()));
                        loggedin_form.SetApartmentState(ApartmentState.STA); // Deprecation Fix
                        loggedin_form.Start();
                        loggedin.set(usernamebox.Text);
                        this.Close();
                    }

                }
                catch (ArgumentNullException ane)
                {
                    MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    MessageBox.Show("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            if (usernamebox.Text != "" && passwordbox.Text != "")
            {
                string CreatedAccount = "201*" + usernamebox.Text + "*" + passwordbox.Text;
                StartClient(CreatedAccount);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IpSocket.Connected)
            {
                // Encode the data string into a byte array.
                string text = "405";
                byte[] msg = Encoding.ASCII.GetBytes(text);

                // Send the data through the socket.
                int bytesSent = IpSocket.Send(msg);

                // Release the socket.
                IpSocket.Shutdown(SocketShutdown.Both);
                IpSocket.Close();
            }
        }
    }
}
