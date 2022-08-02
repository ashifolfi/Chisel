using System;
using Vector2 = System.Numerics.Vector2;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew.Docks
{
    public class Tools : Node
    {
        public Boolean show = true;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");
            
            // Prepare every image texture for the tool buttons
            
        }

        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }

            ImGui.Begin("Tools", ref show, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize);

            ImGui.Separator();
            ImGui.Separator();
            // Tool buttons
            // Yes all transform tools are separated out because why not
            ImGui.Button("Select", new Vector2(50, 50));
            ImGui.Button("Move", new Vector2(50, 50));
            ImGui.Button("Rotate", new Vector2(50, 50));
            ImGui.Button("Scale", new Vector2(50, 50));
            ImGui.Button("Pivot", new Vector2(50, 50));
            ImGui.Separator();
            // Now for the other tools
            ImGui.Button("Entities", new Vector2(50, 50));
            ImGui.Button("Brush", new Vector2(50, 50));
            ImGui.Button("Clipping", new Vector2(50, 50));
            ImGui.Button("Apply Texture", new Vector2(50, 50));
            ImGui.Button("Face Edit", new Vector2(50, 50));
            ImGui.Button("Displacement", new Vector2(50, 50));
            ImGui.Button("Sprinkle", new Vector2(50, 50));
            
            ImGui.End();
        }
    }
}