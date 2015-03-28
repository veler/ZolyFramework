// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Shortcut.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the Shortcut type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Shortcut
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;

    using ZolyFramework.Core.Environment;
    using ZolyFramework.Core.Win32;
    using ZolyFramework.Core.Win32.PropertySystem;

    /// <summary>
    /// Provide some methods to create shortcuts files (.LNK).
    /// </summary>
    public static class Shortcut
    {
        #region Fields

        /// <summary>
        /// The start menu programs path.
        /// </summary>
        public static readonly string StartMenuProgramsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\";

        #endregion

        #region Methods

        /// <summary>
        /// Create a new shortcut.
        /// </summary>
        /// <param name="lnkFilePath">
        /// The LNK file path.
        /// </param>
        /// <param name="overrides">
        /// overrides if already exists.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task CreateShortcutAsync(string lnkFilePath, bool overrides)
        {
            await CreateShortcutAsync(lnkFilePath, Guid.NewGuid(), overrides);
        }

        /// <summary>
        /// Create a new shortcut.
        /// </summary>
        /// <param name="lnkFilePath">
        /// The LNK file path.
        /// </param>
        /// <param name="guid">
        /// The GUID of the shortcut.
        /// </param>
        /// <param name="overrides">
        /// overrides if already exists.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task CreateShortcutAsync(string lnkFilePath, Guid guid, bool overrides)
        {
            var task = new Task(() => CreateShortcut(lnkFilePath, guid, overrides));
            task.Start();
            await task;
        }

        /// <summary>
        /// Create a new shortcut.
        /// </summary>
        /// <param name="lnkFilePath">
        /// The LNK file path.
        /// </param>
        /// <param name="overrides">
        /// overrides if already exists.
        /// </param>
        public static void CreateShortcut(string lnkFilePath, bool overrides)
        {
            CreateShortcut(lnkFilePath, Guid.NewGuid(), overrides);
        }

        /// <summary>
        /// Create a new shortcut.
        /// </summary>
        /// <param name="lnkFilePath">
        /// The LNK file path.
        /// </param>
        /// <param name="guid">
        /// The GUID.
        /// </param>
        /// <param name="overrides">
        /// overrides if already exists.
        /// </param>
        public static void CreateShortcut(string lnkFilePath, Guid guid, bool overrides)
        {
            if (File.Exists(lnkFilePath))
                if (overrides)
                    File.Delete(lnkFilePath);
                else
                    return;

            var exePath = Process.GetCurrentProcess().MainModule.FileName;
            var newShortcut = (IShellLinkW)new CShellLink();

            ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath));
            ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""));

            var newShortcutProperties = (IPropertyStore)newShortcut;
            var systemPropertiesSystemAppUserModelId = new PropertyKey(guid, 5);

            using (var appId = new PropVariant(ApplicationInfo.GetName()))
            {
                ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(systemPropertiesSystemAppUserModelId, appId));
                ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            var newShortcutSave = (IPersistFile)newShortcut;
            ErrorHelper.VerifySucceeded(newShortcutSave.Save(lnkFilePath, true));
        }

        #endregion
    }
}
