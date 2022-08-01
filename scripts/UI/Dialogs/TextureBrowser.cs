/*
	TextureBrowser

	Used to browse available textures to use on brushes/overlays/decals
	
	TODO: Fix issue with textures discoloring once used on a primitive

	(C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Godot.Collections;
using System;
using Chisel;
public class TextureBrowser : WindowDialog
{
	public GridContainer TextureGrid;
	public AssetManager AssetManager;
	public ButtonGroup TexButton = new ButtonGroup();
    public Dictionary<String, String> TextureSelected;

	// Setup the control
	public override void _Ready()
	{
		// Tie nodes to variables
		AssetManager = GetNode<AssetManager>(Globals.RootPath + "Editor/AssetManager");
		TextureGrid = GetNode<GridContainer>("HSplitContainer/ScrollContainer/GridContainer");

		// Set minimum size and exclusivity
		Vector2 MinSize = new Vector2();
		MinSize.x = 730;
		MinSize.y = 500;
		RectMinSize = MinSize;
		PopupExclusive = true;
	}

	// Update contents of the texture grid
	// TODO: Create other sizes for larger columns
	// TODO: There's probably a better way to do this
	public void UpdateTexGrid()
	{
		// Clear out existing children
		foreach (Godot.Node N in TextureGrid.GetChildren())
		{
			TextureGrid.RemoveChild(N);
			N.QueueFree();
		}

		// Go through the entire TextureList and add every texture entry to the grid
		foreach (String Tex in AssetManager.TextureList.Keys)
		{
			// Create vertical split container
			VSplitContainer TexItem = new VSplitContainer();
			TexItem.RectMinSize = new Vector2(128, 154);
			TexItem.Collapsed = true;
			TexItem.MouseFilter = Control.MouseFilterEnum.Pass;
			// Create TextureRect
			TextureRect TexRec = new TextureRect();
			TexRec.Expand = true;
			TexRec.RectMinSize = new Vector2(128, 128);
			ImageTexture Texture;
            AssetManager.TextureList[Tex].TryGetValue("texture", out Texture);
            TexRec.Texture = Texture;
			TexItem.AddChild(TexRec);
			// Create Name Label
			Label TexName = new Label();
			TexName.ClipText = true;
			TexName.Text = Tex;
			TexItem.AddChild(TexName);
			// Define button used for selection
			TextureRadio TexRadio = new TextureRadio();
			TexRadio.RectMinSize = new Vector2(128,154);
			TexRadio.Group = TexButton;
			Dictionary<String, ImageTexture> TexInfo;
			AssetManager.TextureList.TryGetValue(Tex, out TexInfo);
			TexRadio.HasTexture = TexInfo;
			TexRadio.TextureName = Tex;
			// Finally. Add it all to the grid
			TexRadio.AddChild(TexItem);
			TextureGrid.AddChild(TexRadio);
		}
	}

	private void _on_HSlider_value_changed(float value)
	{
		TextureGrid.Columns = Convert.ToInt32(value);
		UpdateTexGrid();
	}

    private void _on_Reload_pressed()
    {
        // Update the texture grid for any new tetures or changed images
        UpdateTexGrid();
    }

    private void _on_Accept_pressed()
    {
        // Check if the pressed button is valid first
        if (TexButton.GetPressedButton() != null)
        {
            // Extremely convoluted method of pulling a node C# is happy with
            // really wish this language allowed variable assumptions.
            String ButtonPath;
            ButtonPath = GetPathTo(TexButton.GetPressedButton());
            AssetManager.ActiveTexture = GetNode<TextureRadio>(ButtonPath).HasTexture;
            AssetManager.ActiveTextureName = GetNode<TextureRadio>(ButtonPath).TextureName;
            
            Visible = false;
        }
    }
}
