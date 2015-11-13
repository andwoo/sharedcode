namespace sharedcode
{
  public interface IReadResponse<TReadObject>
  {
    bool success { get; }
    TReadObject content { get; }
    void SetContent(TReadObject content);
  }
}
