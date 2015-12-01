using System;

namespace sharedcode
{
  class CommandSequence : ICommandSequence
  {
    private ICommandList _commandList;
    private CommandsComplete _allCommandsComplete;
    private int _commandIndex;

    public CommandSequence(ICommandList commandList, CommandsComplete allCommandsComplete)
    {
      _commandList = commandList;
      _allCommandsComplete = allCommandsComplete;
    }

    public void Dispose()
    {
      _commandList = null;
      _allCommandsComplete = null;
    }

    public void Start()
    {
      ExcecuteCommand();
    }

    private void Next()
    {
      if (++_commandIndex < _commandList.commands.Count)
      {
        ExcecuteCommand();
      }
      else
      {
        SequenceComplete();
      }
    }

    private void ExcecuteCommand()
    {
      Command cmd = (Command)Activator.CreateInstance(_commandList.commands[_commandIndex]);
      cmd.Execute();
      if (cmd.retained)
      {
        cmd.onCommandComplete = delegate (bool success)
        {
          cmd.Dispose();
          if (success)
          {
            Next();
          }
          else
          {
            SequenceComplete();
          }
        };
      }
      else
      {
        cmd.Dispose();
        Next();
      }
    }

    private void SequenceComplete()
    {
      _allCommandsComplete();
      Dispose();
    }
  }
}
