/*
 * TextureBrowser
 *
 * Allows the user to view every texture found inside mounted game content
 * and change the active texture.
 *
 * Part of the AssetBrowser component
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
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