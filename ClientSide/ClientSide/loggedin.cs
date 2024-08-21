using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace ClientSide
{
    public partial class loggedin : Form
    {
        private static string loginusername = "";
        public static void set(string name)
        {
            loginusername = name;
        }
        
        public loggedin()
        {
            InitializeComponent();
        }

        private static string testHost = "speedtest.tele2.net"; // Example host
        private static int port = 80;
        private static string request = "GET /1MB.zip HTTP/1.1\r\nHost: speedtest.tele2.net\r\nConnection: close\r\n\r\n";
        
        private byte[] uploadData = new byte[1 * 1024 * 1024]; // 1 MB of data for upload test
        string uploadUrl = "http://speedtest.tele2.net/upload.php";

        private byte[] bytes = new byte[1024];
        private static IPHostEntry host = Dns.GetHostEntry("192.168.73.39");
        private static IPAddress ipAddress = host.AddressList[0];
        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
        private Socket IpSocket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
        private void loggedin_Load(object sender, EventArgs e)
        {
            usernamelabel.Text = loginusername;
            StartClient("connected");
        }


        public async void StartClient(string s)
        {

            try
            {
                try
                {
                    // Connect to Remote EndPoint
                    if (!IpSocket.Connected)
                    {
                        IpSocket.Connect(remoteEP);
                        MessageBox.Show("Socket connected to {1}",
                            IpSocket.RemoteEndPoint.ToString());
                    }

                    while (true)
                    {
                        // Encode the data string into a byte array.
                        /*string text = s;
                        byte[] msg = Encoding.ASCII.GetBytes(text);

                        // Send the data through the socket.
                        int bytesSent = IpSocket.Send(msg);

                        // Receive the response from the remote device.
                        int bytesRec = IpSocket.Receive(bytes);
                        string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        MessageBox.Show(response);*/

                        string text = "";

                        while (true)
                        {
                            long ping = await TestPingAsync(testHost);
                            double DSpeed = await TestDownloadSpeedAsync(testHost, port, request);
                            double USpeed = await TestUploadSpeedAsync(uploadUrl, uploadData);

                            downloadspeedlabel.Text = DSpeed.ToString() + " MBps";
                            uploadspeedlabel.Text = USpeed.ToString() + " MBps";
                            pinglabel.Text = ping.ToString() + " ms";

                            text = "100*" + loginusername + "*" + DSpeed.ToString() + "*" + USpeed.ToString() + "*" + ping.ToString();
                            byte[] msg = Encoding.ASCII.GetBytes(text);

                            int bytesSent = IpSocket.Send(msg);

                            int bytesRec = IpSocket.Receive(bytes);
                            string response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            string[] strings = response.Split("*");
                            AveragePingLabel.Text = strings[0] + " ms";
                            AverageDownloadLabel.Text = strings[1] + "MBps";
                            AverageUploadLabel.Text = strings[2] + "MBps";
                            PingVarianceLabel.Text = strings[3] + "ms";
                            if (Int32.Parse(strings[3]) >= 35)
                            {
                                WelcomeToLebanonLabel.Text = "Better luck when you return to your sense and change the country :)";
                            }

                            await Task.Delay(1000);
                        }

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
                    MessageBox.Show("Bro watch your internet connection then try again!!!");
                    this.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void loggedin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IpSocket.Connected)
            {
                // Encode the data string into a byte array.
                string text = "404*" + loginusername;
                byte[] msg = Encoding.ASCII.GetBytes(text);

                // Send the data through the socket.
                int bytesSent = IpSocket.Send(msg);

                // Release the socket.
                IpSocket.Shutdown(SocketShutdown.Both);
                IpSocket.Close();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            var loggedin_form = new Thread(() => Application.Run(new Form1()));
            loggedin_form.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            loggedin_form.Start();

            this.Close();
        }

        public async Task<long> TestPingAsync(string host)
        {
            using (Ping ping = new Ping())
            {
                PingReply reply = await ping.SendPingAsync(host);
                if (reply.Status == IPStatus.Success)
                {
                    return reply.RoundtripTime;
                }
                else
                {
                    throw new Exception("Ping failed.");
                }
            }
        }

        public async Task<double> TestDownloadSpeedAsync(string host, int port, string request)
        {
            byte[] buffer = new byte[8192];
            int bytesRead = 0;
            double totalBytesRead = 0;
            Stopwatch stopwatch = new Stopwatch();

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream stream = client.GetStream())
            {
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                stopwatch.Start();

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopwatch.Stop();
            }

            double seconds = stopwatch.Elapsed.TotalSeconds;
            //double bits = totalBytesRead * 8;
            double speed = totalBytesRead / seconds; // bits per second

            return Math.Round(speed / (1024 * 1024), 2); // MBps
        }

        public async Task<double> TestUploadSpeedAsync(string host, byte[] data)
        {
            // Create HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Start timer to measure upload time
                    DateTime startTime = DateTime.Now;

                    // Send POST request with file data
                    HttpResponseMessage response = await client.PostAsync(uploadUrl, new ByteArrayContent(data));

                    // End timer
                    DateTime endTime = DateTime.Now;

                    // Check if request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Calculate upload speed
                        TimeSpan duration = endTime - startTime;
                        double uploadSpeedMBps = (data.Length / 1024 / 1024) / duration.TotalSeconds;

                        return Math.Round(uploadSpeedMBps,2);
                    }
                    else
                    {
                        MessageBox.Show($"Upload failed with status code: {response.StatusCode}");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during upload: {ex.Message}");
                    return -1;
                }
            }
        }
    }
}
