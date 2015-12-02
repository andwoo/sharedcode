using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharedcode;

namespace tests
{
  [TestClass]
  public class PoolTest
  {
    private static IPool<TestPoolObject> CreateTestPool()
    {
      return new Pool<TestPoolObject>();
    }

    [TestMethod]
    public void TestPoolCreation()
    {
      IPool<TestPoolObject> pool = CreateTestPool();
    }

    [TestMethod]
    public void TestPoolAcquire()
    {
      IPool<TestPoolObject> pool = CreateTestPool();
      TestPoolObject poolObject = pool.Acquire();
      Assert.AreEqual(1, pool.Count());
      poolObject.Use();
      poolObject.Return();
      Assert.AreEqual(1, pool.Count());
      pool.Dispose();
    }

    [TestMethod]
    public void TestPoolDispose()
    {
      IPool<TestPoolObject> pool = CreateTestPool();
      TestPoolObject poolObject = pool.Acquire();
      poolObject.Return();
      Assert.AreEqual(1, pool.Count());
      pool.ClearAll();
      Assert.AreEqual(0, pool.Count());
      pool.Dispose();
    }

    [TestMethod]
    public void TestPoolDisposeActive()
    {
      IPool<TestPoolObject> pool = CreateTestPool();
      TestPoolObject poolObject = pool.Acquire();
      Assert.AreEqual(1, pool.Count());
      pool.Dispose();
      Assert.AreEqual(0, pool.Count());
    }
  }

  class TestPoolObject : IPoolable
  {
    private ReturnItemToPool _returnCallback;

    public void Dispose()
    {
      Debug.Print("object disposed");
      _returnCallback = null;
    }

    public void Acquired(ReturnItemToPool returnCallback)
    {
      Debug.Print("object acquired");
      _returnCallback = returnCallback;
    }

    public void Returned()
    {
      Debug.Print("object returned");
      _returnCallback = null;
    }

    public void Use()
    {
      Debug.Print("object used");
    }

    public void Return()
    {
      _returnCallback(this);
    }
  }
}
