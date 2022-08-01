/*
    Mouse Brush Drawing

    Used with the brush drawing tool
    
    TODO: Fix brushes being selected on creation

    (C) 2022 by K. "Ashifolfi" J.
*/
using Godot;
using System;
using Chisel;

public class Grid3D : StaticBody
{
    private Boolean ClickMade = false;
    private Spatial PosMark1 = new Spatial();
    private Spatial PosMark2 = new Spatial();
    private MeshBuilder MeshBuilder;
    private AssetManager AssetManager;

    public override void _Ready()
    {
        MeshBuilder = GetNode<MeshBuilder>(Globals.RootPath + "Editor/3dEnv/MeshBuilder");
        AssetManager = GetNode<AssetManager>(Globals.RootPath + "Editor/AssetManager");
    }

    public void OnStaticBodyInputEvent(Node camera, InputEvent MouseEvent, Vector3 position, Vector3 normal, int shape_idx)
    {
        // on the first click
        if ((MouseEvent is InputEventMouseButton) && ((Boolean)MouseEvent.Get("pressed")) 
                                                  && ((int)MouseEvent.Get("button_index") == 1) && (ClickMade != true))
        {
            // Set the position of our first position marker
            PosMark1.Translation = new Vector3(
                Mathf.Stepify(position.x, 0.1F),
                Mathf.Stepify(position.y, 0.1F),
                Mathf.Stepify(position.z, 0.1F));
            ClickMade = true;
        }
        // on the second click
        else if ((MouseEvent is InputEventMouseButton) && ((Boolean)MouseEvent.Get("pressed"))
                                                       && ((int)MouseEvent.Get("button_index") == 1)
                                                       && (ClickMade))
        {
            // set ClickMade to false so we can do this again
            ClickMade = false;
            // Create a new primitive here
            CreateMeshHere();
        }
        // Routine to set the position of the second marker to the last position the mouse was at
        // and allow for proper visual feedback on the current size of the cube we will draw
        if ((MouseEvent is InputEventMouseMotion) && (ClickMade))
        {
            // Set the position of our second marker
            PosMark2.Translation = new Vector3(
                Mathf.Stepify(position.x, 0.1F),
                Mathf.Stepify(position.y, 0.1F),
                Mathf.Stepify(position.z, 0.1F));
        }
    }

    public void CreateMeshHere()
    {
        // Setup the position variables.
        float XFinal;
        float YFinal;
        float ZFinal;
        Vector3 TransFinal = new Vector3();

        // X position
        if (PosMark1.Translation.x > PosMark2.Translation.x)
        {
            XFinal = PosMark1.Translation.x - PosMark2.Translation.x;
            TransFinal.x = PosMark2.Translation.x;
        }
        else
        {
            XFinal = PosMark2.Translation.x - PosMark1.Translation.x;
            TransFinal.x = PosMark1.Translation.x;
        }
        
        // Y position
        if (PosMark1.Translation.y > PosMark2.Translation.y)
        {
            YFinal = PosMark1.Translation.y - PosMark2.Translation.y;
            TransFinal.y = PosMark2.Translation.y;
        }
        else
        {
            YFinal = PosMark2.Translation.y - PosMark1.Translation.y;
            TransFinal.y = PosMark1.Translation.y;
        }
        
        // Z position
        if (PosMark1.Translation.z > PosMark2.Translation.z)
        {
            ZFinal = PosMark1.Translation.z - PosMark2.Translation.z;
            TransFinal.z = PosMark2.Translation.z;
        }
        else
        {
            ZFinal = PosMark2.Translation.z - PosMark1.Translation.z;
            TransFinal.z = PosMark1.Translation.z;
        }
        
        ImageTexture name;
        AssetManager.ActiveTexture.TryGetValue("texture", out name);
        Texture Texture = name;
        
        MeshBuilder.CreateCube(new Vector3(XFinal, 1, ZFinal),
            TransFinal + (new Vector3(XFinal, YFinal, ZFinal) / 2),
            Texture);

        GetNode<MeshManager>(Globals.RootPath + "Editor/3dEnv/MeshManager").SelectedMesh = null;
    }
}