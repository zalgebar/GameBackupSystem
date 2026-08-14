#Requires -Version 5.1
<#
.SYNOPSIS
    Builds GameBackupSystem (.NET Framework 4.6.1, WinForms) with MSBuild.

.DESCRIPTION
    Locates MSBuild via vswhere (installed with Visual Studio / the VS Build Tools) and
    builds the solution, so it works from any PowerShell prompt -- not only a
    "Developer PowerShell for VS". Assumes the build tools are already installed;
    see the README for the one-time winget setup.

.PARAMETER Configuration
    Build configuration: Release (default) or Debug.

.PARAMETER Run
    Launch the built executable after a successful build.

.EXAMPLE
    ./build.ps1
.EXAMPLE
    ./build.ps1 -Configuration Debug -Run
#>
[CmdletBinding()]
param(
    [ValidateSet('Release', 'Debug')]
    [string]$Configuration = 'Release',
    [switch]$Run
)

$ErrorActionPreference = 'Stop'
$root = $PSScriptRoot
$sln  = Join-Path $root 'GameBackupSystem.sln'

# Find MSBuild via vswhere (ships with the VS Installer / Build Tools).
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
if (-not (Test-Path $vswhere)) {
    throw "vswhere not found. Install the Visual Studio Build Tools (see README) and retry."
}

$msbuild = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild `
    -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
if (-not $msbuild) {
    throw "MSBuild not found. Install the '.NET desktop build tools' workload (see README)."
}

Write-Host "MSBuild:       $msbuild"
Write-Host "Configuration: $Configuration`n"

& $msbuild $sln -nologo -m -verbosity:minimal -p:Configuration=$Configuration
if ($LASTEXITCODE -ne 0) {
    throw "Build failed (exit code $LASTEXITCODE)."
}

$exe = Join-Path $root "GameBackupSystem\bin\$Configuration\GameBackupSystem.exe"
Write-Host "`nBuild succeeded -> $exe"

if ($Run) {
    if (Test-Path $exe) { Start-Process $exe }
    else { throw "Executable not found: $exe" }
}
