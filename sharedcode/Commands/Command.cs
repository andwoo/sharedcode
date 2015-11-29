using System;

namespace sharedcode
{
  public abstract class Command : IDisposable
  {
    public bool retained { get; private set; }

    public abstract void Execute();
    public abstract void Dispose();

    protected void Retain()
    {
      retained = true;
    }

    protected void Release()
    {
      Dispose();
    }
  }
}
