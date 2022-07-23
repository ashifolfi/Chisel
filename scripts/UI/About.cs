using Godot;
using System;

public class About : WindowDialog
{
	private void _on_Close_pressed()
	{
		Visible = false;
	}

	private void _on_SourceCode_pressed()
	{
		OS.ShellOpen("https://github.com/ashifolfi/Chisel");
	}
}
