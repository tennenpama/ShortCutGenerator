using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutGenerator
{
    public class ShortCutsGenerator
    {
        /// <summary>
        /// Generate folder with .lnk files into current directory.
        /// </summary>
        public void GenerateWithCurrentDirFiles()
        {
            var folderPath = Directory.GetCurrentDirectory() + @"\ShortCuts";

            //フォルダ作成
            Directory.CreateDirectory(folderPath);

            foreach(var x in GetCurrentFilePathList())
            {
                var ext = Path.GetExtension(x);

                ShortCutFile.Generate(x, x.Replace(Directory.GetCurrentDirectory(), folderPath + @"\").Replace(ext, ".lnk"));
            }

        }

        /// <summary>
        ///   Get list of paths with current directory.
        /// </summary>
        /// <returns>list of paths</returns>
        private IEnumerable<string> GetCurrentFilePathList()
        {
            string[] extensions = { ".mp4", ".avi" };

            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());

            IEnumerable<FileInfo> fileInfoList = di.GetFiles("*.*", SearchOption.AllDirectories).Where(x => extensions.Contains(x.Extension));

            List<string> filePath = new List<string>();

            foreach(var x in fileInfoList)
            {
                filePath.Add(x.FullName);
            }

            return filePath;
        }
    }
}
