/*
	FileManager Class

	Used to handle opening VMF files, Saving VMF files
	and anything else related to Filesystem actions

	(C) 2022 by K. "Ashifolfi" J.
*/
using Godot;
using System;
using System.Collections.Generic;
using Chisel;

public class FileManager : Node
{
	FileDialog FileDialog = new FileDialog();
	private AssetManager AssetManager;

	public override void _Ready()
	{
		AssetManager = GetNode<AssetManager>(Globals.RootPath + "/Editor/AssetManager");
		
		AddChild(FileDialog);
		FileDialog.PopupExclusive = true;
		FileDialog.RectSize = new Vector2(839, 487);
		FileDialog.Resizable = true;
		FileDialog.Access = FileDialog.AccessEnum.Filesystem;
	}

	public void SetupMapNode()
	{
		ViewportContainer Root = new ViewportContainer();
		// Add the rest of the viewport requirements
		Root.AddChild(new Viewport());

		// Setup camera
	}

	public List<String> DirContents(String Path)
	{
		List<String> FileList = new List<string>();
		
		Directory Dir = new Directory();
		if (Dir.Open(Path) == Error.Ok)
		{
			Dir.ListDirBegin();
			String FileName = Dir.GetNext();
			while (FileName != "")
			{
				if (Dir.CurrentIsDir())
				{
					GD.Print("[FS] Found Directory: " + FileName);
				}
				else
				{
					GD.Print("[FS] Found File: " + FileName);
					FileList.Add(FileName);
				}

				FileName = Dir.GetNext();
			}

			return FileList;
		}
		else
		{
			GD.Print("[FS][ERR] Failed to access path");
		}

		return FileList;
	}
	
	// Routine for texture loading
	public void LoadGameTextures(String GameDir)
	{
		String FullPath = Globals.ExeDir + "/" + GameDir;
		
		// Search the materials subdirectory for anything containing .vtf
		List<String> FileList = DirContents(FullPath + "/materials/");
		foreach (String File in FileList.ToArray())
		{
			AssetManager.LoadTexture(File, GameDir);
		}
	}

	// VMF Opening
	public void OpenMap()
	{
		// Ready dialog for opening
		FileDialog.WindowTitle = "Open Map";
		String[] Filter = {"*.vmf ; Valve Map File"};
		FileDialog.Filters = Filter;
		FileDialog.Mode = FileDialog.ModeEnum.OpenFile;

		// Connect to our method
		FileDialog.Connect("file_selected", GetNode("."), "ParseMapVmf");
		FileDialog.Popup_();
	}

	public void ParseMapVmf(String Path)
	{
		FileDialog.Disconnect("file_selected", GetNode("."), "ParseMapVmf");
		GD.Print(Path);
	}

	// VMF Saving
	public void SaveMap()
	{
		// Ready dialog for saving
		FileDialog.WindowTitle = "Save Map";
		String[] Filter = {"*.vmf ; Valve Map File"};
		FileDialog.Filters = Filter;
		FileDialog.Mode = FileDialog.ModeEnum.SaveFile;

		// Connect to our method
		FileDialog.Connect("file_selected", GetNode("."), "SaveMapVmf");
		FileDialog.Popup_();
	}

	public void SaveMapVmf(String Path)
	{
		FileDialog.Disconnect("file_selected", GetNode("."), "SaveMapVmf");
		GD.Print(Path);
	}
}
