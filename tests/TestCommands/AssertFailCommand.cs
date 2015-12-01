using sharedcode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests.TestCommands
{
  class AssertFailCommand : Command
  {
    public override void Execute()
    {
      Assert.Fail();
    }
  }
}
