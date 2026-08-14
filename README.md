# GameBackupSystem

A Windows desktop utility (C# / WinForms) for backing up and restoring your
**game save files** and **options/config files**. Define each game once in an XML
config, then back up or restore them in a click.

## Features

- Back up and restore per-game **save folders** and individual **options/config files**.
- Games are described in an XML config (name, backup folder, save folders, option files).
- Batch operations: back up / restore **all** or just the **checked** games, with a progress bar.

## Building

Windows only (it's a WinForms app). Targets **.NET Framework 4.6.1**; there are **no NuGet
packages** to restore.

**Prerequisites** (once) — MSBuild plus the .NET Framework 4.6.1 targeting pack, from the
Visual Studio **Build Tools**. In an **elevated** PowerShell:

```powershell
winget install --id Microsoft.VisualStudio.2022.BuildTools -e --override "--quiet --wait --norestart --includeRecommended --add Microsoft.VisualStudio.Workload.ManagedDesktopBuildTools --add Microsoft.Net.Component.4.6.1.TargetingPack"
```

An editor is optional (e.g. `winget install --id Microsoft.VisualStudioCode -e`); a full
Visual Studio install works too.

**Build** — from the repo root:

```powershell
./build.ps1
```

`build.ps1` locates MSBuild automatically (via `vswhere`), so it runs from any PowerShell —
no "Developer PowerShell" required. It produces
`GameBackupSystem\bin\Release\GameBackupSystem.exe`. Options: `-Configuration Debug`, and
`-Run` to launch the app after building. If PowerShell blocks the script, run
`powershell -ExecutionPolicy Bypass -File .\build.ps1`.

Prefer an IDE? Just open `GameBackupSystem.sln` in Visual Studio and build there.

## Status

An older personal project, cleaned up and published for reference. Known bugs and
planned enhancements are tracked in the issues — notably INI-aware merging of
option files on restore (so a restore preserves settings the game added after the
backup was made).

## License

GPLv3 — see [LICENSE](LICENSE).
