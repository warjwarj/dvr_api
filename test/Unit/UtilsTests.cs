using System.Runtime.InteropServices;

namespace dvr_api_tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void test_getMDVRIdFromMessage()
        {
            string device_id = "122009887";

            string? d1 = dvr_api.Utils.getMDVRIdFromMessage($"$VIDEO;{device_id};V01;all;4;20231003-164514;5\r");
            string? d2 = dvr_api.Utils.getMDVRIdFromMessage($"$VIDEO;V01;{device_id};all;4;20231003-164514;5\r");
            string? d3 = dvr_api.Utils.getMDVRIdFromMessage($"$VIDEO;V01;XYZ;{device_id};4;20231003-164514;5\r");
            string? d4 = dvr_api.Utils.getMDVRIdFromMessage("");
            string? d5 = dvr_api.Utils.getMDVRIdFromMessage("this string is of arbitrary value");
            string? d6 = dvr_api.Utils.getMDVRIdFromMessage(null);

            Console.WriteLine(d1 == null);
            Console.WriteLine(d2 == null);
            Console.WriteLine(d3 == null);
            Console.WriteLine(d4 == null);
            Console.WriteLine(d5 == null);
            Console.WriteLine(d6 == null);

            Assert.AreEqual(d1, d2, device_id);
            Assert.IsNull(d3, d4, d5, d6);
        }

        [TestMethod]
        public void test_formatIntoDateTime()
        {
            string dtString = "20231003-164514";

            DateTime dt1 = new DateTime(2023, 10, 3, 16, 45, 14);
            DateTime dt2 = dvr_api.Utils.formatIntoDateTime(dtString);

            Assert.AreEqual(dt1, dt2);
        }

        [TestMethod]
        public void test_formatFromDateTime()
        {
            DateTime dtObj = new DateTime(2023, 10, 3, 16, 45, 14);

            string dt1 = "20231003-164514";
            string dt2 = dvr_api.Utils.formatFromDateTime(dtObj);

            Assert.AreEqual(dt1, dt2);
        }

        [TestMethod]
        public void test_section()
        {
            string message = "$VIDEO;122009887;all;4;20231003-164514;5\r";

            string firstSectionActual = "$VIDEO";
            string firstSectionComputed = dvr_api.Utils.section(message, 0);

            Assert.AreEqual(firstSectionActual, firstSectionComputed);
        }

        [TestMethod]
        public void test_getReqMatchStringFromFilePacketHeader()
        {
            string header = "$FILE;V01;1298765582;1;4;20231003-164514;5;20231003-164418;62;3983360\r";

            string reqMatchString1 = "129876558220231003-1645145";
            string reqMatchString2 = dvr_api.Utils.getReqMatchStringFromFilePacketHeader(header);

            Assert.AreEqual(reqMatchString1, reqMatchString2);
        }

        [TestMethod]
        public void test_getReqMatchStringFromVideoPacketHeader()
        {
            string header = "$VIDEO;122009887;all;4;20231003-164514;5\r";

            string reqMatchString1 = "12200988720231003-1645145";
            string reqMatchString2 = dvr_api.Utils.getReqMatchStringFromVideoPacketHeader(header);

            Assert.AreEqual(reqMatchString1, reqMatchString2);
        }

        [TestMethod]
        public void test_replaceByteSequence()
        {
            byte[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            byte[] sequence = { 8, 9, 10, 11 };
            byte[] replacement = { 99, 99 };

            byte[] bA1 = { 1, 2, 3, 4, 5, 6, 7, 99, 99, 12, 13, 14, 15 };
            byte[] bA2 = dvr_api.Utils.replaceByteSequence(input, sequence, replacement);

            Assert.IsTrue(bA1.Length == bA2.Length && !bA1.Where((t, i) => t != bA2[i]).Any());
        }
    }
}