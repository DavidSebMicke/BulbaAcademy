using BulbasaurAPI.Models;
using System.Net.Http.Headers;

namespace BulbasaurAPI.Utils
{
    public class PDFUtils
    {
        // Test all of these once implementation is ready
        public static byte[]? GetFile(Document document)
        {
            try
            {
                return File.ReadAllBytes(document.FilePath);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SaveFile(byte[] file, string filePath)
        {
            try
            {
                File.WriteAllBytes(filePath, file);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}