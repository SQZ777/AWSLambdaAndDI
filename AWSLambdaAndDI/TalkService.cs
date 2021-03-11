namespace AWSLambdaAndDI
{
    public class TalkService : ITalkService 
    {
        public string SayHello(string name)
        {
            return name + ": hello!";
        }
    }
}