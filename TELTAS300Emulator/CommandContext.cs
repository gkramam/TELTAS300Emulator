using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class CommandContext
    {
        public string CommandMessage;
        public Action<string> ResponseQCallback;

        public CommandContext(Action<string> responseQCallback, string commandMessage)
        {
            CommandMessage = commandMessage;
            ResponseQCallback = responseQCallback;
        }
    }
}
