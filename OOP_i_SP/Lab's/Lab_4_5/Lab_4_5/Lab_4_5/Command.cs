using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5
{
    public abstract class Command
    {
        protected PullOfMethods pull;

        public Command(PullOfMethods pull)
        {
            this.pull = pull;
        }
        public abstract void Execute();
    }
}
