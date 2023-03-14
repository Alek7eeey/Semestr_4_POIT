using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.AllCommands
{
    internal class CommandSearchCountry : Command
    {
        public CommandSearchCountry(PullOfMethods pull) : base(pull) { }

        public override void Execute()
        {
            pull.SearchForCountry();
        }
    }
}
