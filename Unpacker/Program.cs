using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Unpacker
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(500);
            if (!Directory.Exists("patch"))
            {
                return;
            }
            foreach (var item in Directory.GetFiles("."))
            {
                try
                {
                    File.Delete(item);
                }
                catch
                {
                    continue;
                }
            }

            foreach (var item in Directory.GetDirectories("patch"))
            {
                Directory.CreateDirectory(item.Replace("patch", "."));
            }

            foreach (var item in Directory.GetFileSystemEntries("patch"))
            {
                File.Copy(item, item.Replace("patch", "."), true);
            }

            Directory.Delete("patch", true);

            if (File.Exists("Data.xml"))
            {
                var reader = new XmlTextReader("Data.xml");
                reader.ReadToFollowing("program");
                Process.Start($"{reader.GetAttribute("title")}.exe");
            }
        }
    }
}
