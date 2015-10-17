[Setup]
;INFO --> http://www.jrsoftware.org/ishelp/

; Always generate a new GUID for every setup!
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)

AppId={{5BC0FD8C-D9C2-4AC9-AC18-C8CF3456FF67}}
AppName=Telemetry update removal
AppVersion=0.3.6.0
AppPublisher=Thoronador
AppPublisherURL=https://github.com/Thoronador/telemetry-update-removal
AppSupportURL=https://github.com/Thoronador/telemetry-update-removal
AppUpdatesURL=https://github.com/Thoronador/telemetry-update-removal
DefaultDirName={pf}\telemetry-update-removal
DisableDirPage=yes
DefaultGroupName=Telemetry update removal
DisableProgramGroupPage=yes
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
;Executable
Source: "..\telemetry-update-removal\bin\Debug\telemetry-update-removal.exe"; DestDir: "{app}"; Flags: ignoreversion
; default update list
Source: "..\telemetry-update-removal\updatelist.xml"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Start Menu entry for the application itself
Name: "{group}\Telemetry update removal 0.3.6"; Filename: "{app}\telemetry-update-removal.exe"
; Start Menu entry with parameters
; Name: "{group}\Telemetry update removal test"; Filename: "{app}\telemetry-update-removal.exe"; Parameters: "--test"
; Start Menu entry for uninstaller
Name: "{group}\Uninstall Telemetry update removal 0.3.6"; Filename: "{app}\unins000.exe"
; Desktopicon (if selected during install - default is unselected)
Name: "{commondesktop}\Telemetry update removal 0.3.6"; Filename: "{app}\telemetry-update-removal.exe"; Tasks: desktopicon
