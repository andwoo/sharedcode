using System;

namespace sharedcode
{
  public class CommandBinder : ICommandBinder
  {
    public ICommandSequencer Bind<TCommand>(IComparable commandTrigger) where TCommand : Command, new()
    {
      throw new NotImplementedException();
    }

    public void UnBind<TCommand>(IComparable commandTrigger) where TCommand : Command
    {
      throw new NotImplementedException();
    }

    public void UnBindAll()
    {
      throw new NotImplementedException();
    }
  }
}
