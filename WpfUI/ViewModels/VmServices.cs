using Services.Enums;
using System;
using System.Collections.Generic;

namespace WpfUI.ViewModels
{
    public class VmServices
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static readonly Dictionary<string, string> Extends = new Dictionary<string, string> {
            { "exe", "Application" },
            { "doc", "Document" },
            { "docx", "Document" },
            { "pdf", "Acrobat Doc." },
            { "txt", "Text" } };

        public static string GetFileType(string ext)
        {
            if (Extends.ContainsKey(ext))
            {
                return Extends.GetValueOrDefault(ext);
            }

            return "File";
        }

        public static string NotAuto(long size, int level)
        {
            double result = size;
            for (int i = 0; i < level; i++)
            {
                result /= 1024.0;
            }

            return string.Format("{0:0.00}", result) + " " + SizeSuffixes[level];
        }

        public static string AutoSize(Int64 value, int decPlaces = 1)
        {
            if (decPlaces < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(decPlaces));
            }

            if (value < 0)
            {
                return "-" + AutoSize(-value, decPlaces);
            }

            if (value == 0)
            {
                return string.Format("{0:n" + decPlaces + "} bytes", 0);
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjastedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjastedSize, decPlaces) >= 1000)
            {
                mag += 1;
                adjastedSize /= 1024;
            }

            return string.Format("{0:n" + decPlaces + "} {1}", adjastedSize, SizeSuffixes[mag]);
        }

        public static string DisplaySize(long size, SizeFormats format)
        {
            switch (format)
            {
                case SizeFormats.AUTO: return AutoSize(size);
                case SizeFormats.kB: return NotAuto(size, 1);
                case SizeFormats.MB: return NotAuto(size, 2);
                case SizeFormats.GB: return NotAuto(size, 3);
            }
            return "Error!";
        }
    }
}
