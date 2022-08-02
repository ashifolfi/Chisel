﻿using System;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs
{
    public class GameConfigSelect : Node
    {
        public Boolean show;
        
        public override void _Ready()
        {
            show = true;
        }

        private void _on_ImGuiNode_IGLayout()
        {
            ImGui.Begin("Select Game Configuration", ref show,
                ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
            ImGui.SetWindowPos(new System.Numerics.Vector2(
                (OS.WindowSize.x / 2) - ImGui.GetWindowSize().X / 2,
                (OS.WindowSize.y / 2) - ImGui.GetWindowSize().Y / 2
                ));
            
            ImGui.Dummy(new System.Numerics.Vector2(320f, 320f));
            
            ImGui.End();
        }
    }
}