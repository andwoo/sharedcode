using System;

namespace sharedcode
{
  public delegate void EventHandler(object data);

  public interface IEventDispatcher : IDisposable
  {
    void AddEventListener(IComparable eventName, EventHandler handler);
    void RemoveEventListener(IComparable eventName, EventHandler handler);
    void DispatchEvent(IComparable eventName, object data);
    void RemoveAllEventListeners();
  }
}
