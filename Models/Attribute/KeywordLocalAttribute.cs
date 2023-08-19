using Models.Emun;

namespace Models.Attribute
{
    /// <summary>
    /// 设置关键字位置
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class KeywordLocalAttribute : System.Attribute
    {
        KeywordLocal Local = KeywordLocal.Contain;

        public KeywordLocalAttribute(KeywordLocal local) => Local = local;

        public KeywordLocal GetLocal() => Local;

    }
}
