namespace Tools
{
    /// <summary>
    /// 设置命令内容
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class KookCommandAttribute : System.Attribute
    {
        string Command;

        public KookCommandAttribute(string command) => Command = command;

        public string GetCommand() => Command;
    }
}
