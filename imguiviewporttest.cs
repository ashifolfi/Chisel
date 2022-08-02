using Godot;
using System;
using ImGuiNET;
using Vector2 = System.Numerics.Vector2;
using Chisel;

public class imguiviewporttest : Control
{
    public Boolean show = true;
    
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
    }

    public override void _Input(InputEvent @event)
    {
        if (Globals.In3DView == true)
        {
            if (@event is InputEventMouse)
            {
                InputEvent MouseEvent = (InputEvent)@event.Duplicate();
                MouseEvent.Set("position", GetGlobalTransform().XformInv((Godot.Vector2)@event.Get("global_position")));
                GetNode<Viewport>("ViewportContainer/Viewport").UnhandledInput(MouseEvent);
            }
            else
            {
                GetNode<Viewport>("ViewportContainer/Viewport").UnhandledInput(@event);
            }
        }
    }

    private void _on_ImGuiNode_IGLayout()
    {
        if (show == false)
        {
            return;
        }

        ImGui.Begin("Viewport Test", ref show, ImGuiWindowFlags.None);

        if (ImGui.IsMouseDown(ImGuiMouseButton.Right))
        {
            Globals.CameraOn = true;
        }
        else
        {
            Globals.CameraOn = false;
        }

        if (ImGui.IsWindowHovered())
            Globals.In3DView = true;
        else
            Globals.In3DView = false;

        Texture Tex = GetNode<Viewport>("ViewportContainer/Viewport").GetTexture();
        IntPtr TexId = ImGuiGD.BindTexture(Tex);
        
        ImGui.Image(TexId, new Vector2(Tex.GetWidth(), Tex.GetHeight()));
        ImGui.SetWindowSize(new Vector2(Tex.GetWidth(), Tex.GetHeight()));
        ImGui.End();
    }
}
