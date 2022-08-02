/*
 * Outliner
 *
 * Displays every entity and brush inside the map along with their names
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;
using System;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Docks
{
    public class Outline : Node
    {
        public Boolean show = true;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");
        }

        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }

            ImGui.Begin("Outliner", ref show, ImGuiWindowFlags.NoCollapse);
            
            // Upper options
            ImGui.Text("Filter: ");
            ImGui.SameLine();
            String Input = "";
            ImGui.InputText("", ref Input, UInt32.MaxValue);
            Boolean dummy1 = false;
            Boolean dummy2 = false;
            ImGui.Checkbox("Include hidden objects", ref dummy1);
            ImGui.Checkbox("Show object IDs", ref dummy2);
            
            // Actual map outline

            ImGui.End();
        }
    }
}