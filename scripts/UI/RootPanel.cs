/*
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
        public List<WindowDockContainer> DockContainers = new List<WindowDockContainer>();

        private Node AssetManager;
        private Node FileManager;
        
        // On ready resize the container to fit the current window size
        public override void _Ready()
        {
            GD.Print("[INF] Initialization Begin");
		
            GD.Print("[INF] Building Root Views");
		
            GD.Print("[INF] Tying AssetManager+FileManager to Variables");
            AssetManager = GetNode<Node>("/root/UI/AssetManager");
            FileManager = GetNode<Node>("/root/UI/FileManager");
            Globals.RootPanel = GetNode<RootPanel>("/root/UI");
            
            GD.Print("[INF] Loading config file");
            
            GD.Print("[INF] Resizing to match window size");
            RectSize = OS.WindowSize;

            GD.Print("[INF] Done!");
		
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