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
using Vector2 = System.Numerics.Vector2;
using ImGuiNET;

namespace Chisel.scripts.UINew.Dialogs.AssetBrowser
{
    public class AssetBrowser : Node
    {
        public Boolean show = false;

        public override void _Ready()
        {
            Node ImGuiNode = GetNode<Node>("/root/RootNode/ImGuiNode");
            ImGuiNode.Connect("IGLayout", GetNode("."), "_on_ImGuiNode_IGLayout");
        }

        private void _on_ImGuiNode_IGLayout()
        {
            if (show == false)
            {
                return;
            }
            /
        }
    }
}