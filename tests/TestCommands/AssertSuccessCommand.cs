using sharedcode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.TestCommands
{
  public class AssertSuccessCommand : Command
  {
    public override void Execute()
    {
      Assert.IsTrue(true);
    }
  }
}
