using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameBackupSystem
{
    static class FileUtilities
    {
        public static void CreateDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        internal static string GetLowestFolder(string folder)
        {
            string lowestFolder = "";
            lowestFolder = Path.GetFileName(folder);
            if(lowestFolder == null)
            {
                lowestFolder = Path.GetFileName(Path.GetDirectoryName(folder));
            }
            return lowestFolder;
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool overwriteFiles, bool copySubDirs, bool removeOrphanFilesAndFolders)
        { //copied from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
          // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (removeOrphanFilesAndFolders)
            {
                Directory.Delete(destDirName);
            }
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, overwriteFiles);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    DirectoryCopy(subdir.FullName, Path.Combine(destDirName, subdir.Name), overwriteFiles, copySubDirs, removeOrphanFilesAndFolders);
                }
            }
        }

        /// <summary>
        /// Returns a printable string of the provided XML document.
        /// </summary>
        /// <param name="doc">The document from which to make the string.</param>
        /// <returns>The printable string</returns>
        public static string PrintXml(XmlDocument doc)
        {
            return PrintXml(doc.FirstChild, 0);
        }

        public static string PrintXml(XmlNode node, int indent)
        {
            string printableDocument = "";
            if (node != null)
            {
                string indents = "";
                for (int i = 0; i < indent; i++)
                {
                    indents += "  ";
                }
                if (node.HasChildNodes)
                {
                    printableDocument += indents + "<" + node.Name;

                    if (node.Attributes != null)
                    {
                        foreach (XmlAttribute att in node.Attributes)
                        {
                            printableDocument += " " + att.Name + "=\"";
                            printableDocument += att.Value + "\"";
                        }
                    }
                    printableDocument += ">";
                    if (node.FirstChild.HasChildNodes)
                    {
                        printableDocument += "\n";
                    }

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        printableDocument += PrintXml(child, indent + 1);
                    }

                    if (node.FirstChild.HasChildNodes)
                    {
                        printableDocument += indents;
                    }
                    printableDocument += "</" + node.Name + ">\n";
                }
                else
                {
                    printableDocument += node.InnerText;
                }
            }
            return printableDocument;
        }
    }
}
