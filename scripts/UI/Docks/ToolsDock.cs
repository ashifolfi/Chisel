/*
 * ToolsDock
 *
 * Contains the tool buttons
 *
 * TODO: Add layout constraints
 * TODO: Add icons for tools
 *
 * (C) 2022 by K. "Ashifolfi" J.
 */
using Godot;

namespace Chisel.UI
{
    public class ToolsDock : DockableDialog
    {
        private MeshManager MeshManager;

        public override void _Ready()
        {
            base._Ready();
            MeshManager = GetNode<MeshManager>("/root/UI/3dEnv/MeshManager");
        }

        public override void _Process(float delta)
        {
            base._Process(delta);
            // We never want to be resizable
            Resizable = false;
        }

        private void _on_CreateCube_pressed()
        {
            GetNode<WindowDialog>("/root/UI/CubeCreate").Popup_();
        }

        private void _on_Select_pressed()
        {
            MeshManager.SelectedMesh = null;
        }
	
        private void _on_Delete_pressed()
        {
            if (MeshManager.SelectedMesh != null)
            {
                MeshManager.DeleteMesh(MeshManager.SelectedMesh);
            }
        }
    }
}