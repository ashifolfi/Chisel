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
using System.Collections.Generic;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs.AssetBrowser
{
    public class TextureBrowser
    {
        public Boolean show = false;

        public static void TextureBrowser_Main(AssetManager AssetManager)
        {
            ImGui.Columns(3);

            foreach (String Tex in AssetManager.TextureList.Keys)
            {
                ImageTexture Material;
                AssetManager.TextureList[Tex].TryGetValue("texture", out Material);
                IntPtr MatID = ImGuiGD.BindTexture(Material);

                ImGui.ImageButton(MatID, new Vector2(128, 128));
                if (ImGui.IsItemActivated())
                {
                    AssetManager.ActiveTexture = AssetManager.TextureList[Tex];
                    AssetManager.ActiveTextureName = Tex;
                    GD.Print(Tex);
                    GD.Print(Material);
                }

                ImGui.NextColumn();
            }
        }
    }
}