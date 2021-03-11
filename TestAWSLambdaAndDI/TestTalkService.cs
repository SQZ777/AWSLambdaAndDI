using AWSLambdaAndDI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAWSLambdaAndDI
{
    [TestClass]
    public class TestTalkService
    {
        [TestMethod]
        public void Input_Darren_Should_Return_Darren_hello()
        {
            var talkService = new TalkService();
            var name = "Darren";
            var actual = talkService.SayHello(name);
            var expect = "Darren: hello!";

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Input_Null_Should_Return_hello()
        {
            var talkService = new TalkService();
            string name = null;
            var actual = talkService.SayHello(name);
            var expect = ": hello!";

            Assert.AreEqual(expect, actual);
        }
    }
}
