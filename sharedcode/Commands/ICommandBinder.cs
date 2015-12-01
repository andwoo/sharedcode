using System;

namespace sharedcode
{
  public interface ICommandBinder : IDisposable
  {
    ICommandList Bind(IComparable commandTrigger);
    bool HasBinding(IComparable commandTrigger);
    void UnBind(IComparable commandTrigger);
    void UnBindAll();
    void Trigger(IComparable commandTrigger);
  }
}
