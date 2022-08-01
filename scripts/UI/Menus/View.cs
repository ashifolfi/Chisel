using Godot;
using System;
using Chisel;

public class View : MenuButton
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
				Panel View3D = GetNode<View3D>(Globals.RootPath + "Editor/Main/ToolsView/View3D");
				Panel Top2D = GetNode<Panel>(Globals.RootPath + "Editor/Main/ToolsView/2DTop");
				Panel Side2D = GetNode<Panel>(Globals.RootPath + "Editor/Main/ToolsView/2DSide");
				Panel Front2D = GetNode<Panel>(Globals.RootPath + "Editor/Main/ToolsView/2DFront");
				if (Globals.Enable2DView == true)
				{
					View3D.Visible = true;
					Top2D.Visible = true;
					Side2D.Visible = true;
					Front2D.Visible = true;
					View3D.RectSize = new Vector2(624, 359);
				}
				else
				{
					View3D.Visible = false;
					Top2D.Visible = false;
					Side2D.Visible = false;
					Front2D.Visible = false;
					View3D.RectSize = new Vector2(1249, 709);
				}
				break;
		}
	}
}
