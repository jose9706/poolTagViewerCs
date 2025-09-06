# poolViewer

Tool to inspect Windows pool tag usage in real time. Basically does what Poolmon does but with a GUI and hopefully easier to use.

## Solution

- Solution: 'poolViewer.sln'
- Project: 'poolViewer\poolViewer.csproj' (WinForms)
- Key files:
  - 'poolViewer/Forms/MainForm.cs' — UI wiring, timer, menu commands
  - 'poolViewer/PoolHandling/PoolGridController.cs' — grid data/presentation logic
  - 'poolViewer/UnsafePoolHandling/*' — native access to system pool tag information
  - Supporting: filtering UI, snapshotting, recording

## Features

- Refresh at 1/2/5/10 seconds; pause/resume
- Regex filtering via a dedicated filter window
- Snapshot saving
- Recording multiple snapshots and exporting

## Requirements

- Windows 10/11
- Administrator privileges recommended (to read system pool tags)
- .NET SDK

## Build and Run

Build solution, requires .NET SDK. Project targets NET8.0.

## Usage

- Sorting: click a column header to cycle sort order.
- Filtering: use the `Filter` menu to add regex filters; `Clear Filter` to remove.
- Refresh interval: choose from the `Interval` menu; use `Pause` to freeze updates.
- Snapshots: click `Save` to write the current snapshot to a file.
- Recording: use the main button to start/stop; prompted to save when finished.

## Inspired by:
 - Poolmon: https://learn.microsoft.com/en-us/windows-hardware/drivers/devtest/poolmon
 - Pool with GUI: 

## Troubleshooting

- Run as Administrator if pool data is empty or access is denied.
- Ensure required .NET tooling is installed if the project fails to load or build.