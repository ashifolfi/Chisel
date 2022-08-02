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
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Docks
{
    public class ActiveTexture : Node
    {
        public Boolean show = false;
        private Texture Tex;
        private String TexName;
        private IntPtr atexTextureId;

        //private AssetManager AssetManager;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");

            GetNode<AssetManager>("/root/RootPanel/AssetManager");
        }


        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }
            
            ImGui.Begin("Active Texture", ref show, ImGuiWindowFlags.NoCollapse);
            
            // Main Texture
            
        }
    }
}