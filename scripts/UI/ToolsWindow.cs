using Godot;
using System;

public class ToolsWindow : Container
{
	private MeshManager MeshManager;

	public override void _Ready()
	{
		MeshManager = GetNode<MeshManager>("/root/UI/3dEnv/MeshManager");
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
