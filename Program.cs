// FileHandlers namespace
namespace FileHandlers
{
    public class BinaryFileHandler
    {
        private readonly string _filePath;

        public BinaryFileHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteBinaryFile(byte[] data)
        {
            FileStream? fs = null;

            try
            {
                if (File.Exists(_filePath))
                {
                    // Logging or Warning mechanism
                }

                fs = new FileStream(_filePath, FileMode.Create);
                fs.Write(data, 0, data.Length);
            }
            catch (UnauthorizedAccessException)
            {
                // Log or throw exception
            }
            catch (PathTooLongException)
            {
                // Log or throw exception
            }
            catch (IOException ex)
            {
                // Log or throw exception
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public byte[]? ReadBinaryFile()
        {
            FileStream? fs = null;

            try
            {
                if (!File.Exists(_filePath))
                {
                    // Log or throw exception
                    return null;
                }

                fs = new FileStream(_filePath, FileMode.Open);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                return data;
            }
            catch (UnauthorizedAccessException)
            {
                // Log or throw exception
            }
            catch (PathTooLongException)
            {
                // Log or throw exception
            }
            catch (IOException ex)
            {
                // Log or throw exception
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return null;
        }
    }
}

// Main program
class Program
{
    static void Main()
    {
        // You may need to add "using FileHandlers;" if not in the same namespace
        FileHandlers.BinaryFileHandler fileHandler = new FileHandlers.BinaryFileHandler(@"./binaryfile.bin");

        // Writing example
        byte[] dataToWrite = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        fileHandler.WriteBinaryFile(dataToWrite);

        // Reading example
        byte[]? readData = fileHandler.ReadBinaryFile();
        if (readData != null)
        {
            foreach (byte b in readData)
            {
                Console.Write(b + " ");
            }
        }
    }
}
