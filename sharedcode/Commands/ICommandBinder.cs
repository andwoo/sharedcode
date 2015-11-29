using System;

namespace sharedcode
{
  public interface ICommandBinder
  {
    ICommandSequencer Bind<TCommand>(IComparable commandTrigger) where TCommand : Command, new();
    void UnBind<TCommand>(IComparable commandTrigger) where TCommand : Command;
    void UnBindAll();
  }
}
