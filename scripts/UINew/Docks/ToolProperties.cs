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
            
            ImGui.Begin("Tool Properties", ref show, ImGuiWindowFlags.NoCollapse);
            
            // Show the current Tool's Properties
            switch (Globals.ToolsMode)
            {
                case "ObjEdit":
                    Docks.Properties.ObjEdit.Dock();
                    break;
                case "Entities":
                    Docks.Properties.Entities.Dock();
                    break;
                case "CreatePrimitive":
                    Docks.Properties.CreatePrimitive.Dock();
                    break;
            }
            
            //ImGui.Dummy(new Vector2(100, 320));
            
            ImGui.End();
        }
    }
}