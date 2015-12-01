using System;

namespace sharedcode
{
  public abstract class Command : IDisposable
  {
    public bool retained { get; private set; }
    public CommandComplete onCommandComplete;

    public abstract void Execute();

    public virtual void Dispose()
    {
      onCommandComplete = null;
    }

    protected void Retain()
    {
      retained = true;
    }

    protected void Release(bool success)
    {
      onCommandComplete(success);
    }
  }
}
