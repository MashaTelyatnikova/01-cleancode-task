using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string file, byte[] data)
		{

		    var fileStream = GetFileStream(file, Path.GetExtension(file), FileMode.OpenOrCreate);
            var backupFileStream = GetFileStream(file, "bkp", FileMode.OpenOrCreate);
			
            WriteDataToFileStream(data, fileStream);
            WriteDataToFileStream(data, backupFileStream);

			var fileTime = file + ".time";
            var timeFileStream = GetFileStream(fileTime, Path.GetExtension(fileTime), FileMode.OpenOrCreate);
			var bytesCurrentTime = BitConverter.GetBytes(DateTime.Now.Ticks);
			
            WriteDataToFileStream(bytesCurrentTime, timeFileStream);
		}

	    public static FileStream GetFileStream(string path, string extension, FileMode fileMode)
	    {
	        return new FileStream(Path.ChangeExtension(path, extension), fileMode);
	    }

	    public static void WriteDataToFileStream(byte[] data, FileStream fileStream)
	    {
	        fileStream.Write(data, 0, data.Length);
            fileStream.Close();
	    }
	}
}