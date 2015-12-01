using System;
using System.Collections.Generic;

namespace sharedcode
{
  class CommandList : ICommandList
  {
    public IList<Type> commands { get; private set; }
    public bool isSingleton { get; private set; }

    public CommandList()
    {
      commands = new List<Type>();
    }

    public void Dispose()
    {
      commands.Clear();
    }

    public ICommandList To<TCommand>() where TCommand : Command
    {
      commands.Add(typeof(TCommand));
      return this;
    }

    public ICommandList AsSingleton()
    {
      isSingleton = true;
      return this;
    }
  }
}
