using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLab.IncrementalModel
{
    class CommandManager
    {
        // Singleton
        private CommandManager()
        {}

        private static CommandManager _inst = null;

        public static CommandManager GetInstance()
        {
            if (_inst == null)
            {
                _inst = new CommandManager();
            }

            return _inst;
        }

        // Поля
        private List<ICommand> _commandList = new List<ICommand>();
        private bool _isUndoProcess = false;

        private void RevertToInitialState()
        {
            throw new NotImplementedException();
        }

        // Функционал
        public void Registry(ICommand command)
        {
            if (!_isUndoProcess)
            {
                _commandList.Add(command);
            }
        }

        public void Undo()
        {
            // Не нужно потому что первой командой всегда будет инициализация приложения,
            // которая все вернет как было
            // RevertToInitialState();

            _isUndoProcess = true;
            if (_commandList.Count > 1)
            {
                _commandList.RemoveAt(_commandList.Count - 1);
            }
            else
            {
                Console.WriteLine("Stack of command is empty");
            }

            
            foreach (var command in _commandList)
            {
                command.Execute();
            }

            _isUndoProcess = false;
        }
    }
}
