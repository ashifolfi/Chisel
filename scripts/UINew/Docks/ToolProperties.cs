using Godot;
using System;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Docks
{
    public class ToolProperties : Node
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
            
            // Insert ImGui Code
            ImGui.Begin("Tool Properties", ref show, ImGuiWindowFlags.NoCollapse);
            
            ImGui.Dummy(new Vector2(100, 320));
            
            ImGui.End();
        }
    }
}