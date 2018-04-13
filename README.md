# GameBackupSystem

A Windows desktop utility (C# / WinForms) for backing up and restoring your
**game save files** and **options/config files**. Define each game once in an XML
config, then back up or restore them in a click.

## Features

- Back up and restore per-game **save folders** and individual **options/config files**.
- Games are described in an XML config (name, backup folder, save folders, option files).
- Batch operations: back up / restore **all** or just the **checked** games, with a progress bar.

## Building

Open `GameBackupSystem.sln` in Visual Studio (targets .NET Framework, WinForms) and build.

## Status

An older personal project, cleaned up and published for reference. Known bugs and
planned enhancements are tracked in the issues — notably INI-aware merging of
option files on restore (so a restore preserves settings the game added after the
backup was made).

## License

GPLv3 — see [LICENSE](LICENSE).
