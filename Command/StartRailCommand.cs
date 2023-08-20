using Models;
using Models.Attribute;
using Models.Emun;
using Tools;

namespace Command
{
    public class StartRailCommand
    {
        private readonly Config config = ConfigHelper.GetBaseConfig();

        [KookCommand("攻略")]
        [KeywordLocal(KeywordLocal.End)]
        public void GetData(Challenge commandJson)
        {
            if (commandJson.d.type != MessageType.Kmarkdown) return;
            string strContent = commandJson.d.content;

            string strCommand = strContent.Remove(strContent.IndexOf("攻略"), "攻略".Length).
                                           Remove(strContent.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim();


        
        
        }
    }
}
