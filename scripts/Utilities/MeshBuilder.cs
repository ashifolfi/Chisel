/*
    MeshBuilder

    Used to create primitives and other map objects

    Interfaces with MeshManager which handles the existing objects

    (C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using System;
using static Chisel.Utilities;

public class MeshBuilder : Spatial
{
    [Export]
    public MeshManager MeshManager;

    // onready var doesn't exist in C# so we need to do it in the ready method
    public override void _Ready()
    {
        MeshManager = GetNode<MeshManager>("../MeshManager");
    }

    // Cube creation function
    // To show you the power of reading documentation I cut this function in half
    public void CreateCube(Vector3 Size, Vector3 Position, Texture Texture)
    {
        // Create the initial mesh variables
        MeshInstance Mesh = new MeshInstance();
        MeshManager.AddChild(Mesh);
        CubeMesh Primitive = new CubeMesh();

        // Scale primitive to the specified values
        Primitive.Size = Size;

        // Setup collision shape used to select the object
        StaticBody SelectBody = new StaticBody();
        // Set script and connection so selection actually works
        SelectBody = (StaticBody)SetScriptSafe(SelectBody ,"res://scripts/3DEnvironment/SelectableMesh.cs");
        SelectBody.Connect("input_event", SelectBody, "_OnSelected");
        // Setup CollisionShape
        CollisionShape ColShape = new CollisionShape();
        ColShape.Shape = new BoxShape();
        ColShape.Shape.Set("extents", Size / 2);
        SelectBody.AddChild(ColShape);
        // Make it ray pickable
        SelectBody.InputRayPickable = true;
        // Add it to the mesh Object
        Mesh.AddChild(SelectBody);

        // Setup the material
        SpatialMaterial Material = new SpatialMaterial();
        Material.AlbedoTexture = Texture;
        // Change uv variables
        Material.Uv1Triplanar = true;
        Material.Uv2Triplanar = true;

        // Set the surface material and mesh of the MeshInstance
        Mesh.Mesh = Primitive;
        Mesh.SetSurfaceMaterial(0, Material);

        // And now reposition the mesh as our final action
        Mesh.Translate(Position);
    }

    public void CreateEntity(String EntityName, Vector3 Position)
    {
        // STUB
    }

    public void CreatePrimitive(String PrimitiveName, Vector3 Size, Vector3 Position, StreamTexture Texture)
    {
        // STUB
    }
}