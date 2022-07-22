/*
	Primitive creation dialog
	(C) 2022 K. "Ashifolfi" J.
*/

using Godot;
using System;


public class CubeCreate : WindowDialog
{
	private AssetManager AssetManager;
	private MeshBuilder MeshBuilder;
	private TextureBrowser TextureBrowser;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Very important nodes we require to create primitives
		AssetManager = GetNode<AssetManager>("/root/UI/AssetManager");
		MeshBuilder = GetNode<MeshBuilder>("/root/UI/3dEnv/MeshBuilder");
		TextureBrowser = GetNode<TextureBrowser>("/root/UI/TextureBrowser");
	}
	
	public override void _Process(float delta)
	{
		// Simple shortcuts
		Label TexName = GetNode<Label>("Texture/Label");
		TextureRect TexImg = GetNode<TextureRect>("Texture/TextureRect");
		
		// Set the values for the image and label to the current Active Texture
		UpdateTextureFields(TexName, TexImg);
	}

	// You would not believe how long it took me to get this function to not throw me an error
	public void UpdateTextureFields(Label TexName, TextureRect TexImg)
	{
		if (AssetManager.ActiveTexture.Count > 0)
		{
			// This went from one line to 3
			String Name;
			AssetManager.ActiveTexture.TryGetValue("name", out Name);
			TexName.Text = Name;
		}
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

		// Grab our texture from the window
		Texture Texture = GetNode<TextureRect>("Texture/TextureRect").Texture;

		// Call the MeshBuilder to create our cube with the provided information
		MeshBuilder.CreateCube(Size, Pos, Texture);

		// And hide ourselves
		Visible = false;
	}

	// Open Texture Browser and refresh texture data
	private void OnBrowsePressed()
	{
		TextureBrowser.Popup_();
		TextureBrowser.UpdateTexGrid();
	}
}
