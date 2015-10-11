/*
    This file is part of the Windows 7/8 telemetry update removal tool.
    Copyright (C) 2015  Thoronador

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace telemetry_update_removal
{
    /// <summary>
    /// delegate type for setting a status bar message
    /// </summary>
    /// <param name="msg">the new status bar message</param>
    public delegate void dlgtChangeStatusBarMessage(string msg);
    

    /// <summary>
    /// delegate type for setting the current value of the progress bar
    /// </summary>
    /// <param name="value">new value</param>
    public delegate void dlgtChangeStatusBarProgress(int value);


    /// <summary>
    /// delegate type for setting the new minimum value of the progress bar
    /// </summary>
    /// <param name="value">the new minimum value</param>
    public delegate void dlgtChangeStatusBarMinimum(int value);


    /// <summary>
    /// delegate type for setting the new maximum value of the progress bar
    /// </summary>
    /// <param name="value">the new maximum value</param>
    public delegate void dlgtChangeStatusBarMaximum(int value);
} //namespace
