using System.Collections.Generic;

namespace sharedcode
{
  public class Pool<TItem> : IPool<TItem> where TItem : IPoolable, new()
  {
    private ISet<TItem> _inactive;
    private ISet<TItem> _active;

    public Pool()
    {
      _inactive = new HashSet<TItem>();
      _active = new HashSet<TItem>();
    }

    public void Dispose()
    {
      ClearAll();
    }

    public int Count()
    {
      return _inactive.Count + _active.Count;
    }

    public void ClearAll()
    {
      ClearInactive();
      ClearActive();
    }

    public void ClearInactive()
    {
      foreach (TItem item in _inactive)
      {
        item.Dispose();
      }
      _inactive.Clear();
    }

    public void ClearActive()
    {
      foreach (TItem item in _active)
      {
        item.Dispose();
      }
      _active.Clear();
    }

    public TItem Acquire()
    {
      TItem item;
      if (_inactive.Count == 0)
      {
        item = new TItem();
        _active.Add(item);
        item.Acquired(onReleased);
      }
      else
      {
        item = _inactive.GetEnumerator().Current;
        _inactive.Remove(item);
      }
      return item;
    }

    private void onReleased(IPoolable item)
    {
      TItem it = (TItem)item;
      item.Returned();
      _active.Remove(it);
      _inactive.Add(it);
    }
  }
}
