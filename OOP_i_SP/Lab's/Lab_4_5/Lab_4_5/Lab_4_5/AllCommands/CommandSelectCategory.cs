using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.AllCommands
{
    public class CommandSelectCategory: Command
    {
        public CommandSelectCategory(PullOfMethods pull) : base(pull) { }
        public override void Execute()
        {
            pull.SelectCategory();
        }
    }
}
