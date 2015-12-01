using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharedcode;
using tests.TestCommands;

namespace tests
{
  [TestClass]
  public class CommandTests
  {
    private static ICommandBinder CreateCommandBinder()
    {
      return new CommandBinder();
    }

    [TestMethod, ExpectedException(typeof(Exception))]
    public void MultiBindSameEventTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).To<AssertSuccessCommand>();
      binder.Bind(TestEnumEvent.Banana).To<AssertSuccessCommand>();
    }

    [TestMethod]
    public void TriggerCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).To<AssertSuccessCommand>();
      binder.Trigger(TestEnumEvent.Banana);
    }

    [TestMethod]
    public void TriggerWrongCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).To<AssertFailCommand>();
      binder.Trigger(TestEnumEvent.Pear);
    }

    [TestMethod]
    public void UnbindAndTriggerCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).To<AssertFailCommand>();
      binder.UnBind(TestEnumEvent.Banana);
      binder.Trigger(TestEnumEvent.Banana);
    }

    [TestMethod]
    public void TriggerSequenceCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>();
      binder.Trigger(TestEnumEvent.Banana);
    }

    [TestMethod]
    public void TriggerSingletonSequenceCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>().
        To<AssertSuccessCommand>().AsSingleton();
      binder.Trigger(TestEnumEvent.Banana);
      binder.Trigger(TestEnumEvent.Banana);
    }

    [TestMethod]
    public void RetainedSuccessCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).
        To<RetainSuccessCommand>().
        To<AssertSuccessCommand>();
      binder.Trigger(TestEnumEvent.Banana);
    }

    [TestMethod]
    public void RetainedFailedCommandTest()
    {
      ICommandBinder binder = CreateCommandBinder();
      binder.Bind(TestEnumEvent.Banana).
        To<RetainFailCommand>().
        To<AssertFailCommand>();
      binder.Trigger(TestEnumEvent.Banana);
    }
  }

  enum TestEnumEvent
  {
    Banana,
    Pear,
    Grape
  }
}
