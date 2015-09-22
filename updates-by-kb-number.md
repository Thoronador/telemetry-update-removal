# Telemetry and "Get Windows 10" updates

The following list contains updates for Windows 7, Windows 8 and Windows 8.1
that either introduce or add to the telemetry and diagnostics service of
Windows or add features for upgrading to Windows 10. Blockquotes below the
update are the summaries (or parts thereof) provided on the linked pages about
the update.

* **[KB2952664](https://support.microsoft.com/en-us/kb/2952664)**
  "Compatibility update for upgrading Windows 7"

    > _This update helps Microsoft make improvements to the current operating
      system in order to ease the upgrade experience to the latest version of
      Windows._

* **[KB2976978](https://support.microsoft.com/en-us/kb/2976978)**
  "Compatibility update for Windows 8.1 and Windows 8"

    > _This update performs diagnostics on the Windows systems that participate
      in the Windows Customer Experience Improvement Program. These diagnostics
      help determine whether compatibility issues may be encountered when the
      latest Windows operating system is installed._

* **[KB2977759](https://support.microsoft.com/en-us/kb/2977759)**
  "Compatibility update for Windows 7 RTM"

    > _This update performs diagnostics on the Windows systems that participate
      in the Windows Customer Experience Improvement Program. These diagnostics
      help determine whether compatibility issues may be encountered when the
      latest Windows operating system is installed._

* **[KB2990214](https://support.microsoft.com/en-us/kb/2990214)**
  "Update that enables you to upgrade from Windows 7 to a later version of Windows"

    > _... an update that enables you to upgrade your computer from Windows 7
      Service Pack 1 (SP1) to a later version of Windows._

* **[KB3021917](https://support.microsoft.com/en-us/kb/3021917)**
  "Update to Windows 7 SP1 for performance improvements"

    > _This update performs diagnostics in Windows 7 Service Pack 1 (SP1) in
      order to determine whether performance issues may be encountered when
      the latest Windows operating system is installed. Telemetry is sent back
      to Microsoft for those computers that participate in the Windows Customer
      Experience Improvement Program (CEIP). This update will help Microsoft
      and its partners deliver better system performance for customers who are
      seeking to install the latest Windows operating system._

* **[KB3022345](https://support.microsoft.com/en-us/kb/3022345)**
  "Update for customer experience and diagnostic telemetry"

    > _This update introduces the Diagnostics and Telemetry tracking service
      to in-market devices. By applying this service, you can add benefits
      from the latest version of Windows to systems that have not yet been
      upgraded._

* **[KB3035583](https://support.microsoft.com/en-us/kb/3035583)**
  "Update installs Get Windows 10 app in Windows 8.1 and Windows 7 SP1"

    > _This update installs the Get Windows 10 app, which helps users
       understand their Windows 10 upgrade options and device readiness._

  In other words: This update installs the "Get Windows 10" app, which urges
  the users to upgrade to Windows 10 as soon as possible.

* **[KB3044374](https://support.microsoft.com/en-us/kb/3044374)**
  "Update that enables you to upgrade from Windows 8.1 to Windows 10"

    > _[...] an update that enables you to upgrade your computer from
      Windows 8.1 to a Windows 10._

* **[KB3065987](https://support.microsoft.com/en-us/kb/3065987)**
  "Windows Update Client for Windows 7 and Windows Server 2008 R2: July 2015"

    > _[...] an update that contains some improvements to Windows Update
      Client in Windows 7 Service Pack 1 (SP1) or Windows Server 2008 R2 SP1._

* **[KB3068708](https://support.microsoft.com/en-us/kb/3068708)**
  "Update for customer experience and diagnostic telemetry"

    > _This update introduces the Diagnostics and Telemetry tracking service
      to existing devices._

* **[KB3075249](https://support.microsoft.com/en-us/kb/3075249)**
  "Update that adds telemetry points to consent.exe in Windows 8.1 and Windows 7"

    > _[...] an update that adds telemetry points to consent.exe in
      Windows 8.1, Windows RT 8.1, Windows Server 2012 R2, Windows 7 Service
      Pack 1 (SP1), and Windows Server 2008 R2 SP1. [...] This update adds
      telemetry points to the User Account Control (UAC) feature to collect
      information on elevations that come from low integrity levels._

* **[KB3075851](https://support.microsoft.com/en-us/kb/3075851)**
  "Windows Update Client for Windows 7 and Windows Server 2008 R2: August 2015"

    > _[...] an update that contains some improvements to Windows Update Client
     in Windows 7 Service Pack 1 (SP1) and Windows Server 2008 R2 SP1. This
     update also resolves an issue in which certain Windows Update operations
     fail when you install Windows Update Client for Windows 7 and Windows
     Server 2008 R2: July 2015 (3065987) on Windows 7 Embedded editions._

* **[KB3080149](https://support.microsoft.com/en-us/kb/3080149)**
  "Update for customer experience and diagnostic telemetry"

    > _This package updates the Diagnostics and Telemetry tracking service to
      existing devices. This service provides benefits from the latest version
      of Windows to systems that have not yet upgraded._


## Uninstall via command line

    wusa.exe /uninstall /kb:3022345 /quiet /norestart
    wusa.exe /uninstall /kb:3068708 /quiet /norestart
    wusa.exe /uninstall /kb:3075249 /quiet /norestart
    wusa.exe /uninstall /kb:3080149 /quiet /norestart

...and so on, just replace the Microsoft Knowledge Base (KB) numbers.

