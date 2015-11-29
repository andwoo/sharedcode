using System;

namespace sharedcode
{
  class CommandSequencer : ICommandSequencer
  {
    public void End()
    {
      throw new NotImplementedException();
    }

    public void Next()
    {
      throw new NotImplementedException();
    }

    public void Start()
    {
      throw new NotImplementedException();
    }

    public ICommandSequencer Then<TCommand>() where TCommand : Command, new()
    {
      throw new NotImplementedException();
    }
  }
}
