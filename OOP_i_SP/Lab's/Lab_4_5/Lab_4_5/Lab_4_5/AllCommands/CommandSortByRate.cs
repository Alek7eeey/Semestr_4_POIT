using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.AllCommands
{
    public class CommandSortByRate : Command
    {
        private int a;
        public CommandSortByRate(PullOfMethods pull, int b) : base(pull) { a = b; }

        public override void Execute()
        {
            pull.SortByRating(a);
        }
    }
}
