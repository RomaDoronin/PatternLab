using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab.IncrementalModel
{
    abstract class ACommand : ICommand
    {
        protected abstract void DoExecute();

        public void Execute()
        {
            CommandManager CM = CommandManager.GetInstance();

            CM.Registry((ICommand)this.MemberwiseClone());

            this.DoExecute();
        }
    }
}
