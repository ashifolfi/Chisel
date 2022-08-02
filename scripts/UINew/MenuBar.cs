using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew
{
    public class MenuBar : Node
    {
        private void _on_ImGuiNode_IGLayout()
        {
            ImGui.BeginMainMenuBar();

            ImGui.BeginMenu("File", true);
            
            ImGui.EndMainMenuBar();
        }
    }
}