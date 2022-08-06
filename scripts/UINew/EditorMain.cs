using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Vector2 = System.Numerics.Vector2;
using Godot;
using ImGuiNET;
using Chisel;

public class EditorMain : Node
{
    private Boolean setup = false;
    private AssetManager AssetManager;
    private FileManager FileManager;

    private ImFontPtr NSPtr;
    public override void _Ready()
    {
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        ImGui.GetIO().ConfigWindowsMoveFromTitleBarOnly = true;

        // Set theme colors
        RangeAccessor<Vector4> colors = ImGui.GetStyle().Colors;
        colors[(int)ImGuiCol.Text]                   = new Vector4(1.00f, 1.00f, 1.00f, 1.00f);
        colors[(int)ImGuiCol.TextDisabled]           = new Vector4(0.50f, 0.50f, 0.50f, 1.00f);
        colors[(int)ImGuiCol.WindowBg]               = new Vector4(0.06f, 0.06f, 0.06f, 0.94f);
        colors[(int)ImGuiCol.ChildBg]                = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
        colors[(int)ImGuiCol.PopupBg]                = new Vector4(0.08f, 0.08f, 0.08f, 0.94f);
        colors[(int)ImGuiCol.Border]                 = new Vector4(0.43f, 0.43f, 0.50f, 0.50f);
        colors[(int)ImGuiCol.BorderShadow]           = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
        colors[(int)ImGuiCol.FrameBg]                = new Vector4(0.29f, 0.16f, 0.48f, 0.54f);
        colors[(int)ImGuiCol.FrameBgHovered]         = new Vector4(0.65f, 0.26f, 0.98f, 0.40f);
        colors[(int)ImGuiCol.FrameBgActive]          = new Vector4(0.67f, 0.26f, 0.98f, 0.67f);
        colors[(int)ImGuiCol.TitleBg]                = new Vector4(0.04f, 0.04f, 0.04f, 1.00f);
        colors[(int)ImGuiCol.TitleBgActive]          = new Vector4(0.33f, 0.13f, 0.61f, 1.00f);
        colors[(int)ImGuiCol.TitleBgCollapsed]       = new Vector4(0.00f, 0.00f, 0.00f, 0.51f);
        colors[(int)ImGuiCol.MenuBarBg]              = new Vector4(0.14f, 0.14f, 0.14f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarBg]            = new Vector4(0.02f, 0.02f, 0.02f, 0.53f);
        colors[(int)ImGuiCol.ScrollbarGrab]          = new Vector4(0.31f, 0.31f, 0.31f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabHovered]   = new Vector4(0.41f, 0.41f, 0.41f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabActive]    = new Vector4(0.51f, 0.51f, 0.51f, 1.00f);
        colors[(int)ImGuiCol.CheckMark]              = new Vector4(0.63f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.SliderGrab]             = new Vector4(0.63f, 0.24f, 0.88f, 1.00f);
        colors[(int)ImGuiCol.SliderGrabActive]       = new Vector4(0.63f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Button]                 = new Vector4(0.63f, 0.26f, 0.98f, 0.40f);
        colors[(int)ImGuiCol.ButtonHovered]          = new Vector4(0.63f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.ButtonActive]           = new Vector4(0.63f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Header]                 = new Vector4(0.63f, 0.26f, 0.98f, 0.31f);
        colors[(int)ImGuiCol.HeaderHovered]          = new Vector4(0.63f, 0.26f, 0.98f, 0.80f);
        colors[(int)ImGuiCol.HeaderActive]           = new Vector4(0.63f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Separator]              = new Vector4(0.43f, 0.43f, 0.50f, 0.50f);
        colors[(int)ImGuiCol.SeparatorHovered]       = new Vector4(0.47f, 0.10f, 0.75f, 0.78f);
        colors[(int)ImGuiCol.SeparatorActive]        = new Vector4(0.47f, 0.10f, 0.75f, 1.00f);
        colors[(int)ImGuiCol.ResizeGrip]             = new Vector4(0.63f, 0.26f, 0.98f, 0.20f);
        colors[(int)ImGuiCol.ResizeGripHovered]      = new Vector4(0.63f, 0.26f, 0.98f, 0.67f);
        colors[(int)ImGuiCol.ResizeGripActive]       = new Vector4(0.63f, 0.26f, 0.98f, 0.95f);
        colors[(int)ImGuiCol.Tab]                    = new Vector4(0.35f, 0.18f, 0.58f, 0.86f);
        colors[(int)ImGuiCol.TabHovered]             = new Vector4(0.59f, 0.26f, 0.98f, 0.80f);
        colors[(int)ImGuiCol.TabActive]              = new Vector4(0.41f, 0.20f, 0.68f, 1.00f);
        colors[(int)ImGuiCol.TabUnfocused]           = new Vector4(0.10f, 0.07f, 0.15f, 0.97f);
        colors[(int)ImGuiCol.TabUnfocusedActive]     = new Vector4(0.26f, 0.14f, 0.42f, 1.00f);
        colors[(int)ImGuiCol.DockingPreview]         = new Vector4(0.59f, 0.26f, 0.98f, 0.70f);
        colors[(int)ImGuiCol.DockingEmptyBg]         = new Vector4(0.20f, 0.20f, 0.20f, 1.00f);
        colors[(int)ImGuiCol.PlotLines]              = new Vector4(0.61f, 0.61f, 0.61f, 1.00f);
        colors[(int)ImGuiCol.PlotLinesHovered]       = new Vector4(1.00f, 0.43f, 0.35f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogram]          = new Vector4(0.90f, 0.70f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogramHovered]   = new Vector4(1.00f, 0.60f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.TableHeaderBg]          = new Vector4(0.19f, 0.19f, 0.20f, 1.00f);
        colors[(int)ImGuiCol.TableBorderStrong]      = new Vector4(0.31f, 0.31f, 0.35f, 1.00f);
        colors[(int)ImGuiCol.TableBorderLight]       = new Vector4(0.23f, 0.23f, 0.25f, 1.00f);
        colors[(int)ImGuiCol.TableRowBg]             = new Vector4(0.00f, 0.00f, 0.00f, 0.00f);
        colors[(int)ImGuiCol.TableRowBgAlt]          = new Vector4(1.00f, 1.00f, 1.00f, 0.06f);
        colors[(int)ImGuiCol.TextSelectedBg]         = new Vector4(0.59f, 0.26f, 0.98f, 0.35f);
        colors[(int)ImGuiCol.DragDropTarget]         = new Vector4(1.00f, 1.00f, 0.00f, 0.90f);
        colors[(int)ImGuiCol.NavHighlight]           = new Vector4(0.59f, 0.26f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.NavWindowingHighlight]  = new Vector4(1.00f, 1.00f, 1.00f, 0.70f);
        colors[(int)ImGuiCol.NavWindowingDimBg]      = new Vector4(0.80f, 0.80f, 0.80f, 0.20f);
        colors[(int)ImGuiCol.ModalWindowDimBg]       = new Vector4(0.80f, 0.80f, 0.80f, 0.35f);
    }
        
    private void _on_ImGuiNode_IGLayout()
    {
        ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());
        //ImGui.ShowStyleEditor();
        if (setup == false)
        {
            GD.Print("[INF] Initialization Begin");

            // Set this right here right now before we even touch the main editor scene.
            Globals.RootPanel = GetNode<EditorMain>("/root/RootNode");
            Globals.RootPath = "/root/RootNode/";
            Globals.ExeDir = OS.GetExecutablePath().GetBaseDir();
            
            // Add our custom font
            ImGuiGD.AddFont(GD.Load<DynamicFontData>(Globals.ExeDir + "/" + "Chisel/resource/Roboto-Medium.ttf"), 12);
		
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
            AssetManager.SwapActiveTexture("dev_measurewall01a");

            GD.Print("[INF] Loading config file");

            GD.Print("[INF] Initialization Complete");
            
            setup = true;
        }
    }
}