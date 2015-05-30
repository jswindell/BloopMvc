using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BloopMvc.Models
{
    internal static class BloopFileFinder
    {
        public static IEnumerable<BloopFile> FindFiles(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (!Directory.Exists(path))
                return Enumerable.Empty<BloopFile>();

            int fileId = 0;
            return Directory.GetFiles(path)
                .Where(file => file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                .Select(file => new BloopFile
                {
                    Id = ++fileId,
                    Name = Path.GetFileName(file),
                    DateTime = File.GetLastWriteTime(file),
                    Content = File.ReadAllText(file)
                });
        }
    }
}