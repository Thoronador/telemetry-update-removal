# Script(s) for continuous integration (CI)

This directory contains scripts that are aimed at continuous integration
processes that need to compile and build the application and installer rather
often. To ease this process, some batch scripts are provided to simplify the
common tasks in this process.

Note: Most of these scripts can be run manually, too, if you know what you are
doing.


## Script(s)

**build_installer.cmd** builds the InnoSetup-base installer for the telemetry
update removal application. In order for this script to run successfully you
will need InnoSetup 5 (see <http://www.jrsoftware.org/isinfo.php>). Also, the
application's binary executable already has to be build - either by building
it directly from Visual Studio or by building it via msbuild.exe from the
command line.

**download_and_install_innosetup.ps1** is a PowerShell script that can be used
to download and install InnoSetup 5.5.6. The later part (installation) needs
administrative privileges, so make sure that this script is run by an
administrator. Otherwise, an UAC prompt will pop up and ask you for the
credentials of an administrator account.

----

The usual order of script execution is:

- Build the project (with MSBuild or directly within Visual Studio).
- Execute download_and_install_innosetup.ps1 (PowerShell script).
- Execute build_installer.cmd (batch script).
