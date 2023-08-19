using Models;
using Tools;

namespace Command
{
    public class StartRailCommand
    {
        [KookCommand("攻略")]
        public void GetData(Challenge commandJson)
        {
            LogHelper.Default.Info("进入1次");
        }
    }
}
