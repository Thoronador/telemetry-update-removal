@echo off
REM Script to build the installer for telemetry update removal.

REM   This file is part of the Windows 7/8 telemetry update removal tool.
REM   Copyright (C) 2015  Thoronador
REM
REM   This program is free software: you can redistribute it and/or modify
REM   it under the terms of the GNU General Public License as published by
REM   the Free Software Foundation, either version 3 of the License, or
REM   (at your option) any later version.
REM
REM   This program is distributed in the hope that it will be useful,
REM   but WITHOUT ANY WARRANTY; without even the implied warranty of
REM   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
REM   GNU General Public License for more details.
REM
REM   You should have received a copy of the GNU General Public License
REM   along with this program.  If not, see <http://www.gnu.org/licenses/>.


REM Set path of ci/ directory, i.e. the current directory (includes trailing
REM backslash).
SET CI_DIR=%~dp0

REM Locate the iscc.exe of InnoSetup.
SET ISCC_BIN=FOO
IF EXIST "C:\Program Files\Inno Setup 5\iscc.exe" SET ISCC_BIN=C:\Program Files\Inno Setup 5\iscc.exe
IF EXIST "C:\Program Files (x86)\Inno Setup 5\iscc.exe" SET ISCC_BIN=C:\Program Files (x86)\Inno Setup 5\iscc.exe

IF "FOO"=="%ISCC_BIN%" (
  echo:Could not find iscc.exe! Make sure that Inno Setup 5 is installed.
  EXIT /B 1
)

REM Generate the installer.
"%ISCC_BIN%" "%CI_DIR%..\innosetup\setup.iss"
IF %ERRORLEVEL% NEQ 0 (
  echo:iscc.exe failed to generate the installer!
  EXIT /B 1
)

REM Report success.
echo:InnoSetup installer was created.
EXIT /B 0
