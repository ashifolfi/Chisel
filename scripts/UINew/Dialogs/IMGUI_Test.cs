using System;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs
{
    public class IMGUI_Test : Node
    {
        private void _on_ImGuiNode_IGLayout()
        {
            Boolean show = true;
            ImGui.Begin("ImGui Test", ref show, ImGuiWindowFlags.None);
            ImGui.End();
        }
    }
}