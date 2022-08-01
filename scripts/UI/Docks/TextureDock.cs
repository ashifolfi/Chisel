/*
 * TextureDock
 *
 * Serves the same purpose as the material dock in hammer
 * TODO: Fix issue with textures discoloring once used on a primitive
 *
 * (C) 2022 by K. "ashifolfi" J.
 */
using Godot;

namespace Chisel.UI
{
    public class TextureDock : DockableDialog
    {
        private AssetManager AssetManager;   
        private TextureBrowser TextureBrowser;
        public override void _Ready()
        {
            base._Ready();
            
            // Bind our elements to variables
            AssetManager = GetNode<AssetManager>("/root/UI/AssetManager");
            TextureBrowser = GetNode<TextureBrowser>("/root/UI/TextureBrowser");
        }
        
        public override void _Process(float delta)
        {
            base._Process(delta);
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
                string name;
                AssetManager.ActiveTexture.TryGetValue("name", out name);
                TexName.Text = name;

                AssetManager.ActiveTexture.TryGetValue("texture", out name);
                TexImg.Texture = (Texture)GD.Load(name);
            }
        }
        
        // Open Texture Browser and refresh texture data
        private void OnBrowsePressed()
        {
            TextureBrowser.Popup_();
            TextureBrowser.UpdateTexGrid();
        }
    }
}