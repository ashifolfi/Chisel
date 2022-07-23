using Godot;
using System;

public class App : MenuButton
{
	PopupMenu Popup;

	public override void _Ready()
	{
		Popup = GetPopup();
		Popup.Connect("id_pressed", GetNode("."), "_OnIDPressed");
	}

	private void _OnIDPressed(int ID)
	{
		switch(ID)
		{
			case 0:
				GetTree().Quit();
				break;
		}
	}
}
