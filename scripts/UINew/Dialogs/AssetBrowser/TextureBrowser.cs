using Godot;
using System;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs.AssetBrowser
{
    public class TextureBrowser : Node
    {
        public Boolean show = false;

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