using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharedcode;

namespace tests
{
  [TestClass]
  public class EventDispatcherTests
  {
    private const string _TEST_STRING = "test_data";
    private const string _TEST_EVENT = "test_event";

    [TestMethod]
    public void TestAddEventListener()
    {
      IEventDispatcher eventDispatcher = new EventDispatcher();
      eventDispatcher.AddEventListener(_TEST_EVENT, delegate (object data)
      {
        Assert.AreEqual(_TEST_STRING, data.ToString());
      });
      eventDispatcher.DispatchEvent(_TEST_EVENT, _TEST_STRING);
      eventDispatcher.Dispose();
    }    

    [TestMethod]
    public void TestRemoveEventListener()
    {
      IEventDispatcher eventDispatcher = new EventDispatcher();
      eventDispatcher.AddEventListener(_TEST_EVENT, FailEventHandler);
      eventDispatcher.RemoveEventListener(_TEST_EVENT, FailEventHandler);
      eventDispatcher.DispatchEvent(_TEST_EVENT, _TEST_STRING);
      eventDispatcher.Dispose();
    }

    private void FailEventHandler(object data)
    {
      Assert.Fail("Event handler was invoked");
    }

    [TestMethod]
    public void TestAddNullEventListener()
    {
      IEventDispatcher eventDispatcher = new EventDispatcher();
      eventDispatcher.AddEventListener(_TEST_EVENT, null);
      eventDispatcher.DispatchEvent(_TEST_EVENT, _TEST_STRING);
      eventDispatcher.Dispose();
    }
  }
}
