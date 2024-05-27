//using System.Net;
//using System.Net.Sockets;
//using System.Text;

//using static dvr_api.Utils;
//using static dvr_api.Globals;

//namespace dvr_api
//{
//    public class MockMDVR : SpecialisedTcpClient, IDisposable
//    {
//        private Socket _secondarySocket = null;

//        public MockMDVR()
//            : base(
//                  randDevIdGen.Next(0, 999999999).ToString("D2"),
//                  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
//                  )
//        {
//            _secondarySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            clientType = ClientType.Mock_FW_MDVR;
//        }

//        public void Dispose()
//        {
//            _clientSocket.Dispose();
//            _secondarySocket.Dispose();
//        }

//        public async Task ConnectToGPSServer()
//        {
//            await _clientSocket.ConnectAsync(new IPEndPoint(new IPAddress(GPS_SVR_IP), GPS_SVR_PORT));
//            Log($"MockMDVR {id} local endpoint: {_clientSocket.LocalEndPoint}");
//        }

//        // main connection loop
//        public async override Task HandleConnectionAsync(CancellationToken cToken)
//        {
//            try
//            {
//                SendString($"ALV;{id};FirstPacket\r");
//                while (!cToken.IsCancellationRequested)
//                {
//                    // these conditions are important to ensure that we do not block on this function when we might want to receive data from this socket elsewhere.
//                    if (!inUse && _clientSocket.Available != 0)
//                    {
//                        string received = await ReceiveMessageStringAsync(cToken);
//                        ProcessMessage(received);
//                        Log($"Mock device received: {received}", LogType.Info);
//                    }
//                }
//            }
//            catch (SocketException sockEx)
//            {
//                Log($"Socket error in HandleClientAsync for MockDevice: {sockEx.Message}", LogType.Error);
//            }
//            catch (Exception ex)
//            {
//                Log($"Error in HandleClientAsync: {ex.Message}", LogType.Error);
//            }
//        }
//        protected async Task ProcessMessage(string message)
//        {
//            string[] message_arr = message.Split(';', StringSplitOptions.TrimEntries);
//            switch (message_arr[0])
//            {
//                case "$VIDEO":
//                    await SendStringAsync($"$VIDEO;{id};OK\r", new CancellationToken());
//                    SendVideoToCamServer();
//                    break;
//                default:
//                    await SendStringAsync($"{message_arr[0]};{id};OK\r", new CancellationToken());
//                    break;
//            }
//        }

//        public byte[] CreateMockVideoFile()
//        {
//            byte[] id_bytes = Encoding.ASCII.GetBytes(id);
//            byte[] placeholder_bytes = new byte[] { 0x5a, 0x5a, 0x5a, 0x5a, 0x5a, 0x5a, 0x5a, 0x5a, 0x5a };
//            return replaceByteSequence(File.ReadAllBytes("placeholder_vid.txt"), placeholder_bytes, id_bytes);
//        }

//        public async void SendVideoToCamServer()
//        {
//            inUse = true;
//            byte[] file_bytes = CreateMockVideoFile();
//            await _secondarySocket.ConnectAsync(new IPEndPoint(new IPAddress(CAM_SVR_IP), CAM_SVR_PORT));
//            TcpUtils.SendBytes(_secondarySocket, file_bytes);
//            await Disconnect();
//            inUse = false;
//        }

//        public static Random randDevIdGen = new Random();

//        public static async Task<MockMDVR[]> connectAndHandleMockDevices(int numOfDevices)
//        {
//            MockMDVR[] devices = new MockMDVR[numOfDevices];

//            for (int i = 0; i < numOfDevices; i++)
//            {
//                devices[i] = new MockMDVR();
//                await devices[i].ConnectToGPSServer();
//                devices[i].HandleConnectionAsync(new CancellationToken());
//            }

//            return devices;
//        }
//    }
//}
