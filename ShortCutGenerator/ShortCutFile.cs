using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortCutGenerator
{
    public static class ShortCutFile
    {
        /// <summary>
        /// Generate short cut file. (.lnk)
        ///  reference: https://dobon.net/vb/dotnet/file/createshortcut.html
        /// </summary>
        public static void Generate(string targetPath, string generatePath)
        {
            dynamic shell = null;
            dynamic shortcut = null;

            try
            {
                //WshShellを作成
                Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
                shell = Activator.CreateInstance(t);

                //WshShortcutを作成
                shortcut = shell.CreateShortcut(generatePath);
                //リンク先
                shortcut.TargetPath = targetPath;
                //アイコンのパス
                shortcut.IconLocation = targetPath + ",0";

                //フォルダが存在しな場合は作成する。
                if (!Directory.Exists(Path.GetDirectoryName(generatePath))) Directory.CreateDirectory(Path.GetDirectoryName(generatePath));

                //ショートカットを作成
                shortcut.Save();
            }
            catch(ArgumentException e)
            {
                //例えば、ファイルパスに絵文字が入っていると発生する。手作業でファイルパス直してください。
                File.AppendAllText("errorFiles.txt", targetPath + Environment.NewLine);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
            }

        }
    }
}
