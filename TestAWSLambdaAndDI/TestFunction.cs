using Amazon.Lambda.TestUtilities;
using AWSLambdaAndDI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace TestAWSLambdaAndDI
{
    [TestClass]
    public class TestFunction
    {
        [TestMethod]
        public void TestMainFunction_Input_Darren_Should_Return_Darren_hello()
        {
            var input = "Darren";
            var mockTalkService = new Mock<ITalkService>();
            mockTalkService.Setup(x => x.SayHello(input)).Returns(input + ": hello!");
            var function = new Function(mockTalkService.Object);

            var actual = function.FunctionHandler(input, new TestLambdaContext());

            Assert.AreEqual("Darren: hello!", actual);
        }
    }
}
