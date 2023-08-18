using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Emun
{
    public enum MessageType
    {
        Text = 1,
        Pic = 2,
        Video = 3,
        File = 4,
        Audeo = 8,
        Kmarkdown = 9,
        Card = 10,
        System = 255
    }
}
