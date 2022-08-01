using Godot;
using System;
using Chisel;

public class File : MenuButton
{
	FileManager FileManager;
	PopupMenu Popup;

	public override void _Ready()
	{
		FileManager = GetNode<FileManager>(Globals.RootPath + "Editor/FileManager");
		Popup = GetPopup();
		Popup.Connect("id_pressed", GetNode("."), "_OnIDPressed");
	}

	private void _OnIDPressed(int ID)
	{
		switch(ID)
		{
			// New Map
			case 0:
				GetNode<Panel>("/root/UI/Main/ToolsView/View3D").Visible = true;
				break;
			// New Map from Template
			case 1:
				break;
			// Open Map
			case 2:
				FileManager.OpenMap();
				break;
			// Save Map
			case 4:
				FileManager.SaveMap();
				break;
		}
	}
}
