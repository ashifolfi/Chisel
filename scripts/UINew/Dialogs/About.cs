using System;
using Vector2 = System.Numerics.Vector2;
using Godot;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs
{
    public class About : Node
    {
        public Boolean show = false;
        private Boolean posset = false;
        private IntPtr iconTextureId;
        private Texture Icon;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");
            
            Icon = (Texture)GD.Load("res://icon.png");
            iconTextureId = ImGuiGD.BindTexture(Icon);
        }

        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }

            ImGui.Begin("About", ref show,
                ImGuiWindowFlags.None | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoSavedSettings |
                ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDocking);
            // Set the window size
            ImGui.SetWindowSize(new Vector2(333, 337));
            if (posset == false)
            {
                // Set window position once
                ImGui.SetWindowPos(new Vector2(
                    (OS.WindowSize.x / 2) - 166, (OS.WindowSize.y / 2) - 168));
                posset = true;
            }
            
            // Actual window elements
            ImGui.Image(iconTextureId, new Vector2(Icon.GetWidth() / 3, Icon.GetHeight() / 3));
            String[] About =
            {
                "Chisel version 0.0.2",
                "Created by K. 'ashifolfi' J.",
                "",
                "Powered by:",
                "Godot Engine, ImGui, VTFLib, VMFLib",
                "Written in: C#"
            };
            foreach (String S in About)
            {
                ImGui.Text(S);
            }

            if (ImGui.Button("Source Code"))
                OS.ShellOpen("https://www.github.com/ashifolfi/Chisel");
            ImGui.SameLine();
            if (ImGui.Button("Close"))
                show = false;

            ImGui.End();
        }
    }
}