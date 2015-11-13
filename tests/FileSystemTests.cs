using Microsoft.VisualStudio.TestTools.UnitTesting;
using sharedcode;

namespace tests
{
  [TestClass]
  public class FileSystemTests
  {
    [TestMethod]
    public void ReadAndWriteStringTest()
    {
      string filePath = "./string.txt";
      string fileContents = "test data";

      FileSystem.WriteStringFile(filePath, fileContents);
      Assert.AreEqual(true, FileSystem.FileExists(filePath));

      IReadResponse<string> response = FileSystem.ReadStringFile<ReadResponse<string>>(filePath);
      Assert.AreEqual(true, response.success);
      Assert.AreEqual(fileContents, response.content);
    }

    [TestMethod]
    public void ReadAndWriteBytesTest()
    {
      string filePath = "./bytes.txt";
      byte[] fileContents = new byte[] {0, 1};

      FileSystem.WriteBytesFile(filePath, fileContents);
      Assert.AreEqual(true, FileSystem.FileExists(filePath));

      IReadResponse<byte[]> response = FileSystem.ReadBytesFile<ReadResponse<byte[]>>(filePath);
      Assert.AreEqual(true, response.success);

      for (int i = 0; i < response.content.Length; ++i)
      {
        Assert.AreEqual(fileContents[i], response.content[i]);
      }
    }
  }
}
