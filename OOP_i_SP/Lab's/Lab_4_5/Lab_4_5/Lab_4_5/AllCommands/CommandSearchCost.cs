using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.AllCommands
{
    internal class CommandSearchCost : Command
    {
        public CommandSearchCost(PullOfMethods pull) : base (pull) { }

        public override void Execute()
        {
            pull.SearchForCost();
        }
    }
}
