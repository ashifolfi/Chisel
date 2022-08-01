using Godot;
using System;
using Chisel;

public class Help : MenuButton
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
				GetNode<WindowDialog>(Globals.RootPath + "Editor/About").Popup_();
				break;
		}
	}
}
