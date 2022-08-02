/*
 * AssetBrowser
 *
 * This is the main asset browser window. for each individual
 * panel inside the browser see it's designated file.
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;
using System;
using System.ComponentModel;
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs.AssetBrowser
{
    public class AssetBrowser : Node
    {
        public Boolean show = false;
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

            ImGui.Begin("Asset Browser", ref show, ImGuiWindowFlags.None | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoCollapse);
            ImGui.BeginTabBar("ab_tabs", ImGuiTabBarFlags.None);

            // Tab Items
            // Texture Browser
            Boolean tex_open = true;
            if (ImGui.BeginTabItem("Textures", ref tex_open, ImGuiTabItemFlags.None))
            {
                TextureBrowser.TextureBrowser_Main(AssetManager);
                
                ImGui.Columns(1);
                ImGui.EndTabItem();
            }
            // Model Browser
            if (ImGui.BeginTabItem("Models", ref tex_open, ImGuiTabItemFlags.None))
            {
                ImGui.EndTabItem();
            }
            // Particle Browser
            if (ImGui.BeginTabItem("Particles", ref tex_open, ImGuiTabItemFlags.None))
            {
                ImGui.EndTabItem();
            }
            
            ImGui.EndTabBar();
            ImGui.End();
        }
    }
}