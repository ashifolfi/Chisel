using System;
using Vector2 = System.Numerics.Vector2;
using Godot;
using ImGuiNET;

public class EditorMain : Node
{
    private Boolean setup = false;
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
            PackedScene scene = (PackedScene)GD.Load("res://EditorMain.tscn");
            AddChild(scene.Instance());
            
            setup = true;
        }
    }
}