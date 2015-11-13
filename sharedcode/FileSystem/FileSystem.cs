using System;
using System.IO;
using System.Text;

namespace sharedcode
{
  /// <summary>
  /// File System helper methods.
  /// </summary>
  public static partial class FileSystem
  {
    #region Utility Methods
    /// <summary>
    /// Returns the combined path.
    /// </summary>
    /// <param name="path1">The first path to combine. Path should not start with "/".</param>
    /// <param name="path2">The second path to combine. Path should not start with "/".</param>
    /// <returns>The combined paths. If one of the specified paths is a zero-length string, this method returns the other path. If path2 contains an absolute path, this method returns path2.</returns>
    public static string ResolvePath(string path1, string path2)
    {
      return Path.GetFullPath(Path.Combine(path1, path2));
    }

    /// <summary>
    /// Returns a bool indicating if the directory exists.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <returns>TRUE if the directory exists.</returns>
    public static bool DirectoryExists(string filePath)
    {
      return Directory.Exists(Path.GetDirectoryName(filePath));
    }

    /// <summary>
    /// Creates a directory if it does not exist.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    public static void CreateDirectory(string filePath)
    {
      if (!DirectoryExists(filePath))
      {
        Directory.CreateDirectory(filePath);
      }
    }

    /// <summary>
    /// Returns a bool indicating if the file at the given path exists.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <returns>TRUE if the file exists.</returns>
    public static bool FileExists(string filePath)
    {
      return File.Exists(filePath);
    }
    #endregion

    #region Read File Methods
    /// <summary>
    /// Reads the file's contents as string and dumps the contents into the response object.
    /// </summary>
    /// <typeparam name="TReadResponse">The response object to dump the file contents into.</typeparam>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <returns>Read response object.</returns>
    public static IReadResponse<string> ReadStringFile<TReadResponse>(string filePath) where TReadResponse : IReadResponse<string>, new()
    {
      TReadResponse response = new TReadResponse();
      filePath = ResolvePath(Environment.CurrentDirectory, filePath);
      if (FileExists(filePath))
      {
        response.SetContent(Encoding.UTF8.GetString(ReadBytesFile(filePath)));
      }
      return response;
    }

    /// <summary>
    /// Reads the file's contents as a byte array and dumps the contents into the response object.
    /// </summary>
    /// <typeparam name="TReadResponse">The response object to dump the file contents into.</typeparam>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <returns>Read response object.</returns>
    public static IReadResponse<byte[]> ReadBytesFile<TReadResponse>(string filePath) where TReadResponse : IReadResponse<byte[]>, new()
    {
      TReadResponse response = new TReadResponse();
      filePath = ResolvePath(Environment.CurrentDirectory, filePath);
      if (FileExists(filePath))
      {
        response.SetContent(ReadBytesFile(filePath));
      }
      return response;
    }

    /// <summary>
    /// Reads the file's contents as a byte array.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <returns>The file's contents as a byte array.</returns>
    private static byte[] ReadBytesFile(string filePath)
    {
      filePath = ResolvePath(Environment.CurrentDirectory, filePath);
      return File.ReadAllBytes(filePath);
    }
    #endregion

    #region Write File Methods
    /// <summary>
    /// Writes the string data to file.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <param name="content">The string data to write to file</param>
    public static void WriteStringFile(string filePath, string content)
    {
      WriteBytesFile(filePath, Encoding.UTF8.GetBytes(content));
    }

    /// <summary>
    /// Writes the byte array data to file.
    /// </summary>
    /// <param name="filePath">Full file path including file name and extension. Path should not start with "/".</param>
    /// <param name="content">The byte array data to write to file</param>
    public static void WriteBytesFile(string filePath, byte[] content)
    {
      filePath = ResolvePath(Environment.CurrentDirectory, filePath);
      CreateDirectory(filePath);
      File.WriteAllBytes(filePath, content);
    }
    #endregion
  }
}
