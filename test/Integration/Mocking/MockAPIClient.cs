//using System.Net;
//using System.Net.Sockets;
//using System.Text;

//using static dvr_api.Utils;
//using static dvr_api.Globals;

//namespace dvr_api
//{
//    public class MockAPIClient : SpecialisedTcpClient, IDisposable
//    {
//        // would normally have the id be the string endpoint of the socket. Random so we can use the base constructor.
//        public MockAPIClient()
//            : base(
//                  randIDGen.Next(0, 999999999).ToString("D2"),
//                  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
//        {
//            clientType = ClientType.Mock_APIClient;
//        }

//        public void Dispose()
//        {
//            _clientSocket.Dispose();
//        }

//        public async Task ConnectToAPIServer()
//        {
//            await Connect(new IPEndPoint(new IPAddress(API_SVR_IP), API_SVR_PORT));
//            Log($"MockAPIClient {id} local endpoint: {_clientSocket.LocalEndPoint}");
//        }

//        /// <summary>
//        /// Assert that response is: $TESTPACKET;{id};OK\r"
//        /// </summary>
//        /// <returns></returns>
//        public async Task<string> SendTestPacket(string devId)
//        {
//            await SendStringAsync($"$TESTPACKET;{devId};ThisTextShouldBeReplacedWithTheLetters-OK\r", new CancellationToken());
//            return await ReceiveMessageStringAsync(new CancellationToken());
//        }

//        public async Task<bool> SendRecvTestVideo(string devId)
//        {
//            byte[] id_bytes = Encoding.ASCII.GetBytes(devId);
//            byte[] placeholder_bytes = new byte[] { 0x5a, 0x5a, 0x5a, };
//            byte[] file_bytes = replaceByteSequence(File.ReadAllBytes("placeholder_vid.txt"), placeholder_bytes, id_bytes);
//            byte[] receivedBytes = ReceiveBytes(file_bytes.Length);
//            return file_bytes.Length == receivedBytes.Length && !file_bytes.Where((t, i) => t != receivedBytes[i]).Any();
//        }

//        // dont need it
//        public async override Task HandleConnectionAsync(CancellationToken cToken) { }

//        public static Random randIDGen = new Random();
//        public static async Task<MockAPIClient[]> connectAndHandleMockClients(int numOfClients)
//        {
//            MockAPIClient[] devices = new MockAPIClient[numOfClients];

//            for (int i = 0; i < numOfClients; i++)
//            {
//                devices[i] = new MockAPIClient();
//                await devices[i].ConnectToAPIServer();
//            }

//            return devices;
//        }
//    }
//}
