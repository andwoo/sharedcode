namespace sharedcode
{
  /// <summary>
  /// Contains a static singleton reference to the base class.
  /// </summary>
  /// <typeparam name="TSingleton">Type of the derived base class.</typeparam>
  public class Singleton<TSingleton> where TSingleton : new()
  {
    /// <summary>
    /// Singleton reference.
    /// </summary>
    private static TSingleton _instance;

    /// <summary>
    /// Singleton reference.
    /// </summary>
    public static TSingleton instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new TSingleton();
        }
        return _instance;
      }
    }
  }
}
