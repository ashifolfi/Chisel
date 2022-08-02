using Chisel.scripts.UINew.Dialogs;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew
{
    public class MenuBar : Node
    {
        private void _on_ImGuiNode_IGLayout()
        {
            ImGui.BeginMainMenuBar();

            if (ImGui.BeginMenu("File", true))
            {
                ImGui.MenuItem("New Map");
                ImGui.MenuItem("New Map from Template");
                ImGui.MenuItem("Open Map");
                ImGui.MenuItem("Save");
                ImGui.MenuItem("Save As");
                ImGui.MenuItem("Run Map");
                ImGui.MenuItem("Close");
                ImGui.EndMenu();
            }
            

            if (ImGui.BeginMenu("Edit", true))
            {
                ImGui.MenuItem("Copy");
                ImGui.MenuItem("Cut");
                ImGui.MenuItem("Paste");
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Map", true))
            {
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("View", true))
            {
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Tools", true))
            {
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Prefabs", true))
            {
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Window", true))
            {
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Help", true))
            {
                if (ImGui.MenuItem("About"))
                {
                    GetNode<About>("/root/RootNode/About").show = true;
                }
                ImGui.EndMenu();
            }

            ImGui.EndMainMenuBar();
        }
    }
}