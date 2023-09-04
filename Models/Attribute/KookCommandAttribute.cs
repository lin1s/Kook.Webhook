using Models.Emun;

namespace Tools
{
    /// <summary>
    /// 设置命令内容
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class KookCommandAttribute : System.Attribute
    {
        string Command;

        KeywordLocal Local;

        public KookCommandAttribute(string command, KeywordLocal local)
        {
            Command = command;
            Local = local;
        }

        public string GetCommand() => Command;

        public KeywordLocal GetLocal() => Local;
    }
}
