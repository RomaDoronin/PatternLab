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
            //ICommand copy = this.CopyCommand();
            //Console.WriteLine("ACommand.Equals           : " + ACommand.Equals(copy, this).ToString());
            //Console.WriteLine("ACommand.ReferenceEquals  : " + ACommand.ReferenceEquals(this.CopyCommand(), this).ToString());

            //CM.Registry(this.CopyCommand());
            CM.Registry((ICommand)this.MemberwiseClone());

            this.DoExecute();
        }

        public abstract ICommand CopyCommand();
    }
}
