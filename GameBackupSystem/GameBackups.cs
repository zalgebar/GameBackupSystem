using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GameBackupSystem
{
    public class GameBackup
    {
        private const string XML_TAG_GAMES = "GameBackups";
        private const string XML_TAG_GAME = "GameBackup";
        private const string XML_ATTR_NAME = "name";
        private const string XML_TAG_BACKUP = "BackupFolder";
        private const string XML_TAG_SAVES = "Saves";
        private const string XML_TAG_FOLDER = "Folder";
        private const string XML_TAG_OPTIONS = "Options";
        private const string XML_TAG_OPTION = "Option";

        public string GameName { get; }
        private string mBackupFolder;
        public string BackupFolder
        {
            get => mBackupFolder;
            set
            {
                Utilities.AssertNotNullOrEmpty(value);
                mBackupFolder = value;
            }
        }
        public LinkedList<string> SavesFolders { get; set; }
        public LinkedList<string> OptionsFiles { get; set; }

        public GameBackup(string gameName)
        {
            Utilities.AssertNotNullOrEmpty(gameName);
            GameName = gameName;
            OptionsFiles = new LinkedList<string>();
            SavesFolders = new LinkedList<string>();
        }

        public GameBackup(string gameName, string backupFolder)
        {
            GameName = gameName;
            BackupFolder = backupFolder;
            OptionsFiles = new LinkedList<string>();
        }

        /// <summary>
        /// Returns the backup path of the Saves folder.
        /// </summary>
        /// <param name="baseBackupFolder"></param>
        /// <returns></returns>
        private string GetBackupSaveFolder(string baseBackupFolder) =>
            Path.Combine(baseBackupFolder, GameName, "Saves");

        /// <summary>
        /// Returns the backup path of the Options folder.
        /// </summary>
        /// <param name="baseBackupFolder"></param>
        /// <returns></returns>
        private string GetBackupOptionsFolder(string baseBackupFolder) =>
            Path.Combine(baseBackupFolder, GameName, "Options");

        /// <summary>
        /// Returns the backup path of the individual Option file.
        /// </summary>
        /// <param name="baseBackupFolder"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetBackupOptionsFile(string baseBackupFolder, string filePath) =>
            Path.Combine(GetBackupOptionsFolder(baseBackupFolder), Path.GetFileName(filePath));

        /// <summary>
        /// Backs up the <strong>contents</strong> of the <see cref="SavesFolders"/> to "&lt;<see cref="BackupFolder">&gt;/Saves".
        /// <remarks>If the source (original) folder does not exist, no backup occurs. Use Directory.Exists() on <see cref="SavesFolders"/></remarks>
        /// </summary>
        /// <param name="overwriteFiles">Set true to overwrite files if any already exist in the <see cref="BackupFolder"> folder.</param>
        public void BackupSaves(bool overwriteFiles)
        {
            BackupSaves(BackupFolder, overwriteFiles);
        }

        /// <summary>
        /// Backs up the <strong>contents</strong> of the <see cref="SavesFolders"/> to "&lt;<see cref="BackupFolder">&gt;/Saves".
        /// <remarks>If the source (original) folder does not exist, no backup occurs. Use Directory.Exists() on <see cref="SavesFolders"/></remarks>
        /// </summary>
        /// <param name="baseBackupFolder">The backup location to which to copy the files.</param>
        /// <param name="overwriteFiles">Set true to overwrite files if any already exist in the <paramref name="baseBackupFolder"/> folder.</param>
        private void BackupSaves(string baseBackupFolder, bool overwriteFiles)
        {
            if (SavesFolders == null || OptionsFiles.Count < 1) return;
            foreach (string folder in SavesFolders)
            {
                string destBackupSaves = Path.Combine(GetBackupSaveFolder(baseBackupFolder), FileUtilities.GetLowestFolder(folder));
                Console.WriteLine("Backup: " + folder);
                Console.WriteLine("To: " + destBackupSaves);
                if (Directory.Exists(folder))
                {
                    FileUtilities.CreateDir(destBackupSaves);
                    FileUtilities.DirectoryCopy(folder, destBackupSaves, overwriteFiles, true, false);
                }
            }
        }

        /// <summary>
        /// Copies each individual file as specified in <see cref="OptionsFiles"/> to "&lt;<see cref="BackupFolder">&gt;/Options".
        /// <remarks>If the source (original) file does not exist, no backup occurs. Use File.Exists() on <see cref="OptionsFiles"/></remarks>
        /// </summary>
        /// <param name="overwriteFiles">Set true to overwrite files if any already exist in the <see cref="BackupFolder"> folder.</param>
        public void BackupOptions(bool overwriteFiles) =>
            BackupOptions(BackupFolder, overwriteFiles);

        /// <summary>
        /// Copies each individual file as specified in <see cref="OptionsFiles"/> to "&lt;<see cref="BackupFolder">&gt;/Options".
        /// <remarks>If the source (original) file does not exist, no backup occurs. Use File.Exists() on <see cref="OptionsFiles"/></remarks>
        /// </summary>
        /// <param name="baseBackupFolder">The backup location to which to copy the files.</param>
        /// <param name="overwriteFiles">Set true to overwrite files if any already exist in the <paramref name="baseBackupFolder"/> folder.</param>
        private void BackupOptions(string baseBackupFolder, bool overwriteFiles)
        {
            if (OptionsFiles == null || OptionsFiles.Count < 1) return;
            foreach (string filePath in OptionsFiles)
            {
                if (filePath != null && !filePath.Equals("") && File.Exists(filePath))
                {
                    FileUtilities.CreateDir(GetBackupOptionsFolder(baseBackupFolder));
                    File.Copy(filePath, GetBackupOptionsFile(baseBackupFolder, filePath), overwriteFiles);
                }
            }
        }

        /// <summary>
        /// Restores the <strong>contents</strong> of "&lt;<see cref="BackupFolder">&gt;/Saves" to <see cref="SavesFolders"/>.
        /// <remarks>If the source (backup) folder does not exist, no restore occurs. Use Directory.Exists() on <see cref="SavesFolders"/></remarks>
        /// </summary>
        /// <param name="overwriteFiles">Overwrites files in the destination folder (folder used by program/user).</param>
        public void RestoreSaves(bool overwriteFiles) =>
            RestoreSaves(BackupFolder, overwriteFiles);

        /// <summary>
        /// Restores the <strong>contents</strong> of "&lt;<see cref="BackupFolder">&gt;/Saves" to <see cref="SavesFolders"/>.
        /// <remarks>If the source (backup) folder does not exist, no restore occurs. Use Directory.Exists() on <see cref="SavesFolders"/></remarks>
        /// </summary>
        /// <param name="baseBackupFolder">The backup location from which to copy the files.</param>
        /// <param name="overwriteFiles">Overwrites files in the destination folder (folder used by program/user).</param>
        private void RestoreSaves(string baseBackupFolder, bool overwriteFiles)
        {
            if (baseBackupFolder == null || baseBackupFolder.Equals("") || !Directory.Exists(baseBackupFolder)) return;
            foreach (string folder in SavesFolders)
            {
                string srcBackupSaves = Path.Combine(GetBackupSaveFolder(baseBackupFolder), FileUtilities.GetLowestFolder(folder));
                Console.WriteLine("Restore: " + srcBackupSaves);
                Console.WriteLine("To: " + folder);
                if (Directory.Exists(srcBackupSaves))
                {
                    Console.WriteLine("-- Restore successful.");
                    FileUtilities.CreateDir(folder);
                    FileUtilities.DirectoryCopy(srcBackupSaves, folder, overwriteFiles, true, false);
                }
            }
        }

        /// <summary>
        /// Restores each file in "&lt;<see cref="BackupFolder">&gt;/Options" to its respective <see cref="OptionsFiles"/> location.
        /// <remarks>If the source (backup) folder does not exist, no restore occurs. Use File.Exists() on <see cref="OptionsFiles"/></remarks>
        /// </summary>
        /// <param name="overwriteFiles">Overwrites files in the destination folder (folder used by program/user).</param>
        public void RestoreOptions(bool overwriteFiles) =>
            RestoreOptions(BackupFolder, overwriteFiles);

        /// <summary>
        /// Restores each file in "&lt;<see cref="BackupFolder">&gt;/Options" to its respective <see cref="OptionsFiles"/> location.
        /// <remarks>If the source (backup) folder does not exist, no restore occurs. Use File.Exists() on <see cref="OptionsFiles"/></remarks>
        /// </summary>
        /// <param name="baseBackupFolder">The backup location from which to copy the files.</param>
        /// <param name="overwriteFiles">Overwrites files in the destination folder (folder used by program/user).</param>
        private void RestoreOptions(string baseBackupFolder, bool overwriteFiles)
        {
            if (baseBackupFolder == null || baseBackupFolder.Equals("") || !Directory.Exists(baseBackupFolder)) return;
            foreach (string filePath in OptionsFiles)
            {
                if (filePath != null && !filePath.Equals("") && File.Exists(GetBackupOptionsFile(baseBackupFolder, filePath)))
                {
                    FileUtilities.CreateDir(Path.GetDirectoryName(filePath));
                    File.Copy(GetBackupOptionsFile(baseBackupFolder, filePath), filePath, overwriteFiles);
                }
            }
        }

        /// <summary>
        /// Returns a list of GameBackup objects created from the <paramref name="doc"/>.
        /// </summary>
        /// <param name="doc">The XmlDocument from which to create the list of GameBackup objects.</param>
        /// <returns>The list of GameBackup objects that were created.</returns>
        /// <exception cref="XmlException"></exception>
        public static LinkedList<GameBackup> ImportXMLToList(XmlDocument doc)
        {
            XmlNode rootNode = doc.FirstChild;
            if (rootNode == null || !rootNode.Name.Equals(XML_TAG_GAMES) || !rootNode.HasChildNodes) { return null; }

            LinkedList<GameBackup> gameList = new LinkedList<GameBackup>();
            foreach (XmlNode n in rootNode.ChildNodes)
            {
                GameBackup game = ImportXML(n);
                if (game != null) gameList.AddLast(game);
            }
            if (gameList.Count < 1) { return null; }
            return gameList;
        }

        /// <summary>
        /// Creates a GameBackup from the <paramref name="node"/>.
        /// <remarks>Returns null if <paramref name="node"/>'s tag name is not "GameBackup".<br/>
        /// Throws an XmlException if <paramref name="node"/>'s name attribute does not exist.<br/>
        /// Throws an XmlException if <paramref name="node"/>'s name attribute does not contain a value.<br/>
        /// Throws an XmlException if <paramref name="node"/>'s BackupFolder child does not exist.<br/>
        /// Throws an XmlException if <paramref name="node"/>'s BackupFolder child does not contain a value.</remarks>
        /// </summary>
        /// <param name="node">The XmlNode from which to create the GameBackup.</param>
        /// <returns>The GameBackup that was created.</returns>
        /// <exception cref="XmlException"></exception>
        public static GameBackup ImportXML(XmlNode node)
        {
            if (!node.Name.Equals(XML_TAG_GAME)) { return null; }
            GameBackup gb = null;

            foreach (XmlAttribute att in node.Attributes)
            {
                if (att.Name.Equals(XML_ATTR_NAME))
                {
                    if (att.Value == null || att.Value.Equals(""))
                    {
                        throw new XmlException(XML_ATTR_NAME + " attribute must contain a value.");
                    }
                    gb = new GameBackup(att.Value);
                }
            }
            if (gb == null) throw new XmlException(XML_ATTR_NAME + " attribute must exist.");
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name.Equals(XML_TAG_OPTIONS))
                {
                    foreach (XmlNode subChild in child.ChildNodes)
                    {
                        if(subChild.Name.Equals(XML_TAG_OPTION))
                        {
                            gb.OptionsFiles.AddLast(subChild.InnerText);
                        }
                    }
                }
                else if(child.Name.Equals(XML_TAG_SAVES))
                {
                    foreach (XmlNode subChild in child.ChildNodes)
                    {
                        if (subChild.Name.Equals(XML_TAG_FOLDER))
                        {
                            gb.SavesFolders.AddLast(subChild.InnerText);
                        }
                    }
                }
                else if(child.Name.Equals(XML_TAG_BACKUP))
                {
                    if (child.InnerText == null || child.InnerText.Equals(""))
                    {
                        throw new XmlException(XML_TAG_BACKUP + " node must contain a value.");
                    }
                    gb.BackupFolder = child.InnerText;
                }
            }
            if(gb.BackupFolder == null) throw new XmlException(XML_TAG_BACKUP + " node must exist.");
            return gb;
        }

        /// <summary>
        /// Creates a complete XmlDocument from the elements of <paramref name="gameList"/>.
        /// </summary>
        /// <param name="gameList">The list of GameBackup objects from which to create the XmlDocument.</param>
        /// <returns>The complete XmlDocument from the elements of <paramref name="gameList"/>.</returns>
        public static XmlDocument ExportListToXML(ICollection<GameBackup> gameList)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement(XML_TAG_GAMES);
            doc.AppendChild(rootNode);
            foreach (GameBackup game in gameList)
            {
                rootNode.AppendChild(ExportXML(doc, game));
            }
            return doc;
        }

        /// <summary>
        /// Creates an XmlNode from <paramref name="game"/>.
        /// <remarks>Append to an existing XmlDocument with myDoc.FirstChild.AppendChild(GameBackup.ExportXML(myDoc, myGame));</remarks>
        /// </summary>
        /// <param name="doc">The document from which to create the node.</param>
        /// <param name="game">The GameBackup from which to create the XmlNode.</param>
        /// <returns></returns>
        public static XmlNode ExportXML(XmlDocument doc, GameBackup game)
        {
            if (doc == null) { doc = new XmlDocument(); }
            XmlNode gameNode = doc.CreateElement(XML_TAG_GAME);
            XmlAttribute att = doc.CreateAttribute(XML_ATTR_NAME);
            att.Value = game.GameName;
            gameNode.Attributes.Append(att);
            if (game.BackupFolder != null && !game.BackupFolder.Equals(""))
            {
                XmlNode backupNode = doc.CreateElement(XML_TAG_BACKUP);
                backupNode.InnerText = game.BackupFolder;
                gameNode.AppendChild(backupNode);
            }
            if (game.SavesFolders != null && game.SavesFolders.Count > 0)
            {
                XmlNode savesNode = doc.CreateElement(XML_TAG_SAVES);
                XmlNode tempNode;
                foreach(string folder in game.SavesFolders)
                {
                    tempNode = doc.CreateElement(XML_TAG_FOLDER);
                    tempNode.InnerText = folder;
                    savesNode.AppendChild(tempNode);
                }
                gameNode.AppendChild(savesNode);
            }
            if (game.OptionsFiles != null && game.OptionsFiles.Count > 0)
            {
                XmlNode optionsNode = doc.CreateElement(XML_TAG_OPTIONS);
                XmlNode tempNode;
                foreach (string file in game.OptionsFiles)
                {
                    tempNode = doc.CreateElement(XML_TAG_OPTION);
                    tempNode.InnerText = file;
                    optionsNode.AppendChild(tempNode);
                }
                gameNode.AppendChild(optionsNode);
            }
            return gameNode;
		}
	}
}
