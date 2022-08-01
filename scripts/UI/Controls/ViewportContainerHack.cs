/*
	ViewportContainer Hack

	Because inputs aren't passed down to viewports by default apparently

	Taken from https://github.com/godotengine/godot/issues/17326#issuecomment-431186323
	Converted to C# by K. "Ashifolfi" J.
*/
using Godot;
using System;
using Chisel;

public class ViewportContainerHack : ViewportContainer
{
	public override void _Input(InputEvent @event)
	{
		if (Globals.In3DView == true)
		{
			if (@event is InputEventMouse)
			{
				InputEvent MouseEvent = (InputEvent)@event.Duplicate();
				MouseEvent.Set("position", GetGlobalTransform().XformInv((Vector2)@event.Get("global_position")));
				GetNode<Viewport>("Viewport").UnhandledInput(MouseEvent);
			}
			else
			{
				GetNode<Viewport>("Viewport").UnhandledInput(@event);
			}
		}
	}
}
