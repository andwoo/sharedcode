using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharedcode;

namespace tests
{
  [TestClass]
  public class SingletonTests
  {
    [TestMethod]
    public void CreateSingleton()
    {
      Assert.IsNotNull(TestSingleton.instance);
      Assert.AreEqual(TestSingleton.instance.ToString(), "test");
    }
  }

  public class TestSingleton : Singleton<TestSingleton>
  {
    public override string ToString()
    {
      return "test";
    }
  }
}
