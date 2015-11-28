using System;

namespace sharedcode
{
  public interface ICommandBinder
  {
    void Bind<TCommand>(IComparable commandTriggerName) where TCommand : Command, new();
    void UnBind<TCommand>(IComparable commandTriggerName) where TCommand : Command;
    void UnBindAll();
  }

  public interface ICommandSequencer
  {
    void Then<TCommand>() where TCommand : Command, new();
  }
}
