using System;
using System.IO;
namespace Chat_Win_App
{
    public class ChatFile
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public ChatFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                FileName = fileInfo.Name;
                FileSize = fileInfo.Length;
                FileType = fileInfo.Extension;
                FileData = File.ReadAllBytes(filePath);
            }
            else
            {
                throw new FileNotFoundException("File not found.", filePath);
            }
        }
        public void SaveToFile(string destinationPath)
        {
            try
            {
                File.WriteAllBytes(destinationPath, FileData);
            }
            catch (Exception ex)
            {
                throw new IOException("Error saving file.", ex);
            }
        }
        public override string ToString()
        {
            return $"{FileName} ({FileSize} bytes)";
        }
    }
}