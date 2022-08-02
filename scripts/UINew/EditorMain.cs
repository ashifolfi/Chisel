using System;
using Vector2 = System.Numerics.Vector2;
using Godot;
using ImGuiNET;
using Chisel;

public class EditorMain : Node
{
    private Boolean setup = false;
    private AssetManager AssetManager;
    private FileManager FileManager;
    public override void _Ready()
    {
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        ImGui.GetIO().ConfigWindowsMoveFromTitleBarOnly = true;
    }
        
    private void _on_ImGuiNode_IGLayout()
    {
        ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());
        if (setup == false)
        {
            GD.Print("[INF] Initialization Begin");
            
            // Set this right here right now before we even touch the main editor scene.
            Globals.RootPanel = GetNode<EditorMain>("/root/RootNode");
            Globals.RootPath = "/root/RootNode/";
            Globals.ExeDir = OS.GetExecutablePath().GetBaseDir();
		
            GD.Print("[INF] Loading main editor components");
            // Instance the main editor scene. Fixes RootPanel not being inited before
            // the rest of the editor gets inited
            PackedScene Editor = (PackedScene)GD.Load("res://EditorMain.tscn");
            AddChild(Editor.Instance());

            AssetManager = GetNode<AssetManager>(Globals.RootPath + "Editor/AssetManager");
            FileManager = GetNode<FileManager>(Globals.RootPath + "Editor/FileManager");
            
            GD.Print("[INF] Loading game files");
            // TODO: Implement game configurations and a launcher
            FileManager.LoadGameTextures("Chisel");

            GD.Print("[INF] Loading config file");

            GD.Print("[INF] Initialization Complete");
            
            setup = true;
        }
    }
}