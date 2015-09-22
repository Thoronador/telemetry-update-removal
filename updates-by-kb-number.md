# Telemetry and "Get Windows 10" updates

The following list contains updates for Windows 7, Windows 8 and Windows 8.1
that either introduce or add to the telemetry and diagnostics service of
Windows or add features for upgrading to Windows 10.

* **[KB2952664](https://support.microsoft.com/en-us/kb/2952664)**
  "Compatibility update for upgrading Windows 7"
* **[KB2976978](https://support.microsoft.com/en-us/kb/2976978)**
  "Compatibility update for Windows 8.1 and Windows 8"
* **[KB2977759](https://support.microsoft.com/en-us/kb/2977759)**
  "Compatibility update for Windows 7 RTM"
* **[KB2990214](https://support.microsoft.com/en-us/kb/2990214)**
  "Update that enables you to upgrade from Windows 7 to a later version of Windows"
* **[KB3021917](https://support.microsoft.com/en-us/kb/3021917)**
  "Update to Windows 7 SP1 for performance improvements"
* **[KB3022345](https://support.microsoft.com/en-us/kb/3022345)**
  "Update for customer experience and diagnostic telemetry"
* **[KB3035583](https://support.microsoft.com/en-us/kb/3035583)**
  "Update installs Get Windows 10 app in Windows 8.1 and Windows 7 SP1"
* **[KB3044374](https://support.microsoft.com/en-us/kb/3044374)**
  "Update that enables you to upgrade from Windows 8.1 to Windows 10"
* **[KB3065987](https://support.microsoft.com/en-us/kb/3065987)**
  "Windows Update Client for Windows 7 and Windows Server 2008 R2: July 2015"
* **[KB3068708](https://support.microsoft.com/en-us/kb/3068708)**
  "Update for customer experience and diagnostic telemetry"
* **[KB3075249](https://support.microsoft.com/en-us/kb/3075249)**
  "Update that adds telemetry points to consent.exe in Windows 8.1 and Windows 7"
* **[KB3075851](https://support.microsoft.com/en-us/kb/3075851)**
  "Windows Update Client for Windows 7 and Windows Server 2008 R2: August 2015"
* **[KB3080149](https://support.microsoft.com/en-us/kb/3080149)**
  "Update for customer experience and diagnostic telemetry"


## Uninstall via command line

    wusa.exe /uninstall /kb:3022345 /quiet /norestart
    wusa.exe /uninstall /kb:3068708 /quiet /norestart
    wusa.exe /uninstall /kb:3075249 /quiet /norestart
    wusa.exe /uninstall /kb:3080149 /quiet /norestart

...and so on, just replace the Microsoft Knowledge Base (KB) numbers.

