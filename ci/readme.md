# Script(s) for continuous integration (CI)

This directory contains scripts that are aimed at continuous integration
processes that need to compile and build the application and installer rather
often. To ease this process, some batch scripts are provided to simplify the
common tasks in this process.

Note: Most of these scripts can be run manually, too, if you know what you are
doing.


## Script(s)

Currently, there is only one script, but more scripts are likely to follow
"soon" (TM).

**build_installer.cmd** builds the InnoSetup-base installer for the telemetry
update removal application. In order for this script to run successfully you
will need InnoSetup 5 (see <http://www.jrsoftware.org/isinfo.php>). Also, the
application's binary executable already has to be build - either by building
it directly from Visual Studio or by building it via msbuild.exe from the
command line.
