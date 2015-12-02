using System;

namespace sharedcode
{
  public interface IPool<TItem> : IDisposable where TItem : IPoolable, new()
  {
    int Count();
    void ClearAll();
    void ClearInactive();
    void ClearActive();
    TItem Acquire();
  }
}
