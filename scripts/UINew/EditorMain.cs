/*
 * Editor Main panel
 *
 * Resizes with the window and fits it's elements accordingly
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;
using System;

public class EditorMain : Control
{
    public override void _Ready()
    {
        // on start resize to the window size
        RectSize = OS.WindowSize;
    }
}
