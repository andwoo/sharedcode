using System;

namespace sharedcode
{
  public delegate void ReturnItemToPool(IPoolable item);

  public interface IPoolable : IDisposable
  {
    void Acquired(ReturnItemToPool returnCallback);
    void Returned();
  }
}
