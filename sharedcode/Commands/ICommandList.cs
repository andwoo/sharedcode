using System;
using System.Collections.Generic;

namespace sharedcode
{
  public interface ICommandList : IDisposable
  {
    IList<Type> commands { get; }
    bool isSingleton { get; }

    ICommandList To<TCommand>() where TCommand : Command;
    ICommandList AsSingleton();
  }
}
