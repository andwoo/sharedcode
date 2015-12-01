using System;
using System.Collections.Generic;

namespace sharedcode
{
  public class CommandBinder : ICommandBinder
  {
    private IDictionary<IComparable, ICommandList> _commandLists;
    private ISet<IComparable> _activeCommands;

    public CommandBinder()
    {
      _commandLists = new Dictionary<IComparable, ICommandList>();
      _activeCommands = new HashSet<IComparable>();
    }

    public void Dispose()
    {
      UnBindAll();
      _commandLists = null;
      _activeCommands.Clear();
      _activeCommands = null;
    }

    public ICommandList Bind(IComparable commandTrigger)
    {
      if (!HasBinding(commandTrigger))
      {
        ICommandList cmdList = new CommandList();
        _commandLists.Add(commandTrigger, cmdList);
        return cmdList;
      }
      else
      {
        throw new Exception("commandTrigger already used");
      }
    }

    public bool HasBinding(IComparable commandTrigger)
    {
      return _commandLists.ContainsKey(commandTrigger);
    }

    public void UnBind(IComparable commandTrigger)
    {
      if (HasBinding(commandTrigger))
      {
        _commandLists[commandTrigger].Dispose();
        _commandLists.Remove(commandTrigger);
      }
    }

    public void UnBindAll()
    {
      foreach (KeyValuePair<IComparable, ICommandList> kvp in _commandLists)
      {
        kvp.Value.Dispose();
      }
      _commandLists.Clear();
    }

    public void Trigger(IComparable commandTrigger)
    {
      if (HasBinding(commandTrigger))
      {
        if (_commandLists[commandTrigger].isSingleton && _activeCommands.Contains(commandTrigger))
        {
          return;
        }

        _activeCommands.Add(commandTrigger);
        new CommandSequence(_commandLists[commandTrigger], delegate()
        {
          if(_activeCommands != null)
          {
            _activeCommands.Remove(commandTrigger);
          }
        }).Start();
      }
    }
  }
}
