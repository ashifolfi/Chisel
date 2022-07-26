﻿/*
 * RootPanel
 *
 * Initializes Chisel on start and handles everything related to proper window scaling
 * along with containing a list of every DockContainer for use with dockable windows
 *
 * (C) 2022 by K. "ashifolfi" J.
 */

using Godot;
using System;
using System.Collections.Generic;
using Chisel;

namespace Chisel.UI
{
    public class RootPanel : Panel
    {
        //public List<WindowDockContainer> DockContainers = new List<WindowDockContainer>();

        private AssetManager AssetManager;
        private FileManager FileManager;
        
        // On ready resize the container to fit the current window size
        public override void _Ready()
        {
            GD.Print("[INF] Initialization Begin");
            
            // Set this right here right now before we even touch the main editor scene.
            Globals.RootPath = "/root/RootPanel/";
            Globals.ExeDir = OS.GetExecutablePath().GetBaseDir();
		
            GD.Print("[INF] Loading main editor components");
            // Instance the main editor scene. Fixes RootPanel not being inited before
            // the rest of the editor gets inited
            PackedScene Editor = (PackedScene)GD.Load("res://scenes/Editor.tscn");
            AddChild(Editor.Instance());

            AssetManager = GetNode<AssetManager>(Globals.RootPath + "Editor/AssetManager");
            FileManager = GetNode<FileManager>(Globals.RootPath + "Editor/FileManager");
            
            GD.Print("[INF] Loading game files");
            // TODO: Implement game configurations and a launcher
            FileManager.LoadGameTextures("Chisel");

            GD.Print("[INF] Loading config file");
            
            GD.Print("[INF] Resizing to match window size");
            RectSize = OS.WindowSize;

            GD.Print("[INF] Initialization Complete");
        }

        public override void _Draw()
        {
            // Resize root panel to the window size
            if (RectSize != OS.WindowSize)
            {
                RectSize = OS.WindowSize;
            }
        }
    }
}