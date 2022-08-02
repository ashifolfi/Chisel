using Godot;
using System;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew
{
    public class StatusBar : Node
    {
        public Boolean show = false;

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
        }
    }
}