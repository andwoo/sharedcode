﻿using System.Threading.Tasks;
using sharedcode;

namespace tests.TestCommands
{
  class RetainFailCommand : Command
  {
    public override void Execute()
    {
      base.Retain();
      Delay(250);
    }

    public async void Delay(int milliseconds)
    {
      await Task.Delay(milliseconds);
      base.Release(false);
    }
  }
}
