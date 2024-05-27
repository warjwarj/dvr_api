//using System.Net.Sockets;
//using System.Net;
//using System.Text;

//namespace dvr_api_tests
//{
//    [TestClass]
//    public class TcpUtilsTests
//    {
//        [TestMethod]
//        public async Task test_SendStringAsync()
//        {
//            // create sockets
//            Socket send_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Socket recv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//            // bind socket to local endpoint, any port, and listen for 1 connection.
//            recv_sock.Bind(new IPEndPoint(dvr_api.Globals.LOOPBACK_ADDR, 0));
//            recv_sock.Listen(1);

//            // test data
//            string data = "This is a test string that will be encoded into ASCII bytes and sent over the socket.";
//            byte[] recv_buffer = new byte[data.Length];

//            // connect socket to the recv one, and send data.
//            send_sock.Connect((IPEndPoint)recv_sock.LocalEndPoint);
//            dvr_api.TcpUtils.SendStringAsync(
//                send_sock,
//                data,
//                CancellationToken.None,
//                true
//                ).Wait();

//            // receive the data off of the recv socket and compare it to the sent data.
//            send_sock = recv_sock.Accept();
//            send_sock.Receive(recv_buffer, 0, data.Length, SocketFlags.None);
//            Assert.AreEqual(data, Encoding.ASCII.GetString(recv_buffer));
//        }

//        [TestMethod]
//        public async Task test_SendString()
//        {
//            // create sockets
//            Socket send_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Socket recv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//            // bind socket to local endpoint, any port, and listen for 1 connection.
//            recv_sock.Bind(new IPEndPoint(dvr_api.Globals.LOOPBACK_ADDR, 0));
//            recv_sock.Listen(1);

//            // test data
//            string data = "This is a test string that will be encoded into ASCII bytes and sent over the socket.";
//            byte[] recv_buffer = new byte[data.Length];

//            // connect socket to the recv one, and send data.
//            send_sock.Connect((IPEndPoint)recv_sock.LocalEndPoint);
//            dvr_api.TcpUtils.SendString(
//                send_sock,
//                data,
//                true
//                );

//            // receive the data off of the recv socket and compare it to the sent data.
//            send_sock = recv_sock.Accept();
//            send_sock.Receive(recv_buffer, 0, data.Length, SocketFlags.None);
//            Assert.AreEqual(data, Encoding.ASCII.GetString(recv_buffer));
//        }

//        [TestMethod]
//        public async Task test_SendBytes()
//        {
//            // create sockets
//            Socket send_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Socket recv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//            // bind socket to local endpoint, any port, and listen for 1 connection.
//            recv_sock.Bind(new IPEndPoint(dvr_api.Globals.LOOPBACK_ADDR, 0));
//            recv_sock.Listen(1);

//            // test data
//            byte[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
//            byte[] recv_buffer = new byte[data.Length];

//            // connect socket to the recv one, and send data.
//            send_sock.Connect((IPEndPoint)recv_sock.LocalEndPoint);
//            dvr_api.TcpUtils.SendBytes(
//                send_sock,
//                data,
//                true
//                );

//            // receive the data off of the recv socket and compare it to the sent data.
//            send_sock = recv_sock.Accept();
//            send_sock.Receive(recv_buffer, 0, data.Length, SocketFlags.None);
//            Assert.IsTrue(data.SequenceEqual(recv_buffer));
//        }

//        [TestMethod]
//        public async Task test_ReceiveBytes()
//        {
//            CancellationToken ct = new CancellationToken();

//            // create sockets
//            Socket send_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Socket recv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//            // bind socket to local endpoint, any port, and listen for 1 connection.
//            recv_sock.Bind(new IPEndPoint(dvr_api.Globals.LOOPBACK_ADDR, 0));
//            recv_sock.Listen(1);

//            // test data
//            byte[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
//            byte[] recv_buffer = new byte[data.Length];

//            // connect socket to the recv one, and send data.
//            send_sock.Connect((IPEndPoint)recv_sock.LocalEndPoint);
//            send_sock.Send(data);

//            // receive the data off of the recv socket and compare it to the sent data.
//            send_sock = recv_sock.Accept();
//            recv_buffer = await dvr_api.TcpUtils.ReceiveBytesAsync(
//                send_sock,
//                data.Length,
//                ct,
//                true
//                );
//            Assert.IsTrue(data.SequenceEqual(recv_buffer));
//        }

//        [TestMethod]
//        public async Task test_ReceiveMessageStringAsync()
//        {
//            // create sockets
//            Socket send_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            Socket recv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//            // bind socket to local endpoint, any port, and listen for 1 connection.
//            recv_sock.Bind(new IPEndPoint(dvr_api.Globals.LOOPBACK_ADDR, 0));
//            recv_sock.Listen(1);

//            // test data
//            string data = "This is a test string that will be encoded into ASCII bytes and sent over the socket.\r";

//            // connect socket to the recv one, and send data.
//            send_sock.Connect((IPEndPoint)recv_sock.LocalEndPoint);
//            send_sock.Send(Encoding.ASCII.GetBytes(data));

//            // receive the data off of the recv socket and compare it to the sent data.
//            send_sock = recv_sock.Accept();
//            string response = await dvr_api.TcpUtils.ReceiveMessageStringAsync(
//                send_sock, 
//                new CancellationToken(), 
//                true
//                );
//            Assert.AreEqual(data, response);
//        }
//    }
//}