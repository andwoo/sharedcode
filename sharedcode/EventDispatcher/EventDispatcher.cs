using System;
using System.Collections.Generic;

namespace sharedcode
{
  /// <summary>
  /// Used to send dispatch events to communicate between objects.
  /// </summary>
  public class EventDispatcher : IEventDispatcher
  {
    /// <summary>
    /// Event handler reference storage.
    /// </summary>
    private IDictionary<IComparable, EventObject> _observers;
    
    /// <summary>
    /// Creates a new instance of the dispatcher.
    /// </summary>
    public EventDispatcher()
    {
      _observers = new Dictionary<IComparable, EventObject>();
    }

    /// <summary>
    /// Binds a event listener. When the value for name is used when dispatching, the subscribed event handles will be invoked.
    /// </summary>
    /// <param name="name">Event name or id.</param>
    /// <param name="eventListener">Event handler method.</param>
    public void AddEventListener(IComparable name, EventHandler eventListener)
    {
      if (!HasEvent(name))
      {
        _observers[name] = new EventObject();
      }
      _observers[name].eventListeners += eventListener;
    }

    /// <summary>
    /// Unbinds the event listner delegate from the event.
    /// </summary>
    /// <param name="name">Event name or id.</param>
    /// <param name="eventListener">Event handler method.</param>
    public void RemoveEventListener(IComparable name, EventHandler eventListener)
    {
      if (HasEvent(name))
      {
        _observers[name].eventListeners -= eventListener;

        if (_observers[name].TotalEventListeners() == 0)
        {
          _observers.Remove(name);
        }
      }
    }

    /// <summary>
    /// Invokes all listners for the supplied event name.
    /// </summary>
    /// <param name="name">Event name or id.</param>
    /// <param name="data">Optional data to be send to all listeners.</param>
    public void DispatchEvent(IComparable name, object data)
    {
      if (HasEvent(name))
      {
        _observers[name].Dispatch(data);
      }
    }

    /// <summary>
    /// Checks if an EventObject has already been created in the observer list.
    /// </summary>
    /// <param name="name">Event name or id.</param>
    /// <returns>TRUE if the EventObject exists.</returns>
    private bool HasEvent(IComparable name)
    {
      return _observers != null && _observers.ContainsKey(name) ? true : false;
    }

    /// <summary>
    /// Removes all event listener delegates.
    /// </summary>
    public void RemoveAllEventListeners()
    {
      if (_observers != null && _observers.Count > 0)
      {
        foreach (KeyValuePair<IComparable, EventObject> kvp in _observers)
        {
          kvp.Value.RemoveAllEventListeners();
        }
      }
      _observers.Clear();
    }

    /// <summary>
    /// Removes all event listeners.
    /// </summary>
    public void Dispose()
    {
      RemoveAllEventListeners();
    }
  }

  /// <summary>
  /// Holds onto data associated to a single event.
  /// </summary>
  internal class EventObject
  {
    /// <summary>
    /// Event object containing listeners.
    /// </summary>
    public event EventHandler eventListeners;

    public EventObject() { }

    /// <summary>
    /// Dispatches the event with the supplied data.
    /// </summary>
    /// <param name="data">Optional data to be send to all listeners.</param>
    public void Dispatch(object data)
    {
      if (eventListeners != null)
      {
        eventListeners(data);
      }
    }

    /// <summary>
    /// Removes all event listener delegates.
    /// </summary>
    public void RemoveAllEventListeners()
    {
      eventListeners = null;
    }

    /// <summary>
    /// Returns the total number of subscribers to the event.
    /// </summary>
    /// <returns>Total subscribers</returns>
    public int TotalEventListeners()
    {
      return eventListeners != null ? eventListeners.GetInvocationList().Length : 0;
    }
  }
}
