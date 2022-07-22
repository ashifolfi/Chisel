/*
    MeshManager

    Handles anything that's done to already existing map objects

    (C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Godot.Collections;
using System;
using Chisel;

public class MeshManager : Spatial
{
    [Export]
    public StaticBody SelectedMesh;
    [Export]
    public Dictionary MeshList = new Dictionary();

    public void DeleteMesh(StaticBody Body)
    {
        // Check to make sure we aren't about to destroy something we absolutely
        // should NOT be destroying. Crash if we are to prevent any dangerous things from happening
        Debug.Assert((Body.GetClass() != "StaticBody"), "Attempted to delete non valid object from map!");
        if (IsInstanceValid(Body.GetParent()))
        {
            Body.GetParent().QueueFree();
            SelectedMesh = null;
        }
        else
        {
            GD.Print("[WARN] Attempted to delete_mesh non-valid parent! File may be corrupt!");
        }
    }

    public void TransformMesh(StaticBody Body)
    {
        // STUB
    }
}