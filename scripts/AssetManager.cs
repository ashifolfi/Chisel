/*
	AssetManager

	Class used to handle the storage of every model, texture, 
	sprite, material that gets loaded when editing a map.

	(C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Godot.Collections;
using System;

public class AssetManager : Node
{
	// Just to make sure these values can be seen by other things
	[Export]
	public Dictionary<String, Dictionary<String, String>> TextureList = new Dictionary<String, Dictionary<String, String>>();
	[Export]
	public Dictionary<String, String> ActiveTexture = new Dictionary<String, String>();

	public override void _Ready()
	{
		// TODO: Make a function to dynamically load all textures in a directory
		LoadTexture("floor", "");
		LoadTexture("wall", "");
		// TODO: Make these Tool textures actually work with their intended purpose
		LoadTexture("hint", "");
		LoadTexture("nodraw", "");
		LoadTexture("skip", "");
		LoadTexture("trigger", "");
		// Set the active texture to the floor texture
		TextureList.TryGetValue("floor", out ActiveTexture);
	}

	// Add item to the texture list
	// TODO: Support VTF Files
	// TODO: Make textures entirely external with a source engine file structure
	public void LoadTexture(String TexName, String GameDir)
	{
		// Make sure the texture actually exists
		Godot.File File = new Godot.File();
		if (!File.FileExists("res://assets/textures/" + TexName + ".png"))
		{
			// Texture doesn't exist
			GD.Print("[INF] Texture " + TexName + " does not exist!");
			// If it's in the list we need to remove it's reference!
			if (TextureList[TexName] != null)
			{
				GD.Print("[INF] Non Existing texture file is in list! - removing");
				TextureList.Remove(TexName);
			}
		}
		// Check if it's already in the list
		else if (TryFindTex(TexName) == true)
		{
			GD.Print("[INF] " + TexName + " is already loaded - skipping");
		}
		// It's not. Let's add it!
		else
		{
			GD.Print("[INF] Adding " + TexName + " to TextureList");
			TextureList.Add(TexName, new Dictionary<String, String>()
			{
				{"texture", "res://assets/textures/" + TexName + ".png"},
				{"name", "textures/" + TexName}
			});
		}
	}

	// Name is self explanatory. Try to find the texture in the list
	public Boolean TryFindTex(String TexName)
	{
		Dictionary<string, string> Dummy;
		TextureList.TryGetValue(TexName, out Dummy);

		if (Dummy != null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
