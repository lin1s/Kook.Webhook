using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class KookCommandAttribute : System.Attribute
    {
        string Command;

        public KookCommandAttribute(string command) => Command = command;

        public string GetCommand() => Command;
    }
}
