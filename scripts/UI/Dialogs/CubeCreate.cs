/*
	Primitive creation dialog
	(C) 2022 K. "Ashifolfi" J.
*/

using Godot;
using System;
using Chisel;


public class CubeCreate : WindowDialog
{
	private AssetManager AssetManager;
	private MeshBuilder MeshBuilder;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Very important nodes we require to create primitives
		AssetManager = GetNode<AssetManager>(Globals.RootPath + "Editor/AssetManager");
		MeshBuilder = GetNode<MeshBuilder>(Globals.RootPath + "Editor/3dEnv/MeshBuilder");
	}

	private void OnCreatePressed()
	{
		// Grab and parse location values as floats
		Vector3 Pos = new Vector3();
		Pos.x = float.Parse(GetNode<LineEdit>("Pos/X/LineEdit").Text);
		Pos.y = float.Parse(GetNode<LineEdit>("Pos/Y/LineEdit").Text);
		Pos.z = float.Parse(GetNode<LineEdit>("Pos/Z/LineEdit").Text);

		// Grab and parse scale values as floats
		Vector3 Size = new Vector3();
		Size.x = float.Parse(GetNode<LineEdit>("Size/W/LineEdit").Text);
		Size.y = float.Parse(GetNode<LineEdit>("Size/H/LineEdit").Text);
		Size.z = float.Parse(GetNode<LineEdit>("Size/L/LineEdit").Text);
		GD.Print(Size);
		GD.Print(Pos);

		// Grab our active texture
		String name;
		AssetManager.ActiveTexture.TryGetValue("texture", out name);
		Texture Texture = (Texture)GD.Load(name);

		// Call the MeshBuilder to create our cube with the provided information
		MeshBuilder.CreateCube(Size, Pos, Texture);

		// And hide ourselves
		Visible = false;
	}
}
