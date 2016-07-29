using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UC_Console
{
    class DirectoryHandler
    {
        //Field
        private string DirPath;

        public int CountItem;

        private List<string> DirsList;

        //Constructor
        public DirectoryHandler(string dirPath)
        {
            this.DirPath = dirPath;
            this.DirsList = new List<string>(Directory.EnumerateDirectories(DirPath));
            this.CountItem = DirsList.Count;
        }

        /// <summary>
        /// Enumerates the directory names for path defined as designer arguments
        /// </summary
        public void OpenDirectory()
        {
            this.DirsList = new List<string>(Directory.EnumerateDirectories(DirPath));

            Int32 listNum = 0;

            foreach (var dir in DirsList)
            {
                DirectoryInfo dirAttrib = new DirectoryInfo(dir);

                // Doesn't shows hidden system directories
                if ((dirAttrib.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    Console.WriteLine("[{0}] {1}", listNum++, dir.Substring(dir.LastIndexOf("\\") + 1));
                }
            }

            Console.WriteLine("\nЧтобы выбрать введите номер каталог [n]");
            Console.WriteLine("\nЧтобы выйти из текущего каталога введите [.]");
        }

        public void OpenDirectory(int cmd)
        {
            Console.Clear();
            this.DirPath = DirsList[cmd];
            this.OpenDirectory();
        }

        public void PrevDirectory()
        {
            if (DirPath.Length != 4)
            {
                Console.Clear();
                this.DirPath = DirPath.Remove(DirPath.LastIndexOf("\\"));
                this.OpenDirectory();
            }
        }
    }
}
