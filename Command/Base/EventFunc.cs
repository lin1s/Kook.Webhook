using Models.Response;

namespace Command.Base
{
    public static partial class EventFunc
    {
        public static void TestEvent(object sender, Challenge commandJson)
        {
            Console.WriteLine(commandJson.ToString());
        }
    }
}
