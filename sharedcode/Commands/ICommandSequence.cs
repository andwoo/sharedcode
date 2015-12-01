using System;

namespace sharedcode
{
  public delegate void CommandsComplete();
  public delegate void CommandComplete(bool success);

  public interface ICommandSequence : IDisposable
  {
    void Start();
  }
}
