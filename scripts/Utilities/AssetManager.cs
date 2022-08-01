/*
	AssetManager

	Class used to handle the storage of every model, texture, 
	sprite, material that gets loaded when editing a map.
	
	TODO: Ditch non VTF support for textures. Source doesn't read from anything BUT a VTF

	(C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Godot.Collections;
using System;
using System.Text.RegularExpressions;
using VTFLibWrapper;
using Chisel;

public class AssetManager : Node
{
	// Just to make sure these values can be seen by other things
	[Export]
	public Dictionary<String, Dictionary<String, ImageTexture>> TextureList = new Dictionary<String, Dictionary<String, ImageTexture>>();
	[Export]
	public Dictionary<String, ImageTexture> ActiveTexture = new Dictionary<String, ImageTexture>();
	[Export]
	public String ActiveTextureName;

	public override void _Ready()
	{
		
	}
	
	// New function specifically to handle changing the active texture
	public void SwapActiveTexture(String TexName)
	{
		TextureList.TryGetValue(TexName, out ActiveTexture);
		ActiveTextureName = TexName;
	}

	// Add item to the texture list
	public void LoadTexture(String FileName, String GameDir)
	{
		// Get a version of the TexName that lacks the extension
		String TexName = Regex.Replace(FileName, @"\.[^.]*$", String.Empty);
		// Setup a few variables
		Godot.File File = new Godot.File();
		VTFFile VTexFile = new VTFFile();
		ImageTexture Tex = new ImageTexture();
		// Make sure the texture actually exists
		if (!File.FileExists(Globals.ExeDir + "/" + GameDir + "/materials/" + FileName))
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
			// Check if we're trying to load a vtf file or not.
			if (Regex.Match(FileName, @"\.[^.]*$").Value == ".vtf")
			{
				// VTF Requires more work to be done
				// Load the VTFFile
				// You must place all vtf files in the exe dir under "vtf_test" as res:// does not work with vtflib
				VTexFile.Load(Globals.ExeDir + "/" + GameDir + "/materials/" + FileName, false);
				// Create a new image from the data given
				Image Converted = new Image();
				Converted.CreateFromData(
					Convert.ToInt32(VTexFile.GetWidth()), Convert.ToInt32(VTexFile.GetHeight()), false,
					Converts.FromVTFFormat(VTexFile.GetFormat()), VTexFile.GetData(0, 0, 0, 0));
				// Convert it into a texture
				Tex.CreateFromImage(Converted);
				
				// Add the texture to the list
				TextureList.Add(TexName, new Dictionary<String, ImageTexture>()
				{
					{
						"texture", Tex
					}
				});
			}
			else
			{
				GD.Print("[INF] Not a VTF. Not loading.");
			}
		}
	}

	// Name is self explanatory. Try to find the texture in the list
	public Boolean TryFindTex(String TexName)
	{
		Dictionary<string, ImageTexture> Dummy;
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
