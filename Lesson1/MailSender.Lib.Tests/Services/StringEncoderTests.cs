using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSenderLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.Tests
{
    [TestClass()]
    public class StringEncoderTests
    {
        [TestMethod()]
        public void EncodeTest()
        {
            const string str = "asd";
            const int key = 1;
            const string expected_str = "bte";

            var actual_str = StringEncoder.Encode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }

        [TestMethod()]
        public void DecodeTest()
        {
            const string str = "bte";
            const int key = 1;
            const string expected_str = "asd";

            var actual_str = StringEncoder.Decode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }
    }
}