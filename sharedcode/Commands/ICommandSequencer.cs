namespace sharedcode
{
  public interface ICommandSequencer
  {
    ICommandSequencer Then<TCommand>() where TCommand : Command, new();
    void Start();
    void Next();
    void End();
  }
}
