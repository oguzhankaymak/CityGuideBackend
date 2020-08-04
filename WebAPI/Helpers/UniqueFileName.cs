using System;
using System.IO;

namespace WebAPI.Helpers
{
    public static class UniqueFileName
    {
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return  Path.GetFileNameWithoutExtension(fileName)
                  + "_" 
                  + Guid.NewGuid().ToString().Substring(0, 4) 
                  + Path.GetExtension(fileName);
        }
    }
}