/*
    Selectable Object

    (C) 2022 by K. "AshiFolfi" J.
*/

using Godot;
using System;
using Chisel;

public class SelectableMesh : StaticBody
{
    MeshManager MeshManager;

    public override void _Ready()
    {
        MeshManager = GetNode<MeshManager>(Globals.RootPath + "Editor/3dEnv/MeshManager");
    }

    public override void _Process(float delta)
    {
        if (MeshManager.SelectedMesh != GetNode("./"))
        {
            Material Mat = GetNode<MeshInstance>("../").GetSurfaceMaterial(0);
            Mat.NextPass = null;
        }
    }

    public void _OnSelected(Node Camera, InputEvent @event, Vector2 Position, Vector3 Normal, int ShapeIdx)
    {
        if (@event is InputEventMouseButton)
		{
			switch ((ButtonList)@event.Get("button_index"))
			{
                case ButtonList.Left:
                    MeshManager.SelectedMesh = GetNode<StaticBody>("./");
                    Material Mat = GetNode<MeshInstance>("../").GetSurfaceMaterial(0);
                    ShaderMaterial ShadMat = new ShaderMaterial();
                    ShadMat.Shader = (Shader)GD.Load("res://assets/shaders/selected_mesh.shader");
                    Mat.NextPass = ShadMat;
                    break;
            }
        }
    }
}