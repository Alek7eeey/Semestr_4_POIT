using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.AllCommands
{
    public class CommandSortByPrice : Command
    {
        private int a; //1 - grow, 0 - wane
        public CommandSortByPrice(PullOfMethods pull, int b) : base(pull) { a = b; }

        public override void Execute()
        {
            pull.SortByPrice(a);   
        }
    }
}
