using Chisel.scripts.UINew.Dialogs;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew
{
    public class MenuBar : Node
    {
        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");
        }
        private void _on_ImGuiNode_IGLayout()
        {
            ImGui.BeginMainMenuBar();

            if (ImGui.BeginMenu("File", true))
            {
                ImGui.MenuItem("New Map");
                ImGui.MenuItem("New Map from Template");
                ImGui.Separator();
                ImGui.MenuItem("Open Map");
                ImGui.Separator();
                ImGui.MenuItem("Save");
                ImGui.MenuItem("Save As");
                ImGui.Separator();
                ImGui.MenuItem("Run Map");
                ImGui.Separator();
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
                ImGui.MenuItem("Chisel Documentation");
                ImGui.Separator();
                if (ImGui.MenuItem("About Chisel"))
                {
                    GetNode<About>("../About").show = true;
                }
                ImGui.EndMenu();
                
            }

            ImGui.EndMainMenuBar();
        }
    }
}