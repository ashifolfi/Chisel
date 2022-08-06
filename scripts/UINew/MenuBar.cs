using Chisel.scripts.UINew.Dialogs;
using Chisel.scripts.UINew.Dialogs.AssetBrowser;
using Chisel.scripts.UINew.Docks;
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

            if (ImGui.BeginMenu("Chisel", true))
            {
                AppMenu();
                ImGui.EndMenu();
            }
            
            if (ImGui.BeginMenu("File", true))
            {
                FileMenu();
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
                WindowMenu();
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

        private void AppMenu()
        {
            if (ImGui.MenuItem("Exit"))
            {
                GetTree().Quit();
            }
        }
        
        private void FileMenu()
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
        }
        
        // Contains the contents of the window menu
        private void WindowMenu()
        {
            if (ImGui.BeginMenu("Docks", true))
            {
                if (ImGui.MenuItem("Tools")) GetNode<Tools>("../Tools").show = true;
                if (ImGui.MenuItem("Active Material")) GetNode<ActiveTexture>("../ActiveTexture").show = true;
                if (ImGui.MenuItem("Tool Properties")) GetNode<ToolProperties>("../ToolProperties").show = true;
                if (ImGui.MenuItem("Outliner")) GetNode<Outline>("../Outliner").show = true;
                ImGui.EndMenu();
            }
            ImGui.Separator();
            if (ImGui.MenuItem("Asset Browser")) GetNode<AssetBrowser>("../AssetBrowser").show = true;
        }
    }
}