/*
 * Editor Main panel
 *
 * Resizes with the window and fits it's elements accordingly
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;
using System;
using System.Collections.Generic;
using Chisel.UI;

public class EditorMain : Control
{
    public List<WindowDockContainer> DockContainers = new List<WindowDockContainer>();
    public override void _Ready()
    {
        // on start resize to the window size
        RectSize = OS.WindowSize;
    }

    public override void _Process(float delta)
    {
        if (RectSize != OS.WindowSize)
        {
            RectSize = OS.WindowSize;
        }
    }
}
