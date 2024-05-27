//using System.Text;

//using dvr_api;

//using static dvr_api.Globals;
//using static dvr_api.Utils;

//namespace dvr_api_tests
//{
//    /*
//     * 
//     * More functional, blackbox style testing than unit.
//     * Run the program in test mode in order for this to work.
//     * 
//     */

//    [TestClass]
//    public class TestRoutines
//    {
//        // setup the server for the tests.
//        public TestRoutines()
//        {
//            SERVER_INSTANCE = new DVRAPI();
//            _ = Task.Run(() => SERVER_INSTANCE.Run());
//        }

//        [TestMethod]
//        public async Task routine_testUnrecognisedPacketLogic()
//        {
//            // these are 'SpecialisedTCPClient' objects with some extra methods.
//            MockMDVR mockMDVR = new MockMDVR();
//            MockAPIClient mockAPIClient = new MockAPIClient();

//            // connect the mock clients
//            await mockMDVR.ConnectToGPSServer();
//            await mockAPIClient.ConnectToAPIServer();

//            // start the mock MDVR listening to messages from the server
//            _ = Task.Run(() => mockMDVR.HandleConnectionAsync(CancellationToken.None));
//            while (!SERVER_INSTANCE.connectedDevicesController.CheckForObject(mockMDVR.id)) { Thread.Sleep(100); }

//            // send a packet to the server. 
//            mockAPIClient.SendString($"$TESTPACKET;{mockMDVR.id};__\r");

//            // the response from the mock DVR, forwarded by the server.
//            string response = mockAPIClient.ReceiveMessageString();

//            // check that the DVR has responded. Should have replaced the __ with OK.
//            Assert.AreEqual($"$TESTPACKET;{mockMDVR.id};OK\r", response);
//        }

//        [TestMethod]
//        public async Task routine_TestVideoReq()
//        {
//            CancellationToken ct = new CancellationToken();

//            // these are 'SpecialisedTCPClient' objects with some extra methods.
//            MockMDVR mockMDVR = new MockMDVR();
//            MockAPIClient mockAPIClient = new MockAPIClient();

//            // connect the mock clients
//            await mockMDVR.ConnectToGPSServer();
//            await mockAPIClient.ConnectToAPIServer();

//            // start the mock MDVR listening to messages from the server and wait for it to connect
//            _ = Task.Run(() => mockMDVR.HandleConnectionAsync(ct));
//            while (!SERVER_INSTANCE.connectedDevicesController.CheckForObject(mockMDVR.id)) { Thread.Sleep(100); }

//            // request the video
//            await mockAPIClient.SendStringAsync($"$VIDEO;{mockMDVR.id};all;4;20231003-164514;5\r", ct);

//            // clear the 'video ok' message
//            Log(await mockAPIClient.ReceiveMessageStringAsync(ct));

//            // read the file and remove the generic '$PACKET' prefix that won't be send to the client anyway.
//            List<byte> expectedResponse = mockMDVR.CreateMockVideoFile().ToList();
//            byte current = 0;
//            while (current != '\r')
//            {
//                current = expectedResponse[0];
//                expectedResponse.RemoveAt(0);
//            }

//            byte[] actualRespose = await mockAPIClient.ReceiveBytesAsync(expectedResponse.Count, ct);

//            Assert.AreEqual(
//                Encoding.ASCII.GetString(expectedResponse.ToArray()),
//                Encoding.ASCII.GetString(actualRespose)
//                );
//        }
//    }
//}
