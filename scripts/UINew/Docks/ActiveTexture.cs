/*
 * ActiveTexture Dock
 *
 * Unlike the previous variant of this we don't set the active texture here
 * Instead we do the sane thing and grab the active texture for display here
 * and set the active texture using the TextureBrowser
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;
using System;
using Chisel.scripts.UINew.Dialogs.AssetBrowser;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Docks
{
    public class ActiveTexture : Node
    {
        public Boolean show = true;
        public ImageTexture Tex;
        public String TexName;
        private IntPtr atexTextureId;

        private AssetManager AssetManager;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");

            AssetManager = GetNode<AssetManager>("../../AssetManager");
        }


        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }
            
            ImGui.Begin("Active Texture", ref show, ImGuiWindowFlags.NoCollapse);
            
            // Main Texture
            if (AssetManager.ActiveTexture != null)
            {
                AssetManager.ActiveTexture.TryGetValue("texture", out Tex);
                atexTextureId = ImGuiGD.BindTexture(Tex);
                TexName = AssetManager.ActiveTextureName;

                ImGui.Image(atexTextureId, new Vector2(128, 128));
                ImGui.Text(TexName);
            }

            // Open asset browser when we press browse
            if (ImGui.Button("Browse", new Vector2(100, 20)))
            {
                GetNode<AssetBrowser>("../AssetBrowser").show = true;
            }
            
            ImGui.End();
        }
    }
}