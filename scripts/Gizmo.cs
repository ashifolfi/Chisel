using Godot;
using System;
using Chisel;

public class Gizmo : Spatial
{
    private StaticBody XArrow;
    private StaticBody YArrow;
    private StaticBody ZArrow;

    private MeshManager MeshManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Setup variables to contain the gizmo arrows
        XArrow = GetNode<StaticBody>("XArrow");
        YArrow = GetNode<StaticBody>("YArrow");
        ZArrow = GetNode<StaticBody>("ZArrow");

        // Get the MeshManager
        MeshManager = GetNode<MeshManager>(Globals.RootPath + "Editor/3dEnv/MeshManager");

        // Make ourselves invisible
        Visible = false;
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (MeshManager.SelectedMesh != null)
        {
            MeshInstance SelMeshParent = (MeshInstance)MeshManager.SelectedMesh.GetParent();
            Translation = SelMeshParent.Translation;
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }
}
