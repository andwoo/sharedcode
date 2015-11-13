namespace sharedcode
{
  public class ReadResponse<TReadObject> : IReadResponse<TReadObject>
  {
    public bool success { get; private set; }
    public TReadObject content { get; private set; }

    public ReadResponse()
    {
      success = false;
    }

    public void SetContent(TReadObject content)
    {
      success = true;
      this.content = content;
    }
  }
}
