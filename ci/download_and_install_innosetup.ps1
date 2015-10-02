# PowerShell script to download and install InnoSetup 5.

#   This file is part of the Windows 7/8 telemetry update removal tool.
#   Copyright (C) 2015  Thoronador
#
#   This program is free software: you can redistribute it and/or modify
#   it under the terms of the GNU General Public License as published by
#   the Free Software Foundation, either version 3 of the License, or
#   (at your option) any later version.
#
#   This program is distributed in the hope that it will be useful,
#   but WITHOUT ANY WARRANTY; without even the implied warranty of
#   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#   GNU General Public License for more details.
#
#   You should have received a copy of the GNU General Public License
#   along with this program.  If not, see <http://www.gnu.org/licenses/>.

$url = "http://files.jrsoftware.org/is/5/isetup-5.5.6-unicode.exe"
$output = ".\isetup-unicode.exe"
$start = Get-Date

# $webcli = New-Object System.Net.WebClient
# $webcli.DownloadFile($url, $output)
(New-Object System.Net.WebClient).DownloadFile($url, $output)

Write-Output "Time required for download: $((Get-Date).Subtract($start).Seconds) second(s)"

# Call executable to install InnoSetup 5, silent/unattended installation.
& $output /VERYSILENT

# Delete the downloaded installer, because we do not want to clutter the file
# system.
If (Test-Path $output){
	Remove-Item $output
}
