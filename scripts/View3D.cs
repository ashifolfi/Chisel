/*
	(C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using Chisel;

public class View3D : Panel
{
	private void _on_ViewportContainer_mouse_entered()
	{
		Globals.In3DView = true;
	}

	public void _on_ViewportContainer_mouse_exited()
	{
		Globals.In3DView = false;
	}
}
