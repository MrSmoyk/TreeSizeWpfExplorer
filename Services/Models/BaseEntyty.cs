using System;
using System.Collections.Generic;

namespace Services.Models
{
    public class BaseEntyty
    {
        public List<BaseEntyty> SubEntytys { get; set; } = new List<BaseEntyty>();

        public string Name { get; set; }

        public long Size { get; set; }

        public long Allocated { get; set; }

        public int SubFoldersCount { get; set; }

        public int SubFilesCount { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modificated { get; set; }

        public bool IsFile { get; set; }

        public bool AccessDenied { get; set; }
    }
}
